using System;
using System.Linq;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var games = loader.LoadGames("dataSample.txt");

            var game = games.First();
            game.Play();
        }
    }
}
