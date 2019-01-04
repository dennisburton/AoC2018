using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day06
{
    public class DataProcessor {
        public int GetGridSize( List<Coordinate> coordinates){
            var gridSize = 0;
            foreach( var point in coordinates ){
                if( point.Location.X > gridSize ) gridSize = point.Location.X;
                if( point.Location.Y > gridSize ) gridSize = point.Location.Y;
            }

            return gridSize + 1;
        }
    }
}
