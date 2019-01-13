using System.Collections.Generic;
using System.Text;

namespace Solver
{

    public class PlantRow
    {
        public List<RuleDescription> Rules { get; set; } = new List<RuleDescription>();
        public string Plants { get; set; }

        public int ZeroIndex { get; set; } = 0;

        public int CurrentPlantIndex { get; set; }

        public string PlantContext(){
            var startingIndex = CurrentPlantIndex - 2;
            var endingIndex = CurrentPlantIndex + 2;
            var plantContextBuilder = new StringBuilder();
            for( int plantIndex=startingIndex; plantIndex<=endingIndex; plantIndex++ ){
                plantContextBuilder.Append(PlantAt(plantIndex));
            }

            var plantContext = plantContextBuilder.ToString();
            return plantContext;
        }

        private char PlantAt(int plantIndex){
            if( plantIndex < 0 || plantIndex > (Plants.Length-1) ) return '.';

            return Plants[plantIndex];
        }

        public RuleResult ProcessRule(RuleDescription ruleDescription)
        {
            var currentPlant = Plants[CurrentPlantIndex];
            var ruleResult = new RuleResult { HasChanged = false, Result = currentPlant };

            var startingIndex = CurrentPlantIndex - 2;
            string testPlants = PlantContext();
            // if (startingIndex < 0)
            // {
            //     testPlants = $"..{Plants.Substring(CurrentPlantIndex, 3)}";
            // }
            // else
            // {
            //     testPlants = Plants.Substring(CurrentPlantIndex - 2, 5);
            // }

            var ruleMatches = (testPlants == ruleDescription.Specifier);
            if (ruleMatches && currentPlant != ruleDescription.Result)
            {
                ruleResult.HasChanged = true;
                ruleResult.Result = ruleDescription.Result;
            }

            return ruleResult;
        }
    }

}
