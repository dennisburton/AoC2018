using System.Collections.Generic;

namespace Solver
{

    public class PlantRow {
        public List<RuleDescription> Rules {get; set;} = new List<RuleDescription>();
        public string Plants { get; set; }

        public int CurrentPlantIndex { get; set; }


        public RuleResult ProcessRule( RuleDescription ruleDescription ){
            var currentPlant = Plants[CurrentPlantIndex];
            var ruleResult = new RuleResult { HasChanged=false, Result = currentPlant };

            var testPlants = Plants.Substring(CurrentPlantIndex-2, 5);

            var ruleMatches = (testPlants == ruleDescription.Specifier);
            if( ruleMatches && currentPlant != ruleDescription.Result )
            { 
                ruleResult.HasChanged = true;
                ruleResult.Result = ruleDescription.Result;
            }

            return ruleResult;
        }
    }

}
