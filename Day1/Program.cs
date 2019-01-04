using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new FrequencyChanges();
            loader.LoadFrequencyChanges("c:/dev/aoc/Day1/data.txt");

            var isComplete = false;
            var currentFrequency = 0;
            var frequencies = new HashSet<int>();

            while(!isComplete){
                var nextFrequencyChange = loader.NextFrequencyChange();
                var resultFrequency  = currentFrequency + nextFrequencyChange;
                System.Console.WriteLine($"Current frequency {currentFrequency}, change of {nextFrequencyChange}; resulting frequency {resultFrequency}.");
                currentFrequency = resultFrequency;
                if( frequencies.Contains( currentFrequency )){
                    isComplete = true;
                }
                else{
                    frequencies.Add(currentFrequency);
                }
            }
            System.Console.WriteLine( $"First frequency reached twice ${currentFrequency}");
            System.Console.WriteLine($"Size of frequencies: ${frequencies.Count}");
        }
    }

    class FrequencyChanges {
        private int _currentIndex = 0;
        private List<int> _changes = new List<int>();

        public void LoadFrequencyChanges(string fileName){
            if( !File.Exists(fileName) ){ 
                System.Console.WriteLine($"Could not locate file: {fileName}");
                _changes = new List<int>();
            }
            _changes = File.ReadLines(fileName)
                       .Select(stringFrequency => Convert.ToInt32(stringFrequency))
                       .ToList();
        }

        public int NextFrequencyChange(){
            if( _currentIndex >= _changes.Count() ){ _currentIndex = 0; }

            var currentFrequencyChange = _changes[_currentIndex];
            _currentIndex++;

            return currentFrequencyChange;
        }
    }
}
