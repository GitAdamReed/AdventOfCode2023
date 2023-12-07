﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Classes
{
    public static class Day1
    {
        private static readonly string _inputPath = "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Input\\Day1.txt";
        private static readonly string _outputPath = "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Output\\Day1.txt";


        private static int CalcuateCalSum()
        {
            int sum = 0;
            foreach (string line in File.ReadLines(_inputPath))
            {
                List<string> nums = new();
                foreach (char c in line)
                {
                    if (Char.IsDigit(c))
                    {
                        nums.Add(c.ToString());
                    }
                }
                sum += Int32.Parse(nums[0] + nums[^1]);
            }
            return sum;
        }


        private static int CalcualteCalSumAdjusted()
        {
            int sum = 0;
            foreach (string line in File.ReadLines(_inputPath))
            {
                string[] words = new string[] { "one", "two", "three", "four", "five",
                                                "six", "seven", "eight", "nine" };
                string newLine = string.Empty;
                List<string> nums = new();
                foreach (char c in line)
                {
                    if (Char.IsDigit(c))
                    {
                        nums.Add(c.ToString());
                    }
                    else
                    {
                        newLine += c;
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (newLine.Contains(words[i]))
                            {
                                nums.Add((i + 1).ToString());
                                newLine = newLine.Remove(0, newLine.Length - 1);
                            }
                        }
                    }                    
                }
                sum += Int32.Parse(nums[0] + nums[^1]);
            }
            return sum;
        }


        public static void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {CalcuateCalSum()}");
            File.AppendAllText(_outputPath, $"\nPart 2: {CalcualteCalSumAdjusted()}");
        }
    }
}
