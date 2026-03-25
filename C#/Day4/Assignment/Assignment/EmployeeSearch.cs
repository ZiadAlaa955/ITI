using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    /// <summary>
    /// Utility class to search through an array of Employees using multiple Indexers.
    /// </summary>
    internal class EmployeeSearch
    {
        #region Attributes
        int[] NationalIDs;
        Employee[] Employees;
        int size;
        #endregion

        #region Constructor
        public EmployeeSearch(Employee[] _Employees)
        {
            size = _Employees.Length;
            NationalIDs = new int[size];
            Employees = new Employee[size];
            for(int i =0; i < size; i++)
            {
                Employees[i].Name = _Employees[i].Name;
                Employees[i].ID = _Employees[i].ID;
                NationalIDs[i] = _Employees[i].ID;
                Employees[i].SecurityLevel = _Employees[i].SecurityLevel;
                Employees[i].Salary = _Employees[i].Salary;
                Employees[i].HireDate = _Employees[i].HireDate;
                Employees[i].Gender = _Employees[i].Gender;
                Employees[i].SecurityPrivileges = _Employees[i].SecurityPrivileges;
            }
        }
        #endregion

        #region Indexeres
        public Employee this[int NationalID]
        {
            get
            {
                for(int i = 0; i < size; i++)
                {
                    if (NationalIDs[i] == NationalID)
                    {
                        return Employees[i];
                    }
                }
                return new Employee ();
            }
        }
        public Employee[] this[HiringDate hiringDate]
        {
            get
            {
                Employee[] employeesArr = new Employee[size];
                int count = 0;
                for(int i = 0; i < size; i++)
                {
                    if (Employees[i].HireDate.day == hiringDate.day && Employees[i].HireDate.month == hiringDate.month && Employees[i].HireDate.year == hiringDate.year)
                    {
                        employeesArr[count++] = Employees[i]; 
                    }
                }
                return employeesArr;
            }
        }
        public Employee[] this[string name]
        {
            get
            {
                Employee[] employeesArr = new Employee[size];
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (Employees[i].Name == name)
                    {
                        employeesArr[count++] = Employees[i];
                    }
                }
                return employeesArr;
            }
        }
        #endregion
    }
}
