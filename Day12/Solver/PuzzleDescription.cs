using System.Collections.Generic;

namespace Solver
{
    public class PuzzleDescription {
        public string InitialState{get; set;}
        public List<string> RuleDescription {get; set;} = new List<string>();
    }
}
