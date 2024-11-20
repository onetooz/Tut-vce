//using class_ResearchTeam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

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