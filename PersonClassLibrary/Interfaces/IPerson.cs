namespace PersonClassLibrary.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        int Age { get; }

        decimal Salary { get; }

        void IncreaseSalary(decimal percentage);
    }
}
