using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff
{
    public static class CustomShapeMaker
    {

        public static List<string> MakeSideBar(int barHeight, int barWidth)
        {
            List<string> returnList = new List<string>();


            string leftBorder = "||";
            string rightBorder = leftBorder;
            int sideBorderAdjust = leftBorder.Length + rightBorder.Length;
            string innerSpace = string.Concat(Enumerable.Repeat(" ", barWidth - sideBorderAdjust));

            string topBorder = "[]" + string.Concat(Enumerable.Repeat("=", barWidth - sideBorderAdjust)) + "[]";
            string botBorder = topBorder;


            int centerRowCount = barHeight - 2;


            returnList.Add(topBorder);
            for (int i = 0; i < centerRowCount; i++)
            {
                returnList.Add(leftBorder + innerSpace + rightBorder);
            }
            returnList.Add(botBorder);


            return returnList;
        }




    }
}
