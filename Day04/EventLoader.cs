using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04{
    public class EventLoader{

        public List<GuardEvent> LoadEvents( string fileName ){
            var results = new List<GuardEvent>();

            if( !File.Exists(fileName) ) return results;

            foreach(var eventLine in File.ReadAllLines(fileName)){
                var evt = Parse(eventLine);
                results.Add(evt);
            }

            return results;
        }

        public List<Guard> CreateGuards( List<Shift> shifts){
            var guards = new List<Guard>();

            foreach( var shift in shifts){
                var existingGuard = guards.FirstOrDefault( guard => guard.Id == shift.GuardId );
                if( existingGuard == null ){
                    existingGuard = new Guard {Id=shift.GuardId};
                    guards.Add(existingGuard);
                }
                existingGuard.Shifts.Add(shift);
            }

            return guards;
        }

        public List<Shift> CreateShifts( List<GuardEvent> guardEvents ){
            var results = new List<Shift>();
            var orderedEvents = guardEvents.OrderBy( x => x.actualTimeStamp ).ToList();
            Shift currentShift = null;
            const string shiftPattern = @"Guard #(\d+) (.*)";
            var shiftRegex = new Regex(shiftPattern);


            //System.Console.WriteLine("ordered Shifts ------");

            foreach(var guardEvent in orderedEvents){
                var effectiveTimeStamp = guardEvent.effectiveTimeStamp;
                //System.Console.WriteLine($"{effectiveTimeStamp.ToLongDateString()} -- {effectiveTimeStamp.ToLongTimeString()}");

                var shiftMatches = shiftRegex.Match(guardEvent.description);

                 if( shiftMatches.Success ){
                     //System.Console.WriteLine($"adding shift: {guardEvent.description}");
                     currentShift = new Shift();
                     currentShift.GuardId = Convert.ToInt32(shiftMatches.Groups[1].Value);
                     results.Add(currentShift);
                 }
                 else{
                     //System.Console.WriteLine($"adding event: {guardEvent.description}");
                     currentShift.guardEvents.Add(guardEvent);
                 }
            }

            System.Console.WriteLine( $"shift count {results.Where( shift => shift.GuardId == 3533 ).Count()}");

            return results;
        }

        private GuardEvent Parse( string eventLine ){
            const string pattern = @"\[(.*)\] (.*)";
            const string timeStampPattern = @"yyyy-MM-dd HH:mm";
            var regex = new Regex(pattern);
            var match = regex.Match(eventLine);

            if( !match.Success ) return null;

            var exactTimeStamp = DateTime.ParseExact(match.Groups[1].Value, timeStampPattern, CultureInfo.InvariantCulture);
            var effectiveTimeStamp = exactTimeStamp;
            if( effectiveTimeStamp.Hour != 0 ) {
                effectiveTimeStamp.AddDays(1);
                effectiveTimeStamp = exactTimeStamp.Date;
            }


            var guardEvent = new GuardEvent{
                actualTimeStamp = exactTimeStamp,
                effectiveTimeStamp = effectiveTimeStamp,
                description = match.Groups[2].Value
            };

            return guardEvent;
        }


    }
}