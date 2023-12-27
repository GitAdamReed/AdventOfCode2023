using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2023.Classes
{
    public class Day5 : Day
    {
        private static readonly string _inputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Input\\Day5.txt";
        private static readonly string _outputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Output\\Day5.txt";


        public Day5()
        {
            CreateOutput();
        }


        private static long GetLowestLocNum()
        {
            List<long> seeds = new();
            List<long[]> seedToSoil = new();
            List<long[]> soiltoFert = new();
            List<long[]> fertToWater = new();
            List<long[]> waterToLight = new();
            List<long[]> lightToTemp = new();
            List<long[]> tempToHumidity = new();
            List<long[]> humidityToLoc = new();
            List<long[]>[] maps = new[]
            {
                seedToSoil,
                soiltoFert,
                fertToWater,
                waterToLight,
                lightToTemp,
                tempToHumidity,
                humidityToLoc
            };

            List<string> lines = File.ReadLines(_inputPath).ToList();
            string[] seedLine = lines[0].Split(" ");
            lines.RemoveRange(0, 2);
            
            foreach (string element in seedLine)
            {
                if (long.TryParse(element, out long result))
                {
                    seeds.Add(result);
                }
            }

            int arrNum = 0;
            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    arrNum++;
                    continue;
                }
                if (arrNum >= maps.Length)
                {
                    break;
                }
                
                List<long> longs = new();
                foreach (string element in line.Split(" "))
                {
                    if (long.TryParse(element, out long result))
                    {
                        longs.Add(result);
                    }
                    else
                    {
                        break;
                    }
                }
                if (longs.Count > 0)
                {
                    maps[arrNum].Add(longs.ToArray());
                }
            }

            long lowestLoc = long.MaxValue;
            Dictionary<long, long> locs = new();
            foreach (var seed in seeds)
            {
                long currentNum = seed;
                foreach (var map in maps)
                {
                    foreach (var arr in map)
                    {
                        long dest = arr[0];
                        long source = arr[1];
                        long range = arr[2];
                        
                        if (currentNum >= source && currentNum < source + range)
                        {
                            currentNum = currentNum + (dest - source);
                            break;
                        }
                    }
                }
                locs.Add(seed, currentNum);
                if (currentNum < lowestLoc) lowestLoc = currentNum;
            }

            return lowestLoc;
        }


        protected override void CreateOutput()
        {    
            File.WriteAllText(_outputPath, $"Part 1: {GetLowestLocNum()}");
            //File.AppendAllText(_outputPath, $"\nPart 2: {GetNumOfCards()}");
        }
    }
}
