using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class Day4
    {
        List<Tuple<int[], int[]>> ElfPairs = new List<Tuple<int[], int[]>>();
        public static Day4 Current = new Day4();

        private Day4()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/4 - Camp Cleanup.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] pair = line.Split(',');
                string[] elf1 = pair[0].Split('-');
                string[] elf2 = pair[1].Split('-');
                ElfPairs.Add(new Tuple<int[], int[]>(Enumerable.Range(int.Parse(elf1[0]), int.Parse(elf1[1]) - int.Parse(elf1[0]) + 1).ToArray(), 
                    Enumerable.Range(int.Parse(elf2[0]), int.Parse(elf2[1]) - int.Parse(elf2[0]) + 1).ToArray()));
            }
        }

        public string Task1()
        {
            int counter = 0;
            foreach(Tuple<int[], int[]> line in ElfPairs)
            {
                if (line.Item1.Intersect(line.Item2).Count() == line.Item2.Length || line.Item2.Intersect(line.Item1).Count() == line.Item1.Length)
                    counter++;
            }
            return "There are " + counter + " fully contained jobs";
        }

        public string Task2()
        {
            int counter = 0;
            foreach (Tuple<int[], int[]> line in ElfPairs)
            {
                if (line.Item1.Intersect(line.Item2).Count() != 0)
                    counter++;
            }
            return "There are " + counter + " somewhat contained jobs";
        }
    }
}
