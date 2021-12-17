using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOne
{
    internal class Program
    {
        private static IEnumerable<int> newList;

        static void Main(string[] args)
        {
            List<int> input = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();
          
              Console.WriteLine("part one: " + PartOne(input));
              Console.WriteLine("part two: " + PartTwo(input));
        }

        private static int PartOne(List<int> list)
        {
            var counter = 0;
            
            for (var i = 0; i < list.Count-1; i++)
            {
                if(list[i]< list[i + 1])
                { 
                    counter++;
                }  
            }
            return counter;

        }
        private static int PartTwo(List<int> list)
        {
            var count = 0;
            var  newList = new List<int>();    
            for (var i = 0; i < list.Count; i++)
            {
              var sum = list.Take(i+3).Skip(i).Sum();
                newList.Add(sum);
            }
            for (var i = 0; i < newList.Count-1; i++)
            { 
                if (newList[i] < newList[i+1]) { count++; } 
            }
                return count;
        }
    }
}