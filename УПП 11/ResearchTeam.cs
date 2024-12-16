//using class_ResearchTeam;
using System.Collections;
using System.Net;
using System.Runtime.CompilerServices;
using УПП_11;

public enum TimeFrame { Year, TwoYears, Long };
public class ResearchTeam : Team, INameAndCopy, IEnumerable
{
    private string searchname;
    private TimeFrame time;
    private ArrayList members;
    private ArrayList publications;

    public ResearchTeam(string searchname, string organizationName, int registrationNumber, TimeFrame time) : base(organizationName, registrationNumber)
    {
        this.searchname = searchname;
        this.time = time;
        members = new ArrayList();
        publications = new ArrayList();
    }

    public ResearchTeam() : base()
    {
        searchname = "default";
        time = TimeFrame.Year;
        members = new ArrayList();
        publications = new ArrayList();
    }

    public ArrayList Publications
    {
        get { return publications; }
    }

    public Paper LatestPublication
    {
        get
        {
            if (publications.Count == 0)
                return null;

            Paper latest = (Paper)publications[0];
            foreach (Paper paper in publications)
            {
                if (paper.publicationDate > latest.publicationDate)
                {
                    latest = paper;
                }
            }
            return latest;
        }
    }

    public void AddPapers(params Paper[] newPapers)
    {
        publications.AddRange(newPapers);
    }

    public ArrayList Participants
    {
        get { return members; }
    }

    public void AddMembers(params Person[] newParticipants)
    {
        members.AddRange(newParticipants);
    }

    public Team TeamData
    {
        get => new Team(OrganizationName, RegistrationNumber);
        set
        {
            OrganizationName = value.OrganizationName;
            RegistrationNumber = value.RegistrationNumber;
        }
    }

    public override string ToString()
    {
        string participantInfo = "Участники: " + string.Join(", ", members.Cast<Person>());
        string publicationInfo = "Публикации: " + string.Join(", ", publications.Cast<Paper>());

        return $"Тема: {searchname}, Продолжительность: {time}, {base.ToString()}, {participantInfo}, {publicationInfo}";
    }

    public string ToShortString()
    {
        return $"Тема: {searchname}, Продолжительность: {time}, {base.ToString()}";
    }

    public override object DeepCopy()
    {
        ResearchTeam copy = new ResearchTeam(this.searchname, this.OrganizationName, this.RegistrationNumber, this.time)
        {
            members = (ArrayList)members.Clone(),
            publications = (ArrayList)publications.Clone()
        };
        return copy;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (Person participant in members)
        {
            if (!publications.Cast<Paper>().Any(p => p.author == participant))
            {
                yield return participant;
            }
        }
    }

    public IEnumerable<Paper> GetRecentPublications(int years)
    {
        DateTime threshold = DateTime.Now.AddYears(-years);
        foreach (Paper paper in publications)
        {
            if (paper.publicationDate >= threshold)
            {
                yield return paper;
            }
        }
    }

    public IEnumerable<Person> GetParticipantsWithMultiplePublications()
    {
        foreach (Person participant in members)
        {
            int count = publications.Cast<Paper>().Count(p => p.author == participant);
            if (count > 1)
            {
                yield return participant;
            }
        }
    }

    public IEnumerable<Paper> GetPublicationsFromLastYear()
    {
        return GetRecentPublications(1);
    }

    public IEnumerator<Person> GetEnumeratorWithPublications()
    {
        foreach (Person participant in members)
        {
            if (publications.Cast<Paper>().Any(p => p.author == participant))
            {
                yield return participant;
            }
        }
    }
}