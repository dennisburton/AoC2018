using System.Collections.Generic;

namespace Solver
{
    public class PuzzleDescription {
        public string InitialState{get; set;}
        public List<RuleDescription> RuleDescriptions {get; set;} = new List<RuleDescription>();
    }
}
