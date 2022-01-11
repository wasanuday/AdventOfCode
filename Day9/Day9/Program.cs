using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var  input = File.ReadAllText("input.txt").Split("\n").ToList();
        
            Console.WriteLine(" Part One: " + PartOne(input));

        }

        private static int PartOne(List<string> input)
        {
            int sum = 0;
            var matrix = new int[input.Count, input[0].Length];

            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input[0].Length; j++)
                {
                    matrix[i, j] = input[i][j] - '0';
                }

            }

            for (var row = 0; row < input.Count; row++)
            {
                for (var col = 0; col < input[0].Length; col++)
                {
                    int currentValue = matrix[row, col];
                   
                    if (row > 0 && currentValue >= matrix[row - 1, col])
                        continue;

                    else if (row+1 < input.Count && currentValue >= matrix[row + 1, col])
                        continue;

                    else if (col > 0 && currentValue >= matrix[row, col - 1])
                        continue;
                    
                    else if (col+1 < input[0].Length && currentValue >= matrix[row, col + 1])
                        continue;
                    
                    else
                        sum += currentValue + 1;
                   
                }
            }
            return sum;
        }
       
    }
}
