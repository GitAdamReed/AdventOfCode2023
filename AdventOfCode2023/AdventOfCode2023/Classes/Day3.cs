using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        

        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {GetPartNumberSum()}");
        }
    }
}
