namespace Solver
{
    public class LightPoint {
        public int xPosition { get; set; }
        public int yPosition { get; set; }

        public int xVelocity { get; set; }
        public int yVelocity { get; set; }

        public void Iterate(Direction direction) {
            if( direction == Direction.forward ){
                xPosition += xVelocity;
                yPosition += yVelocity;
            } else {
                xPosition -= xVelocity;
                yPosition -= yVelocity;
            }
        }
    }
}
