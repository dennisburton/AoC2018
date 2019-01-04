using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day06
{

    public class DataLoader {
        
        public List<Coordinate> LoadCoordinates(string fileName){
            var results = new List<Coordinate>();

            if( !File.Exists(fileName) ) return results;

            const string pattern = @"(\d+), (\d+)";
            var patternRegex = new Regex(pattern);
            foreach(var line in File.ReadAllLines(fileName)){
                var match = patternRegex.Match(line);
                if( !match.Success ) continue;

                var currentPoint = new Coordinate(
                    Convert.ToInt32(match.Groups[1].Value),
                    Convert.ToInt32(match.Groups[2].Value)
                );

                results.Add(currentPoint);
            }

            return results;
        }
    }
}
