using System.Collections.Generic;

namespace Solver
{
    public class Game
    {
        public int PlayerCount { get; set; }
        public int LastMarbleScore { get; set; }

        public List<Marble> Marbles { get; set; }
        public int CurrentMarbleIndex { get; set; }

        public Game()
        {
            Marbles = new List<Marble>();
            var initialMarble = new Marble { Value = 0 };
            CurrentMarbleIndex = 0;
            Marbles.Add(initialMarble);
        }


        public int NextMarbleIndex()
        {
            //var currentMarbleIndex = Marbles.IndexOf(CurrentMarble);

            var firstIndex = ClockwiseOffset(1);
            //var secondIndex = ClockwiseOffset(2);

            return firstIndex + 1;
        }

        public int ClockwiseOffset(int offset)
        {
            //var currentMarbleIndex = Marbles.IndexOf(CurrentMarble);
            var resultIndex = (CurrentMarbleIndex + offset) % Marbles.Count;

            return resultIndex;
        }

        public int CounterClockwiseOffset(int offset)
        {
            //var currentMarbleIndex = Marbles.IndexOf(CurrentMarble);
            var resultIndex = ( CurrentMarbleIndex - offset ) ;

            if (resultIndex < 0)
            {
                resultIndex += Marbles.Count;
            }

            return resultIndex;
        }

        public int AddMarble(int marbleValue)
        {
            if (marbleValue % 23 == 0)
            {
                var resultingPoints = marbleValue;

                var secondMarbleIndex = CounterClockwiseOffset(7);
                var secondMarble = Marbles[secondMarbleIndex];
                resultingPoints += secondMarble.Value;
                CurrentMarbleIndex = secondMarbleIndex;
                //var nextCurrentIndex = ClockwiseOffset(1);
                //CurrentMarbleIndex = nextCurrentIndex;// Marbles[nextCurrentIndex];
                Marbles.RemoveAt(secondMarbleIndex);

                if( CurrentMarbleIndex == Marbles.Count ) { 
                    System.Console.WriteLine("wrapped");
                    CurrentMarbleIndex = 0;
                }

                return resultingPoints;
            }
            else
            {
                var nextIndex = NextMarbleIndex();
                var newMarble = new Marble() { Value = marbleValue };

                Marbles.Insert(nextIndex, newMarble);

                CurrentMarbleIndex = nextIndex;

                return 0;
            }

        }

        public void LogMarbles(){
            //foreach( var marble in Marbles ){
            for( int marbleIndex=0; marbleIndex<Marbles.Count; marbleIndex++ ) {// var marble in Marbles ){
                var marble = Marbles[marbleIndex];
                if( marbleIndex == CurrentMarbleIndex ){
                    System.Console.Write($" ({marble.Value}) ");
                } else {
                    System.Console.Write($" {marble.Value} ");
                }
            }
            System.Console.WriteLine("");
        }


    }
}
