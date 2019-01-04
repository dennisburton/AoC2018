using System;
using Solver;
using Xunit;

namespace SolverTests
{
    public class DataLoaderTests
    {

        public DataLoaderTests(){
            _loader = new DataLoader();
        }
        private DataLoader _loader;

        [Theory]
        [InlineData("10 players; last marble is worth 1618 points", 10, 1618)]
        [InlineData("13 players; last marble is worth 7999 points", 13, 7999)]
        [InlineData("17 players; last marble is worth 1104 points", 17, 1104)]
        [InlineData("21 players; last marble is worth 6111 points", 21, 6111)]
        [InlineData("30 players; last marble is worth 5807 points", 30, 5807)]
        public void GameIsParsedFromString( string gameDescription, int expectedPlayerCount, int expectedLastMarbleScore )
        {
            var game = _loader.LoadGameFromString( gameDescription );
            Assert.Equal( expectedPlayerCount, game.PlayerCount );
            Assert.Equal( expectedLastMarbleScore, game.LastMarbleScore );
        }

        [Theory]
        [InlineData("some players; last marble is worth more points")]
        public void InvalidGameIsNotParsed( string gameDescription ){
            var game = _loader.LoadGameFromString( gameDescription );
            Assert.Null( game );

        }
    }
}