using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Classes
{
    public class Day2 : Day
    {
        private static readonly string _inputPath = GetInputPath("Day2.txt");
        private static readonly string _outputPath = GetOutputPath("Day2.txt");

        
        public Day2()
        {
            CreateOutput();
        }
        

        private static int GetPossibleGameIDSum(int red, int green, int blue)
        {
            int idSum = 0;
            int id = 1;
            foreach (string line in File.ReadLines(_inputPath))
            {
                Dictionary<string, int> rgbSum = new()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };
                
                var game = line.Split(" ").ToList();
                game.RemoveRange(0, 2);
                bool validGame = true;
                int currNum = 0;
                foreach (string word in game)
                {
                    if (Int32.TryParse(word, out int parseNum)) currNum = parseNum;
                    else
                    {
                        string colour = word;
                        if (!Char.IsLetter(word[^1]))
                        {
                            colour = word.Remove(word.Length - 1);
                        }
                        rgbSum[colour] += currNum;

                        if (word[^1] == ';' || game[^1] == word)
                        {
                            if (rgbSum["red"] > red || rgbSum["green"] > green || rgbSum["blue"] > blue)
                            {
                                validGame = false;
                                break;
                            }
                            else
                            {
                                foreach (var kvp in rgbSum)
                                {
                                    rgbSum[kvp.Key] = 0;
                                }
                            }
                        }
                    }
                }
                
                if (validGame) idSum += id;
                id++;
            }

            return idSum;
        }


        // TODO: Make this method ambiguous with ALL Day# classes
        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {GetPossibleGameIDSum(12, 13, 14)}");
            //File.AppendAllText(_outputPath, $"\nPart 2: {CalcualteCalSumAdjusted()}");
        }
    }
}
