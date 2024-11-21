//using class_ResearchTeam;
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

    public Paper LatestPublication
    {
        get
        {
            if (publications == null || publications.Length == 0)
            {
                return null;
            }
            Paper latest = publications[0];
            foreach (var publication in publications)
            {
                if (publication != null && publication.publicationDate > latest.publicationDate)
                {
                    latest = publication;
                }
            }
            return latest;
        }
    }

    public void AddPaper(params Paper[] publications)
    {
        int Length = publications.Length;
        Array.Resize(ref publications, Length + publications.Length);
        for (int i = 0; i < publications.Length; i++)
        {
            publications[Length + i] = publications[i];
        }
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
}

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
