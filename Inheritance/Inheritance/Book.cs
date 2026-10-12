namespace Inheritance
{
    public class Book : Item
    {
        public Book(int catalogNumber, string title , decimal lateFeePerDay) : base(catalogNumber, title, 21, lateFeePerDay , 1.0m)
        {

        }
    }
}
