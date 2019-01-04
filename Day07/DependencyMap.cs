using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class DependencyMap {
        public List<Step> Steps {get; set;} = new List<Step>();
        public List<Step> CompletedSteps {get; set;} = new List<Step>();

        public Step FindStep( string Id ){
            var existingStep = Steps.FirstOrDefault( step => step.Id == Id);
            if( existingStep != null ) return existingStep;

            var newStep = new Step{Id = Id};
            Steps.Add(newStep);
            return newStep;
        }

        public bool IsComplete(){
            return !Steps.Any();
        }

        public Step NextStep(){
            return Steps.OrderBy( step => step.Id )
                        .Where( step => !step.Dependencies.Any() )
                        .FirstOrDefault();
        }

        public List<Step> AvailableSteps(){
            var stepsWithoutDependencies =  Steps.OrderBy( step => step.Id )
                                                 .Where( step => !step.Dependencies.Any() );

            if( !stepsWithoutDependencies.Any() ) return stepsWithoutDependencies.ToList();;

            var earliestStep = stepsWithoutDependencies.Min( step => step.StartTime );

            return stepsWithoutDependencies.Where( step => step.StartTime == earliestStep )
                                           .ToList();
        }

        public void CompleteStep(Step completedStep, Worker worker, int startTime){
            completedStep.Worker = worker;
            //System.Console.WriteLine($"Completion of step {completedStep.Id} by worker {worker.Id}");
            //System.Console.WriteLine($"\tworker available: {worker.availableSecond} step start {completedStep.StartTime} duration {completedStep.Duration - 1} ");
            completedStep.StartTime = startTime;
            completedStep.CompletedOn = startTime + completedStep.Duration - 1;
            //completedStep.CompletedOn = Math.Max(worker.availableSecond, completedStep.StartTime) + completedStep.Duration - 1;
            //System.Console.WriteLine($"\tstarted on: {completedStep.StartTime} completed on {completedStep.CompletedOn}");
            worker.availableSecond = completedStep.CompletedOn + 1;
            foreach(var step in Steps){
                if( !step.Dependencies.Any() ) continue;
                step.Dependencies.Remove(completedStep);
                if( !step.Dependencies.Any() ){
                    step.StartTime = completedStep.CompletedOn + 1; 
                }
            }
            Steps.Remove(completedStep);
            CompletedSteps.Add(completedStep);
        }



        public void Log(){
            System.Console.WriteLine("Pending");
            foreach( var step in Steps.OrderBy( s => s.Id ) ){
                System.Console.WriteLine($"Step: {step.Id} Duration: {step.Duration}");
                foreach( var dependentStep in step.Dependencies ){
                    System.Console.WriteLine($"\tDepends on {dependentStep.Id}");
                }
            }

            System.Console.WriteLine("Completed");
            foreach( var step in CompletedSteps ){
                System.Console.WriteLine($"Step: {step.Id} Started at: {step.StartTime} Completed at: {step.CompletedOn} by worker {step.Worker.Id}");
            }

            if( CompletedSteps.Any() ){
                var lastCompleted = CompletedSteps.Aggregate( (left, right) => left.CompletedOn > right.CompletedOn ? left : right );
                System.Console.WriteLine($"Last Step was {lastCompleted.Id} on {lastCompleted.CompletedOn}");
            }
        }
    }
    //Step C must be finished before step A can begin.
}
