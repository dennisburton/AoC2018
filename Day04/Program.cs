using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new EventLoader();
            var unOrderedEvents = loader.LoadEvents("data.txt");
            var shifts = loader.CreateShifts(unOrderedEvents);

            foreach( var shift in shifts){
                shift.PopulateMinutes();
                System.Console.WriteLine($"Guard: {shift.GuardId} num events: {shift.guardEvents.Count}");
                //shift.Log();
            }

            var guards = loader.CreateGuards(shifts);

/* 
            System.Console.WriteLine($"Event Count: {unOrderedEvents.Count}");
            System.Console.WriteLine($"Shift Count: {shifts.Count}");
            System.Console.WriteLine($"Guard Count: {guards.Count}");

            var sleepiestGuard = guards.Aggregate( (left,right) => left.NumberOfSleepingMinutes > right.NumberOfSleepingMinutes ? left : right );
            var mostFrequentMinuteSlept = sleepiestGuard.MostFrequentMinuteSlept.minutesSlept + 1;

            System.Console.WriteLine($"guard {sleepiestGuard.Id} slept the most on minute {mostFrequentMinuteSlept} result = {sleepiestGuard.Id * (mostFrequentMinuteSlept)}");
            */

            var sleepiestGuard = guards.Aggregate( (left,right) => left.NumberOfSleepingMinutes > right.NumberOfSleepingMinutes ? left : right );
            sleepiestGuard = null;
            (int minute,int minutesSlept) sleepiestMinute = (0,0);

            foreach(var guard in guards.Where(guard => guard.Id != 3533)){
                System.Console.WriteLine($"processing guard: {guard.Id}");
                var guardSleepiestMinute = guard.MostFrequentMinuteSlept;

                if( sleepiestGuard == null){
                    sleepiestGuard = guard;
                    sleepiestMinute = guardSleepiestMinute;
                }
                else{
                    if( guardSleepiestMinute.minutesSlept > sleepiestMinute.minutesSlept ){
                        sleepiestGuard = guard;
                        sleepiestMinute = guardSleepiestMinute;
                    }
                }
            }

            System.Console.WriteLine($"guardID: {sleepiestGuard.Id} slept {sleepiestMinute.minutesSlept} on minute {sleepiestMinute.minute}");
            System.Console.WriteLine($"{sleepiestGuard.Id * (sleepiestMinute.minute+1)}");
        }
    }
}
