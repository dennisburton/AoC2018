using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day05
{
    public class PolymerProcessor
    {
        public string ContainedLetters( string polymer ){
            var containedLetters = polymer.ToLower().Distinct().OrderBy(c => c);
            return String.Join("",containedLetters);
        }

        public string RemoveElement( char element, string polymer ){
            var result = Regex.Replace(polymer, $"[{char.ToLower(element)}{char.ToUpper(element)}]","");
            return result;
        }

        public string RemoveReactions(string polymer)
        {
            var done = false;
            var foundReaction = false;
            while( !done ){
                foundReaction = false;

                for(int charIndex=0; charIndex<polymer.Length-1; charIndex++ ){
                    var left = polymer[charIndex];
                    var right = polymer[charIndex+1];
                    //System.Console.WriteLine($"processing {charIndex}");

                    if( IsReaction( left, right ) ){
                        //System.Console.WriteLine($"removing {left}{right}");
                        polymer = polymer.Remove(charIndex, 2);
                        foundReaction = true;
                        break;
                    }
                }

                done = !foundReaction;
            }
            return polymer;
        }

        public Boolean IsReaction( char left, char right){
            var isSameChar = char.ToLower(left) == char.ToLower(right);
            var isReaction = (char.IsLower(left) && char.IsUpper(right)) || (char.IsUpper(left) && char.IsLower(right));

            return isSameChar && isReaction;
        }
    }
}