using Examination_Management_System.AnswerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.QuestionModel
{
    public  abstract class Question
    {
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        #endregion

        #region Constructor
        protected Question(string header, string body, int marks, AnswerList answers, Answer correctAnswer)
        {
            if (header == null) throw new Exception("Header cannot be null");
            else Header = header;

            if(body == null ) throw new Exception("Body cannot be null");
            else Body = body;

            if(Marks < 0) throw new Exception("Marks cannot less than 0");
            else Marks = marks;

            if(answers == null || answers.Count ==0) throw new Exception("Answers cannot be null or empty");
            else Answers = answers;

            if(correctAnswer == null) throw new Exception("correctAnswer cannot be null ");
            else CorrectAnswer = correctAnswer;

        }
        #endregion

        #region Methods
        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);
        #endregion

        #region System.Object override
        public override string ToString()
        {
            string ans = "";
            for(int i = 0; i < Answers.Count; i++)
            {
                ans += $"{Answers[i]}\n";
            }

            return $"{Header} ({Marks} Marks)\n" +
                $"{Body}\n" +
                ans;
        }
        public override bool Equals(object obj)
        {
            if(obj is Question Right)
            {
                return Header == Right.Header && Body == Right.Body && Marks == Right.Marks && Answers == Right.Answers && CorrectAnswer == Right.CorrectAnswer;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks, Answers, CorrectAnswer);
        }
        #endregion
    }
}
