using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = File.ReadAllText("input.txt").Split(",").Select(int.Parse).ToList();

            Console.WriteLine("part one: " + PartOne(list));
            Console.WriteLine("part two: " + PartTwo(list));


        }

        private static int PartOne(List<int> list)
        {
            for (int i = 0; i < 80; i++)
            {
                for (var j = 0; j < list.Count; j++)
                {
                    if (list[j] == 0)
                    {
                        list[j] = 7;
                        list.Add(9);
                    }
                    list[j]--;
                }
            }
            return list.Count;
        }
        private static int PartTwo(List<int> list)
        {
            List<int> fishCountByInternalTimer = new List <int>(9);
            for (var t = 1; t < 256; t++)
            {
                fishCountByInternalTimer[(t + 7) % 9] += fishCountByInternalTimer[t % 9];
            }

            return fishCountByInternalTimer.Sum();
            
        }
    }
}