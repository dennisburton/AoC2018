using System;
using System.IO;
using Solver;
using Xunit;
using Xunit.Abstractions;

namespace SolverTests
{
    public class DataLoaderTests
    {
        const string sourceFileName = "../../../dataSample.txt";
        const string expectedInitialState = "#..#.#..##......###...###";
        DataLoader _loader = new DataLoader();
        ITestOutputHelper _logger;

        public DataLoaderTests( ITestOutputHelper logger ){
            _logger = logger;
        }

        [Fact]
        public void FileIsFound()
        {
            Assert.True( _loader.FileExists( sourceFileName ));
        }

        [Fact]
        public void InitialStateIsRead( ){
            var data = _loader.LoadData( sourceFileName );

            Assert.NotNull( data.InitialState );
            Assert.Equal( expectedInitialState, data.InitialState );
        }

        [Fact]
        public void InitialStateProcessing() {
            const string source = "initial state: #..#.#..##......###...###";
            var result = _loader.ProcessInitialState( source );

            Assert.Equal( expectedInitialState, result );
        }
    }
}
