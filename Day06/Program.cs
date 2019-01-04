using System;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var points = loader.LoadCoordinates("data.txt");

            var processor = new DataProcessor();
            var gridSize = processor.GetGridSize(points);
            var grid = new Grid(gridSize,points);

            System.Console.WriteLine($"loaded {points.Count()} coordinates with gridSize of {gridSize}");

            //grid.MarkCells();
            //grid.MarkInfiniteAreas();
            //int result = grid.LargestNonInfiniteArea();
            //System.Console.WriteLine($"largest area: {result}");

            const int targetDistance = 10000;
            var safeCount = grid.MarkCellsWithTotalDistance(targetDistance);
            //grid.Log();

            System.Console.WriteLine($"safe cell count = {safeCount}");
        }
    }
}
