using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff.Movements
{
    public class Diagonal_BL_TR : _Movements
    {
        public Diagonal_BL_TR(int linearDistance, int waitTime = 5)
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
                lMovementOrder.Add(ShapeMover.MoveDirections.up_right);
            }

            for (int i = 0; i < WaitTime; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.Wait);
            }

            for (int i = 0; i < LinearDistance; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.down_left);
            }

            for (int i = 0; i < WaitTime; i++)
            {
                lMovementOrder.Add(ShapeMover.MoveDirections.Wait);
            }
        }
    }
}
