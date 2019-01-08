using System;
using Solver;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "SolverTests/dataSample.txt";
            var loader = new DataLoader();

            var puzzleDescription = loader.LoadData( fileName );

            System.Console.WriteLine( $" program initial state {puzzleDescription.InitialState}");
            System.Console.WriteLine( $" rules {puzzleDescription.RuleDescriptions.Count}");
        }
    }
}
