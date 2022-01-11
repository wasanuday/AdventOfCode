using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            Console.WriteLine("part one:" + PartOne(input));
            Console.WriteLine("part two:" + PartTwo(input));
        }

        private static int PartOne(List<string> input)
        {
            int errors = 0;
            Dictionary<char, char> closingCharacters = GetClosingCharacters();

            Stack<int> openingCharacters = new();

            for (int i = 0; i < input.Count; i++)
            {
                foreach (char c in input[i].ToCharArray())
                {
                    if (c == '(' || c == '{' || c == '[' || c == '<')
                        openingCharacters.Push(c);

                    else if (openingCharacters.Pop() != closingCharacters[c])
                        errors += GetErrors(c);
                    
                }
            }
            return errors;
        }

        private static Dictionary<char, char> GetClosingCharacters()
        {
            return new()
            { [']'] = '[', ['}'] = '{', [')'] = '(', ['>'] = '<', };
        }

        private static int GetErrors(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    break;
            }
            return 0;

        }
        private static int PartTwo(List<string> input)
        {
            int score = 0;
            Boolean incomplete = true;
            List<int> Scores = new();
            Dictionary<char, char> closingCharacters = GetClosingCharacters();

            Stack<char> openingCharacters = new();

            for (int i = 0; i < input.Count; i++)
            {
                foreach (char c in input[i].ToCharArray())
                {
                    if (c == '(' || c == '{' || c == '[' || c == '<')
                        openingCharacters.Push(c);

                    else if (openingCharacters.Pop() != closingCharacters[c])
                    {
                        incomplete = false;
                    }
                }

                if (incomplete)
                { 
                    while (openingCharacters.Count > 0)
                    {
                        char c = openingCharacters.Pop();
                        score = (score * 5) + GetScores(c);
                        Scores.Add(score);
                    }
                    
                }
            }
            Scores.Sort();
            return Scores[Scores.Count / 2];
        }
            private static int GetScores(char c)
            {
                switch (c)
                {
                    case '(':
                        return 1;
                    case '[':
                        return 2;
                    case '{':
                        return 3;
                    case '<':
                        return 4;
                    default:
                        break;
                }
                return 0;

            }

        }
}
