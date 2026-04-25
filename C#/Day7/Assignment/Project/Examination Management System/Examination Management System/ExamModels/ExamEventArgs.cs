using Examination_Management_System.ExamModel;
using Examination_Management_System.SubjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.ExamModels
{
    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }
}
