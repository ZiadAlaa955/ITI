using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Publisher
{
    public enum LayOffCause
    { 
        overAge, LowVacationStock, FailedToAchieveTarget, Resign
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }

        public EmployeeLayOffEventArgs(LayOffCause l) { Cause = l; }
    }
}
