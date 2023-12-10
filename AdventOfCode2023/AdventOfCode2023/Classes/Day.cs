using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Classes
{
    public abstract class Day
    {
        protected static string GetInputPath(string textfile)
        {
            return "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Input\\" + textfile;
        }
        protected static string GetOutputPath(string textfile)
        {
            return "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\AdventOfCode2023\\AdventOfCode2023\\AdventOfCode2023\\Output\\" + textfile;
        }
        protected abstract void CreateOutput();
    }
}
