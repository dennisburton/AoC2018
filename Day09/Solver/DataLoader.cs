using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Solver
{
    public class DataLoader
    {
        const string gameDescriptionPattern = @"(\d+) players; last marble is worth (\d+) points";
        private Regex _gameRegex;
        public DataLoader(){
            _gameRegex = new Regex( gameDescriptionPattern );
        }

        public List<Game> LoadGames( string fileName ){
            var games = new List<Game>();

            if( !File.Exists( fileName )) return games;
            System.Console.WriteLine("Found File");

            foreach( var gameDescription in File.ReadAllLines( fileName ) ){
                var game = LoadGameFromString( gameDescription );
                if( game == null ){
                    System.Console.WriteLine($"could not parse {gameDescription}");
                    continue;
                }
                games.Add(game);
            }

            return games;
        }

        public Game LoadGameFromString( string gameDescription ){
            //System.Console.WriteLine($"Loading {gameDescription}");

            var matches = _gameRegex.Match( gameDescription );
            if( !matches.Success ) {
                System.Console.WriteLine("no match");
                return null;
            }

            var game = new Game();

            game.PlayerCount = Convert.ToInt32(matches.Groups[1].Value);
            game.LastMarbleScore = Convert.ToInt32(matches.Groups[2].Value);

            return game;
        }
    }
}
