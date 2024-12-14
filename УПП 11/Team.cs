using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УПП_11
{
    public interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }

    public class Team : INameAndCopy
    {
        protected string organizationName;
        protected int registrationNumber;

        public Team(string organizationName, int registrationNumber)
        {
            this.organizationName = organizationName;
            this.registrationNumber = registrationNumber > 0 ? registrationNumber : throw new ArgumentOutOfRangeException(nameof(registrationNumber), "Регистрационный номер должен быть больше нуля.");
        }

        public Team()
        {
            organizationName = "default";
            registrationNumber = 1;
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Регистрационный номер должен быть больше нуля.");
                }
                registrationNumber = value;
            }
        }

        public override string ToString()
        {
            return $"Название организации: {organizationName}, Регистрационный номер: {registrationNumber}";
        }

        public virtual object DeepCopy()
        {
            return new Team(organizationName, registrationNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Team other = (Team)obj;
            return organizationName == other.organizationName && registrationNumber == other.registrationNumber;
        }

        public static bool operator ==(Team lhs, Team rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Team lhs, Team rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(organizationName, registrationNumber);
        }

        public string Name
        {
            get { return organizationName; }
            set { organizationName = value; }
        }
    }
}
