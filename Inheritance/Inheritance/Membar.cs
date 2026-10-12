namespace Inheritance
{
    public class Member : Person
    {
        private readonly List<Loan> _loans;
        public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

        public int MaxLoanItems { get; }
        public decimal FeeDiscount { get; }
        protected Member(int id, string fullName, string phoneNumber , int maxLoanItems, decimal feeDiscount) : base(id, fullName, phoneNumber)
        {
            MaxLoanItems = maxLoanItems;
            FeeDiscount = feeDiscount;
            _loans = new List<Loan>();
        }

        public void BorrowItem(Loan loan)
        {
            _loans.Add(loan);
        }
    }
}
