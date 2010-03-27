using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BlueprintNazi
    {
        public static void AlignToGrid(DivPanel div)
        {
            SnapPositionToColumn(div);

            SnapWidthToColumn(div);
        }

        public static void SnapPositionToColumn(DivPanel div)
        {
            if (NotAlignedWithAColumn(div.Left))
            {
                AlignPositionWithNearestColumn(div);
            }
        }

        public static void SnapWidthToColumn(DivPanel div)
        {
            if (NotAlignedWithAColumn(div.Width))
            {
                div.Width = (BlueprintAdapter.NearestColumn(div.Right) * Blueprint.TotalColumnWidth) - div.Location.X;
                div.RedrawName();
            }
        }

        private static void AlignPositionWithNearestColumn(DivPanel div)
        {
            // Don't go outside the grid.
            int column = Math.Min(BlueprintAdapter.NearestColumn(div.Left), Blueprint.LastColumn);

            div.Left = (column * Blueprint.TotalColumnWidth);
        }

        private static bool NotAlignedWithAColumn(int dimension)
        {
            return (dimension % Blueprint.TotalColumnWidth) != 0;
        }

        //public static int NearestColumn(int measurement)
        //{
        //    bool roundUp = ((measurement % Blueprint.TotalColumnWidth) >= Tools.half(Blueprint.TotalColumnWidth));

        //    // Find column:
        //    int column = (measurement / Blueprint.TotalColumnWidth);

        //    if (roundUp) column++;

        //    return column;
        //}



    }
}
