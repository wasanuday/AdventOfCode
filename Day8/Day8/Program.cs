using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            Console.WriteLine("Part one: " + PartOne(input));
        }

        private static int PartOne(string input)
        {
            int counter = 0;
            foreach (var line in input.Split("\n"))
            {
                var parts = line.Split("|");
                foreach( var secondPart in parts[1].Split(" "))
                {
                    if (secondPart.Length == 2 ||
                        secondPart.Length == 3 ||
                        secondPart.Length == 4 ||
                        secondPart.Length == 7)
                        counter++;
                }
            }
                return counter;
        }
    }
}
