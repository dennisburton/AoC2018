using System;
using System.IO;
using System.Linq;
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
                   System.Console.WriteLine( $"state: {nextState} data: {dataLine}");
                   description.InitialState = ProcessInitialState( dataLine );
                   nextState = DataLoaderState.BlankLine;
               }
               else if( nextState == DataLoaderState.BlankLine ){
                   nextState = DataLoaderState.Rules;
               }
               else if( nextState == DataLoaderState.Rules ){
                   var ruleDescription = ProcessRule( dataLine );
                   description.RuleDescriptions.Add( ruleDescription );
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

        const string rulePattern = @"([\.#]{5}) => ([\.#])";
        public RuleDescription ProcessRule( string ruleDescription ){
            var description = new RuleDescription();
            var ruleRegex = new Regex( rulePattern );

            var matches = ruleRegex.Match( ruleDescription );

            if( !matches.Success ) throw new ArgumentException($"Could not parse {ruleDescription} as a rule");

            description.Specifier = matches.Groups[1].Value;
            description.Result = matches.Groups[2].Value.First();

            return description;
        }
    }
}
