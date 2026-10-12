namespace Inheritance
{
    public class Librarian : Staff
    {
        public Librarian(int id, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary)
            : base(id, fullName, phoneNumber, hireDate, monthlySalary, 0)
        {
        }

        public void ReturnItem(Loan loan, DateTime returnDate)
        {
            if (loan == null) throw new ArgumentNullException(nameof(loan));
            loan.ReturnItem(returnDate);
        }

        public void MarkItemAsLost(Loan loan)
        {
            if (loan == null) throw new ArgumentNullException(nameof(loan));
            loan.MarkAsLost();
        }
    }
}