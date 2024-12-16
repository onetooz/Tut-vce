//using class_ResearchTeam;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

public class Programm
{
    static void Main(string[] args)
    {
        // Пункт 1. Проверка класса Team
        Console.WriteLine("\n=== Пункт 1. Проверка класса Team ===");
        Team team1 = new Team("Организация1", 123);
        Team team2 = new Team("Организация1", 123);
        Console.WriteLine("Объекты равны: " + (team1 == team2)); // True
        Console.WriteLine("Ссылки равны: " + ReferenceEquals(team1, team2)); // False
        Console.WriteLine("Хэш-коды: " + team1.GetHashCode() + " и " + team2.GetHashCode());

        try
        {
            team1.RegistrationNumber = -5;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        // Пункт 2. Создание ResearchTeam
        Console.WriteLine("\n=== Пункт 2. Создание ResearchTeam ===");
        ResearchTeam researchTeam = new ResearchTeam("ИИ Исследования", "Tech Corp", 456, TimeFrame.TwoYears);
        researchTeam.AddMembers(new Person("Алиса", "Смит", new DateTime(1985, 5, 10)),
                                 new Person("Боб", "Браун", new DateTime(1990, 8, 20)));

        researchTeam.AddPapers(new Paper("ИИ в 2024 году", new Person("Алиса", "Смит", new DateTime(1985, 5, 10)), DateTime.Now),
                               new Paper("Тренды машинного обучения", new Person("Боб", "Браун", new DateTime(1990, 8, 20)), DateTime.Now.AddYears(-1)));

        Console.WriteLine(researchTeam);
        Console.WriteLine("Объект Team: " + researchTeam.TeamData);

        // Пункт 3. DeepCopy
        Console.WriteLine("\n=== Пункт 3. DeepCopy ===");
        ResearchTeam copiedTeam = (ResearchTeam)researchTeam.DeepCopy();
        researchTeam.OrganizationName = "Изменённая организация";
        Console.WriteLine("Исходный объект:");
        Console.WriteLine(researchTeam);
        Console.WriteLine("Копия объекта:");
        Console.WriteLine(copiedTeam);

        // Пункт 4. Итераторы
        Console.WriteLine("\n=== Пункт 4. Итераторы ===");
        Console.WriteLine("Участники без публикаций:");
        foreach (Person p in researchTeam)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Публикации за последние 2 года:");
        foreach (Paper p in researchTeam.GetRecentPublications(2))
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Участники с более чем одной публикацией:");
        foreach (Person p in researchTeam.GetParticipantsWithMultiplePublications())
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Публикации за последний год:");
        foreach (Paper p in researchTeam.GetPublicationsFromLastYear())
        {
            Console.WriteLine(p);
        }
    }
}

