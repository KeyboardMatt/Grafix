using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff.Movements
{
    public class Left_Right : _Movements
    {
        public Left_Right(int linearDistance, int waitTime = 5)
        {
            LinearDistance = linearDistance;
            WaitTime = waitTime;
            InitializeMovementOrder();
        }

        int LinearDistance { get; set; }
        int WaitTime { get; set; }

        protected override void InitializeMovementOrder()
        {
            for (int i = 0; i < LinearDistance; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.right);
            }

            for (int i = 0; i < WaitTime; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.Wait);
            }

            for (int i = 0; i < LinearDistance; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.left);
            }

            for (int i = 0; i < WaitTime; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.Wait);
            }
        }
    }
}
