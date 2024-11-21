//using class_ResearchTeam;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

public class Programm
{
    public static void Main()
    {
        Console.Write("Введите тему исследований: ");
        string theme = Console.ReadLine();

        Console.Write("Введите название организации: ");
        string orgName = Console.ReadLine();

        Console.Write("Введите регистрационный номер исследований: ");
        int regNum = int.Parse(Console.ReadLine());

        Console.WriteLine("Выберите временной интервал (0 - Year, 1 - TwoYears, 2 - Long): ");
        TimeFrame timeFrame = (TimeFrame)int.Parse(Console.ReadLine());

        ResearchTeam researchTeam = new ResearchTeam(theme, orgName, regNum, timeFrame);

        Console.WriteLine("\nПроверка индексатора:");
        foreach (TimeFrame frame in Enum.GetValues(typeof(TimeFrame)))
        {
            Console.WriteLine($"Для {frame}: {researchTeam[frame]}");
        }

        Console.WriteLine("\nПрисваивание новых значений свойствам...");
        Console.Write("Введите тему исследований: ");
        researchTeam.Theme = Console.ReadLine();
        Console.Write("Введите название организации: ");
        researchTeam.OrgName = Console.ReadLine();
        Console.Write("Введите регистрационный номер исследований: ");
        researchTeam.RegNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Выберите временной интервал (0 - Year, 1 - TwoYears, 2 - Long): ");
        researchTeam.Time = (TimeFrame)int.Parse(Console.ReadLine());

        Console.WriteLine("\nПолная информация:");
        Console.WriteLine(researchTeam.ToString());

        Console.WriteLine("\nДобавление публикаций...");
        Console.Write("Сколько публикаций вы хотите добавить? ");
        int numPapers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numPapers; i++)
        {
            Console.WriteLine($"\nДобавление публикации {i + 1}:");
            researchTeam.AddPaper();
        }
      //  researchTeam.AddPaper(new Paper(), new Paper(),new Paper());

        Console.WriteLine("\nДанные после добавления публикаций:");
        Console.WriteLine(researchTeam.ToString());

 
        Paper latestPaper = Find(researchTeam.Publications);
        if (latestPaper != null)
        {
            Console.WriteLine("\nСамая поздняя публикация:");
            Console.WriteLine(latestPaper.ToString());
        }

        Console.WriteLine("\nСравнение времени работы с массивами...");
        Comp();
    }

    static Paper Find(Paper[] publications)
    {
        if (publications == null || publications.Length == 0) return null;

        Paper latest = publications[0];
        foreach (var paper in publications)
        {
            if (paper != null && paper.publicationDate > latest.publicationDate)
                latest = paper;
        }
        return latest;
    }

    static void Comp()
    {
        int size = 100000;
        var one = new Paper[size];
        var two = new Paper[100, 1000];
        var Ar = new Paper[100][];
        for (int i = 0; i < 100; i++)
            Ar[i] = new Paper[1000];


        for (int i = 0; i < size; i++)
            one[i] = new Paper();
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 1000; j++)
            {
                two[i, j] = new Paper();
                Ar[i][j] = new Paper();
            }

        var watch = new Stopwatch();


        watch.Restart();
        for (int i = 0; i < size; i++)
        {
            one[i].title="qwerty";
        }
        watch.Stop();
        Console.WriteLine($"Время работы с одномерным массивом: {watch.ElapsedMilliseconds} ms");

        watch.Restart();
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 1000; j++)
            {
                two[i, j].title="qwerty";
            }
        watch.Stop();
        Console.WriteLine($"Время работы с двумерным массивом: {watch.ElapsedMilliseconds} ms");

        watch.Restart();
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 1000; j++)
            {
                Ar[i][j].title="qwerty";
            }
        watch.Stop();
        Console.WriteLine($"Время работы с зубчатым массивом: {watch.ElapsedMilliseconds} ms");
    }
}
