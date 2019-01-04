using System;

namespace Solver
{
    public class BoundingRect {
        public int MaxXValue {get; set;}
        public int MaxYValue {get; set;}

        public int MinXValue {get; set;}
        public int MinYValue {get; set;}

        public int Area { get{
            return Math.Abs(MaxXValue-MinXValue) * Math.Abs(MaxYValue-MinYValue);
        }}
    }
}
