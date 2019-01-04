using System.Collections.Generic;
using Solver;
using Xunit;

namespace SolverTests
{
    public class GameTests {
        private Game _game;
        public GameTests(){
            _game = new Game();
        }

        [Fact]
        public void NewGameShouldHaveOneMarble(){
            Assert.Single( _game.Marbles );
        }

        [Fact]
        public void NewGameShouldHaveOneMarbleWithValueZero(){
            Assert.Equal( 0, _game.Marbles[0].Value );
        }

        [Fact]
        public void NewGameShouldHaveCurrentMarbleSet(){
            var currentMarbleIndex = _game.CurrentMarbleIndex;
            Assert.Equal(0,  currentMarbleIndex );
        }

        [Fact]
        public void NewGameNextMarbleIndexShouldBeAtEnd(){
            var nextMarbleIndex = _game.NextMarbleIndex( );
            Assert.Equal( 1, nextMarbleIndex );
        }

        [Theory]
        [InlineData(1, 3, 0)]
        [InlineData(2, 3, 1)]
        [InlineData(1 ,2, 3)]
        [InlineData(2 ,2, 0)]
        public void ClockwiseIndexShouldWrap( int offset, int currentMarbleIndex, int expectedIndex){
            var testMarbles = new List<Marble>{
                new Marble { Value = 2 },
                new Marble { Value = 1 },
                new Marble { Value = 3 },
            };
            _game.Marbles.AddRange( testMarbles );
            _game.CurrentMarbleIndex = currentMarbleIndex;

            var resultingIndex = _game.ClockwiseOffset( offset );

            Assert.Equal( expectedIndex, resultingIndex );
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 1, 3)]
        [InlineData(1 ,0, 3)]
        [InlineData(2 ,0, 2)]
        public void CounterClockwiseIndexShouldWrap( int offset, int currentMarbleIndex, int expectedIndex){
            var testMarbles = new List<Marble>{
                new Marble { Value = 2 },
                new Marble { Value = 1 },
                new Marble { Value = 3 },
            };
            _game.Marbles.AddRange( testMarbles );
            _game.CurrentMarbleIndex = currentMarbleIndex;

            var resultingIndex = _game.CounterClockwiseOffset( offset );

            Assert.Equal( expectedIndex, resultingIndex );
        }


        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1)]
        public void NextMarbleIndex( int currentMarbleIndex, int expectedNextIndex ){
            var testMarbles = new List<Marble>{
                new Marble { Value = 2 },
                new Marble { Value = 1 },
                new Marble { Value = 3 },
            };
            _game.Marbles.AddRange( testMarbles );
            _game.CurrentMarbleIndex = currentMarbleIndex;

            var nextMarbleIndex = _game.NextMarbleIndex();

            Assert.Equal( expectedNextIndex, nextMarbleIndex );
        }
    }
}