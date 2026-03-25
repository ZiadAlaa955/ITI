using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArr = new Employee[3];
            Privileges[] privs = new Privileges[3];
            privs[0] = Privileges.Guest;
            privs[1] = Privileges.DBA;
            privs[2] = Privileges.securityOfficer;
            
            checked {
                for (int i = 0; i < 3; i++) {
                    Console.WriteLine("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter security level: ");
                    int secLevel = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Salary: ");
                    decimal sal = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Hiring Date: ");
                    Console.WriteLine("Day: ");
                    int day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Month: ");
                    int mon = int.Parse(Console.ReadLine());
                    Console.WriteLine("Year: ");
                    int year = int.Parse(Console.ReadLine());
                    HiringDate hire = new HiringDate(day, mon, year);

                    Console.WriteLine("Enter Gender (Male/Female): ");
                    string genderInput = Console.ReadLine();
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), genderInput, true);

                    Employee userEmployee = new Employee(id, secLevel, sal, hire, gender, privs[i]);
                    empArr[i] = userEmployee;

                    Console.WriteLine("-----------------------------------------------------------");
                }
            }

            //Sorting
            

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(empArr[i].ToString());
            }
        }
    }
}
