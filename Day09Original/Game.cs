using System.Collections.Generic;

namespace Day09
{
    public class Game {
        public int PlayerCount {get; set;}
        public int LastMarbleScore {get; set;}

        public List<int> Marbles = new List<int> {0};
        public int CurrentMarbleIndex = 0;

        public int _nextMarbleValue = 0;
        public int GetNextMarbleValue(){
            _nextMarbleValue += 1;
            return _nextMarbleValue;
        }

        public int ClockwiseIndex(int offset){
            var nextIndex = (CurrentMarbleIndex + offset) % Marbles.Count;
            return nextIndex;
        }

        public int CounterClockwiseIndex(int offset){
            var nextIndex = (CurrentMarbleIndex - offset);

            return nextIndex;
        }

        public void Play(){
            var lastValue = 0;
            for(int i = 1; i < 24; i++ ){
                //System.Console.WriteLine($"Adding marble value {i}");
                lastValue = AddMarble();
                LogMarbles();
            }
            System.Console.WriteLine($"last value {lastValue}");
        }

        public int AddMarble(){
            var nextMarbleValue = GetNextMarbleValue();

            if( nextMarbleValue % 23 == 0 ){
                return AddScoringMarble( nextMarbleValue );
            } else {
                AddNonScoringMarble( nextMarbleValue );
                return 0;
            }
        }

        private void AddNonScoringMarble( int marbleValue ){
            var firstIndex = ClockwiseIndex( 1 );
            var secondIndex = ClockwiseIndex( 2 );
            var nextIndex = secondIndex;

            if( firstIndex == Marbles.Count - 1  ){
                Marbles.Add( marbleValue );
                CurrentMarbleIndex = firstIndex + 1;
            } else {
                Marbles.Insert(secondIndex, marbleValue );
                CurrentMarbleIndex = secondIndex;
            }

           CurrentMarbleIndex = nextIndex;
        }

        private int AddScoringMarble( int marbleValue ){
            //First, the current player keeps the marble they would have placed, adding 
            //it to their score. 
            var score = marbleValue;

            //In addition, the marble 7 marbles counter-clockwise from the current marble is 
            //removed from the circle and also added to the current player's score. The marble located immediately 
            //clockwise of the marble that was removed becomes the new current marble.
            var nextScoreIndex = CounterClockwiseIndex( 7 );
            System.Console.WriteLine($"scoring marble index {nextScoreIndex} score {Marbles[nextScoreIndex]}");
            score += Marbles[nextScoreIndex];
            CurrentMarbleIndex = nextScoreIndex;
            var nextCurrentIndex = ClockwiseIndex( 1 );
            Marbles.RemoveAt(nextScoreIndex);

            return score;
        }

        public void LogMarbles(){
            //System.Console.WriteLine($"Count: {Marbles.Count}");
            for( int marbleIndex = 0; marbleIndex < Marbles.Count; marbleIndex++ ){
                if( marbleIndex == CurrentMarbleIndex ){
                    System.Console.Write($"({Marbles[marbleIndex]}) ");
                } else {
                    System.Console.Write($"{Marbles[marbleIndex]} ");
                }
            }
            System.Console.WriteLine("");
        }

    }
}

/*

Then, each Elf takes a turn placing the lowest-numbered remaining marble into the circle between the
 marbles that are 1 and 2 marbles clockwise of the current marble. (When the circle is large enough, 
 this means that there is one marble between the marble that was just placed and the current marble.) 
 The marble that was just placed then becomes the current marble.

However, if the marble that is about to be placed has a number which is a multiple of 23, something 
entirely different happens. First, the current player keeps the marble they would have placed, adding 
it to their score. In addition, the marble 7 marbles counter-clockwise from the current marble is 
removed from the circle and also added to the current player's score. The marble located immediately 
clockwise of the marble that was removed becomes the new current marble.

 */