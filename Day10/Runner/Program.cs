using System;
using Solver;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var points = loader.LoadFile( "./Runner/data.txt" );
            var grid = new Grid();
            grid.LoadPoints( points );

            var done = false;
            var iterationNumber = 0;
            long lastArea = long.MaxValue;
            while( !done ){
                iterationNumber++;

                grid.Iterate(Direction.forward);
                long currentArea = grid.BoundingRect.Area;
                var firstPoint = grid.Points[0];
                if( currentArea > lastArea ){
                    grid.Iterate(Direction.backward);
                    grid.Log();
                    done = true;
                    System.Console.WriteLine($"seconds: {iterationNumber - 1}");
                } 
                lastArea = currentArea;
            }


            

        }
    }
}
