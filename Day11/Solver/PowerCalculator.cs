namespace Solver
{
    public class PowerCalculator {
        public PowerCalculator( Grid grid ){
            _grid = grid;
        }
        private Grid _grid;

        public int PowerLevel( FuelCell cell ){
            var rackId = RackId( cell );
            var step1 = Step1( rackId, cell );
            var step2 = Step2( step1, cell );
            var step3 = Step3( step2, rackId );
            var step4 = Step4( step3 );
            var power = Step5( step4 );

            return power;
        }

        // Find the fuel cell's rack ID, which is its X coordinate plus 10.
        public int RackId( FuelCell cell ){
            return cell.X + 10;
        }

        // Step1 - Begin with a power level of the rack ID times the Y coordinate.
        public int Step1( int rackId, FuelCell cell ){
            return rackId * cell.Y;
        }

        // Step2 - Increase the power level by the value of the grid serial number (your puzzle input).
        public int Step2( int step1, FuelCell cell ){
            return step1 + _grid.SerialNumber;
        }
        
        // Step3 - Set the power level to itself multiplied by the rack ID.
        public int Step3( int step2, int rackId ){
            return step2 * rackId;
        }

        // Step4 Keep only the hundreds digit of the power level 
        // (so 12345 becomes 3; numbers with no hundreds digit become 0).
        public int Step4( int step3 ){
            return (step3 % 1000) / 100;
        }

        // Step5 - Subtract 5 from the power level.
        public int Step5( int step4 ){
            return step4 - 5;
        }
    }
}