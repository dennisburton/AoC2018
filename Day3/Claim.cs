using System;

namespace Day3{
    public class Claim{
        public int id {get; set;}
        public int top {get; set;}
        public int left{get;set;}
        public int width{get;set;}
        public int height{get;set;}

        public void Log(){
            System.Console.WriteLine( $"#{id} @ {top},{left}: {height}x{width}");
        }
    }
}