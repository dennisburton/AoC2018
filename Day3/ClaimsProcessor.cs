using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day3 {
    public class ClaimsProcessor
    {
        public List<Claim> LoadClaims(string fileName){
            var results = new List<Claim>();

            if( !File.Exists(fileName)) return results;

            foreach(var claimDescription in File.ReadLines(fileName)){
                results.Add( ParseClaimDescription(claimDescription) );
            }

            return results;
        } 


        private const string pattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)";
        private Regex _patternExpression;
        public Regex PatternExpression{
            get{ return _patternExpression ?? (_patternExpression = new Regex(pattern)); }
        }

       private Claim ParseClaimDescription(string description){
           var matchResults = PatternExpression.Match(description);

           if( !matchResults.Success){
               System.Console.WriteLine($"Could not parse {description}");
               return null;
           }

           var claim = new Claim{
               id = Convert.ToInt32(matchResults.Groups[1].Value),
               left = Convert.ToInt32(matchResults.Groups[2].Value),
               top = Convert.ToInt32(matchResults.Groups[3].Value),
               width = Convert.ToInt32(matchResults.Groups[4].Value),
               height = Convert.ToInt32(matchResults.Groups[5].Value)
           };

           return claim;
        }
    }
}
