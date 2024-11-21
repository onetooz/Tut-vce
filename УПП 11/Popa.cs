//using class_ResearchTeam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

public enum TimeFrame { Year, TwoYears, Long };
public class ResearchTeam
{

    private string theme;
    private string orgname;
    private int regnum;
    private TimeFrame time;
    private Paper[] publications;
    private int n;

    public ResearchTeam(string theme, string orgname, int regnum, TimeFrame time)
    {
        this.theme = theme;
        this.orgname = orgname;
        this.regnum = regnum;
        this.time = time;
    }

    public ResearchTeam()
    {
        theme = "Не выбрана";
        orgname = "Отсудствует";
        regnum = 0;
        time = TimeFrame.Year;
    }

    public string Theme
    {
        get { return theme; }
        set { theme = value; }
    }

    public string OrgName
    {
        get { return orgname; }
        set { orgname = value; }
    }

    public int RegNum
    {
        get { return regnum; }
        set { regnum = value; }
    }

    public TimeFrame Time
    {
        get { return time; }
        set { time = value; }
    }

    public Paper[] Publications
    {
        get { return publications; }
        set { publications = value; }
    }

    public bool this[TimeFrame timeFrame]
    {
        get { return time == timeFrame; }
    }

    public void AddPaper()
    {
        if (publications == null)
        {
            publications = new Paper[1];
        }
        if (n >= publications.Length)
        {
            Array.Resize(ref publications, publications.Length + 1);
        }
        publications[n] = new Paper();
        Console.Write("Введите название публикации :");
        publications[n].title = Console.ReadLine();
        Console.Write("Введите имя автора публикации :");
        string name = Console.ReadLine();
        Console.Write("Введите фамилию автора публикации:");
        string surname = Console.ReadLine();
        Console.Write("Введите день рождения автора публикации:");
        int day = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите месяц рождения автора публикации:");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите год рождения автора публикации:");
        int year = Convert.ToInt32(Console.ReadLine());
        DateTime birthDate = new DateTime(year, month, day);
        publications[n].author = new Person(name, surname, birthDate);
        Console.Write("Введите день публикации:");
        int pubday = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите месяц публикации:");
        int pubmonth = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите год публикации:");
        int pubyear = Convert.ToInt32(Console.ReadLine());
        publications[n].publicationDate = new DateTime(pubyear, pubmonth, pubday);
        n++;
    }

    public override string ToString()
    {
        string result = $"Тема исследований: {theme}" + $"\n" +
        $"Название исследовательской организации: {orgname}\n" +
        $"Регистрационный номер исследований: {regnum}\n" +
        $"Время, отведённое на исследования: {time}\n" +
        $"Количество публикаций: {publications?.Length}\n";
        if (publications != null && publications.Length > 0)
        {
            result += "Публикации:\n";
            for (int i = 0; i < publications.Length; i++)
            {
                if (publications[i] != null)
                {
                    result += $" Публикация {i + 1}:" +
                    $"\n" + $" Название: {publications[i].title}" +
                    $"\n" + $" Автор: {publications[i].author.Name} {publications[i].author.Surname}" +
                    $"\n" + $" Дата рождения автора: {publications[i].author.BirthDate.ToShortDateString()}" +
                    $"\n" + $" Дата публикации: {publications[i].publicationDate.ToShortDateString()}" + $"\n";
                }
            }
        }
        else
        {
            result += "Публикаций нет.\n";
        }
        return result;
    }

    public virtual string ToShortString()
    {
        return "Тема исследований : " + theme + "\nНазвание исследовательской огранизации : " + orgname + "\nРегистрационный номер исследований : " + regnum + "\nВремя отведённое на исследования : " + time;
    }

    //public void AddPaper(params Paper[] papers)
    //{
    //    throw new NotImplementedException();
    //}
}
