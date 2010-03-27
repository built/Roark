using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class DesignBoard : Panel
    {
        protected bool GridActivated = false;

        public bool UseGridAlignment
        {
            get
            {
                return this.GridActivated;
            }

            set
            {
                this.GridActivated = value;

                if (this.GridActivated)
                {
                    this.SnapToGrid();
                }
            }
        }




        public int RenderMode = RenderModes.Hardcode;

        public DesignBoard() : base()
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WhenMouseIsReleased);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WhenMouseIsPressed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WhenMouseMoves);
            
            this.DoubleBuffered = true;

            colors.Add(Color.LightBlue);
            colors.Add(Color.WhiteSmoke);
            colors.Add(Color.LightGray);
            colors.Add(Color.SkyBlue);
            colors.Add(Color.LightCyan);
        }

        ColorCycler colors = new ColorCycler();

        public List<DivPanel> Divs = new List<DivPanel>();
        public int NextDivNumber = 1;
        bool UserIsDrawing = false;

        private void WhenMouseIsPressed(object sender, MouseEventArgs e)
        {
            Divs.Add(new DivPanel("Div-" + NextDivNumber++, this));

            LastDiv.BackColor = colors.Next;

            LastDiv.Location = e.Location;

            this.Controls.Add(LastDiv);

            LastDiv.Show();

            LastDiv.BringToFront();

            UserIsDrawing = true;
        }

        private void WhenMouseMoves(object sender, MouseEventArgs click)
        {
            if (UserIsDrawing)
            {
                LastDiv.ResizeNewDiv(click.Location);
            }
        }

        private void WhenMouseIsReleased(object sender, MouseEventArgs click)
        {
            // If you didn't move your mouse more than the min pixels in the X direction, we're not creating anything.
            int minDrawWidth = 8;

            if ((click.Location.X - LastDiv.Location.X) < minDrawWidth)
            {
                Divs.Remove(Divs.Last());
            }
            else
            {
                LastDiv.FinalResize(click.Location);

                CorrectDivPositionsIfNeeded();
            }

            UserIsDrawing = false;
        }

        public void CorrectDivPositionsIfNeeded()
        {
            if (this.GridActivated)
            {
                SnapToGrid();
            }
        }

        protected DivPanel LastDiv
        {
            get
            {
                return Divs.Last();
            }
        }

        //int gridStepX = 30 + 10; // 30 pixels wide plus 10 pixel margin.
        //int gridMarginX = 0; // Distance from edge of window to grid.
        //int gridMarginY = 0; // Distance from edge of window to grid.

        protected void DrawGrid(Graphics canvas)
        {
            ControlPaint.DrawGrid(canvas, this.Bounds, new Size(40, 18), Color.SpringGreen);

            // TO DO: Apparently the following is far too resource intensive. Need to explore more on next rev.
            //string checkerboard = "bigchecker.bmp";

            //if (System.IO.File.Exists(checkerboard))
            //{
            //    this.BackgroundImage = new Bitmap(checkerboard);
            //}
            //else MessageBox.Show("The checker file doesn't exist.");

            // TO DO: This is the original column code I used. It seemed to work fairly well.
            //Pen gridPen = new Pen(Color.SteelBlue);

            //DrawVerticalGridLines(24, gridStepX, canvas, gridPen);
        }

        //private void DrawVerticalGridLines(int quantity, int spacing, Graphics canvas, Pen gridPen)
        //{
        //    for (int i = 0; i < quantity; i++)
        //    {
        //        int x = gridMarginX + (i * spacing);
        // 
        //        canvas.DrawLine(gridPen, x, gridMarginY, x, 800);
        //    }
        //}




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
        }


        public void DeleteDiv(DivPanel div)
        {
            // Hide it.
            div.Hide();

            // Delete it from the design board.
            this.Controls.Remove(div);
            
            // Remove it from list.
            Divs.Remove(div);

            // Now with no refernces it should get picked up by the GC.
        }

        public void SnapToGrid()
        {
            // Walk list of divs and make each div align with a column on the grid.
            // There are 24 columns so 23 offsets starting at zero and incrementing by 40. This is for Blueprint.
            foreach (DivPanel div in Divs)
            {
                BlueprintNazi.AlignToGrid(div);
            }
        }

        public static string RenderDivs()
        {
            return " TO DO  - Not done yet!";
        }

    }
}
