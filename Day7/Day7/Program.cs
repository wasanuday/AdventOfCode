using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = File.ReadAllText("input.txt")
                 .Split(",")
                 .Select(int.Parse).ToList();

            Console.WriteLine("part one: " + PartOne(list));
            Console.WriteLine("part two: " + PartTwo(list));
        }
        private static int PartOne(List<int> list)
        {  
            List<int> allResults = new List<int>();
            
            for (int i = 1; i < list.Count; i++)
            {
                int result = 0;
                for (int j = 0; j < list.Count; j++)
                {
                  result += Math.Abs(list[j] - i);
                }
                allResults.Add(result);
            }
            return allResults.Min();
        }

        private static int PartTwo(List<int> list)
        { 
            List<int> allResults = new();

            for (int i = 1; i < list.Count; i++)
            {
                int result = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    int steps = Math.Abs(list[j]-i);
                    while (steps != 0)
                    {
                        result +=steps ;
                        steps--;
                    }
                }
                allResults.Add(result);
            }
            return allResults.Min();
        }
    }
}
