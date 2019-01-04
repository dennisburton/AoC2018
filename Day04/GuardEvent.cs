using System;

namespace Day04 {
    public class GuardEvent {
        public DateTime actualTimeStamp {get; set;}
        public DateTime effectiveTimeStamp {get; set;}
        public string description {get; set;}

        public void Log(){
            System.Console.WriteLine($"TimeStamp: {effectiveTimeStamp.ToLongDateString()} -- {effectiveTimeStamp.ToLongTimeString()}");
            System.Console.WriteLine($"Description: {description}");
        }
    }
}