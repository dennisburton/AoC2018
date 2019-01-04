using System.Drawing;

namespace Day06
{
    public class Coordinate {
        public Coordinate(int row, int column)
        {
            Location = new Point {X = row, Y = column};
        }

        public string Id {get; set;}

        public Point Location {get; set;} 
        public bool IsInfinite {get; set;}
    }
}
