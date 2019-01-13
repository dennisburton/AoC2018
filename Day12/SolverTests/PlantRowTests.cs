using System.Collections.Generic;
using Solver;
using Xunit;
using Xunit.Abstractions;

namespace SolverTests
{
    public class PlantRowTests {
        // testing rules
        // 
        private PlantRow _plantRow;
        ITestOutputHelper _logger;


        // setup rules with:
        //..#.. => .
        //##.## => .
        //.##.# => #
        // setup row of plants as:
        // ..#..##.##.##.# in order to have the rules available with different offsets in the row
        public PlantRowTests( ITestOutputHelper logger ) {
            _logger = logger;
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

        [Theory]
        [InlineData(2, "..#..","")]
        [InlineData(1, "...#.","")]
        [InlineData(0, "....#","")]
        [InlineData(2, "#####","###########")]
        [InlineData(1, ".####","###########")]
        [InlineData(0, "..###","###########")]
        [InlineData(12, ".##.#","")]
        [InlineData(13, "##.#.","")]
        [InlineData(14, "#.#..","")]
        public void CurrentPlantContext(int startingIndex, string expectedPlantContext, string plantOverride){
            if( !string.IsNullOrEmpty(plantOverride) ) _plantRow.Plants = plantOverride;


            _plantRow.CurrentPlantIndex = startingIndex;
            var actualPlantContext = _plantRow.PlantContext( );

            _logger.WriteLine($"offset: {startingIndex}  expected:{expectedPlantContext} actual:{actualPlantContext}");

            Assert.Equal( expectedPlantContext, actualPlantContext );
        }





    }
}
