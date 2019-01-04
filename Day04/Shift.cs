using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04 {
    public class Shift {
        public int GuardId {get; set;}
        public List<GuardEvent> guardEvents {get; set;} = new List<GuardEvent>();

        private Dictionary<int, char> _minutes = Enumerable.Range(0,60).ToDictionary(minute => minute, _ => '.');
        public Dictionary<int, char> Minutes => _minutes;

        public const char awakeIndicator = '.';
        public const char sleepIndicator = '#';
        public void PopulateMinutes(){
            var nextState = awakeIndicator;
            var lastState = awakeIndicator;
            var lastMinuteProcessed = 0;

            System.Console.WriteLine($"numberOfEvents: {_minutes.Count}");
            foreach(var guardEvent in guardEvents){
                //System.Console.WriteLine($"*{guardEvent.description}*");
                if( guardEvent.description.Equals("falls asleep") ){
                    System.Console.WriteLine("sleep");
                    nextState = sleepIndicator;
                }
                if( guardEvent.description.Equals("wakes up")){
                    System.Console.WriteLine("wake");
                    nextState = awakeIndicator;
                }

                var eventMinute = guardEvent.effectiveTimeStamp.Minute;
                //System.Console.WriteLine($"eventMinute {eventMinute} currentMinute {currentMinute}");
                var currentMinute = lastMinuteProcessed;
                //if( lastMinuteProcessed >= currentMinute ){
                    for(int minute=currentMinute; minute<eventMinute; minute++){
                //        System.Console.WriteLine($"logging minute {minute}");
                        _minutes[minute] = lastState;
                        currentMinute = minute;
                        lastMinuteProcessed = minute;
                    }
                //    lastMinute = currentMinute;
                //}

                lastState = nextState;
            }
        }

        public int NumberOfSleepingMinutes {
            get{
                return _minutes.Count(minute => minute.Value == sleepIndicator);
            }
        }

        public void Log(){
            for( int minuteIndex=0; minuteIndex<60; minuteIndex++ ){
                System.Console.Write($"{_minutes[minuteIndex]}");
            }
            System.Console.WriteLine("");
        }
    }
}