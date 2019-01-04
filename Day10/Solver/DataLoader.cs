using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Solver
{
    public class DataLoader
    {
        const string lightPointPattern = @"position=< *(-*\d+), *(-*\d+)> velocity=< *(-*\d+), *(-*\d+)>";
        const int xPositionIndex = 1;
        const int yPositionIndex = 2;
        const int xVelocityIndex = 3;
        const int yVelocityIndex = 4;
        private Regex lightPointRegex = new Regex( lightPointPattern );

        public List<LightPoint> LoadFile( string fileName ){
            System.Console.WriteLine("LoadFile");
            var points = new List<LightPoint>();

            if( !File.Exists( fileName )) return points;

            System.Console.WriteLine("Found File");

            foreach( var pointDescription in File.ReadAllLines( fileName )){
                var currentPoint = PointFromDescription( pointDescription );
                points.Add( currentPoint );
            }

            return points;
        }

        public LightPoint PointFromDescription( string description ){
            var point = new LightPoint();

            var matches = lightPointRegex.Match( description );
            if( !matches.Success ) throw new ArgumentException($"could not parse input: {description}", nameof(description));

            point.xPosition = Convert.ToInt32( matches.Groups[xPositionIndex].Value );
            point.yPosition = Convert.ToInt32( matches.Groups[yPositionIndex].Value );
            point.xVelocity = Convert.ToInt32( matches.Groups[xVelocityIndex].Value );
            point.yVelocity = Convert.ToInt32( matches.Groups[yVelocityIndex].Value );

            return point;
        }
    }
}
