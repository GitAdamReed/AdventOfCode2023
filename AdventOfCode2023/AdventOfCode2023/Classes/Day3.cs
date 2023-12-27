using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Classes
{
    public class Day3 : Day
    {
        private static readonly string _inputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Input\\Day3.txt";
        private static readonly string _outputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Output\\Day3.txt";


        public Day3()
        {
            CreateOutput();
        }
        

        private static int GetPartNumberSum()
        {
            int sum = 0;
            List<char[]> charArrays = new();
            foreach (string line in File.ReadLines(_inputPath))
            {
                charArrays.Add(line.ToArray());
            }

            int arrNum = 0;
            foreach (var arr in charArrays)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (Char.IsDigit(arr[i]))
                    {
                        string num = String.Empty;
                        int j = i;
                        bool isPartNum = false;

                        // Get full number
                        try
                        {
                            while (Char.IsDigit(arr[j]))
                            {
                                num += arr[j];
                                j++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                        }

                        // Check surrounding nodes for symbols
                        for (int k = arrNum - 1; k <= arrNum + 1; k++)
                        {
                            int l = i - 1;
                            while (l <= j && !isPartNum)
                            {
                                try
                                {
                                    if (!Char.IsDigit(charArrays[k][l]) && charArrays[k][l] != '.')
                                    {
                                        isPartNum = true;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                                l++;
                            }
                        }

                        if (isPartNum) sum += Int32.Parse(num);
                        i = j;
                    }
                }
                arrNum++;
            }

            return sum;
        }


        private static int GetGearRatioSum()
        {
            List<char[]> charArrays = new();
            foreach (string line in File.ReadLines(_inputPath))
            {
                charArrays.Add(line.ToArray());
            }

            List<KeyValuePair<int, RatioCoords>> ratioList = new();
            int arrNum = 0;
            foreach (var arr in charArrays)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (Char.IsDigit(arr[i]))
                    {
                        string num = String.Empty;
                        int j = i;
                        bool isRatio = false;
                        
                        // Get full number
                        try
                        {
                            while (Char.IsDigit(arr[j]))
                            {
                                num += arr[j];
                                j++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                        }

                        // Check surrounding nodes for symbols
                        int k = arrNum - 1;
                        while (k <= arrNum + 1 && !isRatio)
                        {
                            int l = i - 1;
                            while (l <= j && !isRatio)
                            {
                                try
                                {
                                    if (charArrays[k][l] == '*')
                                    {
                                        isRatio = true;
                                        ratioList.Add(KeyValuePair.Create(Int32.Parse(num), new RatioCoords(k, l)));
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                                l++;
                            }
                            k++;
                        }
                        i = j;
                    }
                }
                arrNum++;
            }

            List<int> matchProducts = new();
            foreach (var kvp in ratioList)
            {
                var match = ratioList.FirstOrDefault(x => x.Value.CompareCoords(kvp.Value) && x.Key != kvp.Key);
                if (match.Key != 0 && !matchProducts.Contains(kvp.Key * match.Key))
                {
                    matchProducts.Add(kvp.Key * match.Key);
                }
            }

            return matchProducts.Sum();
        }


        private struct RatioCoords
        {
            public RatioCoords(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool CompareCoords(RatioCoords target)
            {
                return X == target.X && Y == target.Y;
            }

            public int X { get; }
            public int Y { get; }
        }

        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {GetPartNumberSum()}");
            File.AppendAllText(_outputPath, $"\nPart 2: {GetGearRatioSum()}");
        }
    }
}
