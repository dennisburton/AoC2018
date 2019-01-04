using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04
{
    public class Guard
    {

        public int Id { get; set; }
        public List<Shift> Shifts { get; set; } = new List<Shift>();

        public int NumberOfSleepingMinutes
        {
            get
            {
                return Shifts.Sum(shift => shift.NumberOfSleepingMinutes);
            }
        }


        public Dictionary<int, int> SleepLog
        {
            get {
                var sleepLog = new Dictionary<int, int>();
                foreach (var shift in Shifts)
                {
                    foreach (var minute in shift.Minutes)
                    {
                        if (minute.Value == Shift.sleepIndicator)
                        {
                            if (sleepLog.ContainsKey(minute.Key))
                            {
                                sleepLog[minute.Key] += 1;
                            }
                            else
                            {
                                sleepLog[minute.Key] = 1;
                            }
                        }
                    }
                }

                if(!sleepLog.Any()){
                    for(int minute=0; minute<60; minute++){
                        sleepLog[minute] = 0;
                    }

                    System.Console.WriteLine($"empty log for {Id} and shiftCount: {Shifts.Count()}");
                }
                System.Console.WriteLine($"calling sleep log");

                return sleepLog;
            }
        }

        public (int minute, int minutesSlept) MostFrequentMinuteSlept
        {
            get
            {
                var sleepLog = SleepLog;
                var maxMinute = sleepLog.Aggregate((left, right) => left.Value > right.Value ? left : right);

                return (maxMinute.Key, maxMinute.Value);
            }
        }


        public void Log()
        {
            System.Console.WriteLine($"guard: {Id} slept {NumberOfSleepingMinutes} ");
        }





    }
}
