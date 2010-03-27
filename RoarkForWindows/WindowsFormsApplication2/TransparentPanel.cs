using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);

            this.BackColor = Color.Transparent;

        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x020;
                return cp;
            }
        }

//Step 2:

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        // dont code anything here. Leave blank
        }

// Step 3

        protected void InvalidateEx()
        {
            if(Parent==null) return;
            Rectangle rc=new Rectangle(this.Location,this.Size);
            Parent.Invalidate(rc,true);
        }


    }
}
