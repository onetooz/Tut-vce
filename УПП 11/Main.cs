//using class_ResearchTeam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

public class Programm
{
    public static void Main()
    {
        // 1. Создать объект ResearchTeam с вводом данных
        Console.WriteLine("Создание объекта ResearchTeam:");
        Console.Write("Введите тему исследований: ");
        string theme = Console.ReadLine();

        Console.Write("Введите название исследовательской организации: ");
        string orgName = Console.ReadLine();

        Console.Write("Введите регистрационный номер исследований: ");
        int regNum = int.Parse(Console.ReadLine());

        Console.Write("Введите время, отведенное на исследования (0 - Year, 1 - TwoYears, 2 - Long): ");
        TimeFrame time = (TimeFrame)int.Parse(Console.ReadLine());

        ResearchTeam researchTeam = new ResearchTeam(theme, orgName, regNum, time);

        Console.WriteLine("\nКраткая информация об объекте ResearchTeam:");
        Console.WriteLine(researchTeam.ToShortString());

        // 10. Вывод значений индексатора
        Console.WriteLine("\nПроверка значений индексатора:");
        Console.WriteLine($"TimeFrame.Year: {researchTeam[TimeFrame.Year]}");
        Console.WriteLine($"TimeFrame.TwoYears: {researchTeam[TimeFrame.TwoYears]}");
        Console.WriteLine($"TimeFrame.Long: {researchTeam[TimeFrame.Long]}");

        // 11. Присвоить значения свойствам
        Console.WriteLine("\nОбновление свойств ResearchTeam:");
        Console.Write("Введите новую тему исследований: ");
        researchTeam.Theme = Console.ReadLine();

        Console.Write("Введите новое название исследовательской организации: ");
        researchTeam.OrgName = Console.ReadLine();

        Console.Write("Введите новый регистрационный номер исследований: ");
        researchTeam.RegNum = int.Parse(Console.ReadLine());

        Console.Write("Введите новое время, отведенное на исследования (0 - Year, 1 - TwoYears, 2 - Long): ");
        researchTeam.Time = (TimeFrame)int.Parse(Console.ReadLine());

        Console.WriteLine("\nПолная информация об объекте ResearchTeam:");
        Console.WriteLine(researchTeam.ToString());

        // 12. Добавление публикаций
        Console.WriteLine("\nДобавление публикаций в ResearchTeam:");
        Console.Write("Сколько публикаций вы хотите добавить? ");
        int paperCount = int.Parse(Console.ReadLine());

        Paper[] papers = new Paper[paperCount];
        for (int i = 0; i < paperCount; i++)
        {
            Console.WriteLine($"\nДобавление публикации {i + 1}:");

            Console.Write("Введите название публикации: ");
            string title = Console.ReadLine();

            Console.Write("Введите имя автора публикации: ");
            string authorName = Console.ReadLine();

            Console.Write("Введите фамилию автора публикации: ");
            string authorSurname = Console.ReadLine();

            Console.Write("Введите дату рождения автора (дд.мм.гггг): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите дату публикации (дд.мм.гггг): ");
            DateTime publicationDate = DateTime.Parse(Console.ReadLine());

            papers[i] = new Paper
            {
                title = title,
                author = new Person(authorName, authorSurname, birthDate),
                publicationDate = publicationDate
            };
        }

        researchTeam.Publications = papers;

        Console.WriteLine("\nИнформация после добавления публикаций:");
        Console.WriteLine(researchTeam.ToString());

        // 13. Публикация с самой поздней датой
        Paper latestPaper = GetLatestPaper(researchTeam.Publications);
        Console.WriteLine("\nСамая поздняя публикация:");
        if (latestPaper != null)
        {
            Console.WriteLine($"Название: {latestPaper.title}");
            Console.WriteLine($"Автор: {latestPaper.author.Name} {latestPaper.author.Surname}");
            Console.WriteLine($"Дата публикации: {latestPaper.publicationDate.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine("Нет доступных публикаций.");
        }

        // 14. Сравнение времени работы с массивами
        CompareArrayPerformance();
    }

    // Метод для получения самой поздней публикации
    static Paper GetLatestPaper(Paper[] publications)
    {
        if (publications == null || publications.Length == 0) return null;

        Paper latest = publications[0];
        foreach (var paper in publications)
        {
            if (paper.publicationDate > latest.publicationDate)
                latest = paper;
        }
        return latest;
    }

    // Метод для сравнения времени работы с массивами
    static void CompareArrayPerformance()
    {
        int size = 1000;
        Paper[] oneDimensionalArray = new Paper[size];
        Paper[,] twoDimensionalArray = new Paper[size, 1];
        Paper[][] jaggedArray = new Paper[size][];

        for (int i = 0; i < size; i++)
        {
            oneDimensionalArray[i] = new Paper();
            twoDimensionalArray[i, 0] = new Paper();
            jaggedArray[i] = new Paper[1];
            jaggedArray[i][0] = new Paper();
        }

        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Операции с одномерным массивом
        watch.Restart();
        for (int i = 0; i < size; i++) { var _ = oneDimensionalArray[i]; }
        watch.Stop();
        Console.WriteLine($"\nВремя работы с одномерным массивом: {watch.ElapsedMilliseconds} ms");

        // Операции с двумерным прямоугольным массивом
        watch.Restart();
        for (int i = 0; i < size; i++) { var _ = twoDimensionalArray[i, 0]; }
        watch.Stop();
        Console.WriteLine($"Время работы с двумерным массивом: {watch.ElapsedMilliseconds} ms");

        // Операции с двумерным ступенчатым массивом
        watch.Restart();
        for (int i = 0; i < size; i++) { var _ = jaggedArray[i][0]; }
        watch.Stop();
        Console.WriteLine($"Время работы с двумерным ступенчатым массивом: {watch.ElapsedMilliseconds} ms");
    }
}
