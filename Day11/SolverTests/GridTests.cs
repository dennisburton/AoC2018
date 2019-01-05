using Solver;
using Xunit;

namespace SolverTests
{
    public class GridTests
    {
        [Theory]
        [InlineData(122,79,57,-5)]
        [InlineData(217,196,39,0)]
        [InlineData(101,153,71,4)]
        public void CellSpotChecks(int x, int y, int serialNumber, int expectedPower) {
            const int size=300;
            var calculator = new PowerCalculator();
            
            var grid = new Grid();
            grid.SerialNumber = serialNumber;
            grid.Initialize( size, calculator );

            var xIndex = x-1;
            var yIndex = y-1;

            var testCell = grid.Cells[yIndex,xIndex];

            Assert.Equal(expectedPower, testCell.PowerLevel );
        }

        [Theory]
        [InlineData(18, 33, 45, 29)]
        [InlineData(42, 21, 61, 30)]
        public void PowerSpotChecks( int serialNumber, int expectedX, int expectedY, int expectedPower ){
            const int size=300;
            var calculator = new PowerCalculator();
            
            var grid = new Grid();
            grid.SerialNumber = serialNumber;
            grid.Initialize( size, calculator );

            var highestPower = grid.HighestPowerCube(3);

            Assert.Equal( expectedPower, highestPower);
            Assert.Equal( expectedX, grid.highest.X );
            Assert.Equal( expectedY, grid.highest.Y );
        }

    }
}