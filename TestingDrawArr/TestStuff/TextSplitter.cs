using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.TestStuff
{
    public static class TextSplitter
    {
        /// <summary>
        /// Takes a single long string and breaks it up so that it returns a list of strings >= the allowed length
        /// </summary>
        /// <param name="textToSplit"> Full string to be split</param>
        /// <param name="maxLength"> The longest a line of text can be </param>
        /// <param name="minLength"> The shortest a line of text can be </param>
        /// <returns></returns>
        public static List<string> SplitUpText(string textToSplit, int maxLength = 25, int minLength = 10)
        {
            List<string> returnString = new List<string>();
            List<string> lSeperatedWords = new List<string>();

            int startPoint = 0;
            int endPoint;
            int checkLength;
            string nextWord;

            //---------------------------------------------------
            // Get the list of words
            //---------------------------------------------------
            bool continueLoop = true;
            while (continueLoop)
            {
                checkLength = Math.Min(textToSplit.Length - startPoint, maxLength);
                endPoint = textToSplit.IndexOf(" ", startPoint, checkLength);

                // End loop once the end is found
                if (endPoint == -1) { endPoint = textToSplit.Length; continueLoop = false; }

                // Get the next word and add a space to it
                nextWord = textToSplit.Substring(startPoint, endPoint - startPoint);
                if (nextWord != "") { lSeperatedWords.Add(nextWord + " "); }
                else { lSeperatedWords.Add(" "); }

                startPoint = endPoint + 1;
            }


            //---------------------------------------------------
            // Make strings that fit within boundaries
            //---------------------------------------------------
            string tempWord;
            string lineOfStrings = "";
            for (int i = 0; i < lSeperatedWords.Count; i++)
            {
                tempWord = lSeperatedWords[i];
                if (lineOfStrings.Length + tempWord.Length <= maxLength)
                {
                    lineOfStrings += (tempWord);
                    if (i == lSeperatedWords.Count - 1) { returnString.Add(lineOfStrings); }
                }
                else
                {
                    returnString.Add(lineOfStrings);
                    lineOfStrings = tempWord;
                }
            }

            return returnString;
        }
    }
}
