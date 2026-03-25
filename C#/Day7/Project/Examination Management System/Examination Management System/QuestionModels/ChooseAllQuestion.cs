using Examination_Management_System.AnswerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.QuestionModel
{
    internal class ChooseAllQuestion : Question
    {
        #region Constructor
        public ChooseAllQuestion(string header, string body, int marks, AnswerList answers, Answer correctAnswer)
            : base(header, body, marks, answers, correctAnswer) { }
        #endregion

        #region Methods
        public override bool CheckAnswer(Answer studentAnswer)
        {
            string[] correctList = CorrectAnswer.Text.Split(',');
            string[] studentList = studentAnswer.Text.Split(',');


            if(correctList.Length == studentList.Length)
            {
                Array.Sort(correctList);
                Array.Sort(studentList);

                for (int i = 0; i < correctList.Length; i++)
                {
                    if (correctList[i] != studentList[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Display() { Console.WriteLine(this); }
        #endregion
    }
}
