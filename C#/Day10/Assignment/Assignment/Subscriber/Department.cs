using Assignment.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Sunscriber
{
    internal class Department
    {
        #region Properties
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff = new(); 
        #endregion
        public void AddStaff(Employee E)
        {
            if (E != null && Staff?.Contains(E) == false && E.VacationStock >= 0 && E.BirthDate.Year - DateTime.Now.Year < 60)
            {
                Staff.Add(E);
                E.EmployeeLayOff += RemoveStaff;
            }
        }
        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee E && Staff.Contains(E))
            {
                Staff.Remove(E);
                E.EmployeeLayOff -= RemoveStaff;
                Console.WriteLine($"Employee {E.EmployeeID} has been removed from {DeptName} due to {e.Cause}.");
            }
        }
    }
}
