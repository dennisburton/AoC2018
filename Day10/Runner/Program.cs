using System;
using Solver;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var points = loader.LoadFile( "./Runner/sampleData.txt" );
            

        }
    }
}
