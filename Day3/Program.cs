using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new ClaimsProcessor();
            var claims = processor.LoadClaims("data.txt");

            var fabricMap = new FabricMap();
            fabricMap.AddClaims(claims);

            var collisionCount = fabricMap.CollisionCount();

            System.Console.WriteLine($"Collisions: {collisionCount}");

            var cleanClaim = claims.First( claim => !fabricMap.HasCollision(claim) );

            System.Console.Write("Clean Claim: ");
            cleanClaim.Log();
        }
    }


}
