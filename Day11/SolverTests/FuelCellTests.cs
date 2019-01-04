using System;
using Solver;
using Xunit;

namespace SolverTests
{
    public class FuelCellTests
    {
        public FuelCellTests(){
            _grid = new Grid { SerialNumber = 8 };
            _calculator = new PowerCalculator( _grid );
            _cell = new FuelCell { X = 3, Y = 5 };
        }
        private Grid _grid;
        private PowerCalculator _calculator;
        private FuelCell _cell;

        const int expectedRackId = 13;
        const int expectedStep1 = 65;
        const int expectedStep2 = 73;
        const int expectedStep3 = 949;
        const int expectedStep4 = 9;
        const int expectedStep5 = 4;


        //The rack ID is 3 + 10 = 13.
        [Fact]
        public void RackIdCalculations()
        {
            var rackId = _calculator.RackId( _cell );

            Assert.Equal( expectedRackId, rackId );
        }
        
        //The power level starts at 13 * 5 = 65.
        [Fact]
        public void Step1Calculations(){
            var step1 = _calculator.Step1( expectedRackId, _cell );

            Assert.Equal( expectedStep1, step1 );
        }

        //Adding the serial number produces 65 + 8 = 73.
        [Fact]
        public void Step2Calculations(){
            var step2 = _calculator.Step2( expectedStep1,  _cell );

            Assert.Equal( expectedStep2, step2 );
        }

        //Multiplying by the rack ID produces 73 * 13 = 949.
        [Fact]
        public void Step3Calculations(){
            var step3 = _calculator.Step3( expectedStep2, expectedRackId );
            Assert.Equal(expectedStep3, step3);
        }


        //The hundreds digit of 949 is 9.
        // (so 12345 becomes 3; numbers with no hundreds digit become 0).
        [Theory]
        [InlineData(expectedStep3, expectedStep4)]
        [InlineData(12345,3)]
        [InlineData(55,0)]
        public void Step4Calculation(int step3Results, int expectedResult){
            var step4 = _calculator.Step4( step3Results );
            Assert.Equal(expectedResult, step4);
        }

        //Subtracting 5 produces 9 - 5 = 4.
        [Fact]
        public void Step5Calculations(){
            int step5 = _calculator.Step5( expectedStep4 );
            Assert.Equal( expectedStep5, step5 );
        }

        //Subtracting 5 produces 9 - 5 = 4.
        [Fact]
        public void CalculatePower(){
            var power = _calculator.PowerLevel( _cell );
            Assert.Equal( expectedStep5, power );
        }

    }
}