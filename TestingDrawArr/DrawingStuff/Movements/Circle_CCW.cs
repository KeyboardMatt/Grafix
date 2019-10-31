using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff.Movements
{
    public class Circle_CCW : _Movements
    {

        public Circle_CCW()
        {
            InitializeMovementOrder();
        }
      
        protected override void InitializeMovementOrder()
        {
            lMovementOrder.Add(ShapeMover.MoveDirections.down);
            lMovementOrder.Add(ShapeMover.MoveDirections.down);
            lMovementOrder.Add(ShapeMover.MoveDirections.down);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.right);
            lMovementOrder.Add(ShapeMover.MoveDirections.right);
            lMovementOrder.Add(ShapeMover.MoveDirections.right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up);
            lMovementOrder.Add(ShapeMover.MoveDirections.up);
            lMovementOrder.Add(ShapeMover.MoveDirections.up);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);

            lMovementOrder.Add(ShapeMover.MoveDirections.left);
            lMovementOrder.Add(ShapeMover.MoveDirections.left);
            lMovementOrder.Add(ShapeMover.MoveDirections.left);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);            
        }
    }
}
