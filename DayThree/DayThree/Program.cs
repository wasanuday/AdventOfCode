using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> input = File.ReadAllLines("input.txt").ToList();

            Console.WriteLine("part one: " + PartOne(input));
            Console.WriteLine("part Two: " + GetCO2ScrubberRate(input) * GetOxygenRate(input));

        }

        private static int PartOne(List<string> arr)
        {
            string gama = "";
            string epselon = "";

            for (int i = 0; i < arr[0].Length; i++)
            {
                int oneCounter = 0;
                int zeroCounter = 0;
                for (int j = 0; j < arr.Count; j++)
                {
                    char index = arr[j].ToCharArray()[i];

                    if (index.Equals('0'))
                        zeroCounter++;
                    else
                        oneCounter++;
                }
                if (zeroCounter > oneCounter)
                {
                    gama += "0";
                    epselon += "1";
                }
                else
                {
                    gama += "1";
                    epselon += "0";
                }
            }
            return Convert.ToInt32(gama, 2) * Convert.ToInt32(epselon, 2);
        }

        private static int GetCO2ScrubberRate(List<string> list)
        {
            var newList = list.ToList();

            for (int i = 0; i < list[0].Length; i++)
            {
                int oneCounter = 0;
                int zeroCounter = 0;

                for (int j = 0; j < newList.Count; j++)
                {
                    var index = newList[j].ToCharArray()[i];

                    if (index.Equals('0'))
                        zeroCounter++;
                    else
                        oneCounter++;
                }

                if (newList.Count > 1)
                {
                    if (zeroCounter <= oneCounter && newList.Count > 1)
                        newList = newList.Where(val => val[i] != '1').ToList();

                    else
                        newList = newList.Where(val => val[i] != '0').ToList();
                }
                else
                    break;
            }  
            return Convert.ToInt32(newList.First(), 2);
        }

        private static int GetOxygenRate(List<string> list)
        {
            var newList = list.ToList();

            for (int i = 0; i < list[0].Length; i++)
            {
                int oneCounter = 0;
                int zeroCounter = 0;

                for (int j = 0; j < newList.Count; j++)
                {
                    var index = newList[j].ToCharArray()[i];

                    if (index.Equals('0'))
                        zeroCounter++;
                    else
                        oneCounter++;
                }

                if (newList.Count > 1)
                {
                    if (zeroCounter > oneCounter && newList.Count > 1)
                        newList = newList.Where(val => val[i] != '1').ToList();

                    else
                        newList = newList.Where(val => val[i] != '0').ToList();
                }
                else
                    break;
            }
            return Convert.ToInt32(newList.First(), 2);
        }
    }       
}
