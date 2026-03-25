using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Publisher
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public override int VacationStock { get; set; }
        

        public bool CheckTarget(int Quota)
        {
            if(AchievedTarget < Quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.FailedToAchieveTarget));
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
