using System;
using System.Collections.Generic;
using System.Linq;

namespace Solver
{
    public enum Direction { forward,backward }
    public class Grid {

        public List<LightPoint> Points {get; set;} = new List<LightPoint>();
        public BoundingRect BoundingRect {get; set;} = new BoundingRect();

        public void LoadPoints( List<LightPoint> points ){
            Points.AddRange( points );
        }

        public void Iterate(Direction direction){
            BoundingRect.Reset();

            foreach( var point in Points ){
                point.Iterate(direction);

                BoundingRect.MaxXValue = Math.Max( BoundingRect.MaxXValue, point.xPosition );
                BoundingRect.MaxYValue = Math.Max( BoundingRect.MaxYValue, point.yPosition );
                BoundingRect.MinXValue = Math.Min( BoundingRect.MinXValue, point.xPosition );
                BoundingRect.MinYValue = Math.Min( BoundingRect.MinYValue, point.yPosition );
            }
        }

        public void Log(){
            for( var rowIndex=BoundingRect.MinYValue; rowIndex<=BoundingRect.MaxYValue; rowIndex++ ){
                for( var columnIndex=BoundingRect.MinXValue; columnIndex<=BoundingRect.MaxXValue; columnIndex++ ){
                    var printChar = Points.Any( p => p.xPosition == columnIndex && p.yPosition == rowIndex ) ? '#' : '.';
                    System.Console.Write($"{printChar}");
                }
                System.Console.WriteLine("");
            }
        }
    }
}
