using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff.Movements
{
    public class _Movements
    {
        protected int ShiftPoint = 2;
        protected int mode = 0;
        protected int counter1 = 0;
        protected int listIndex = 0;

        public List<ShapeMover.MoveDirections> lMovementOrder = new List<ShapeMover.MoveDirections>();

        protected virtual void InitializeMovementOrder() { }
    }
}
