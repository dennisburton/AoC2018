using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    public class Grid
    {
        private string[,] _grid;
        private int _gridSize;
        private List<Coordinate> _coordinates;

        public const string indeterminateIndicator = @"[]";
        public const string safeIndicator = @"##";

        public Grid(int gridSize, List<Coordinate> coordinates)
        {
            _gridSize = gridSize;
            _coordinates = coordinates;
            _grid = new string[_gridSize,_gridSize];

            _coordinates.ForEach( coordinate => coordinate.Id = NextId() );

            for(int rowIndex = 0; rowIndex<_gridSize; rowIndex++ ){
                for(int columnIndex = 0; columnIndex<_gridSize; columnIndex++ ){
                    var coordinate = FindAt(rowIndex,columnIndex);
                    if( coordinate != null ){
                        _grid[rowIndex,columnIndex] = coordinate.Id;
                    }
                    else{
                        _grid[rowIndex,columnIndex] = indeterminateIndicator;
                    }
                }
            }
        }

        public int LargestNonInfiniteArea(){
            var largestCoordinate = _coordinates.Where( coordinate => !coordinate.IsInfinite )
                                                .ToDictionary( coordinate => coordinate, coordinate => OwnedByCount(coordinate) )
                                                .Aggregate( (left, right) => left.Value > right.Value ? left : right );

            return largestCoordinate.Value;
        }

        private int OwnedByCount(Coordinate coordinate){
            int count = 0;
            foreach(var cell in _grid){
                if( cell.ToLower() == coordinate.Id.ToLower() ) count++;
            }

            return count;
        }

        public void MarkCells(){
            for(int rowIndex=0; rowIndex<_gridSize; rowIndex++){
                for(int columnIndex=0; columnIndex<_gridSize; columnIndex++){
                    var owningCells = DetermineOwnership( rowIndex, columnIndex);

                    var isCompeting = owningCells.Count() > 1;
                    if( isCompeting ){
                        _grid[rowIndex,columnIndex] = indeterminateIndicator;
                    }
                    else {
                        if( !owningCells.Any() ) continue;
                        var closestCoordinate = owningCells.Single();
                        _grid[rowIndex,columnIndex] = closestCoordinate.Id.ToLower();
                    }
                }
            }
        }

        public int MarkCellsWithTotalDistance(int targetDistance){
            int safeCount  = 0;
            int lowestDistance = int.MaxValue;
            (int row, int column) lowestPoint = (0,0);
            
            for(int rowIndex=0; rowIndex<_gridSize; rowIndex++ ){
                for(int columnIndex=0; columnIndex<_gridSize; columnIndex++ ){
                    var totalDistance = DetermineTotalDistance( rowIndex, columnIndex );
                    //System.Console.WriteLine($"cell {rowIndex},{columnIndex} distance: {totalDistance}");
                    if( totalDistance < lowestDistance ){
                        lowestDistance = totalDistance;
                        lowestPoint = (row: rowIndex, column: columnIndex);
                    }
                    if(totalDistance < targetDistance){
                        _grid[rowIndex, columnIndex] = safeIndicator;
                        safeCount++;
                    }
                }
            }

            System.Console.WriteLine($"lowest point {lowestPoint.row},{lowestPoint.column} with distance {lowestDistance}");

            return safeCount;
        }


        public void MarkInfiniteAreas(){
            var testCoordinates = new List<(int row, int column)>();
            // (-1, -1..n+1)
            for( int columnIndex=-1; columnIndex<=_gridSize; columnIndex++ ){
                testCoordinates.Add( (row: -1, column: columnIndex ) );
            }

            // (0..n, -1,n+1)
            for( int rowIndex=0; rowIndex<_gridSize; rowIndex++ ){
                testCoordinates.Add((row: rowIndex, column: -1));
                testCoordinates.Add((row: rowIndex, column: _gridSize));
            }

            // (n+1, -1..n+1)
            for(int columnIndex=-1; columnIndex<=_gridSize; columnIndex++){
                testCoordinates.Add( (row:_gridSize, column: columnIndex ));
            }


            foreach( var testCoordinate in testCoordinates ){
                var owningCoordinates = DetermineOwnership(testCoordinate.row, testCoordinate.column);
                if( owningCoordinates.Count == 1){
                    owningCoordinates.ForEach(coordinate => coordinate.IsInfinite=true);
                }
            }
        }

        public List<Coordinate> DetermineOwnership(int row, int column){
            var owningCoordinates = new List<Coordinate>();

            var distances = _coordinates.ToDictionary( coordinate => coordinate, coordinate =>{
                var testCell = new Coordinate(row,column);
                return Distance(testCell, coordinate);
            });

            var shortestDistance = distances.Min( distance => distance.Value );
            if( shortestDistance == 0 ) return owningCoordinates;

            owningCoordinates.AddRange( distances.Where( distance => distance.Value == shortestDistance).Select(distance => distance.Key) );
            return owningCoordinates;
        }

        public int DetermineTotalDistance(int row, int column){

            var distances = _coordinates.ToDictionary( coordinate => coordinate, coordinate =>{
                var testCell = new Coordinate(row,column);
                return Distance(testCell, coordinate);
            });

            var totalDistance = distances.Sum( distance => distance.Value );

            return totalDistance;
        }


        public Coordinate FindAt(int row, int column){
            return _coordinates.FirstOrDefault(coordinate => coordinate.Location.X==row && coordinate.Location.Y==column);
        }

        public int Distance(Coordinate left, Coordinate right){
            var xDistance = Math.Abs(left.Location.X - right.Location.X);
            var yDistance = Math.Abs(left.Location.Y - right.Location.Y);
            return xDistance + yDistance;
        }

        private int _nextNumber = 0;
        private char _nextLetter = 'A';
        public string NextId(){
            var result =  $"{_nextLetter}{_nextNumber}";
            if( _nextNumber == 9 ){
                _nextNumber = 0;
                _nextLetter += (char)1;
            }
            else{
                _nextNumber++;
            }

            return result;
        }


        public void Log(){
            System.Console.WriteLine("");
            for( int rowIndex=0; rowIndex<_gridSize; rowIndex++ ) {
                for( int columnIndex=0; columnIndex<_gridSize; columnIndex++ ){
                    System.Console.Write($" {_grid[rowIndex,columnIndex]} ");
                }
                System.Console.WriteLine("");
            }
            System.Console.WriteLine("");
        }
    }
}
