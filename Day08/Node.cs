using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    public class Node {
        public int Name {get; set;}
        public char NameAsChar {
            get {
                return (char)('A' + Name);
            }
        }
        public List<Node> Children {get; set;} = new List<Node>();
        public List<int> MetaData{get; set;} = new List<int>();

        public int SumOfMetaData(){
            var sum = 0;
            foreach( var metaNumber in MetaData ){
                sum += metaNumber;
            }
            foreach( var child in Children){
                sum += child.SumOfMetaData();
            }

            return sum;
        }

        public void Log(int tabIndex){
            for(int t = 0; t<tabIndex; t++ ){ System.Console.Write("\t"); }
            char baseChar = 'A';
            System.Console.WriteLine($"Name: {(char)(baseChar + Name)}");

            for(int t = 0; t<tabIndex; t++ ){ System.Console.Write("\t"); }
            var ms = string.Join("," , MetaData);
            System.Console.WriteLine($"Meta: {ms}");

            foreach(var child in Children){
                child.Log(tabIndex+1);
            }
        }

        public int ValueOfNode(){
            //System.Console.WriteLine($"Node {Name}: Children {Children.Count}");
            if( !Children.Any() ){ 
                var sum =  MetaData.Sum(); 
                //System.Console.WriteLine($"Node {Name} has not children returning {sum}");
                //System.Console.WriteLine($"{NameAsChar} : {sum} sum");
                return sum; 
            }

            if( !MetaData.Any() ) { 
                //System.Console.WriteLine($"Node {Name} has no children returning 0");
                return 0; 
                }


            var result = 0;
            var childCount = Children.Count;
            foreach(var metaEntry in MetaData){
                var childIndex = metaEntry - 1;
                //System.Console.WriteLine($"childIndex {childIndex} count {childCount}");
                if( childIndex >= 0 && childIndex < childCount){
                    //System.Console.WriteLine($"Index: {childIndex} Count {childCount}");
                    var childValue = Children[childIndex].ValueOfNode();
                    //System.Console.WriteLine($"Node {Name} child {Children[childIndex].Name} value {childValue}");
                    result += childValue;
                }
                else{
                    //System.Console.WriteLine($"Node {Name} invalid index {childIndex}");
                }
            }

            //System.Console.WriteLine($"{NameAsChar} : {result} childValues");
            return result;
        }

    }
}

/*
If a node has no child nodes, its value is the sum of its metadata entries. So, the value of node B 
is 10+11+12=33, and the value of node D is 99.

However, if a node does have child nodes, the metadata entries become indexes which refer to those 
child nodes. A metadata entry of 1 refers to the first child node, 2 to the second, 3 to the third, 
and so on. The value of this node is the sum of the values of the child nodes referenced by the 
metadata entries. If a referenced child node does not exist, that reference is skipped. A child 
node can be referenced multiple time and counts each time it is referenced. A metadata entry of 0 
does not refer to any child node.

 */