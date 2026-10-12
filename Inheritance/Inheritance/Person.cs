namespace Inheritance
{
    public class Person
    {

        public int Id { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        protected Person(int id, string fullName, string phoneNumber)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be positive.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.");


            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

    }
}
