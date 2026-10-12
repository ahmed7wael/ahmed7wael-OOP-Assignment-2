namespace Inheritance
{
    public class Item
    {

        public int CatalogNumber { get; }
        public string Title { get; }
        public int LoanPeriod { get; protected set; }
        public decimal LateFeePerDay { get; private set; }
        public decimal feeMulitplier { get; }

        public bool IsWithdrawn { get; private set; } = false;
        public bool IsOnLoan { get; private set; } = false;

        protected Item(int catalogNumber, string title , int loanPeriod, decimal lateFeePerDay , decimal feeMultiplier)
        {
            if (catalogNumber <= 0) throw new ArgumentException("Catalog number must be positive.");
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be null or empty.");
            if (lateFeePerDay <= 0)
                throw new ArgumentException("Late fee per day must be positive.");

            CatalogNumber = catalogNumber;
            Title = title;
            LoanPeriod = loanPeriod;
            LateFeePerDay = lateFeePerDay;
            feeMulitplier = feeMultiplier;
        }
        public void UpdateLateFee(decimal newFee)
        {
            if (newFee < 0)
                throw new ArgumentException("New late fee cannot be negative.");
            LateFeePerDay = newFee;
        }

        public decimal GetDailyLateFee()
        {
            return LateFeePerDay * feeMulitplier;
        }

        public void Withdraw()
        {
            if(IsWithdrawn)
                throw new InvalidOperationException("Item is already withdrawn.");

            IsWithdrawn = true;
        }
        public void Restore()
        {
            if(!IsWithdrawn)
                throw new InvalidOperationException("Item is not currently withdrawn.");

            IsWithdrawn = false;
        }

        public void MarkAsOnLoan()
        {
            if(IsWithdrawn)
                throw new InvalidOperationException("Cannot mark a withdrawn item as on loan.");

            if(IsOnLoan)
                throw new InvalidOperationException("Item is already on loan.");
            IsOnLoan = true;
        }

        public void MarkAsReturned()
        {
            if (!IsOnLoan)
                throw new InvalidOperationException("Item is not currently on loan.");
            IsOnLoan = false;
        }
    }
}
