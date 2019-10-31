using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.TestStuff
{
    public static class CTools
    {

        //======================================================
        // Text Boxes
        //======================================================
        public static void WriteTextBox(string textInBox, int boxTopLine, int boxWidth)
        {
            int finalBoxWidth = boxWidth;


            List<string> equalWidthStrings = TextSplitter.SplitUpText(textInBox, finalBoxWidth);
            List<string> lBoxedStrings = TextBoxer.GetBoxedList_OneBigBox(equalWidthStrings);
        }

        public static List<string> GetTextBox_Single(string textInBox, int boxWidth)
        {
            int finalBoxWidth = boxWidth;

            List<string> equalWidthStrings = TextSplitter.SplitUpText(textInBox, finalBoxWidth);
            List<string> lBoxedStrings = TextBoxer.GetBoxedList_OneBigBox(equalWidthStrings);

            return lBoxedStrings;
        }



        //======================================================
        // Various Headers
        //======================================================

        /// <summary>
        /// Use this to write out a standard header with autosized borders
        /// </summary>
        /// <param name="headerString"> The words to appear in the header</param>
        /// <param name="consoleLine"> Top line of the header</param>
        public static void Write_Header(string headerString, int consoleLine, int leftStart = 2, int minBorderWidth = 30)
        {
            int minBorderLength = minBorderWidth;
            int letterCount = headerString.Length;
            int borderLength = (int)Math.Max(minBorderLength, (letterCount + 6));
            string border = string.Concat(Enumerable.Repeat("=", borderLength));


            int wordStartIndex = CenterText_GetIndex(borderLength, headerString.Length);

            leftStart += 10;

            Console.SetCursorPosition(leftStart, consoleLine); Console.WriteLine(border);
            Console.SetCursorPosition(leftStart + wordStartIndex, Console.CursorTop); Console.WriteLine(headerString);
            Console.SetCursorPosition(leftStart, Console.CursorTop); Console.WriteLine(border);
        }

        /// <summary>
        /// Use this to write out a standard header with autosized borders AND highlight a word
        /// </summary>
        /// <param name="headerString"></param>
        /// <param name="consoleLine"></param>
        /// <param name="highlightedWord"></param>
        /// <param name="color"></param>
        public static void Write_Header(string fullHeaderString, int consoleLine, string wordToHighlight, ConsoleColor color, int leftStart = 2, int minBorderWidth = 30)
        {
            int minBorderLength = minBorderWidth;
            int letterCount = fullHeaderString.Length;
            int borderLength = (int)Math.Max(minBorderLength, (letterCount + 6));
            string border = string.Concat(Enumerable.Repeat("=", borderLength));

            int highlightedWordStartIndex = fullHeaderString.IndexOf(wordToHighlight);
            string beforeHighlightedWord = fullHeaderString.Substring(0, highlightedWordStartIndex);

            leftStart += 10;

            Console.SetCursorPosition(leftStart, consoleLine); Console.WriteLine(border);
            Console.SetCursorPosition(leftStart, Console.CursorTop); Console.Write(" " + beforeHighlightedWord);
            CTools.Color_Write(wordToHighlight, color, false); Console.WriteLine();
            Console.SetCursorPosition(leftStart, Console.CursorTop); Console.WriteLine(border);
        }



        /// <summary>
        /// Returns the index of that the first character of the 'word to center' should be
        /// </summary>
        /// <param name="totalSpaceInWhichToCenter"> Length within which to center </param>
        /// <param name="lengthOfWordToCenter"> Length of the word to be centered </param>
        /// <returns></returns>
        public static int CenterText_GetIndex(int totalSpaceInWhichToCenter, int lengthOfWordToCenter)
        {
            if (totalSpaceInWhichToCenter < lengthOfWordToCenter)
            {
                throw new Exception("Word to be centered is shorter than space in which to center");
            }
            else
            {
                int extraSpace = totalSpaceInWhichToCenter - lengthOfWordToCenter;
                return extraSpace / 2;
            }
        }




        //======================================================
        // Underheader Text
        //======================================================


        /// <summary>
        /// Add text below the header.
        /// </summary>
        /// <param name="underHeaderText"> The text to appear under the header </param>
        /// <param name="color"> The color of the text</param>
        public static void Write_UnderHeader(string underHeaderText, ConsoleColor color = ConsoleColor.Yellow)
        {
            string belowHeader_Underline = string.Concat(Enumerable.Repeat("`", underHeaderText.Length + 4));
            Console.SetCursorPosition(10 + 5, Console.CursorTop);
            CTools.Color_Write(underHeaderText, color, true);
            Console.SetCursorPosition(10 + 3, Console.CursorTop);
            CTools.Color_Write(belowHeader_Underline, color, false);
        }



        //======================================================
        //  Pop-up Style Alerts
        //======================================================

        public static void PopupAlertMessage()
        {
            List<string> lArt_ExlamationPoint = new List<string>();
        }




        //======================================================
        // Incorporating color into the console.
        //======================================================

        /// <summary>
        /// Write in a color.  Choose whether or not to WriteLine or Write
        /// </summary>
        /// <param name="textString"></param>
        /// <param name="color"></param>
        public static void Color_Write(string textString, ConsoleColor color, bool goToNextLine = true, bool includeSpaces = false)
        {
            ConsoleColor startColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            int endOfSpaces = textString.TakeWhile(Char.IsWhiteSpace).Count();

            string newString = textString.Substring(endOfSpaces, textString.Length - endOfSpaces);
            newString = newString.TrimEnd();

            if (goToNextLine) { Console.WriteLine(newString); Console.SetCursorPosition(Console.CursorLeft + endOfSpaces + 10, Console.CursorTop); }
            else { Console.CursorLeft += endOfSpaces; Console.Write(newString); }


            Console.ForegroundColor = startColor;
        }

        /// <summary>
        /// Write in a color.  Choose whether or not to WriteLine or Write
        /// </summary>
        /// <param name="textString"></param>
        /// <param name="color"></param>
        public static void Color_Write(string textString, ConsoleColor color, ConsoleColor bgColor, bool goToNextLine = true)
        {
            ConsoleColor startColor = Console.ForegroundColor;
            ConsoleColor startColorBG = Console.BackgroundColor;
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgColor;

            if (goToNextLine) { Console.WriteLine(textString); Console.SetCursorPosition(Console.CursorLeft + 10, Console.CursorTop); }
            else { Console.Write(textString); }

            Console.ForegroundColor = startColor;
            Console.BackgroundColor = startColorBG;
        }

        /// <summary>
        /// Writes a string with a single word in colored text.  It will find ONLY the first instance of the word and color it.
        /// </summary>
        /// <param name="fullString">The entire string</param>
        /// <param name="wordToColor">The word in the full string to be colored</param>
        /// <param name="color">What color will the special word be</param>
        public static void Write_StringWith_ColoredWord(string fullString, string wordToColor, ConsoleColor color)
        {
            int coloredWordStartIndex = fullString.IndexOf(wordToColor);
            string beforeColoredWord = fullString.Substring(0, coloredWordStartIndex);
            string afterColoredWord = fullString.Substring(coloredWordStartIndex + wordToColor.Length, fullString.Length - (coloredWordStartIndex + wordToColor.Length));

            Console.Write(beforeColoredWord);
            CTools.Color_Write(wordToColor, color, false);
            Console.Write(afterColoredWord);
        }




        //======================================================
        // Some Basic Edits
        //======================================================

        /// <summary>
        /// Add X number of newlines
        /// </summary>
        /// <param name="numberOfNewLines"></param>
        public static void WriteNewLine_xTimes(int numberOfNewLines)
        {
            for (int i = 0; i < numberOfNewLines; i++) { Console.WriteLine(); }
            Console.SetCursorPosition(Console.CursorLeft + 10, Console.CursorTop);
        }


        /// <summary>
        /// Deleted the character in the immediate left index.
        /// </summary>
        /// <param name="farLeftCursorPosition"> The very first permissible typing index </param>
        public static void ClearPreviousCharacter(int farLeftCursorPosition = 0)
        {
            farLeftCursorPosition += 10;
            if (Console.CursorLeft > farLeftCursorPosition) { Console.Write("\b"); }
            else { Console.Write("\b \b"); }
        }




        /// <summary>
        /// Inclusive.  Clears a rectangle area on the console
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bot"></param>
        public static void ClearArea(int left, int right, int top, int bot)
        {
            Console.ResetColor();

            int width = right - left + 1;
            string emptySpace = string.Concat(Enumerable.Repeat(" ", width));
            for (int i = top; i <= bot; i++)
            {
                Console.SetCursorPosition(left, i);
                Console.Write(emptySpace);
            }
            Console.SetCursorPosition(10, 0);
            Console.SetWindowPosition(0, 0);

        }

        /// <summary>
        /// Returns a list of "boxed terms".  Each sub list is a list of strings such as border, content, border.  All will be formatted to match length.
        /// </summary>
        /// <param name="listToBox"></param>
        /// <returns></returns>
        public static List<List<string>> GetBoxedList(List<string> listToBox, int minimumBoxBorderWidth = 15)
        {
            return TestStuff.TextBoxer.GetBoxedList_IndividualBoxes(listToBox, minimumBoxBorderWidth);
        }

        public static void setCursorToLeft_CenterArea(int cursorTop)
        {
            Console.SetCursorPosition(10 - 1, cursorTop);
        }


        //======================================================
        // Short Messages
        //======================================================

        /// <summary>
        /// Basic "Press any key to continue" message
        /// </summary>
        /// <param name="consoleLine"></param>
        public static void PressAnyKeyToContinue(int consoleLine)
        {
            Console.SetCursorPosition(10 + 2, consoleLine);
            Color_Write("PRESS ANY KEY TO CONTINUE...", ConsoleColor.DarkYellow);
        }

    }
}
