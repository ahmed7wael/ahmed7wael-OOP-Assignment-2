namespace Inheritance
{
    public enum LoanStatus
    {
        Borrowed,
        Returned,
        Lost
    }
    public class Loan
    {

        public int LoanId { get; }
        public DateTime BorrowDate { get; }
        public DateTime DueDateTime { get; }
        public DateTime? ReturnDate { get; private set; }

        public Item ItemName { get; }
        public Member MemberName { get; }

        public LoanStatus Status { get; private set; }
        public Loan(int loanId, Item itemName, Member memberName, DateTime borrowDate)
        {
            if (itemName.IsWithdrawn)
                throw new InvalidOperationException("Cannot create a loan for a withdrawn item.");
            if (itemName.IsOnLoan)
                throw new InvalidOperationException("Item is already on loan.");

            LoanId = loanId;
            ItemName = itemName;
            BorrowDate = borrowDate;
            MemberName = memberName;

            DueDateTime = BorrowDate.AddDays(ItemName.LoanPeriod);

            Status = LoanStatus.Borrowed;

            ItemName.MarkAsOnLoan();
        }
        public void ReturnItem(DateTime returnDate)
        {
            if (Status != LoanStatus.Borrowed)
            {
                throw new InvalidOperationException("Item cannot be returned as it is not currently borrowed.");
            }
             ReturnDate = returnDate;
            Status = LoanStatus.Returned;

            ItemName.MarkAsReturned();
        }

        public void MarkAsLost()
        {
            if (Status == LoanStatus.Returned)
                throw new InvalidOperationException("Cannot mark a returned loan as lost.");

            if (Status == LoanStatus.Lost)
                throw new InvalidOperationException("Loan is already marked as lost.");

            Status = LoanStatus.Lost;
        }
        public decimal CalculateLateFee()
        {
            if (ReturnDate == null || ReturnDate.Value.Date <= DueDateTime.Date)
            {
                return 0m;
            }

            int daysLate = (int)(ReturnDate.Value.Date - DueDateTime.Date).TotalDays;
            decimal totalFee = daysLate * ItemName.GetDailyLateFee();
            decimal finalFee = totalFee - MemberName.FeeDiscount;

            return finalFee > 0 ? finalFee : 0m;
        }
    }

}

