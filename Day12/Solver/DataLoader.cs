using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Solver
{
    public class DataLoader
    {
        public bool FileExists( string fileName ){
            return File.Exists( fileName );
        }

        public PuzzleDescription LoadData( string fileName ){

            if( !FileExists( fileName ) ) throw new ArgumentException($"File ${fileName} not found");
            var nextState = DataLoaderState.InitialState;

            var description = new PuzzleDescription();
            foreach( var dataLine in File.ReadAllLines( fileName ) ){
               if( nextState == DataLoaderState.InitialState ) {
                   var initialState = ProcessInitialState( dataLine );
                   nextState = DataLoaderState.BlankLine;
               }
            }


            return description;
        }

        const string initialStatePattern = "initial state: (.*)";
        public string ProcessInitialState( string input ){
            var initialStateRegex = new Regex( initialStatePattern );
            var matches = initialStateRegex.Match( input );

            if( !matches.Success ) throw new ArgumentException($"Could not parse {input} as initial state");

            return matches.Groups[1].Value;
        }
    }
}
