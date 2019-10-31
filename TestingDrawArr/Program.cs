using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestingDrawArr
{
    class Program
    {
        static readonly Random r = new Random();

        static void Main(string[] args)
        {

            PUBV.Initialize_ConsoleArray();



            string textString = "Hello hi this is a test so I'm just writing a really really really really long message that will be sure to jump down to the next line because hey, what else am I supposed to do to test this thing. If it works, then I will have proven an important theory; Anything can be boxed, organized and displayed on this console.";


            DrawingStuff.ASCII_Shape myTextBox = new DrawingStuff.ASCII_Shape(textString, 50);

            DrawingStuff.ASCII_Shape myAxe = new DrawingStuff.ASCII_Shape(DrawingStuff.DrawTool.ShapeTypes.Axe);
            DrawingStuff.ASCII_Shape mySword = new DrawingStuff.ASCII_Shape(DrawingStuff.DrawTool.ShapeTypes.Sword);


            DrawingStuff.ASCII_Shape mySideBar = new DrawingStuff.ASCII_Shape(PUBV.ConsoleHeight-1, 30);

            DrawingStuff.DrawTool.AddImageToConsoleArrays_MovementLayer(10, 20, myTextBox);
            DrawingStuff.DrawTool.AddImageToConsoleArrays_StaticLayer(0, 0, mySideBar);

            



            DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();

            Array.Clear(PUBV.consoleArr_NeedsUpdate, 0, PUBV.consoleArr_NeedsUpdate.Length);
            ConsoleKey key = ConsoleKey.D9;
            bool dontCheck = false;
            for (; ; )
            {
                if (!dontCheck)
                {
                    key = Console.ReadKey(true).Key;


                    switch (key)
                    {
                        case ConsoleKey.W:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up);
                            break;

                        case ConsoleKey.S:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.down);
                            break;

                        case ConsoleKey.D:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.right);
                            break;

                        case ConsoleKey.A:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.left);
                            break;

                        case ConsoleKey.Q:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up_left);
                            break;

                        case ConsoleKey.E:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up_right);
                            break;

                        case ConsoleKey.Z:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.down_left);
                            break;

                        case ConsoleKey.C:
                            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.down_right);
                            break;

                        default:
                            // Do nothing
                            break;
                    }
                
                }
                else
                {
                    DrawingStuff.ShapeMover.StepAllShapes();
                }


                DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();

            }
        }
    }    
}
    
