namespace Inheritance
{
    public class Shelver : Staff
    {
        public string Section { get; private set; }
        public Shelver(int id, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary , string section) : base(id, fullName, phoneNumber, hireDate, monthlySalary , 0)
        {
            if(string.IsNullOrWhiteSpace(section))
                throw new ArgumentException("Section cannot be null or empty.");
         
            Section = section;
        }

        public void Reassign(string newSection)
        {
            if(string.IsNullOrWhiteSpace(newSection))
            {
                throw new ArgumentException("New section cannot be null or empty.");
            }

            Section = newSection;
        }

    }
}
