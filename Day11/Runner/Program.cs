using System;
using Solver;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            const int serialNumber = 9435;
            const int size=300;
            var calculator = new PowerCalculator();
            
            var grid = new Grid();
            grid.SerialNumber = serialNumber;
            grid.Initialize( size, calculator );

            var highestResultAny = grid.HighestPowerCubeAnySize();

            System.Console.WriteLine($"Result: X:{highestResultAny.result.Cell.X} Y:{highestResultAny.result.Cell.Y} power: {highestResultAny.result.TotalPower} size: {highestResultAny.cubeSize}");

        }
    }
}
