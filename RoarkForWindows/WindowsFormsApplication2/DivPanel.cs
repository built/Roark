using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public class DivPanel : Panel
    {
        DesignBoard board;

        Regex nameFilter = new Regex("^[A-Za-z][A-Za-z0-9:_.-]*$"); // Names must match this pattern.

        TextBox editableLabel = new TextBox();

        public DivPanel(DesignBoard designBoard) : base()
        {
            init("", designBoard);
        }

        public DivPanel(string name, DesignBoard designBoard) : base()
        {
            init(name, designBoard);
        }

        protected void init(String name, DesignBoard designBoard)
        {
            this.Name = name;
            this.board = designBoard;

            SetPreferences();

            HandleMouseEvents(this);

            SetupDivNameEditor();

            this.Paint += new PaintEventHandler(DivPanel_Paint);
        }

        private void SetPreferences()
        {
            this.Size = new Size(1, 1);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.DoubleBuffered = false; // Disable double buffering to avoid the blank-on-parent-resize bug!
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //            base.OnPaint(e);
            //RedrawName();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
//            base.OnPaintBackground(e);
            RedrawName();
        }


        Form appForm = null;
        bool attachedToFormResize = false;

        void DivPanel_Paint(object sender, PaintEventArgs e)
        {
            if (appForm == null)
            {
                // This is essentially our OnLoad event.
                appForm = this.FindForm();

                if (appForm != null && !attachedToFormResize)
                {
                    appForm.Resize += new EventHandler(appForm_Resize);
                    appForm.ResizeEnd += new EventHandler(appForm_ResizeEnd);

                    attachedToFormResize = true;
                }
            }
        }

        void appForm_ResizeEnd(object sender, EventArgs e)
        {
            RedrawName();
        }

        void appForm_Resize(object sender, EventArgs e)
        {
            RedrawName();
        }

        void WhenUserDoubleClicksOnDiv(object sender, EventArgs e)
        {
            BeginEdit();
        }

        private void BeginEdit()
        {
            editableLabel.Left = Tools.half(this.Width) - Tools.half(editableLabel.Width);
            editableLabel.Top = Tools.half(this.Height) - Tools.half(editableLabel.Height);
            this.editableLabel.Text = this.Name;
            this.editableLabel.Show();
            this.editableLabel.Focus();
            this.editableLabel.SelectAll();
        }

        void WhenMouseIsOverDiv(object sender, EventArgs e)
        {
            RedrawName();
            ShowDynamicIcons();
        }

        void WhenMouseLeavesDiv(object sender, EventArgs e)
        {
            HideDynamicIcons();
        }

        private void ShowDynamicIcons()
        {
            ShowResizeGrip();

            ShowDeleteControl();
        }

        public void HideDynamicIcons()
        {
            this.CreateGraphics().DrawRectangle(new Pen(this.BackColor), CalculateDeleteControlRectangle() );
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), CalculateDeleteControlRectangle() );
            
            this.CreateGraphics().DrawRectangle(new Pen(this.BackColor), CalculateResizeGripRectangle() );
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), CalculateResizeGripRectangle() );
        }

        private void HandleMouseEvents(Panel div)
        {
            div.MouseDown       += new MouseEventHandler(WhenClickStarts);
            div.MouseMove       += new MouseEventHandler(WhenMouseMoves);
            div.MouseUp         += new MouseEventHandler(WhenClickEnds);
            div.MouseEnter      += new EventHandler(WhenMouseIsOverDiv);
            div.MouseLeave      += new EventHandler(WhenMouseLeavesDiv);
            div.DoubleClick     += new EventHandler(WhenUserDoubleClicksOnDiv);
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                // Keep child controls the same color as this panel.
                base.BackColor = value;
                this.editableLabel.BackColor = base.BackColor;
                editableLabel.BackColor = ControlPaint.LightLight(this.BackColor);
            }
        }


        bool UserIsMovingDiv = false;
        bool UserIsResizingDiv = false;

        Point initialClickLocation = new Point(0, 0);

        Point divResizeGripClickPosition = new Point();

        void WhenClickStarts(object sender, MouseEventArgs click)
        {
            this.BringToFront();
            this.Focus();
            this.AbortEdit();

            initialClickLocation = click.Location;

            if (IsOnResizeGrip(click.Location))
            {
                BeginResizing(click);
            }
            else if (IsOnDeleteControl(click.Location))
            {
                RemoveSelfFromDesignBoard();
            }
            else
            {
                UserIsMovingDiv = true;
            }
        }


        void WhenMouseMoves(object sender, MouseEventArgs mouse)
        {
            // TODO: With 2-input computing on the horizon, maybe moving and resizing should be 
            // able to work simultaneously.

            if (UserIsMovingDiv)
            {
                MoveToHere(mouse.Location);
            }
            else if(UserIsResizingDiv)
            {
                ResizeToHere(mouse.Location);
            }
            else if (IsOnDeleteControl(mouse.Location))
            {
                ShowActiveDeleteControl();
            }
            else
            {
                ShowDynamicIcons();
            }
        }

        void WhenClickEnds(object sender, MouseEventArgs e)
        {
            EndMove();

            EndResize();

            this.board.CorrectDivPositionsIfNeeded();
        }


        #region Resizing

        Size resizeGripBounds = new Size(16, 16);

        public Rectangle CalculateResizeGripRectangle()
        {
            return new Rectangle(this.Width - resizeGripBounds.Width, this.Height - resizeGripBounds.Height, resizeGripBounds.Width, resizeGripBounds.Height);
        }

        private void ShowResizeGrip()
        {
            ControlPaint.DrawSizeGrip(this.CreateGraphics(), this.BackColor, CalculateResizeGripRectangle());
        }

        private bool IsOnResizeGrip(Point location)
        {
            return LocationIsInRegion(location, CalculateResizeGripRectangle());
        }


        private void BeginResizing(MouseEventArgs e)
        {
            divResizeGripClickPosition = new Point(this.Width - e.X, this.Height - e.Y);

            UserIsResizingDiv = true;
        }

        private void ResizeToHere(Point location)
        {
            HideDynamicIcons();

            InternalResize(location);

            ShowDynamicIcons();
        }

        public void EndResize()
        {
            EnsureDivStaysUseableSize();
            UserIsResizingDiv = false;
        }

        private void InternalResize(Point location)
        {
            // Why is this named InternalResize?
            this.Width = location.X + divResizeGripClickPosition.X;
            this.Height = location.Y + divResizeGripClickPosition.Y;
            
            RedrawName();
        }


        public void ResizeNewDiv(Point clickLocation)
        {
            this.Size = new Size(clickLocation.X - this.Location.X, clickLocation.Y - this.Location.Y);

            RedrawName();
        }

        Size SmallestAllowedSize = new Size(40, 16);

        private bool IsTooSmall()
        {
            return (this.Width <= this.SmallestAllowedSize.Width) || (this.Height <= this.SmallestAllowedSize.Height);
        }

        public void FinalResize(Point clickLocation)
        {
            this.ResizeNewDiv(clickLocation);

            EnsureDivStaysUseableSize();
        }

        private void EnsureDivStaysUseableSize()
        {
            if (this.IsTooSmall())
            {
                this.Size = new Size(Math.Max(SmallestAllowedSize.Width, this.Width), Math.Max(SmallestAllowedSize.Height, this.Height));
            }
        }


        #endregion

        #region Deleting

        Size deleteControlPadding = new Size(5, 2);
        Size deleteControlBounds = new Size(16, 16);

        public Rectangle CalculateDeleteControlRectangle()
        {
            return new Rectangle(new Point(this.Width - deleteControlBounds.Width - deleteControlPadding.Width, deleteControlPadding.Height), deleteControlBounds);
        }

        private void ShowDeleteControl()
        {
            ShowDeleteControl(Color.Navy);
        }

        private void ShowActiveDeleteControl()
        {
            ShowDeleteControl(Color.Red);
        }


        private void ShowDeleteControl(Color background)
        {
            if (this.Height < 32 || this.Width < 32) return; // Don't bother drawing if the control is going to be obscured.

            // The X in the corner which we will click to delete.
            Rectangle bounds = CalculateDeleteControlRectangle();

            PointF topLeft = new PointF(bounds.Left, bounds.Top);
            PointF bottomRight = new PointF(bounds.Right, bounds.Bottom);
            PointF topRight = new PointF(bounds.Right, bounds.Top);
            PointF bottomLeft = new PointF(bounds.Left, bounds.Bottom);

            this.CreateGraphics().FillRectangle(new LinearGradientBrush(new PointF(topLeft.X - 1, topLeft.Y - 1), bottomRight, Color.White, background), CalculateDeleteControlRectangle());

            //this.CreateGraphics().FillRectangle(new SolidBrush(background), bounds);

            this.CreateGraphics().DrawRectangle(new Pen(Color.White), CalculateDeleteControlRectangle());

            Pen p = new Pen(Color.White);

            p.Width = 2;

            int pad = 3;

            topLeft = new PointF(bounds.Left - 1 + pad, bounds.Top - 1 + pad);
            bottomRight = new PointF(bounds.Right - pad, bounds.Bottom - pad);
            topRight = new PointF(bounds.Right - pad, bounds.Top - 1 + pad);
            bottomLeft = new PointF(bounds.Left - 1 + pad, bounds.Bottom - pad);

            this.CreateGraphics().DrawLine(p, topLeft, bottomRight);
            this.CreateGraphics().DrawLine(p, topRight, bottomLeft);

        }



        private bool IsOnDeleteControl(Point location)
        {
            return LocationIsInRegion(location, CalculateDeleteControlRectangle());
        }

        private void RemoveSelfFromDesignBoard()
        {
            ((DesignBoard)this.Parent).DeleteDiv(this);
        }

        #endregion

        #region Moving

        private void MoveToHere(Point location)
        {
            int deltaX = location.X - initialClickLocation.X;
            int deltaY = location.Y - initialClickLocation.Y;

            this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
        }


        private void EndMove()
        {
            UserIsMovingDiv = false;
        }

        #endregion


        #region Helper Functions

        protected bool xIsInRectangle(int x, Rectangle rectangle)
        {
            return (x > rectangle.Location.X && x < rectangle.Location.X + rectangle.Width);
        }

        protected bool yIsInRectangle(int y, Rectangle rectangle)
        {
            return (y > rectangle.Location.Y && y < rectangle.Location.Y + rectangle.Height);
        }

        protected bool LocationIsInRegion(Point location, Rectangle region)
        {
            return (xIsInRectangle(location.X, region) && yIsInRectangle(location.Y, region));
        }

        #endregion

        #region Name Editing


        void editableLabel_DoubleClick(object sender, EventArgs e)
        {
            this.WhenUserDoubleClicksOnDiv(sender, e);
        }

        private void SetupDivNameEditor()
        {
            editableLabel.TextAlign = HorizontalAlignment.Center;
            editableLabel.Font = new Font("Lucida Sans Unicode", 24);
            editableLabel.ForeColor = Color.Black;
            editableLabel.Text = this.Name;
            editableLabel.Hide();
            editableLabel.BorderStyle = BorderStyle.FixedSingle;

            editableLabel.KeyUp += new KeyEventHandler(editableLabel_KeyUp);
            editableLabel.LostFocus += new EventHandler(editableLabel_LostFocus);

            this.Controls.Add(editableLabel);
        }

        void editableLabel_LostFocus(object sender, EventArgs e)
        {
            AbortEdit();
        }

        Font fontRegular    = new Font("Lucida Sans Unicode", 24);
        Font fontSmall      = new Font("Lucida Sans Unicode", 12);

        public void RedrawName()
        {
            this.CreateGraphics().Clear(this.BackColor);

            Font fontToUse = SelectAppropriateFont();

            SizeF textSize = this.CreateGraphics().MeasureString(this.Name, fontToUse);

            this.CreateGraphics().DrawString(this.Name, fontToUse, Brushes.Black, new PointF(Tools.half(this.Width) - Tools.half((int)textSize.Width), Tools.half(this.Height) - Tools.half((int)textSize.Height)));
        }

        private Font SelectAppropriateFont()
        {
            Font selectedFont = fontRegular; // The default.

            SizeF textDimensions = this.CreateGraphics().MeasureString(this.Name, selectedFont);

            if (textDimensions.Height >= this.Height || textDimensions.Width >= this.Width) // Is the font too big for full size text?
            {
                selectedFont = fontSmall; //Shrink it.
            }

            return selectedFont;
        }

        public void AbortEdit()
        {
            editableLabel.Text = this.Name;
            HideEditor();
            this.Refresh();
            RedrawName();
        }

        void editableLabel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (nameFilter.IsMatch(editableLabel.Text))
                {
                    EndEdit();
                }
                else
                {
                    editableLabel.BackColor = Color.MistyRose;
                }

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                AbortEdit();
            }
            else
                if (nameFilter.IsMatch(editableLabel.Text))
                {
                    editableLabel.BackColor = this.BackColor;
                }
                else
                {
                    editableLabel.BackColor = Color.MistyRose;
                }
        }

        private void EndEdit()
        {
            this.Name = editableLabel.Text;

            HideEditor();

            RedrawName();
        }

        private void HideEditor()
        {
            this.Focus(); // Focus back on entire div.

            editableLabel.Hide();
        }

        #endregion

    }
}
