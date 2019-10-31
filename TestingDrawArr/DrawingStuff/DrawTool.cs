using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff
{
    public static class DrawTool
    {


        // The character that will be a space (other empty spots are not shown)
        static char omitChar = '8';

        /// <summary>
        /// Add an image into the movement layer (Image must have movement orders)
        /// </summary>
        /// <param name="StartLeft"></param>
        /// <param name="StartTop"></param>
        /// <param name="shape"></param>
        public static void AddImageToConsoleArrays_MovementLayer(int StartLeft, int StartTop, ASCII_Shape shape, bool OverwriteOld = false)
        {

            List<string> lStrings = shape.lStrings;
            List<string> lColors = shape.lColors;            
            int Left = StartLeft;
            int Top = StartTop;
            char nextChar;

            shape.Left = Left;
            shape.Top = Top;

            for (int i = 0; i < lStrings.Count; i++)
            {
                char[] rowChars = lStrings[i].ToCharArray();
                char[] rowColors = lColors[i].ToCharArray();

                for (int j = 0; j < rowChars.Length; j++)
                {

                    if (rowChars[j] == omitChar)
                    { nextChar = ' '; }
                    else { nextChar = rowChars[j]; }

                    // Don't process blanks
                    if (nextChar != '\0')
                    {
                        // If checked spot is empty, then add.  Else, do nothing.
                        if (Top + i >= 0 && Left + j >= 0)
                        {
                            if (PUBV.consoleArr_MovementLayer[Top + i, Left + j] == '\0' || OverwriteOld == true)
                            {
                                PUBV.consoleArr_MovementLayer[Top + i, Left + j] = nextChar;
                                PUBV.consoleArr_MovementLayer_Colors[Top + i, Left + j] = rowColors[j];
                                PUBV.consoleArr_NeedsUpdate[Top + i, Left + j] = true;
                            }
                        }
                    }
                }
            }            
        }


        /// <summary>
        /// Add an image into the static background layer (newest is highest priority.)
        /// </summary>
        /// <param name="StartLeft"></param>
        /// <param name="StartTop"></param>
        /// <param name="shape"></param>
        public static void AddImageToConsoleArrays_StaticLayer(int StartLeft, int StartTop, ASCII_Shape shape)
        {
            List<string> lStrings = shape.lStrings;
            List<string> lColors = shape.lColors;
            int Left = StartLeft;
            int Top = StartTop;
            char nextChar;

            shape.Left = Left;
            shape.Top = Top;

            // The char that will carry down to the lower priority array
            char shuttleChar = '\0';
            char shuttleChar_Color = '\0';
            for (int i = 0; i < lStrings.Count; i++)
            {
                char[] rowChars = lStrings[i].ToCharArray();
                char[] rowColors = lColors[i].ToCharArray();

                for (int j = 0; j < rowChars.Length; j++)
                {
                    // Get rid of blanks
                    if (rowChars[j] == ' ')
                    {rowChars[j] = '\0';}

                    // *ADD blanks where the omit char is (inside of solid objects aren't transparent)
                    if (rowChars[j] == omitChar)
                    { nextChar = ' '; }
                    else { nextChar = rowChars[j]; }


                    // Don't process blanks
                    if (nextChar != '\0')
                    {
                        //**** Need this?
                        PUBV.consoleArr_NeedsUpdate[Top+i, Left+j] = true;

                        // Try Array1
                        if (PUBV.consoleArr_Static1[Top+i, Left+j] == '\0')
                        {
                            PUBV.consoleArr_Static1[Top+i, Left+j] = nextChar;
                            PUBV.consoleArr_Static1_Colors[Top+i, Left+j] = rowColors[j];
                        }
                        else
                        {
                            shuttleChar = PUBV.consoleArr_Static1[Top + i, Left + j];
                            shuttleChar_Color = PUBV.consoleArr_Static1_Colors[Top + i, Left + j];
                            PUBV.consoleArr_Static1[Top + i, Left + j] = nextChar;
                            PUBV.consoleArr_Static1_Colors[Top + i, Left + j] = rowColors[j];
                        }


                        // If there is a character to shuttle
                        if (shuttleChar != '\0')
                        {
                            // Try Array2
                            if (PUBV.consoleArr_Static2[Top + i, Left + j] == '\0')
                            {
                                // Empty spot found
                                PUBV.consoleArr_Static2[Top + i, Left + j] = shuttleChar;
                                PUBV.consoleArr_Static2_Colors[Top + i, Left + j] = shuttleChar_Color;
                                shuttleChar = '\0';
                                shuttleChar_Color = '\0';
                            }
                            else
                            {
                                // Spot's taken
                                shuttleChar = PUBV.consoleArr_Static2[Top + i, Left + j];
                                shuttleChar_Color = PUBV.consoleArr_Static2_Colors[Top + i, Left + j];
                                PUBV.consoleArr_Static2[Top + i, Left + j] = shuttleChar;
                                PUBV.consoleArr_Static2_Colors[Top + i, Left + j] = shuttleChar_Color;
                            }

                            // If there is still a character to shuttle
                            if (shuttleChar != '\0')
                            {
                                // Try Array3
                                if (PUBV.consoleArr_Static3[Top + i, Left + j] == '\0')
                                {
                                    // Empty spot found
                                    PUBV.consoleArr_Static3[Top + i, Left + j] = shuttleChar;
                                    PUBV.consoleArr_Static3_Colors[Top + i, Left + j] = shuttleChar_Color;
                                }
                                else
                                {
                                    // Spot's taken
                                    shuttleChar = PUBV.consoleArr_Static3[Top + i, Left + j];
                                    shuttleChar_Color = PUBV.consoleArr_Static3_Colors[Top + i, Left + j];
                                    PUBV.consoleArr_Static3[Top + i, Left + j] = shuttleChar;
                                    PUBV.consoleArr_Static3_Colors[Top + i, Left + j] = shuttleChar_Color;
                                }

                                // Add more arrays to extend this
                                shuttleChar = '\0';
                                shuttleChar_Color = '\0';
                            }

                        }
                    }
                }
                Left = StartLeft;
            }
            Console.CursorVisible = false;
        }


        public static void Draw_ConsoleArrayLayers()
        {
            char charToWrite = '\0';
            char charToWrite_Color = '\0';

            // 1 ) MOVEMENT ARRAY
            for (int i = 0; i < PUBV.consoleArr_NeedsUpdate.GetUpperBound(0); i++)
            {
                for (int j = 0; j < PUBV.consoleArr_NeedsUpdate.GetUpperBound(1); j++)
                {
                    // If index needs an update
                    if(PUBV.consoleArr_NeedsUpdate[i,j] == true)
                    {
                        if (PUBV.consoleArr_MovementLayer[i, j] != '\0')
                        {
                            charToWrite = PUBV.consoleArr_MovementLayer[i, j];
                            charToWrite_Color = PUBV.consoleArr_MovementLayer_Colors[i, j];
                            Console.SetCursorPosition(j, i);
                            ColorWrite(charToWrite, charToWrite_Color);
                            PUBV.consoleArr_NeedsUpdate[i, j] = false;
                        }
                    }
                }
            }

            // 2 ) STATIC BG ARRAY
            for (int i = 0; i < PUBV.consoleArr_NeedsUpdate.GetUpperBound(0); i++)
            {
                for (int j = 0; j < PUBV.consoleArr_NeedsUpdate.GetUpperBound(1); j++)
                {
                    // If index needs an update
                    if (PUBV.consoleArr_NeedsUpdate[i,j] == true)
                    {
                        charToWrite = PUBV.consoleArr_Static1[i, j];
                        charToWrite_Color = PUBV.consoleArr_Static1_Colors[i, j];
                        Console.SetCursorPosition(j, i);
                        ColorWrite(charToWrite, charToWrite_Color);
                        PUBV.consoleArr_NeedsUpdate[i, j] = false;
                    }
                }
            }

        }




        public static void MoveShape(ASCII_Shape shape, int NewLeft, int NewTop)
        {

            int previousLeft = shape.Left;
            int previousRight = previousLeft + (shape.shapeWidth - 1);
            int previousTop = shape.Top;
            int previousBot = shape.Top + (shape.shapeHeight - 1);

            int newLeft = NewLeft;
            int newRight = NewLeft + (shape.shapeWidth - 1);
            int newTop = NewTop;
            int newBot = NewTop + (shape.shapeHeight - 1);

            for (int i = newBot; i < newTop; i++)
            {
                for (int j = newLeft; j < newRight; j++)
                {

                }
            }
        }





        static void ColorWrite(Char characterToWrite, char color)
        {
            string myColorString;
            int myColorInt;

            myColorString = color.ToString();
            if (myColorString != " ")
            { myColorInt = GetColorInt(myColorString); }
            else { myColorInt = -1; }


            if (myColorInt != (int)Colors.None)
            {
                switch (myColorInt)
                {
                    case (int)Colors.Black:
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case (int)Colors.White:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case (int)Colors.Gray:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;


                    case (int)Colors.DarkGray:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;

                    case (int)Colors.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case (int)Colors.DarkRed:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;

                    case (int)Colors.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;

                    case (int)Colors.DarkBlue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;

                    case (int)Colors.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case (int)Colors.DarkGreen:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;

                    case (int)Colors.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case (int)Colors.DarkYellow:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;

                    case (int)Colors.Cyan:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;

                    case (int)Colors.DarkCyan:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;

                    case (int)Colors.Magenta:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case (int)Colors.DarkMagenta:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;

                }

                string newChar = characterToWrite.ToString();
                Console.Write(newChar);
            }
        }
        


        /// <summary>
        /// Converts the color letter to a color Int from the colors enum
        /// </summary>
        /// <returns></returns>
        static int GetColorInt(string myColorString)
        {
            switch(myColorString)
            {
                case "X":
                    return (int)Colors.Black;
                case "W":
                    return (int)Colors.White;
                case "o":
                    return (int)Colors.Gray;
                case "O":
                    return (int)Colors.DarkGray;
                case "r":
                    return (int)Colors.Red;
                case "R":
                    return (int)Colors.DarkRed;
                case "b":
                    return (int)Colors.Blue;
                case "B":
                    return (int)Colors.DarkBlue;
                case "g":
                    return (int)Colors.Green;
                case "G":
                    return (int)Colors.DarkGreen;
                case "y":
                    return (int)Colors.Yellow;
                case "Y":
                    return (int)Colors.DarkYellow;
                case "c":
                    return (int)Colors.Cyan;
                case "C":
                    return (int)Colors.DarkCyan;
                case "m":
                    return (int)Colors.Magenta;
                case "M":
                    return (int)Colors.DarkMagenta;
                default:
                    return (int)Colors.White;
            }
        }

        public enum directions
        {
            up,
            down,
            left,
            right,
            up_left,
            up_right,
            down_left,
            down_right
        }
        public enum Colors
        {
            Black,
            White,
            Gray,
            DarkGray,
            Red,
            DarkRed,
            Blue,
            DarkBlue,
            Green,
            DarkGreen,
            Yellow,
            DarkYellow,
            Cyan,
            DarkCyan,
            Magenta,
            DarkMagenta,
            None
        }
        public enum ShapeTypes
        {
            Sword,
            Axe,
            Hammer,
            Unarmed,
            Building_0,
            Custom
        }
    }
}
