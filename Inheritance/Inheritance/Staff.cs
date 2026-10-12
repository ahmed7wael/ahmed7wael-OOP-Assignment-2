namespace Inheritance
{
    public class Staff : Person
    {
        public DateTime HireDate { get; }
        public Decimal MonthlySalary { get; private set; }

        public int Allowance { get; }

        protected Staff(int id, string fullName, string phoneNumber , DateTime hireDate, Decimal monthlySalary , int allowance) : base(id, fullName, phoneNumber)
        {
            if(monthlySalary < 0)
                throw new ArgumentException("Monthly salary cannot be negative.");

            HireDate = hireDate;
            MonthlySalary = monthlySalary;
            Allowance = allowance;
        }

        public void UpdateSalary(Decimal percentage)
        {
            if(percentage <= 0 )
                throw new ArgumentException("Percentage must be positive.");
            MonthlySalary *= (1 + (percentage / 100));
        }

        public decimal GetMonthlySalary()
        {
            return MonthlySalary + Allowance;
        }
    }
}
