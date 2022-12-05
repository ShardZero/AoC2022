using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class Day3
    {
        List<string> Backpacks = new List<string>();
        public static Day3 Current = new Day3();

        private Day3()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/3 - Backpacks.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Length > 0)
                {
                    Backpacks.Add(line);
                }
            }
        }

        public string Task1()
        {
            List<int> backpackValues = new List<int>();
            foreach (string line in Backpacks)
            {
                char priority = line.Substring(0, line.Length / 2).Intersect(line.Substring(line.Length / 2)).ToArray()[0];
                if (priority >= 'a' && priority <= 'z')
                    backpackValues.Add(priority - 'a' + 1);
                else
                    backpackValues.Add(priority - 'A' + 27);
            }
            return "Backpackvalues: " + backpackValues.Sum();
        }

        public string Task2()
        {
            List<int> backpackValues = new List<int>();
            for (int i = 0; i < Backpacks.Count; i+=3)
            {
                char priority = Backpacks[i].Intersect(Backpacks[i + 1]).Intersect(Backpacks[i + 2]).ToArray()[0];
                if (priority >= 'a' && priority <= 'z')
                    backpackValues.Add(priority - 'a' + 1);
                else
                    backpackValues.Add(priority - 'A' + 27);
            }
            return "Backpackvalues: " + backpackValues.Sum();
        }
    }
}
