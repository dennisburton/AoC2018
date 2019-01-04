using System;
using Solver;
using Xunit;

namespace SolverTests
{
    public class DataLoadingTests
    {
        public DataLoadingTests(){
            _loader = new DataLoader();
        }
        private DataLoader _loader;

        [Theory]
        [InlineData("position=< 9,  1> velocity=< 0,  2>", 9, 1, 0, 2)]
        [InlineData("position=< 3, -2> velocity=<-1,  1>", 3, -2, -1, 1)]
        [InlineData("position=<-6, 10> velocity=< 2, -2>", -6, 10, 2,-2)]
        [InlineData("position=<-11, -22> velocity=< -33, -44>", -11, -22, -33, -44)]
        [InlineData("position=< -9888,  -9919> velocity=< 1,  1>", -9888, -9919, 1, 1 )]
        public void PointAreLoadedFromDescription( string description, int expectedXPosition, int expectedYPosition, int expectedXVelocity, int expectedYVelocity )
        {
            var point = _loader.PointFromDescription( description );

            Assert.Equal( expectedXPosition, point.xPosition );
            Assert.Equal( expectedYPosition, point.yPosition );
            Assert.Equal( expectedXVelocity, point.xVelocity );
            Assert.Equal( expectedYVelocity, point.yVelocity );
        }
    }
}
