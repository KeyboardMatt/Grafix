using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.TestStuff
{
    public static class TextBoxer
    {
        /// <summary>
        /// Returns a list of "boxed terms".  Each sub list is a list of strings such as border, content, border.  All will be formatted to match length.
        /// </summary>
        /// <param name="GetBoxedList"></param>
        /// <param name=""></param>
        public static List<List<string>> GetBoxedList_IndividualBoxes(List<string> listToBox, int minimumBorderLength)
        {
            List<List<string>> listOfLists = new List<List<string>>();

            int longestStringLength = getLongestStringLength();
            int boxBorderLength = (int)Math.Max((longestStringLength), (minimumBorderLength));
            string borderString = "[-]" + string.Concat(Enumerable.Repeat("=", boxBorderLength - 2)) + "[-]";

            int currentLength;
            int emptySpaceTotal;
            int emptySpaceLeft;
            int emptySpaceRight;
            string spacesBefore;
            string spacesAfter;
            string leftBorder = "]|[";
            string rightBorder = "]|[";


            List<string> tempListOfListIndex;
            for (int i = 0; i < listToBox.Count; i++)
            {
                listOfLists.Add(new List<string>());


                tempListOfListIndex = new List<string>();

                //===========================
                // Add Top Line
                //===========================
                tempListOfListIndex.Add(borderString);


                //===========================
                // Add Middle Line
                //===========================
                currentLength = listToBox[i].Length;

                emptySpaceTotal = boxBorderLength - currentLength;// - leftBorder.Length - rightBorder.Length;
                emptySpaceLeft = (int)((emptySpaceTotal / 2));
                emptySpaceRight = emptySpaceTotal - emptySpaceLeft;

                spacesBefore = string.Concat(Enumerable.Repeat(" ", emptySpaceLeft - (leftBorder.Length / 2)));
                spacesAfter = string.Concat(Enumerable.Repeat(" ", emptySpaceRight - (rightBorder.Length / 2)));

                tempListOfListIndex.Add(leftBorder + spacesBefore + listToBox[i] + spacesAfter + rightBorder);

                //===========================
                // Add Bottom Line
                //===========================
                tempListOfListIndex.Add(borderString);


                // Transfer temp list to actual list
                listOfLists[listOfLists.Count - 1] = tempListOfListIndex;
            }

            return listOfLists;


            //_______________________________________________
            // Internal Methods

            int getLongestStringLength()
            {
                int tempLength = 0;
                for (int i = 0; i < listToBox.Count; i++)
                {
                    if (listToBox[i].Length > tempLength) { tempLength = listToBox[i].Length; }
                }
                return tempLength;
            }
        }


        public static List<string> GetBoxedList_OneBigBox(List<string> lLinesOfText, ConsoleColor boxColor = ConsoleColor.Gray, ConsoleColor textColor = ConsoleColor.Green)
        {
            List<string> lReturnStrings = new List<string>();

            int longestStringLength = 0;

            // Get longest string length
            for (int i = 0; i < lLinesOfText.Count; i++)
            {
                if (lLinesOfText[i].Length > longestStringLength)
                { longestStringLength = lLinesOfText[i].Length; }
            }

            int leadingSpacesCount = 2;
            string leadingSpaces = string.Concat(Enumerable.Repeat(" ", leadingSpacesCount));

            int totalWordSpaceWidth = longestStringLength + (leadingSpacesCount * 2);
            string topBorder = "[=]" + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + "[=]";
            string botBorder = "[=]" + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + "[=]";

            string leftBorder = "[|]"; string rightBorder = "[|]";

            string midString;
            int trailingSpacesCount;
            string trailingSpaces;

            lReturnStrings.Add(topBorder);


            // Write
            //Console.CursorTop = top;
            //Console.CursorLeft = left;
            //CTools.Color_Write(topBorder, boxColor, true);

            for (int i = 0; i < lLinesOfText.Count; i++)
            {
                trailingSpacesCount = totalWordSpaceWidth - leadingSpacesCount - lLinesOfText[i].Length;
                trailingSpaces = string.Concat(Enumerable.Repeat(" ", trailingSpacesCount));
                /*
                Console.CursorLeft = left;

                CTools.Color_Write(leftBorder, boxColor, false);
                Console.Write(leadingSpaces);
                CTools.Color_Write(lLinesOfText[i], textColor, false);
                Console.Write(trailingSpaces);
                CTools.Color_Write(rightBorder, boxColor, true);
                */
                midString = leftBorder + leadingSpaces + lLinesOfText[i] + trailingSpaces + rightBorder;
                lReturnStrings.Add(midString);
            }

            //Console.CursorLeft = left;
            //CTools.Color_Write(botBorder, boxColor, true);
            lReturnStrings.Add(botBorder);

            Console.ReadKey();

            return lReturnStrings;
        }
    }
}
