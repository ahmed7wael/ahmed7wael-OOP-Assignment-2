namespace Inheritance
{
    public class PremiumMember : Member
    {
        public int ReadingPoints { get; private set; }
        public PremiumMember(int id, string fullName, string phoneNumber, int maxLoanItems, decimal feeDiscount) : base(id, fullName, phoneNumber, 10 , feeDiscount)
        {
            ReadingPoints = 0;
        }

        public void ReturnLoan()
        {
            ReadingPoints += 5;
        }
    }
}
