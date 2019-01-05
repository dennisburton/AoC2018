namespace Solver
{

    public class Grid {
        public int SerialNumber { get; set; }

        private int _size = 0;
        public void Initialize( int size, PowerCalculator calculator ){
            _size = size;
            Cells = new FuelCell[size,size];
            for(int rowIndex=0; rowIndex<size; rowIndex++){
                var currentY = rowIndex + 1;
                for(int columnIndex=0; columnIndex<size; columnIndex++){
                    var currentX = columnIndex + 1;

                    var cell = new FuelCell {X = currentX, Y = currentY};
                    var power = calculator.PowerLevel( SerialNumber, cell );
                    cell.PowerLevel = power;

                    Cells[rowIndex,columnIndex] = cell;
                }
            }
        }

        public PowerResult HighestPowerCube(int gridSize) {
            var highestTotalPower = int.MinValue;
            FuelCell highestCell = null;

            for(int rowIndex=0; rowIndex<_size -(gridSize-1); rowIndex++){
                for(int columnIndex=0; columnIndex<_size - (gridSize-1); columnIndex++){
                    var currentTotalPower = 0;
                    for(int rowOffset=0; rowOffset<gridSize; rowOffset++){
                        for(int columnOffset=0; columnOffset<gridSize; columnOffset++){
                            var cellPower = Cells[rowIndex+rowOffset, columnIndex+columnOffset].PowerLevel;
                            currentTotalPower += cellPower;
                        }
                    }
                    if( highestTotalPower < currentTotalPower){
                        highestTotalPower = currentTotalPower;
                        highestCell = Cells[rowIndex,columnIndex];
                    }
                }
            }

            return new PowerResult{Cell=highestCell, TotalPower=highestTotalPower};
        }

        public (PowerResult result, int cubeSize) HighestPowerCubeAnySize(){
            int highestCubeSize = 0;
            PowerResult highestResult = null;
            for(int cubeSize=1; cubeSize<_size; cubeSize++){
                var result = HighestPowerCube(cubeSize);
                if( highestResult == null || result.TotalPower > highestResult.TotalPower ){
                    highestResult = result;
                    highestCubeSize = cubeSize;
                }
            }

            return (highestResult, highestCubeSize);
        } 

        public void Log(){
            for(int rowIndex=0; rowIndex<_size; rowIndex++){
                for(int columnIndex=0; columnIndex<_size; columnIndex++){
                    System.Console.Write($" {Cells[rowIndex,columnIndex]:G3} ");
                }
                System.Console.WriteLine("");
            }

        }

        public FuelCell[,] Cells {get; set;}
    }
}
