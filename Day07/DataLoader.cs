using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day07
{
    public class DataLoader {
        public DependencyMap LoadSteps(string fileName, int taskDuration){
            var dependencyMap = new DependencyMap();

            if( !File.Exists(fileName) ) return dependencyMap;

            foreach(var line in File.ReadAllLines(fileName)){
                var singleDependency = Parse(line);
                var step = dependencyMap.FindStep(singleDependency.stepId);
                var dependencyStep = dependencyMap.FindStep(singleDependency.dependencyStepId);
                step.AddDependency( dependencyStep );
            }

            var currentDuration = taskDuration + 1;;
            var orderedSteps = dependencyMap.Steps.OrderBy(step => step.Id);
            foreach( var step in orderedSteps ){
                step.Duration = currentDuration;
                currentDuration++;
            }

            return dependencyMap;
        }

        const string inputPattern = @"Step (\w+) must be finished before step (\w+) can begin.";
        Regex inputRegex = new Regex(inputPattern);
        public (string stepId, string dependencyStepId) Parse( string inputLine ){
            var match = inputRegex.Match(inputLine);
            if( !match.Success ) throw new InvalidDataException($"Input line not in correct format {inputLine}");

            string dependencyStepId = match.Groups[1].Value;
            string stepId = match.Groups[2].Value;

            return (stepId, dependencyStepId);
        }

    }
    //Step C must be finished before step A can begin.
}
