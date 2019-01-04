using System.Collections.Generic;
using Solver;
using Xunit;

namespace SolverTests
{
    public class GridTest{
        public GridTest(){
            _grid = new Grid();

        }
        private Grid _grid;

        [Fact]
        public void GridCanLoadPoints(){
            var points = new List<LightPoint>();
            points.Add( new LightPoint {xPosition=11, yPosition=22, xVelocity=33, yVelocity=44});
            points.Add( new LightPoint {xPosition=-11, yPosition=-22, xVelocity=-33, yVelocity=-44});

            _grid.LoadPoints(points);

            Assert.Equal( 2, _grid.Points.Count );
        }


        [Fact]
        public void GridIterationGeneratesBoundingCoords(){
            var points = new List<LightPoint>();
            points.Add( new LightPoint {xPosition=11, yPosition=22, xVelocity=-2, yVelocity=-3});
            points.Add( new LightPoint {xPosition=-11, yPosition=-22, xVelocity=3, yVelocity=4});
            _grid.LoadPoints(points);

            _grid.Iterate();

            var boundingRect = _grid.BoundingRect;

            Assert.Equal( 9, boundingRect.MaxXValue );
            Assert.Equal( 19, boundingRect.MaxYValue );
            Assert.Equal( -8, boundingRect.MinXValue );
            Assert.Equal( -18, boundingRect.MinYValue );
        }

    }
}