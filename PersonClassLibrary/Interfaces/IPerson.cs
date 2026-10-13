namespace PersonClassLibrary.Interfaces
{
    public interface IPerson
    {
        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }

        public decimal Salary { get; }
    }
}
