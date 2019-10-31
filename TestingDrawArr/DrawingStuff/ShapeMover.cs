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

       public static List<Movements._Movements> lShapeMovement = new List<Movements._Movements>();


        // ENTRY POINT TO A FULL SCREEN 'STEP'
        public static void StepAllShapes()
        {
            Array.Clear(PUBV.consoleArr_NeedsUpdate,0, PUBV.consoleArr_NeedsUpdate.Length);

            ASCII_Shape nextShape;
            for (int i = 0; i < PUBV.PriorityList_Shapes.Count; i++)
            {
                nextShape = PUBV.PriorityList_Shapes[i];

                if (nextShape.Has_MovementOrders)
                {
                    nextShape.TakeMovement_Step();
                }
            }

            Thread.Sleep(20);
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
                            clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                            clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                            clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                            clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                                eraseBot = Top + shapeHeight;
                                eraseLeft = Left + shapeWidth - LRInterval;
                                eraseRight = Left + shapeWidth ;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top + shapeHeight - UDInterval;
                                eraseBot = eraseTop + UDInterval;
                                eraseLeft = Left;
                                eraseRight = Left + shapeWidth;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                                eraseBot = Top + shapeHeight ;
                                eraseLeft = Left + shapeWidth - LRInterval;
                                eraseRight = Left + shapeWidth;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + UDInterval ;
                                eraseLeft = Left;
                                eraseRight = eraseLeft + shapeWidth ;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                                eraseBot = Top + shapeHeight ;
                                eraseLeft = Left;
                                eraseRight = Left + LRInterval ;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
                            }
                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top + shapeHeight - UDInterval;
                                eraseBot = Top + shapeHeight ;
                                eraseLeft = Left;
                                eraseRight = Left + shapeWidth;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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
                                eraseBot = Top + shapeHeight;
                                eraseLeft = Left;
                                eraseRight = Left + LRInterval;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
                            }

                            //------------------
                            // Erase Wide Area
                            //------------------
                            {
                                eraseTop = Top;
                                eraseBot = Top + UDInterval;
                                eraseLeft = Left;
                                eraseRight = Left + shapeWidth;
                                clearIt(eraseTop, eraseLeft, eraseBot, eraseRight);
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



                /*

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
                */

                DrawTool.AddImageToConsoleArrays_MovementLayer(newLeft, newTop, shape, true);


                Left = newLeft;
                Top = newTop;
            }


            void clearIt(int eraseTop, int eraseLeft, int eraseBot, int eraseRight)
            {
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
