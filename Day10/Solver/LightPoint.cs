namespace Solver
{
    public class LightPoint {
        public int xPosition { get; set; }
        public int yPosition { get; set; }

        public int xVelocity { get; set; }
        public int yVelocity { get; set; }

        public void Iterate() {
            xPosition += xVelocity;
            yPosition += yVelocity;
        }
    }
}
