using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr
{
    public static class PUBV
    {

        // This layer is reset with every step and keeps up with which parts of the array need an update
        public static bool[,] consoleArr_NeedsUpdate;


        // This is the uppermost layer of the console display because it is constantly moving so needs attention.  Calls on ONLY the first static array for potential updates (fill in after movement) 
        // because if there is nothing in the first static array in those spots, there can't be anything in the second and third static arrays
        public static char[,] consoleArr_MovementLayer;

        public static char[,] consoleArr_MovementLayer_Colors;



        // These are static arrays, which are basically background arrays.  These are not updated unless called upon.
        // ONLY information in the FIRST static console is EVER displayed. The others only exist to hold backup info in case the first static array is cleared.
        public static char[,] consoleArr_Static1;
        public static char[,] consoleArr_Static2;
        public static char[,] consoleArr_Static3;

        public static char[,] consoleArr_Static1_Colors;
        public static char[,] consoleArr_Static2_Colors;
        public static char[,] consoleArr_Static3_Colors;


        public static List<DrawingStuff.ASCII_Shape> PriorityList_Shapes = new List<DrawingStuff.ASCII_Shape>();


        public static int ConsoleHeight;
        public static int ConsoleWidth;

        public static void Initialize_ConsoleArray()
        {
            ConsoleHeight = Console.LargestWindowHeight;
            ConsoleWidth = Console.LargestWindowWidth;

            consoleArr_NeedsUpdate = new bool[Console.LargestWindowHeight, ConsoleWidth];


            consoleArr_MovementLayer        = new char[ConsoleHeight, ConsoleWidth];
            consoleArr_MovementLayer_Colors = new char[ConsoleHeight, ConsoleWidth];
                       

            consoleArr_Static1          = new char[ConsoleHeight, ConsoleWidth];
            consoleArr_Static2          = new char[ConsoleHeight, ConsoleWidth];
            consoleArr_Static3          = new char[ConsoleHeight, ConsoleWidth];

            consoleArr_Static1_Colors   = new char[ConsoleHeight, ConsoleWidth];
            consoleArr_Static2_Colors   = new char[ConsoleHeight, ConsoleWidth];
            consoleArr_Static3_Colors   = new char[ConsoleHeight, ConsoleWidth];
        }


        public static void Initialize_NewShape(DrawingStuff.ASCII_Shape newShape)
        {
            PriorityList_Shapes.Add(newShape);
        }


        public static int CurrentHighestPriorityIndex { get; set; }

        public static int indexInt = 0;
        public static int GetNextShapeIndex()
        {
            indexInt++;
            CurrentHighestPriorityIndex = indexInt;
            return indexInt;
        }

    }
}
