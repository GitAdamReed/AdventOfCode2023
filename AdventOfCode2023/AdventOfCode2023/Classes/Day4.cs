using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Classes
{
    public class Day4 : Day
    {
        private static readonly string _inputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Input\\Day4.txt";
        private static readonly string _outputPath = "D:\\GitHub\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Output\\Day4.txt";


        public Day4()
        {
            CreateOutput();
        }


        private static int GetTotalPoints()
        {
            int sum = 0;
            foreach (string line in File.ReadLines(_inputPath))
            {
                List<int> winningNums = new();
                List<int> myNums = new();
                List<int> matchingNums = new();
                string[] cardArr = line.Split(" ");
                bool isMyNums = false;
                foreach (string element in cardArr)
                {
                    if (Int32.TryParse(element, out int result))
                    {
                        if (isMyNums) myNums.Add(result);
                        else winningNums.Add(result);
                    }
                    if (element == "|") isMyNums = true;
                }

                List<int> matches = new();
                foreach (int num in myNums)
                {
                    if (winningNums.Contains(num))
                    {
                        matches.Add(num);
                    }
                }

                int totalPoints = 0;
                for (int i = 0; i < matches.Count; i++)
                {
                    if (i > 0) totalPoints *= 2;
                    else totalPoints = 1;
                }
                sum += totalPoints;
            }

            return sum;
        }


        private static int GetNumOfCards()
        {
            int totalCards = 0;
            List<string> lines = File.ReadLines(_inputPath).ToList();
            Dictionary<int, string[]> cardDict = new();
            Dictionary<int, int> cardCopies = new();

            // Initialise card dict
            for (int i = 0; i < lines.Count; i++)
            {
                string[] cardArr = lines[i].Split(" ");
                cardDict.Add(i, cardArr);
            }

            // Initialise card copy dict
            for (int i = 0; i < cardDict.Count; i++)
            {
                cardCopies.Add(i, 1);
            }

            foreach (var kvp in cardDict)
            {
                List<int> winningNums = new();
                List<int> myNums = new();
                List<int> matchingNums = new();
                bool isMyNums = false;
                foreach (string element in kvp.Value)
                {
                    if (Int32.TryParse(element, out int result))
                    {
                        if (isMyNums) myNums.Add(result);
                        else winningNums.Add(result);
                    }
                    if (element == "|") isMyNums = true;
                }

                foreach (int num in myNums)
                {
                    if (winningNums.Contains(num))
                    {
                        matchingNums.Add(num);
                    }
                }

                for (int i = 1; i <= matchingNums.Count; i++)
                {
                    if (i >= cardDict.Count) break;
                    cardCopies[kvp.Key + i] += cardCopies[kvp.Key];
                }
                totalCards += cardCopies[kvp.Key];
            }

            return totalCards;
        }

        
        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {GetTotalPoints()}");
            File.AppendAllText(_outputPath, $"\nPart 2: {GetNumOfCards()}");
        }
    }
}
