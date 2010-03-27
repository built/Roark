using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class ColorCycler : List<System.Drawing.Color>
    {
        protected int colorIndex = 0;
        
        public int Index
        {
            get
            {
                return colorIndex;
            }

            set
            {
                if (value >= this.Count)
                {
                    colorIndex = 0; // Wrap around to first item if we've passed the end of the list.
                }
                else
                {
                    colorIndex = value;
                }
            }

        }


        public Color Next
        {
            get
            {
                return this[Index++];
            }
        }


    }
}
