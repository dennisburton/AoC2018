using System;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var map = loader.LoadSteps("data.txt",60);

            /*
            System.Console.WriteLine("sequence:");

            var nextStep = map.NextStep();
            while( nextStep != null  ){
                System.Console.Write($"{nextStep.Id}");
                map.CompleteStep(nextStep);
                nextStep = map.NextStep();
            }
            System.Console.WriteLine("");
            */

            const int numberOfWorkers = 5;
            var workforce = new WorkForce();
            workforce.PrepareWorkForce(numberOfWorkers);

            map.Log();

            /* 
            map.Log();

            var nextStep = map.NextStep();
            var nextWorker = workforce.NextAvailableWorker();
            nextStep.Worker = nextWorker;
            map.CompleteStep(nextStep);
            */

// need to get all avilable step and complete while there are workers
/* 
            var nextStep = map.NextStep();
            while( nextStep != null ){
                System.Console.WriteLine($"Next Step: {nextStep.Id} ");
                var nextWorker = workforce.NextAvailableWorker();
                nextStep.Worker = nextWorker;
                map.CompleteStep(nextStep);
                nextStep = map.NextStep();
            }
            */

            while(!map.IsComplete()){
                var availableSteps = map.AvailableSteps();
                var earliestStepStartTime = availableSteps.First().StartTime;
               var  earliestWorkerStartTime = workforce.NextAvailableWorker().availableSecond;

               var taskStartTime = earliestWorkerStartTime > earliestStepStartTime ? earliestWorkerStartTime : earliestStepStartTime; 


                var workers = workforce.AvailableAt(taskStartTime);



                //System.Console.WriteLine($"steps {availableSteps.Count()} workers {workers.Count()} at {requiredAvailablity}");
                while( availableSteps.Any() && workers.Any() ){
                    var step = availableSteps.First();
                    var worker = workers.First();

                    map.CompleteStep(step,worker, taskStartTime);

                    availableSteps.Remove(step);
                    workers.Remove(worker);
                    //System.Console.WriteLine("****inner end");
                }
                //System.Console.WriteLine(("****outer end"));
            }

            map.Log();
        }
    }
}
