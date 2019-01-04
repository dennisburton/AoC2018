using System;

namespace Solver
{
    public class BoundingRect {
        public long MaxXValue {get; set;}
        public long MaxYValue {get; set;}

        public long MinXValue {get; set;}
        public long MinYValue {get; set;}

        public void Reset() {
            MaxXValue = int.MinValue;
            MaxYValue = int.MinValue;

            MinXValue = int.MaxValue;
            MinYValue = int.MaxValue;
        }

        public long Area { get{
            return Math.Abs(MaxXValue-MinXValue) * Math.Abs(MaxYValue-MinYValue);
        }}
    }
}
