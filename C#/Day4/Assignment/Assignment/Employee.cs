using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    /// <summary>
    /// Represents the gender of the employee.
    /// </summary>
    #region Enums
    public enum GenderEnum
    {
        Male, Female
    }

    /// <summary>
    /// Represents the security privileges assigned to an employee. Uses Flags for multiple assignments.
    /// </summary>
    [Flags]
    enum Privileges : byte
    {
        //  0001         0010           0100        1000
        Guest = 1, Developer = 2, Secretary = 4, DBA = 8, securityOfficer = 15
    }
    #endregion


    /// <summary>
    /// Represents the hiring date of an employee.
    /// </summary>
    //Structs
    public struct HiringDate
    {
        //Attributes
        public int day;
        public int month;
        public int year;

        //Constructor
        public HiringDate(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
    }
    struct Employee : IComparable
    {
        #region Attributes
        string name;
        int Id;
        int securityLevel;
        decimal salary;
        HiringDate hireDate;
        GenderEnum gender;
        Privileges securityPrivileges;

        public static int BoxingCount = 0;
        public static int UnboxingCount = 0;
        #endregion

        #region Constructor
        public Employee()
        {
            name = string.Empty;
            Id = default;
            securityLevel =default;
            salary = default;
            hireDate = default;
            gender = default;
            securityPrivileges = default;
        }
        public Employee(string _name, int ID, int _securityLevel, decimal _salary, HiringDate _hireDate, GenderEnum _gender, Privileges _securityPrivileges)
        {
            name = _name;
            Id = ID;
            securityLevel = _securityLevel;
            salary = _salary;
            hireDate = _hireDate;
            gender = _gender;
            securityPrivileges = _securityPrivileges;
        }
        #endregion

        #region CompareTo
        public int CompareTo(object obj)
        {
            BoxingCount++;

            if (obj is Employee)
            {
                Employee other = (Employee)obj;
                UnboxingCount++;

                if (this.hireDate.year != other.hireDate.year)
                    return this.hireDate.year.CompareTo(other.hireDate.year);

                if (this.hireDate.month != other.hireDate.month)
                    return this.hireDate.month.CompareTo(other.hireDate.month);

                return this.hireDate.day.CompareTo(other.hireDate.day);
            }
            return 0;
        }
        #endregion

        #region ToString override
        public override string ToString()
        {
            return $"Employee Name: {this.name}\n" + 
                $"ID: {this.Id}\n" +
                $"Security Level: {this.securityLevel}\n" +
                $"Salary: {String.Format("{0:c}", this.salary)}\n" +
                $"Hiring Date: {this.hireDate.day}/{this.hireDate.month}/{this.hireDate.year}\n" +
                $"Gender: {this.gender}\n" +
                $"privileges: {this.securityPrivileges}\n";
        }
        #endregion

        #region Getters & Setters
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        } 
        public int SecurityLevel
        {
            get
            {
                return securityLevel;
            }
            set
            {
                securityLevel = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        
        public HiringDate HireDate
        {
            get
            {
                return hireDate;
            }
            set
            {
                hireDate = value;
            }
        }
        
        public GenderEnum Gender{
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        } 
       
        public Privileges SecurityPrivileges
        {
            get
            {
                return securityPrivileges;
            }
            set
            {
                securityPrivileges = value;
            }
        }
        #endregion
    }
}
