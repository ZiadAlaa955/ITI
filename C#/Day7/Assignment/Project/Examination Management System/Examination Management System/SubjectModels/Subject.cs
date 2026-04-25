using Examination_Management_System.StudentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.SubjectModel
{
    public class Subject
    {
        #region Properties
        public string Name { get; set; }
        public Student[] EnrolledStudents;
        public int Count { get; private set; }
        #endregion

        #region Constructor
        public Subject(string name)
        {
            Name = name;
            EnrolledStudents = new Student[5];
            Count = 0;
        }
        #endregion

        #region Methods
        public void Enroll(Student student)
        {
            if (Count == EnrolledStudents.Length)
            {
                Array.Resize(ref EnrolledStudents, EnrolledStudents.Length * 2);
            }
            EnrolledStudents[Count] = student;
            Count++;
        }
        #endregion
    }
}
