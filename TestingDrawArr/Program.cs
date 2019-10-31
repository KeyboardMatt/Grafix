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


            DrawingStuff.DrawTool.AddImageToConsoleArrays_MovementLayer(10, 40, myTextBox);
            DrawingStuff.DrawTool.AddImageToConsoleArrays_StaticLayer(50, 18, mySword);
            DrawingStuff.DrawTool.AddImageToConsoleArrays_StaticLayer(20, 15, myAxe);
            DrawingStuff.DrawTool.AddImageToConsoleArrays_StaticLayer(7, 10, myAxe);
            


            DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();

            Array.Clear(PUBV.consoleArr_NeedsUpdate, 0, PUBV.consoleArr_NeedsUpdate.Length);
            Console.ReadKey();
            ConsoleKey key;
            for (; ; )
            {

               

                key = Console.ReadKey().Key;

                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up);
                        break;

                    case ConsoleKey.DownArrow:
                        DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.down);
                        break;

                    case ConsoleKey.RightArrow:
                        DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.right);
                        break;

                    case ConsoleKey.LeftArrow:
                        DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.left);
                        break;

                    default:
                        DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.down);
                        break;
                }

                DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();
            }

            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up);
            DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();
            Console.ReadKey();

            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up);
            DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();
            Console.ReadKey();

            DrawingStuff.ShapeMover.Move_Custom(myTextBox, DrawingStuff.ShapeMover.MoveDirections.up);
            DrawingStuff.DrawTool.Draw_ConsoleArrayLayers();
            Console.ReadKey();

        }
    }    
}
    
