using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Publisher
{
    internal class Employee
    {
        #region Properties
        public int EmployeeID { get; set; }

        protected DateTime birthDate;
        public virtual DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (DateTime.Now.Year - value.Year >= 60)
                {
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.overAge));
                }
                else
                {
                    birthDate = value;
                }
            }
        }

        protected int vactionStock;
        public virtual int VacationStock
        {
            get => vactionStock;
            set
            {
                if(value < 0)
                {
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.LowVacationStock));
                }
                else
                {
                    vactionStock = value;
                }
            }
        }
        #endregion

        #region Methods
        public bool RequestVacation(DateTime From, DateTime To)
        {
            int Days = To.Day - From.Day;
            if (Days <= VacationStock)
            {
                VacationStock -= Days;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EndOfYearOperation()
        {
            if(DateTime.Now.Year - BirthDate.Year >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.overAge));
                VacationStock = 20;
            }
        }
        #endregion
        
        #region Event
        public event
        EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
        #endregion
    }
}
