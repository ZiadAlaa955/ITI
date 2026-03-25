using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{

    #region Enums
    public enum Gender
    {
        Male, Female
    }

    [Flags]
    enum Privileges : byte
    {
        //  0001         0010           0100        1000
        Guest = 1, Developer = 2, Secretary = 4, DBA = 8, securityOfficer = 15
    }
    #endregion


    //Structs
    public struct HiringDate
    {
        public int day;
        public int month;
        public int year;

        public HiringDate (int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
    }
    struct Employee
    {
        int ID;
        int securityLevel;
        decimal salary ;
        HiringDate hireDate;
        Gender gender;
        Privileges securityPrivileges;

        public Employee(int ID, int securityLevel, decimal salary, HiringDate hireDate, Gender gender, Privileges securityPrivileges)
        {

            this.ID = ID;
            this.securityLevel = securityLevel;
            this.salary = salary;
            this.hireDate = hireDate;
            this.gender = gender;
            this.securityPrivileges = securityPrivileges;
        }
        
        public override string ToString()
        {
            return $"Employee ID: {this.ID}\n" +
                $"Security Level: {this.securityLevel}\n" +
                $"Salary: {String.Format("{0:c}", this.salary)}\n" +
                $"Hiring Date: {this.hireDate.day}/{this.hireDate.month}/{this.hireDate.year}\n" +
                $"Gender: {this.gender}\n" +
                $"privileges: {this.securityPrivileges}\n";
        }

        #region Getters & Setters
        public void setID(int id)
        {
            this.ID = id;
        }
        public int getID()
        {
            return this.ID;
        }
        public void setSecurityLevel(int level)
        {
            this.securityLevel = level;
        }
        public int getSecurityLevel()
        {
            return this.securityLevel;
        }
        public void setSalary(decimal value)
        {
            this.salary = value;
        }
        public decimal getSalary()
        {
            return this.salary;
        }
        public void setHireDate(HiringDate date)
        {
            this.hireDate = date;
        }
        public HiringDate getHireDate()
        {
            return this.hireDate;
        }
        public void setGender(Gender gen)
        {
            this.gender = gen;
        }
        public Gender getGender()
        {
            return this.gender;
        }
        public void setSecurityPrivileges(Privileges priv)
        {
            this.securityPrivileges = priv;
        }
        public Privileges getSecurityPrivileges()
        {
            return this.securityPrivileges;
        }
        #endregion

    }
}
