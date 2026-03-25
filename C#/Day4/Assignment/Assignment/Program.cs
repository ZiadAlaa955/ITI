namespace Assignment
{
    internal class Program
    {
        /// <summary>
        /// The main method of the application handling user I/O, array population, sorting, and displaying logic.
        /// </summary>
        static void Main(string[] args)
        {
            Employee[] empArr = new Employee[3];
            Privileges[] privs = new Privileges[3];
            privs[0] = Privileges.Guest;
            privs[1] = Privileges.DBA;
            privs[2] = Privileges.securityOfficer;

            checked
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();

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
                    GenderEnum gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), genderInput, true);

                    Employee userEmployee = new Employee(name, id, secLevel, sal, hire, gender, privs[i]);
                    empArr[i] = userEmployee;

                    Console.WriteLine("-----------------------------------------------------------");
                }
            }

            #region Use Indexeres
            EmployeeSearch employeeSearch = new EmployeeSearch(empArr);
            Console.WriteLine("--Employee of ID = 1: ");
            Console.WriteLine(employeeSearch[1]);
            Console.WriteLine("------------------------");

            Console.WriteLine("--Employees of hiring date = 29/5/2020: ");
            HiringDate hireSearch = new HiringDate(29, 5, 2020);
            Employee[] empHire = new Employee[3];
            empHire = employeeSearch[hireSearch];
            for(int i = 0; i < 3; i++)
            {
               if (empHire[i].Name != null)
                {
                    Console.WriteLine(empHire[i]);
                } 
            }
            Console.WriteLine("------------------------");

            Console.WriteLine("--Employees of name = \"Ahmed\": ");
            Employee[] empName = new Employee[3];
            empName = employeeSearch["Ahmed"];
            for (int i = 0; i < 3; i++)
            {
                if (empName[i].Name != null)
                {
                    Console.WriteLine(empName[i]);
                }
            }
            Console.WriteLine("------------------------");
            #endregion

            Console.WriteLine("\n==== SORTING ====\n");
            Employee.BoxingCount = 0;
            Employee.UnboxingCount = 0;

            Array.Sort(empArr);

            Console.WriteLine("--Sorted Employees List: ");
            for (int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine(empArr[i]);
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Total Boxing operations during sort: {Employee.BoxingCount}");
            Console.WriteLine($"Total Unboxing operations during sort: {Employee.UnboxingCount}");
            Console.WriteLine("------------------------");

        }
    }
}
