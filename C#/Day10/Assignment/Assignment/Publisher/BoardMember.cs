using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Publisher
{
    internal class BoardMember : Employee
    {
        public override DateTime BirthDate { get; set; }
        public override int VacationStock { get; set; }

        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.Resign));
        }
    }
}
