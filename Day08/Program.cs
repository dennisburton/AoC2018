using System;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataFile = "data.txt";

            var loader = new DataLoader();
            var numbers = loader.LoadNumbers(dataFile);

            var node = loader.LoadNode(numbers);

            System.Console.WriteLine($"Numbers in file {numbers.Count}");

            //node.Log(0);
            //System.Console.WriteLine($"metadata sum {node.SumOfMetaData()}");

            var res = node.ValueOfNode();

            System.Console.WriteLine($"Value calculated as {res}");

        }
    }
}
