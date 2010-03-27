using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BlueprintAdapter
    {
        DivPanel subject;

        public BlueprintAdapter(DivPanel div)
        {
            subject = div;
        }

        /// <summary>
        /// Yields the width, in columns, of this div.
        /// </summary>
        public int Span
        {
            get
            {
                return NearestColumn(this.subject.Right) - NearestColumn(this.subject.Left);
            }
        }

        public int Prepend
        {
            get
            {
                return NearestColumn(this.subject.Left);
            }
        }

        public static int NearestColumn(int measurement)
        {
            bool roundUp = ((measurement % Blueprint.TotalColumnWidth) >= Tools.half(Blueprint.TotalColumnWidth));

            // Find column:
            int column = (measurement / Blueprint.TotalColumnWidth);

            if (roundUp) column++;

            return column;
        }


    }
}
