using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff.Movements
{
    public class Spiral_CW : _Movements
    {
        public Spiral_CW()
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



            lMovementOrder.Add(ShapeMover.MoveDirections.down);
            lMovementOrder.Add(ShapeMover.MoveDirections.down);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.right);
            lMovementOrder.Add(ShapeMover.MoveDirections.right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up);
            lMovementOrder.Add(ShapeMover.MoveDirections.up);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);

            lMovementOrder.Add(ShapeMover.MoveDirections.left);
            lMovementOrder.Add(ShapeMover.MoveDirections.left);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);
            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);



            lMovementOrder.Add(ShapeMover.MoveDirections.down);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_right);

            lMovementOrder.Add(ShapeMover.MoveDirections.up);

            lMovementOrder.Add(ShapeMover.MoveDirections.up_left);

            lMovementOrder.Add(ShapeMover.MoveDirections.left);

            lMovementOrder.Add(ShapeMover.MoveDirections.down_left);
        }
    }
}
