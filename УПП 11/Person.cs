enum TimeFrame { Year, TwoYears, Long }

class Person
{
    private string name;
    private string surname;
    private DateTime birthDate;

    public Person(string name, string surname, DateTime birthDate)
    {
        this.name = name;
        this.surname = surname;
        this.birthDate = birthDate;
    }

    public Person()
    {
        name = "defaul";
        surname = "default";
        birthDate = new DateTime(1, 01, 2000);
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
        return $"{name} {surname}";
    }
}

