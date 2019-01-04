using System.Linq;
using Solver;
using Xunit;

namespace SolverTests
{
    public class MarblePlacementTests {

        [Fact]
        public void Add4Validates(){
            // [-] (0)
            var game = new Game();

            //[1]  0 (1)
            var resultingPoints = game.AddMarble( 1 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 1, game.Marbles[1].Value );
            Assert.Equal( 1, game.CurrentMarbleIndex );

            //[2]  0 (2) 1 
            resultingPoints = game.AddMarble( 2 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 2, game.Marbles[1].Value );
            Assert.Equal( 1, game.Marbles[2].Value );
            Assert.Equal( 1, game.CurrentMarbleIndex );

            //[3]  0  2  1 (3)
            resultingPoints = game.AddMarble( 3 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 2, game.Marbles[1].Value );
            Assert.Equal( 1, game.Marbles[2].Value );
            Assert.Equal( 3, game.Marbles[3].Value );
            Assert.Equal( 3, game.CurrentMarbleIndex );

            //[4]  0 (4) 2  1  3 
            resultingPoints = game.AddMarble( 4 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 4, game.Marbles[1].Value );
            Assert.Equal( 2, game.Marbles[2].Value );
            Assert.Equal( 1, game.Marbles[3].Value );
            Assert.Equal( 3, game.Marbles[4].Value );
            Assert.Equal( 1, game.CurrentMarbleIndex );

            //[5]  0  4  2 (5) 1  3 
            resultingPoints = game.AddMarble( 5 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 4, game.Marbles[1].Value );
            Assert.Equal( 2, game.Marbles[2].Value );
            Assert.Equal( 5, game.Marbles[3].Value );
            Assert.Equal( 1, game.Marbles[4].Value );
            Assert.Equal( 3, game.Marbles[5].Value );
            Assert.Equal( 3, game.CurrentMarbleIndex );

            //[6]  0  4  2  5  1 (6) 3 
            resultingPoints = game.AddMarble( 6 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 4, game.Marbles[1].Value );
            Assert.Equal( 2, game.Marbles[2].Value );
            Assert.Equal( 5, game.Marbles[3].Value );
            Assert.Equal( 1, game.Marbles[4].Value );
            Assert.Equal( 6, game.Marbles[5].Value );
            Assert.Equal( 3, game.Marbles[6].Value );
            Assert.Equal( 5, game.CurrentMarbleIndex );

            game.AddMarble( 7 );

            //[8]  0 (8) 4  2  5  1  6  3  7 
            resultingPoints = game.AddMarble( 8 );
            Assert.Equal(0, resultingPoints);
            Assert.Equal( 0, game.Marbles[0].Value );
            Assert.Equal( 8, game.Marbles[1].Value );
            Assert.Equal( 4, game.Marbles[2].Value );
            Assert.Equal( 2, game.Marbles[3].Value );
            Assert.Equal( 5, game.Marbles[4].Value );
            Assert.Equal( 1, game.Marbles[5].Value );
            Assert.Equal( 6, game.Marbles[6].Value );
            Assert.Equal( 3, game.Marbles[7].Value );
            Assert.Equal( 7, game.Marbles[8].Value );
            Assert.Equal( 1, game.CurrentMarbleIndex );
        }

        [Fact]
        public void Add23rdMarbleValidates(){
            var game = new Game();
            Enumerable.Range(1, 22).ToList().ForEach( nextMarbleValue => game.AddMarble( nextMarbleValue ) );
            Assert.Equal( 22, game.Marbles[game.CurrentMarbleIndex].Value );
            Assert.Equal( 22, game.Marbles[13].Value );

            game.LogMarbles();

            var resultingPoints = game.AddMarble( 23 );
            Assert.Equal( 19, game.Marbles[game.CurrentMarbleIndex].Value );
            Assert.Equal( 32, resultingPoints);
        }


    }
}