using System;
using System.IO;
using System.Linq;

namespace Day05 {
    public class DataLoader {
        public string LoadPolymer( string fileName ){
            if( !File.Exists(fileName) ){
                return String.Empty;
            }

            var polymer = File.ReadAllLines(fileName).Single();

            return polymer;
        }
    }
}