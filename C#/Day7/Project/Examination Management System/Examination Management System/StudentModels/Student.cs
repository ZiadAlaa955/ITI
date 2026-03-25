using Examination_Management_System.ExamModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.StudentModel
{
    public class Student
    {
        #region Properties
        public string Name { get; set; }
        public int ID { get; set; }
        #endregion

        #region Constructor
        public Student(string name, int id) { Name = name; ID = id; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"[{ID}] {Name}";
        }

        //public void OnExamStarted(object sender, ExamEventArgs e) {}
        #endregion

        #region CallbackMethod
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"[Notification]: Student {Name} (ID: {ID}) has been notified that the {e.Subject.Name} exam is starting...");
        }
        #endregion
    }
}
