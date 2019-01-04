using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class Step {
        public string Id {get; set;}
        
        public int Duration {get; set;}
        
        public int StartTime {get; set;} = 0;
        public int CompletedOn {get; set;}

        public Worker Worker {get; set;}
        public List<Step> Dependencies { get; set; } = new List<Step>();

        public void AddDependency(Step step){
            if( Dependencies.Any( dependencyStep => dependencyStep.Id == step.Id )) return;

            Dependencies.Add(step);
        }
    }
    //Step C must be finished before step A can begin.
}
