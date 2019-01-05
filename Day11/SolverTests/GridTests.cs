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

            var highestResult = grid.HighestPowerCube(3);

            Assert.Equal( expectedPower, highestResult.TotalPower);
            Assert.Equal( expectedX, highestResult.Cell.X );
            Assert.Equal( expectedY, highestResult.Cell.Y );
        }

        [Theory]
        [InlineData(18, 90, 269, 113, 16)]
        //[InlineData(42, 232, 251, 119, 12)]
        public void PowerSpotChecksAnySize( int serialNumber, int expectedX, int expectedY, int expectedPower, int expectedCubeSize ){
            const int size=300;
            var calculator = new PowerCalculator();
            
            var grid = new Grid();
            grid.SerialNumber = serialNumber;
            grid.Initialize( size, calculator );

            var highestResult = grid.HighestPowerCubeAnySize();

            Assert.Equal( expectedPower, highestResult.result.TotalPower);
            Assert.Equal( expectedX, highestResult.result.Cell.X );
            Assert.Equal( expectedY, highestResult.result.Cell.Y );
            Assert.Equal( expectedCubeSize, highestResult.cubeSize );
        }


    }
}