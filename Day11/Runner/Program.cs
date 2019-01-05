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

            var power = grid.HighestPowerCube(3);

            System.Console.WriteLine($"Result: X:{grid.highest.X} Y:{grid.highest.Y} power: {power}");

        }
    }
}
