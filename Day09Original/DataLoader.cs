using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day09
{
    public class DataLoader {
        public List<Game> LoadGames( string fileName ){
            var games = new List<Game>();

            if( !File.Exists(fileName) ){ return games; }

            var pattern = @"(\d+) players; last marble is worth (\d+) points";
            var gameRegex = new Regex( pattern );
            foreach(var dataLine in File.ReadAllLines( fileName )){
                var matches = gameRegex.Match( dataLine );
                if( matches.Success ){
                    //System.Console.WriteLine($"Match with {matches.Groups[1].Value} players and {matches.Groups[2].Value} last marble points ");
                    var game = new Game {PlayerCount=Convert.ToInt32(matches.Groups[1].Value), LastMarbleScore=Convert.ToInt32(matches.Groups[2].Value) };
                    games.Add(game);
                }
                else {
                    System.Console.WriteLine($"No Match: {dataLine}");
                }

            }
            return games;
        }



    }
}
