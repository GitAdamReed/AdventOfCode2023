using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
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
                foreach (string s in game)
                {
                    if (Int32.TryParse(s, out int parseNum)) currNum = parseNum;
                    else
                    {
                        string colour = s;
                        if (!Char.IsLetter(s[^1])) colour = s.Remove(s.Length - 1);

                        rgbSum[colour] += currNum;

                        if (s[^1] == ';' || game[^1] == s)
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


        private static int GetLowestColourPower()
        {
            int powerSum = 0;
            foreach (string line in File.ReadLines(_inputPath))
            {
                Dictionary<string, int> rgbMin = new()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };
                Dictionary<string, int> currRGBMin = new()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                var game = line.Split(" ").ToList();
                game.RemoveRange(0, 2);
                int currNum = 0;
                foreach (string s in game)
                {
                    if (Int32.TryParse(s, out int parseNum)) currNum = parseNum;
                    else
                    {
                        string colour = s;
                        if (!Char.IsLetter(s[^1])) colour = s.Remove(s.Length - 1);

                        currRGBMin[colour] += currNum;

                        if (s[^1] == ';' || game[^1] == s)
                        {
                            foreach (var kvp in currRGBMin)
                            {
                                if (kvp.Value > rgbMin[kvp.Key])
                                {
                                    rgbMin[kvp.Key] = kvp.Value;
                                }
                                currRGBMin[kvp.Key] = 0;
                            }
                        }
                    }
                }

                int power = 1;
                foreach (var kvp in rgbMin) power *= kvp.Value;
                powerSum += power;
            }

            return powerSum;
        }


        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {GetPossibleGameIDSum(12, 13, 14)}");
            File.AppendAllText(_outputPath, $"\nPart 2: {GetLowestColourPower()}");
        }
    }
}
