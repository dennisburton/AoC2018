using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3 {
    public class FabricMap {
        const int size = 1000;
        const char unusedIndicator = '.';
        const char usedIndicator = '+';
        const char collisionIndicator = 'X';

        char[,] locations = new char[size,size];

        
        public FabricMap()
        {
            for( var rowIndex = 0; rowIndex<size; rowIndex++ ){
                for( var columnIndex = 0; columnIndex<size; columnIndex++ ){
                    locations[rowIndex,columnIndex] = unusedIndicator;
                }
            }
        }

        public void AddClaims( List<Claim> claims ){
            foreach(var claim in claims){
                AddClaim(claim);
            }
        }

        public void AddClaim( Claim claim ){
            for( var rowIndex = claim.top; rowIndex<claim.top + claim.height; rowIndex++ ){
                for( var columnIndex = claim.left; columnIndex<claim.left + claim.width; columnIndex++ ){
                    var currentLocation = locations[rowIndex,columnIndex];
                    if( currentLocation == unusedIndicator ){
                        locations[rowIndex,columnIndex] = usedIndicator;
                    }else if( currentLocation == usedIndicator || currentLocation == collisionIndicator ){
                        locations[rowIndex,columnIndex] = collisionIndicator;
                    }
                }
            }
        }

        public bool HasCollision( Claim claim ){

            for( var rowIndex = claim.top; rowIndex<claim.top + claim.height; rowIndex++ ){
                for( var columnIndex = claim.left; columnIndex<claim.left + claim.width; columnIndex++ ){
                    var currentLocation = locations[rowIndex,columnIndex];
                    if( currentLocation == collisionIndicator ){
                        return true;
                    }
                }
            }

            return false;
        }

        public int CollisionCount(){
            var collisions = 0;

            for( var rowIndex = 0; rowIndex<size; rowIndex++ ){
                for( var columnIndex = 0; columnIndex<size; columnIndex++ ){
                    if( locations[rowIndex,columnIndex] == collisionIndicator ) collisions++;
                }
            }

            return collisions;
        }

        public void Log(){
            for( var rowIndex = 0; rowIndex<size; rowIndex++ ){
                for( var columnIndex = 0; columnIndex<size; columnIndex++ ){
                    Console.Write(locations[rowIndex,columnIndex]);
                }
                Console.WriteLine("");
            }
        }
    }
}