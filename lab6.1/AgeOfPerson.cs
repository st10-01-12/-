using System;

namespace lab6._1
{
    internal class AgeOfPerson : DateOfBirth
    {
        public AgeOfPerson() : base() 
        { 
        }
        public AgeOfPerson(int day, int month, int year) : 
            base(day, month, year) 
        { 
        }

        public AgeOfPerson(DateOfBirth other) : base(other) 
        { 
        }

        public int CalculateAge()
        {
            int age;

            DateTime birthDate = new DateTime(this.Year, 
                this.Month, this.Day);
            DateTime today = DateTime.Today;

            age = today.Year - birthDate.Year;

            if (today.Month < birthDate.Month || (today.Month 
                == birthDate.Month && today.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(this.Year);
        }

    }
}
