using Examination_Management_System.AnswerModel;
using Examination_Management_System.ExamModels;
using Examination_Management_System.QuestionModel;
using Examination_Management_System.SubjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.ExamModel
{
    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
    public enum ExamMode
    {
        Starting, Queued, Finished
    }

    public abstract class Exam : IComparable<Exam>, ICloneable
    {
        #region Properties
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions{ get; set; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary{ get; set; }
        public Subject Subject { get; set; }

        private ExamMode _mode;
        public ExamMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                if (_mode == ExamMode.Starting)
                    OnExamStarted(new ExamEventArgs(Subject, this));
            }
        }
        #endregion

        #region Constructor
        protected Exam(int time, int numOfQuestions, Subject subject, ExamMode mode)
        {
            if (time <= 0) throw new Exception("Time must be greater than 0");
            if(numOfQuestions <= 0) throw new Exception("questions' numbers must be greater than 0");
            if(subject == null ) throw new Exception("Subject cannot be null");
            Time = time;
            NumberOfQuestions = numOfQuestions;
            Questions = new Question[NumberOfQuestions];
            QuestionAnswerDictionary = new Dictionary<Question, Answer> ();
            Subject = subject;
            _mode = mode;

            for (int i = 0; i < Subject.Count; i++)
                this.ExamStarted += Subject.EnrolledStudents[i].OnExamStarted;
        }
        #endregion

        #region Methods
        public abstract void ShowExam();
        public virtual void Start() { Console.WriteLine("Exam Start!"); }
        public virtual void Finish() { Console.WriteLine("Exam Finish!"); }
        public void CorrectExam() { 
            
        }
        #endregion

        #region System.Object override
        public override string ToString()
        {
            return $"------{Subject.Name} Exam----\n" +
           $"Time : {Time} \n" +
           $"Number of Questions: {NumberOfQuestions}\n" +
           $"Current Status: {Mode}";
        }
        public override bool Equals(object obj)
        {
            if(obj is Exam Right)
            {
                return Time == Right.Time && NumberOfQuestions == Right.NumberOfQuestions && Questions == Right.Questions && QuestionAnswerDictionary == Right.QuestionAnswerDictionary && Subject == Right.Subject && Mode == Right.Mode;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Questions, QuestionAnswerDictionary, Subject, Mode);
        }
        #endregion

        #region CompareTo() & Clone()
        public int CompareTo(Exam other)
        {
            if(other != null)
            {
                if (Time == other.Time) return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
                else return Time.CompareTo(other.Time);
            }
            else
            {
                return 1;
            }
        }

        public object Clone()
        {
            Exam other = (Exam)MemberwiseClone();

            other.Questions = new Question[NumberOfQuestions];
            for(int i = 0; i < Questions.Length; i++)
            {
                other.Questions[i] = Questions[i];
            }

            other.QuestionAnswerDictionary = new Dictionary<Question, Answer>();
            foreach(var item in QuestionAnswerDictionary)
            {
                other.QuestionAnswerDictionary.Add(item.Key, item.Value);
            }

            return other;
        }
        #endregion

        #region Event
        public event ExamStartedHandler ExamStarted;
        protected virtual void OnExamStarted(ExamEventArgs e)
        {
            ExamStarted?.Invoke(this, e);
        }
        #endregion
    }
}
