using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            var template = input[0];
            var pairInsertion = input.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(i => i[0], j => j[1][0]);
            Console.WriteLine("Part One:" + PartOne(template, pairInsertion));

        }

        private static int PartOne(string template, Dictionary<string, char> pairInsertion)
        {
            for (var i = 0; i < 40; i++)
            {
                var sb = new StringBuilder();
                char[] charArray = template.ToCharArray();
                for (var j = 0; j < charArray.Length-1; j++)
                {
                    var middleElement = pairInsertion[charArray[j].ToString() + charArray[j + 1]];
                    if(sb.Length == 0)
                    sb.Append(charArray[j]);
                    sb.Append(middleElement);
                    sb.Append(charArray[j+1]);
                }
                template = sb.ToString();
            }

            return GetScore(template);
        }
        private static int GetScore(string template)
        {
            Dictionary<char, int> map = new();

            for (int i = 0; i < template.Length; i++)
            {
                if (map.ContainsKey(template[i]))
                    map[template[i]]++;
                else
                    map[template[i]]= 0;
                
            }
            return map.Max(x => x.Value) - map.Min(x => x.Value);
        }
    }
}
