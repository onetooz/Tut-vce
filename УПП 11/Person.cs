

public class Person
{
    public string name;
    public string surname;
    public DateTime birthDate;

    public Person(string name, string surname, DateTime birthDate)
    {
        this.name = name;
        this.surname = surname;
        this.birthDate = birthDate;
    }

    public Person()
    {
        name = "default";
        surname = "default";
        birthDate = new DateTime(2000, 01, 1);
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public int BirthYear
    {
        get { return birthDate.Year; }
        set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
    }

    public override string ToString()
    {
        return $"Имя: {name}, Фамилия: {surname}, Дата рождения: {birthDate.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $" Имя {name} Фамиия {surname}";
    }
}

