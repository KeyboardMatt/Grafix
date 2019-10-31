using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff
{
    public class ASCII_Shape
    {
        public int IDnumber { get; }


        /// <summary>
        /// INITIALIZER 1 : For predefined objects
        /// </summary>
        /// <param name="shapeType"></param>
        public ASCII_Shape(DrawTool.ShapeTypes shapeType)
        {

            Left =0;
            Top =0;
            ShapeType = shapeType;

            shapeHeight =   PredefinedShapes.Get_Height(shapeType);
            shapeWidth =    PredefinedShapes.Get_Width(shapeType);
            lStrings =      PredefinedShapes.Get_ListStrings(shapeType);
            lColors =       PredefinedShapes.Get_ListColors(shapeType);

            IDnumber = PUBV.GetNextShapeIndex();
            PUBV.Initialize_NewShape(this);
        }

        /// <summary>
        /// INITIALIZER 2 : For custom size textbox objects
        /// </summary>
        /// <param name="textBoxString"></param>
        /// <param name="widthOfTextBox"></param>
        /// <param name="listOfColors"></param>
        public ASCII_Shape(string textBoxString, int widthOfTextBox, List<string> listOfColors = null)
        {

            Left = 0;
            Top = 0;
            ShapeType = DrawTool.ShapeTypes.Custom;

            List<string> listOfStrings = TestStuff.CTools.GetTextBox_Single(textBoxString, widthOfTextBox);
            lStrings = listOfStrings;

            shapeHeight = lStrings.Count();
            shapeWidth = lStrings[0].Length;

            if (listOfColors == null)
                { lColors = lStrings; }
            else { lColors = listOfColors; }

            IDnumber = PUBV.GetNextShapeIndex();
            PUBV.Initialize_NewShape(this);
        }





        //========================================
        //      MOVEMENT ORDERS
        //========================================

        public Movements._Movements movementOrder = new Movements._Movements();

        public bool Has_MovementOrders { get; set; }


        int repeatCount;
        /// <summary>
        /// Add new movement orders
        /// </summary>
        /// <param name="newMovement"></param>
        /// <param name="repeatXtimes"> enter -44 to do infinitely</param>
        public void Add_Movement(Movements._Movements newMovement, int repeatXtimes = 0)
        {
            Has_MovementOrders = true;
            movementOrder = newMovement;
            CurrentStep = 0;
            TotalMovementSteps = newMovement.lMovementOrder.Count();
            repeatCount = repeatXtimes;
        }

        int TotalMovementSteps { get; set; }
        int CurrentStep { get; set; }
        public void TakeMovement_Step()
        {

            ShapeMover.Move_Custom(this, movementOrder.lMovementOrder[CurrentStep]);
            CurrentStep++;
            if(CurrentStep >= TotalMovementSteps)
            {
                if(repeatCount>0)
                {
                    // Reset if repeatable
                    repeatCount--;
                    CurrentStep = 0;
                }
                else if(repeatCount == -44)
                {
                    // Reset forever
                    CurrentStep = 0;
                }
                else
                {
                    CurrentStep = -1;
                    TotalMovementSteps = -1;
                    movementOrder = null;
                    Has_MovementOrders = false;
                }
            }            
        }


        public void Initialize_CustomShape(List<string> listOfStrings, List<string> listOfColors = null)
        {
            lStrings = listOfStrings;

            shapeWidth = lStrings[0].Length;
            shapeHeight = lStrings.Count();
        }

        public List<string> lStrings = new List<string>();
        public List<string> lColors = new List<string>();

        public int Left { get; set; }
        public int Top { get; set; }
        public DrawTool.ShapeTypes ShapeType { get; }


        /// <summary>
        /// Makes visibile (draws the shape) or invisible (erases the shape)
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set
            {
                if (value == true)
                {
                    visible = true;
                    //DrawTool.Draw_A_Shape(Left, Top, this);
                }
                else
                {
                    visible = false;
                    //DrawTool.EraseArea(Left, Top, this);
                }
            }
        }
        private bool visible;

        public int shapeWidth { get; set; }
        public int shapeHeight { get; set; }
        

        public void Move_Up()       { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.up);}
        public void Move_Down()     { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.down);}
        public void Move_Left()     { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.left);}
        public void Move_Right()    { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.right);}
        public void Move_UpLeft()   { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.up_left);}
        public void Move_UpRight()  { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.up_right);}
        public void Move_DownLeft() { ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.down_left);}
        public void Move_DownRight(){ ShapeMover.Move_Custom(this, ShapeMover.MoveDirections.down_right);}






        
    }
}
