using System;
using System.Collections.Generic;

namespace Solver
{
    public class Grid {

        public List<LightPoint> Points {get; set;} = new List<LightPoint>();
        public BoundingRect BoundingRect {get; set;} = new BoundingRect();

        public void LoadPoints( List<LightPoint> points ){
            Points.AddRange( points );
        }

        public void Iterate(){
            foreach( var point in Points ){
                point.Iterate();

                BoundingRect.MaxXValue = Math.Max( BoundingRect.MaxXValue, point.xPosition );
                BoundingRect.MaxYValue = Math.Max( BoundingRect.MaxYValue, point.yPosition );
                BoundingRect.MinXValue = Math.Min( BoundingRect.MinXValue, point.xPosition );
                BoundingRect.MinYValue = Math.Min( BoundingRect.MinYValue, point.yPosition );
            }
        }
    }
}
