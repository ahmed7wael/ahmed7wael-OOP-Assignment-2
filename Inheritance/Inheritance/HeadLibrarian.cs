namespace Inheritance
{
    public class HeadLibrarian : Staff
    {
        public HeadLibrarian(int id, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary)
            : base(id, fullName, phoneNumber, hireDate, monthlySalary, 400)
        {
        }

        public void ChangeLateFee(Item item, decimal newFee)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.UpdateLateFee(newFee);
        }

        public void WithdrawItem(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Withdraw();
        }

        public void RestoreItem(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Restore();
        }
    }
}