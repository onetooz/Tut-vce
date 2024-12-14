

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
        return $" Имя {name} Фамилия {surname}";
    }

    // Переопределение метода Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Person other = (Person)obj;
        return name == other.name && surname == other.surname && birthDate == other.birthDate;
    }

    // Переопределение оператора ==
    public static bool operator ==(Person lhs, Person rhs)
    {
        if (ReferenceEquals(lhs, null))
        {
            return ReferenceEquals(rhs, null);
        }
        return lhs.Equals(rhs);
    }

    // Переопределение оператора !=
    public static bool operator !=(Person lhs, Person rhs)
    {
        return !(lhs == rhs);
    }

    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(name, surname, birthDate);
    }

    // Метод для глубокой копии объекта
    public Person DeepCopy()
    {
        return new Person(name, surname, birthDate);
    }
}