using System.Collections.Generic;
using Solver;
using Xunit;

namespace SolverTests
{
    public class PlantRowTests {
        // testing rules
        // 
        private PlantRow _plantRow;


        // setup rules with:
        //..#.. => .
        //##.## => .
        //.##.# => #
        // setup row of plants as:
        // ..#..##.##.##.# in order to have the rules available with different offsets in the row
        public PlantRowTests() {

            _plantRow = new PlantRow();

            var rules = new List<RuleDescription> {
                new RuleDescription{Result='.', Specifier="..#.." },
                new RuleDescription{Result='.', Specifier="##.##" },
                new RuleDescription{Result='#', Specifier=".##.#" }
            };
            _plantRow.Rules.AddRange( rules );

            _plantRow.Plants = "..#..##.##.##.#";
        }

        // A note like ..#.. => . means that a pot that contains a plant but with no plants within two pots of it will not 
        // have a plant in it during the next generation.

        // A note like ##.## => . means that an empty pot with two plants on each side of it will remain empty in the next 
        // generation.

        // A note like .##.# => # means that a pot has a plant in a given generation if, in the previous generation, 
        // there were plants in that pot, the one immediately to the left, and the one two pots to the right, but not in the ones immediately to the right and two to the left.
        [Theory]
        // [InlineData(2,"..#..",'.','.', true)]
        // [InlineData(7,"##.##",'.','.', false)]
        // [InlineData(12,".##.#",'#','#', false)]
        // [InlineData(2,".##.#",'.','#', false)]
        [InlineData(0,"....#",'#','#', true)]
        public void RuleProcessing(int startingIndex, string ruleSpecifier, char ruleResult, char expectedResult, bool expectedHasChanged){
            _plantRow.CurrentPlantIndex = startingIndex;
            var ruleDescription = new RuleDescription{Result=ruleResult, Specifier=ruleSpecifier };

            var result = _plantRow.ProcessRule( ruleDescription );


            Assert.Equal( expectedHasChanged, result.HasChanged );
            Assert.Equal( expectedResult, result.Result );
        }





    }
}
