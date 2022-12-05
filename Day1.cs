using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class ElfBackpack
    {
        private List<int> ListCalories = new List<int>();
        public int CalorieSum { get { return ListCalories.Sum(); } }

        public void AddCalories(int calories)
        {
            ListCalories.Add(calories);
        }
    }

    class Day1
    {
        private List<ElfBackpack> ElfBackpacks;
        public static Day1 Current = new Day1();

        private Day1()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/1 - Calories.txt");
            ElfBackpacks = new List<ElfBackpack>();
            ElfBackpacks.Add(new ElfBackpack());
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == "")
                    ElfBackpacks.Add(new ElfBackpack());
                else
                    ElfBackpacks.Last().AddCalories(int.Parse(line));
            }
            reader.Close();
        }

        public string Task1()
        {
            return "Day 1.1: Elf with most Calories: " + ElfBackpacks.Max(x => x.CalorieSum);
        }

        public string Task2()
        {
            return "Day 1.2: Top 3 Elfs with most Calories: " + ElfBackpacks.OrderByDescending(x => x.CalorieSum).Take(3).Sum(x => x.CalorieSum);
        }
    }
}
