using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TestingDrawArr.DrawingStuff
{
    public class ShapeMover
    {

        List<Movements._Movements> lShapeMovement = new List<Movements._Movements>();


        // ENTRY POINT TO A FULL SCREEN 'STEP'
        public void StepAllShapes()
        {
            Array.Clear(PUBV.consoleArr_NeedsUpdate,0, PUBV.consoleArr_NeedsUpdate.Length);

            List<int> UpdateIndex_Left = new List<int>();
            List<int> UpdateIndex_Top = new List<int>();

            FillUpdateIndexLists();

            Thread.Sleep(20);


            // Go through each shape in order of priority, and note necessary updates
            void FillUpdateIndexLists()
            {
                UpdateIndex_Left.Clear();
                UpdateIndex_Top.Clear();


                ASCII_Shape nextShape;
                for (int i = 0; i < PUBV.PriorityList_Shapes.Count; i++)
                {
                    nextShape = PUBV.PriorityList_Shapes[i];

                    if (nextShape.Has_MovementOrders)
                    {
                        nextShape.TakeMovement_Step();
                    }
                }
            }
        }





        public void AddShapeToList(ASCII_Shape shape, MovementTypes movementType, int linearDistance = 0)
        {
            switch(movementType)
            {
                case MovementTypes.Up_Down:
                    shape.Add_Movement(new Movements.Up_Down(linearDistance));
                    break;

                case MovementTypes.Left_Right:
                    shape.Add_Movement(new Movements.Left_Right(linearDistance));
                    break;

                case MovementTypes.Diagonal_BL_TR:
                    shape.Add_Movement(new Movements.Diagonal_BL_TR(linearDistance));
                    break;

                case MovementTypes.Circle_CW:
                    shape.Add_Movement(new Movements.Circle_CW());
                    break;

                case MovementTypes.Circle_CCW:
                    shape.Add_Movement(new Movements.Circle_CCW());
                    break;

                case MovementTypes.Spiral_CW:
                    shape.Add_Movement(new Movements.Spiral_CW());
                    break;
            }
        }



        static int UDInterval = 1;
        static int LRInterval = 2;
        public static void Move_Custom(ASCII_Shape shape, MoveDirections directionToMove)
        {
            int Top = shape.Top;
            int Left = shape.Left;
            int shapeHeight = shape.shapeHeight;
            int shapeWidth = shape.shapeWidth;

            if (directionToMove != MoveDirections.Wait)
            {
                int newTop = 0;
                int newLeft = 0;

                int eraseTop = 0;
                int eraseBot = 0;
                int eraseLeft = 0;
                int eraseRight = 0;

                int eraseHeight = 0;
                int eraseWidth = 0;
                bool diagonalMove = false;

                //|| Tall - 0,1,2 || Wide - 0,1,2 ||
                int[,] arrEraseInts = new int[2, 4];

                switch (directionToMove)
                {
                    case MoveDirections.up:
                        {
                            newTop = Top - UDInterval;
                            newLeft = Left;

                            eraseTop = Top + (shapeHeight - 1);
                            eraseBot = Top + (shapeHeight - 1) + UDInterval;
                            eraseLeft = Left;
                            eraseRight = Left + shapeWidth ;
                            break;
                        }

                    case MoveDirections.down:
                        {
                            newTop = Top + UDInterval;
                            newLeft = Left;

                            eraseTop = Top;
                            eraseBot = Top + UDInterval;
                            eraseLeft = newLeft;
                            eraseRight = newLeft + shapeWidth ;
                            break;
                        }

                    case MoveDirections.left:
                        {
                            newTop = Top;
                            newLeft = Left - LRInterval;

                            eraseTop = newTop;
                            eraseBot = newTop + shapeHeight;
                            eraseLeft = newLeft + shapeWidth;
                            eraseRight = eraseLeft + LRInterval;
                            break;
                        }

                    case MoveDirections.right:
                        {
                            newTop = Top;
                            newLeft = Left + LRInterval;

                            eraseTop = newTop;
                            eraseBot = newTop + shapeHeight;
                            eraseLeft = Left;
                            eraseRight = Left + LRInterval;
                            break;
                        }

                    case MoveDirections.up_left:
                        {
                            diagonalMove = true;
                            newTop = Top - UDInterval;
                            newLeft = Left - LRInterval;

                            //------------------
                            // Erase Tall Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (shapeHeight - 1);
                                eraseLeft = Left + shapeWidth - LRInterval;
                                eraseRight = Left + (shapeWidth - 1);

                                eraseHeight = shapeHeight;
                                eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                                arrEraseInts[0, 0] = eraseLeft;
                                arrEraseInts[0, 1] = eraseTop;
                                arrEraseInts[0, 2] = eraseHeight;
                                arrEraseInts[0, 3] = eraseWidth;
                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top + (shapeHeight - 1);
                                eraseBot = eraseTop - UDInterval;
                                eraseLeft = Left;
                                eraseRight = Left + (shapeWidth - 1);

                                eraseHeight = shapeHeight;
                                eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                                arrEraseInts[1, 0] = eraseLeft;
                                arrEraseInts[1, 1] = eraseTop;
                                arrEraseInts[1, 2] = eraseHeight;
                                arrEraseInts[1, 3] = eraseWidth;
                            }
                            break;
                        }

                    case MoveDirections.down_left:
                        {
                            diagonalMove = true;
                            newTop = Top + UDInterval;
                            newLeft = Left - LRInterval;

                            //------------------
                            // Erase Tall Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (shapeHeight - 1);
                                eraseLeft = Left + shapeWidth - LRInterval;
                                eraseRight = Left + (shapeWidth - 1);

                                eraseHeight = shapeHeight;
                                eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                                arrEraseInts[0, 0] = eraseLeft;
                                arrEraseInts[0, 1] = eraseTop;
                                arrEraseInts[0, 2] = eraseHeight;
                                arrEraseInts[0, 3] = eraseWidth;
                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (UDInterval - 1);
                                eraseLeft = Left;
                                eraseRight = eraseLeft + (shapeWidth - 1);

                                eraseHeight = Math.Abs(eraseTop - eraseBot) + 1;
                                eraseWidth = shapeWidth;

                                arrEraseInts[1, 0] = eraseLeft;
                                arrEraseInts[1, 1] = eraseTop;
                                arrEraseInts[1, 2] = eraseHeight;
                                arrEraseInts[1, 3] = eraseWidth;
                            }
                            break;
                        }


                    case MoveDirections.up_right:
                        {
                            diagonalMove = true;
                            newTop = Top - UDInterval;
                            newLeft = Left + LRInterval;

                            //------------------
                            // Erase Tall Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (shapeHeight - 1);
                                eraseLeft = Left;
                                eraseRight = Left + (LRInterval - 1);

                                eraseHeight = shapeHeight;
                                eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                                arrEraseInts[0, 0] = eraseLeft;
                                arrEraseInts[0, 1] = eraseTop;
                                arrEraseInts[0, 2] = eraseHeight;
                                arrEraseInts[0, 3] = eraseWidth;

                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top + (shapeHeight - 1);
                                eraseBot = Top + (shapeHeight - 1) + UDInterval;
                                eraseLeft = Left;
                                eraseRight = Left + (shapeWidth - 1);

                                eraseHeight = Math.Abs(eraseTop - eraseBot) + 1;
                                eraseWidth = shapeWidth;

                                arrEraseInts[1, 0] = eraseLeft;
                                arrEraseInts[1, 1] = eraseTop;
                                arrEraseInts[1, 2] = eraseHeight;
                                arrEraseInts[1, 3] = eraseWidth;
                            }
                            break;
                        }


                    case MoveDirections.down_right:
                        {
                            diagonalMove = true;
                            newTop = Top + UDInterval;
                            newLeft = Left + LRInterval;


                            //------------------
                            // Erase Tall Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (shapeHeight - 1);
                                eraseLeft = Left;
                                eraseRight = Left + (LRInterval - 1);

                                eraseHeight = shapeHeight;
                                eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                                arrEraseInts[0, 0] = eraseLeft;
                                arrEraseInts[0, 1] = eraseTop;
                                arrEraseInts[0, 2] = eraseHeight;
                                arrEraseInts[0, 3] = eraseWidth;
                            }

                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + (UDInterval - 1);
                                eraseLeft = Left;
                                eraseRight = Left + (shapeWidth - 1);

                                eraseHeight = Math.Abs(eraseTop - eraseBot) + 1;
                                eraseWidth = shapeWidth;

                                arrEraseInts[1, 0] = eraseLeft;
                                arrEraseInts[1, 1] = eraseTop;
                                arrEraseInts[1, 2] = eraseHeight;
                                arrEraseInts[1, 3] = eraseWidth;
                            }
                            break;
                        }

                    default:
                        newTop = Top;
                        newLeft = Left;

                        eraseTop = Top;
                        eraseBot = Top;
                        eraseLeft = Left;
                        eraseRight = Left;
                        break;
                }

                //================================
                // *** NEW STUFF ***
                //================================
                if (eraseTop < 0) { eraseTop = 0; }
                if (eraseLeft < 0) { eraseLeft = 0; }
                for (int i = eraseTop; i < eraseBot; i++)
                {
                    for (int j = eraseLeft; j < eraseRight; j++)
                    {
                        PUBV.consoleArr_MovementLayer[i, j] = '\0';
                        PUBV.consoleArr_NeedsUpdate[i, j] = true;
                    }
                }
                DrawTool.AddImageToConsoleArrays_MovementLayer(newLeft, newTop, shape, true);
                //================================
                // *** NEW STUFF ***
                //================================


                if (newLeft < 1) { newLeft = Left; }
                else if (newLeft > Console.WindowWidth - shapeWidth - 1) { newLeft = Left; }

                if (!diagonalMove)
                {
                    eraseHeight = Math.Abs(eraseTop - eraseBot) + 1;
                    eraseWidth = Math.Abs(eraseLeft - eraseRight) + 1;

                    //DrawTool.EraseArea(eraseLeft, eraseTop, eraseHeight, eraseWidth);
                }
                else
                {
                    //DrawTool.EraseArea(arrEraseInts[0, 0], arrEraseInts[0, 1], arrEraseInts[0, 2], arrEraseInts[0, 3]);
                    //DrawTool.EraseArea(arrEraseInts[1, 0], arrEraseInts[1, 1], arrEraseInts[1, 2], arrEraseInts[1, 3]);
                }

                // DrawTool.Draw_A_Shape(newLeft, newTop, this);
                Left = newLeft;
                Top = newTop;
            }
        }

        public enum MoveDirections
        {
            up,
            down,
            left,
            right,
            up_left,
            up_right,
            down_left,
            down_right,
            Wait
        }




        public enum MovementTypes
        {
            Up_Down,
            Left_Right,
            Diagonal_BL_TR,
            Circle_CW,
            Circle_CCW,
            Spiral_CW
        }
    }
}
