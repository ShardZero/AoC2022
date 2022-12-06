using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class Day5
    {
        Stack<char>[] Stacks;
        List<string> Movements = new List<string>();
        public static Day5 Current = new Day5();

        private Day5()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/5 - Supply Stack.txt");

            List<string> StackStrings = new List<string>(); //temporäre Liste der Stackdaten
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (Stacks == null)
                {
                    if (line.Length != 0)
                    {
                        StackStrings.Add(line);
                    }
                    else
                    {
                        string temp = Regex.Replace(StackStrings[StackStrings.Count - 1], @"\s+", " "); //Mehrere spaces mit einem space ersetzen
                        Stacks = new Stack<char>[temp.Trim().Split(' ').Length];
                        for (int i = 0; i < Stacks.Length; i++)
                            Stacks[i] = new Stack<char>();


                        for (int i = StackStrings.Count-2; i >= 0; i--)
                        {
                            for(int j = 0; j < Stacks.Length; j++)
                            {
                                if (StackStrings[i][1 + 4 * j] != ' ')
                                    Stacks[j].Push(StackStrings[i][1 + 4 * j]);
                            }
                        }
                    }
                }
                else
                {
                    if(line.Length > 0)
                        Movements.Add(line);
                }

            }
        }

        public string Task1()
        {
            Stack<char>[] TempStack = new Stack<char>[Stacks.Length];
            for (int i = 0; i < Stacks.Length; i++)
                TempStack[i] = new Stack<char>(Stacks[i]);

            foreach (string line in Movements)
            {
                string[] movesplit = line.Split(' ');
                for(int i = 0; i < int.Parse(movesplit[1]); i++)
                    TempStack[int.Parse(movesplit[5]) - 1].Push(TempStack[int.Parse(movesplit[3]) - 1].Pop());
            }
            string result = "";
            foreach (Stack<char> tmp in TempStack)
                result += tmp.Peek();
            return "The End of the Stacks spell: " + result;
        }

        public string Task2()
        {
            Stack<char>[] TempStack = new Stack<char>[Stacks.Length];
            for (int i = 0; i < Stacks.Length; i++)
                TempStack[i] = Stacks[i];

            foreach (string line in Movements)
            {
                string[] movesplit = line.Split(' ');
                Stack<char> PufferStack = new Stack<char>();
                for (int i = 0; i < int.Parse(movesplit[1]); i++)
                   PufferStack.Push(TempStack[int.Parse(movesplit[3]) - 1].Pop());
                while(PufferStack.Count() != 0)
                    TempStack[int.Parse(movesplit[5]) - 1].Push(PufferStack.Pop());
            }
            string result = "";
            foreach (Stack<char> tmp in TempStack)
                result += tmp.Peek();
            return "The End of the Stacks spell: " + result;
        }
    }
}
