using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new BoxIdLoader();
            //var boxIds = loader.LoadBoxIds("dataSimilarSmall.txt");
            var boxIds = loader.LoadBoxIds("data.txt");

            var processor = new BoxIdProcessor();
            //var checksum = processor.CalculateChecsum(boxIds);

            var similarIds = processor.FindSimilarIds(boxIds);
            var scrubbedIds = processor.ScrubMatchingCharacters(similarIds.firstId, similarIds.secondId);

            System.Console.WriteLine($"SimilarIds: {similarIds.firstId} : {similarIds.secondId} ");
            System.Console.WriteLine($"ScrubbedIds: {scrubbedIds.firstId} : {scrubbedIds.secondId} ");
        }
    }

    public class BoxIdProcessor{
        public (string firstId, string secondId) FindSimilarIds(List<string> boxIds){
            for( int firstIndex=0; firstIndex<boxIds.Count; firstIndex++ ){
                for( int secondIndex=0; secondIndex<boxIds.Count; secondIndex++ ){
                    if( firstIndex == secondIndex ) continue;

                    var numberOfDifferentCharacters = DifferingCharacterCount( boxIds[firstIndex], boxIds[secondIndex] );

                    if( numberOfDifferentCharacters == 1 ){
                        return (firstId: boxIds[firstIndex], secondId: boxIds[secondIndex]);
                    }
                }
            }

            return (firstId: String.Empty, secondId: String.Empty);
        }
        public int DifferingCharacterCount( string first, string second ){
            var length = first.Length;
            var differentCharactersCount = 0; 
            for( int characterIndex = 0; characterIndex<length; characterIndex++ ){
                if( first[characterIndex] != second[characterIndex] )
                    differentCharactersCount++;
            }

            return differentCharactersCount;
        }

        public (string firstId, string secondId) ScrubMatchingCharacters( string first, string second){
            var length = first.Length;
            var matchingCharacterIndex = 0;
            for( int characterIndex = 0; characterIndex<length; characterIndex++ ){
                if( first[characterIndex] != second[characterIndex] ){
                    matchingCharacterIndex = characterIndex;
                    break;
                }
            }

            return ( firstId: first.Remove(matchingCharacterIndex,1), 
                     secondId: second.Remove(matchingCharacterIndex,1));
        }

        public int CalculateChecsum( List<string> boxIds ){
            var countContainingTwo = 0;
            var countContainingThree = 0;


            foreach( var boxId in boxIds ){
                var results = ProcessId( boxId );
                if( results.twoLetterCount > 0 ) countContainingTwo++;
                if( results.threeLetterCount > 0 ) countContainingThree++;
            }

            return countContainingTwo * countContainingThree;
        }

        public (int twoLetterCount, int threeLetterCount) ProcessId( string boxId ){
            var characterCounts = new Dictionary<char, int>();
            foreach( var character in boxId ){
                if( characterCounts.ContainsKey(character) ){
                    characterCounts[character] += 1;
                }
                else {
                    characterCounts[character] = 1;
                }
            }

            var twoLetterCount = characterCounts.Where( kvp => kvp.Value == 2).Count();
            var threeLetterCount = characterCounts.Where( kvp => kvp.Value == 3).Count();

            return (twoLetterCount: twoLetterCount, threeLetterCount: threeLetterCount);
        }
    }

    public class BoxIdLoader
    {
        public List<string> LoadBoxIds( string fileName ){
            var boxIds = new List<string>();

            if( !File.Exists(fileName)) return boxIds;

            foreach( var boxId in File.ReadLines(fileName) ){
                boxIds.Add(boxId);
            }

            return boxIds;
        }
    }
}
