namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Testing Staff Polymorphism (Monthly Pay) ===");
            List<Staff> staffList = new List<Staff>
            {
                new Librarian(1, "Ahmed Ali", "01012345678", DateTime.Now.AddYears(-2), 6000m),
                new HeadLibrarian(2, "Mohamed Hassan", "01112345678", DateTime.Now.AddYears(-5), 9000m),
                new Shelver(3, "Ibrahim Khaled", "01212345678", DateTime.Now.AddYears(-1), 4500m, "Section A")
            };

            foreach (var staff in staffList)
            {
                Console.WriteLine($"Staff: {staff.FullName} [{staff.GetType().Name}] - Total Pay: {staff.GetMonthlySalary()}");
            }

            Console.WriteLine("\n=== 2. Testing Items Polymorphism (Loan Period & Daily Late Fee) ===");
            List<Item> items = new List<Item>
            {
                new Book(101, "Clean Code", 2m),
                new DVD(102, "Inception Movie", 3m),
                new Magazine(103, "Tech Monthly", 1m)
            };

            foreach (var item in items)
            {
                Console.WriteLine($"Item: {item.Title} [{item.GetType().Name}] | Loan Period: {item.LoanPeriod} days | Daily Late Fee: {item.GetDailyLateFee()}");
            }

            Console.WriteLine("\n=== 3. Testing Failure Rules & Exceptions ===");

            StudentMember student = new StudentMember(4, "Omar Student", "01098765432", 3, 0);
            Book book1 = new Book(201, "C# in Depth", 2m);
            Book book2 = new Book(202, "Design Patterns", 2m);
            Book book3 = new Book(203, "Entity Framework", 2m);
            Book book4 = new Book(204, "ASP.NET Core", 2m);

            Loan loan1 = new Loan(1, book1, student, DateTime.Now);
            Loan loan2 = new Loan(2, book2, student, DateTime.Now);
            Loan loan3 = new Loan(3, book3, student, DateTime.Now);

            try
            {
                Loan loan4 = new Loan(4, book4, student, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Caught Expected Error - Max Loans]: {ex.Message}");
            }

            Book withdrawnBook = new Book(205, "Old Book", 2m);
            withdrawnBook.Withdraw();
            try
            {
                Loan withdrawnLoan = new Loan(5, withdrawnBook, student, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Caught Expected Error - Withdrawn]: {ex.Message}");
            }

            Book activeBook = new Book(206, "Active Book", 2m);
            Loan activeLoanRef = new Loan(6, activeBook, student, DateTime.Now);
            try
            {
                StudentMember anotherStudent = new StudentMember(5, "Ziad Ali", "01512345678", 3, 0);
                Loan duplicateLoan = new Loan(7, activeBook, anotherStudent, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Caught Expected Error - Already on Loan]: {ex.Message}");
            }

            Console.WriteLine("\n=== 4. Testing Premium Member Late Return & Reading Points ===");
            PremiumMember premiumMember = new PremiumMember(6, "Sara Ahmed", "01234567890", 10, 5.0m);
            DVD dvdItem = new DVD(301, "Interstellar DVD", 4m);

            DateTime pastBorrowDate = DateTime.Now.AddDays(-15);
            Loan dvdLoan = new Loan(8, dvdItem, premiumMember, pastBorrowDate);

            DateTime specificReturnDate = dvdLoan.DueDateTime.AddDays(5);
            dvdLoan.ReturnItem(specificReturnDate);
            premiumMember.ReturnLoan();

            Console.WriteLine($"Due Date: {dvdLoan.DueDateTime.ToShortDateString()}");
            Console.WriteLine($"Return Date: {dvdLoan.ReturnDate?.ToShortDateString()}");
            Console.WriteLine($"Calculated Late Fee: {dvdLoan.CalculateLateFee()}");
            Console.WriteLine($"Reading Points: {premiumMember.ReadingPoints}");

            Console.WriteLine("\n=== 5. Testing Invalid Status Transitions ===");

            try
            {
                dvdLoan.ReturnItem(DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Caught Expected Error - Double Return]: {ex.Message}");
            }

            try
            {
                dvdLoan.MarkAsLost();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Caught Expected Error - Mark Returned as Lost]: {ex.Message}");
            }
        }
    }
}
