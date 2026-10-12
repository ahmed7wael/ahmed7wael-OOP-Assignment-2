namespace Inheritance
{
    public class Magazine : Item
    {
        public Magazine(int catalogNumber, string title, decimal lateFeePerDay) : base(catalogNumber, title, 3, lateFeePerDay , 0.5m)
        {
        }
    }
}
