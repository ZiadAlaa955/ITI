using Examination_Management_System.AnswerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.QuestionModel
{
    internal class ChooseOneQuestion : Question
    {
        #region Constructor
        public ChooseOneQuestion(string header, string body, int marks, AnswerList answers, Answer correctAnswer)
            : base(header, body, marks, answers, correctAnswer) { }
        #endregion

        #region Methods
        public override bool CheckAnswer(Answer studentAnswer) { return CorrectAnswer.Equals(studentAnswer); }
        public override void Display() {
            Console.WriteLine(this);
        }
        #endregion
    }
}
