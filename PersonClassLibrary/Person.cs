using PersonClassLibrary.Interfaces;

namespace PersonClassLibrary
{
    public class Person(string firstName, string lastName, int age, decimal salary) : IPerson
    {
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value < 460.00m)
                {
                    throw new ArgumentException("Salary cannot be less than 460.00 dollars!");
                }

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage) => Salary += (Age < 30) ? Salary * (percentage / 2) : Salary * percentage;

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old and receives {Salary} dollars.";
        }
    }
}
