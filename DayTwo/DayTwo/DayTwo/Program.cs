using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayTwo
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
           var list = File.ReadAllLines("input.txt")
                     .Select(x => x.Split())
                     .Select(x=> (x[0], int.Parse(x[1]))).ToList();

            Console.WriteLine("part one: " + PartOne(list));
            Console.WriteLine("part two: " + PartTwo(list));
        }

        private static int PartOne(List<(string,int)> list)
        {
            int horizontalPos = 0;
            int depth = 0;
            foreach (var (word, value) in list)
            {
                if(word == "forward")
                    horizontalPos += value;

                else if (word  == "up")
                    depth -= value;

               else
                    depth += value;
            }
               return horizontalPos*depth;
        }
        private static int PartTwo(List<(string, int)> list)
        {
            int horizontalPos = 0;
            int depth = 0;
            int aim =0;
            foreach (var (word, value) in list)
            {
                if (word == "forward")
                {
                    horizontalPos += value;
                    depth += aim * value;
                }
                else if (word == "up")
                {
                    aim -= value;
                }
               else
                { 
                    aim += value;
                }
            }
            return horizontalPos * depth;
        }

    }
}
