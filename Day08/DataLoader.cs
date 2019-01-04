using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    public class DataLoader {
        public List<int> LoadNumbers( string fileName ){
            var results = new List<int>();

            if( !File.Exists(fileName) ) return results;

            foreach(var line in File.ReadAllLines(fileName)){
                var textNumbers = line.Split(" ");
                var numbers = textNumbers.Select( textNumber => Convert.ToInt32(textNumber) );
                results.AddRange(numbers);
            }
            
            return results;
        }

        private int _currentIndex = 0;
        public Node LoadNode( List<int> numbers){
            var node = new Node();

            node.Name = NextNodeNumber() ;

            var numberOfChildren = numbers[_currentIndex++];
            var metaDataCount = numbers[_currentIndex++];

            for( int childIndex=0; childIndex<numberOfChildren; childIndex++ ){
                node.Children.Add( LoadNode(numbers) );
            }

            for( int metaDataIndex=0; metaDataIndex<metaDataCount; metaDataIndex++ ){
                var currentNumber = numbers[_currentIndex++];
                node.MetaData.Add(currentNumber);
            }

            return node;
        }

        private int _nextNodeNumber = 0;
        public int NextNodeNumber(){
            return _nextNodeNumber++;
            /* 
            var result = $"{_nextNodeLetter}{_nextNodeNumber}";
            System.Console.WriteLine($"result {result}");
            _nextNodeLetter = _nextNodeLetter == 'Z' ? 'A' : _nextNodeLetter++;
            _nextNodeNumber = _nextNodeNumber == 9 ? 0 : _nextNodeNumber++;
            return result;
            */
        }
    }
}
