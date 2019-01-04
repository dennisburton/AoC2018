using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solver;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var games = loader.LoadGames( "./Runner/data.txt" );

foreach( var game in games ){
            //var game = games.First();
            long lastMarbleScore = 0;
            var PlayerScores = new Dictionary<int, long>();
            var currentPlayer = 0;
            var nextMarbleValue = 1;
            var done = false;
            var endingScore = game.LastMarbleScore;// * 100;
            while( !done ){
                lastMarbleScore = game.AddMarble( nextMarbleValue );

                if( nextMarbleValue % 10000 == 0 ){
                    System.Console.WriteLine($"value {nextMarbleValue}");
                }

                if( PlayerScores.ContainsKey(currentPlayer) ){
                    PlayerScores[currentPlayer] += (long)lastMarbleScore;
                }else{
                    PlayerScores[currentPlayer] = (long)lastMarbleScore;
                }
                //System.Console.Write($"[{currentPlayer}]: ");
                //game.LogMarbles();

                if( nextMarbleValue == endingScore ){
                    done = true;
                } else {
                    currentPlayer = (currentPlayer + 1) % game.PlayerCount;
                    nextMarbleValue += 1;
                }
            }

            var highPlayerScore = PlayerScores.Aggregate( (left,right) => left.Value > right.Value ? left : right );
            System.Console.WriteLine($"PlayerCount: {game.PlayerCount} LastMarble: {game.LastMarbleScore}");
            System.Console.WriteLine($"player {highPlayerScore.Key} score: {highPlayerScore.Value} ");
            System.Console.WriteLine("");


            //game.LogMarbles();



        }
        }
    }

}
