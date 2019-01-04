using Solver;
using Xunit;

namespace SolverTests
{
    public class LightPointTests {

        [Fact]
        public void PointInteratesUsingVelocity(){
            var point = new LightPoint{ xPosition=100, yPosition=200, xVelocity=-25, yVelocity=-50 };

            point.Iterate(Direction.forward);

            Assert.Equal( 75,  point.xPosition );
            Assert.Equal( 150, point.yPosition );
        }

        [Fact]
        public void PointInterationDoesNotChangeVelocity(){
            var point = new LightPoint{ xPosition=100, yPosition=200, xVelocity=-25, yVelocity=-50 };

            point.Iterate(Direction.forward);

            Assert.Equal( -25,  point.xVelocity );
            Assert.Equal( -50, point.yVelocity );
        }
    }
}