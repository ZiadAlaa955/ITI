using Assignment.Publisher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Sunscriber
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members = new();
        public void AddMember(Employee E)
        {
            if (E != null && Members?.Contains(E) == false && E.VacationStock >= 0)
            {
                Members.Add(E);
                E.EmployeeLayOff += RemoveMember;
            }
        }

        ///CallBackMethod
        public void RemoveMember
        (object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee E && Members != null && Members.Contains(E))
            {
                if (sender is BoardMember BM)
                    return;
                if (e.Cause == LayOffCause.LowVacationStock){
                    Members.Remove(E);
                    E.EmployeeLayOff -= RemoveMember;
                    Console.WriteLine($"Member {E.EmployeeID} has been removed from {ClubName} due to {e.Cause}.");
                }
            }
        }
    }
}
