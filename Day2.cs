using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class Day2
    {
        private List<string> Rounds = new List<string>();
        public static Day2 Current = new Day2();

        private Day2()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/2 - RockPaperScissors.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Length > 0)
                {
                    Rounds.Add(line);
                }
            }
        }

        public string Task1()
        {
            int result = 0;
            foreach (string line in Rounds)
            {
                string[] values = line.Split(' ');
                int val = (values[0][0] - 'A') - (values[1][0] - 'X');
                if (val == 0) //tie
                    result += 3 + (values[1][0] - 'W');
                else if (val == -1 || val == 2) //win
                    result += 6 + (values[1][0] - 'W');
                else  //loose
                    result += (values[1][0] - 'W');
            }
            return "Rock Paper Scissor Score #1: " + result;
        }

        public string Task2()
        {
            int result = 0;
            foreach (string line in Rounds)
            {
                string[] values = line.Split(' ');
                if (values[1] == "X")   //Lose
                    result += 0 + ((values[0][0] - 'A' == 0) ? 3 : values[0][0] - 'A');
                else if (values[1] == "Y")   //Draw
                    result += 3 + values[0][0] - 'A' + 1;
                else //Win
                    result += 6 + ((values[0][0] - 'A' == 2) ? 1 : values[0][0] - 'A' + 2);
            }
            return "Rock Paper Scissor Score #2: " + result;
        }
    }
}
