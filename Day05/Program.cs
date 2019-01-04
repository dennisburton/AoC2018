using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var polymer = loader.LoadPolymer("data.txt");

            var processor = new PolymerProcessor();
            //var result = processor.RemoveReactions(polymer);

            var containedLetters = processor.ContainedLetters(polymer);
            var processedResults = containedLetters.ToDictionary(letter => letter, (letter)=>{
                var preProcessed = processor.RemoveElement(letter,polymer);
                var result = processor.RemoveReactions(preProcessed);
                System.Console.WriteLine($"{letter} : {result.Length}");
                return result.Length;
            });

            var smallestResult =  processedResults.Aggregate( (left, right) => left.Value < right.Value ? left : right );
            System.Console.WriteLine($"smallest removedLetter = {smallestResult.Key} length = {smallestResult.Value}");
/* 
            foreach(var r in processedResults){
                System.Console.WriteLine($"{r.Key} : {r.Value}");
            }

*/


            //System.Console.WriteLine($"polymer: {polymer}");
            //System.Console.WriteLine($"{result.Length}");
        }
    }
}
