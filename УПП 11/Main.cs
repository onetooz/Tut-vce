using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УПП_11
{
    internal class Main
    {
        public class Programm
        {
            public static void Main()
            {
                TimeFrame time = TimeFrame.Year;
                int n = 1;
                ResearchTeam bag = new ResearchTeam("Литералы", "Лобачи Интернешнл", 12, time);
                DateTime birthday = new DateTime(2001, 07, 11);
                DateTime pubtime = new DateTime(2020, 03, 23);
                Person Vania = new Person("Vania", "Lobach", birthday);
                Paper[] mas = new Paper[n];
                for (int i = 0; i < n; i++)
                {
                    bag.AddPaper();
                }
                Console.WriteLine(bag.ToString());
                Console.WriteLine(bag[time]);
            }
        }
    }
}
