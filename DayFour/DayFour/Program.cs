using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayFour
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var input = File.ReadAllLines("input.txt");
            var numbers = input[0].Split(',').Select(int.Parse).ToList();
            List<int[,]> boards = new();
            int row = 0;
            int[,] board = new int[5, 5];
            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    boards.Add(board);
                    board = new int[5, 5];
                    row = 0;
                }
                else
                {
                    var line = input[i].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    for (int col = 0; col < line.Length; col++)
                    {
                        board[row, col] = int.Parse(line[col]);
                    }
                    row++;
                }
            }
            boards.Add(board);
            Console.WriteLine("Part one:" + PartOne(numbers, boards));
        }

        private static int PartOne(List<int> numbers, List<int[,]> boards)
        {
            for (int num = 0; num < numbers.Count; num++)
            {
                foreach (var board in boards)
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (board[row, col] == numbers[num])
                                board[row, col] = -1;
                        }
                    }

                }
                foreach (var board in boards)
                {
                    if (IsBingo(board))
                       return UnmarkedNumbers(board, numbers[num]);
                }
            }
            return 0;
        }
       
        private static bool IsBingo(int[,] board)
        {
            int counter =0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (board[row, col] == -1)
                    {
                       counter ++;
                        continue;
                    }      
                }
                if (counter == 5)
                    return true ;
                else counter =0;
            }

            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    if (board[col, row] == -1)
                        counter++;
                        continue;
                }
                if (counter == 5)
                    return true;
                else counter = 0;
            }
            return false ;
        }
        private static int UnmarkedNumbers(int[,] board, int num)
        {
            int sum =0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (board[row, col] != -1)
                        sum += board[row, col];
                }
            }
                        return sum * num;
        }
    }
}
