namespace Inheritance
{
    public class DVD : Item
    {
        public DVD(int catalogNumber, string title, decimal lateFeePerDay) : base(catalogNumber, title, 7, lateFeePerDay , 2.0m)
        {
        }
    }
}
