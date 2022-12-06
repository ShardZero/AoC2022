using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    class Day6
    {
        private string datastream;
        public static Day6 Current = new Day6();

        private Day6()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/6 - Tuning Trouble.txt");
            datastream = reader.ReadToEnd();
            reader.Close();
        }

        public string Task1()
        {
            for(int i = 0; i < datastream.Length-4; i++)
            {
                if (datastream.Substring(i, 4).Distinct().Count() == 4)
                    return "first marker after character " + (i + 4);
            }
            return "Nothing found";
        }

        public string Task2()
        {
            for (int i = 0; i < datastream.Length - 14; i++)
            {
                if (datastream.Substring(i, 14).Distinct().Count() == 14)
                    return "first marker after character " + (i + 14);
            }
            return "Nothing found";
        }
    }
}
