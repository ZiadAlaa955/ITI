using Assignment.Publisher;
using Assignment.Sunscriber;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Emp1 = new() { EmployeeID = 101, VacationStock = 15, BirthDate = new DateTime(2000, 10, 5) };
            SalesPerson SalesEmp = new() { EmployeeID = 103, VacationStock = 10, AchievedTarget = 50, BirthDate = new DateTime(1999, 2, 20) };
            BoardMember boardMember = new() { EmployeeID = 104, VacationStock = 20, BirthDate = new DateTime(2002, 2, 9) };

            Department Dept1 = new() { DeptID = 300, DeptName = "Dept01" };
            Club Club1 = new() { ClubID = 400, ClubName = "Club01" };

            Dept1.AddStaff(Emp1);
            Dept1.AddStaff(SalesEmp);
            Dept1.AddStaff(boardMember);

            Club1.AddMember(Emp1);
            Club1.AddMember(SalesEmp);
            Club1.AddMember(boardMember);
            
            Emp1.VacationStock = -2;
            Console.WriteLine("======================");

            Employee Emp2 = new() { EmployeeID = 102, VacationStock = 10};
            Dept1.AddStaff(Emp2);
            Club1.AddMember(Emp2);
            Emp2.BirthDate = new DateTime(1950, 1, 1);

            Console.WriteLine("======================");
            SalesEmp.CheckTarget(100);

            Console.WriteLine("======================");
            boardMember.Resign();
        }
    }
}
