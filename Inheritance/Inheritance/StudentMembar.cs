namespace Inheritance
{
    public class StudentMember : Member
    {
        public StudentMember(int id, string fullName, string phoneNumber, int maxLoanItems, decimal feeDiscount) : base(id, fullName, phoneNumber, 3 , 0)
        {
        }
    }
}
