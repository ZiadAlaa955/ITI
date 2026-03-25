using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.QuestionModel
{
    internal class QuestionList 
    {
        #region properties
        string FileName { get; set; }
        private Question[] questions;
        public int Count { get; set; }
        #endregion

        #region Methods
        public QuestionList(string fileName) {
            FileName = fileName;
            Count = 0;
            questions = new Question[5];
        }
        public void Add(Question question)
        {
            if (Count == questions.Length)
            {
                Array.Resize(ref questions, questions.Length * 2);
            }

            questions[Count] = question;
            Count++;

            StreamWriter Writer = new StreamWriter(FileName, true);
            using (Writer)
            {
                Writer.WriteLine(question);
                Writer.WriteLine("--------------------------------");   
            }
        }

        public Question this [int index]
        {
            get
            {
                if(index <0 || index >= Count)
                {
                    throw new Exception("This index out of range");
                }
                else
                {
                    return questions[index];
                }
            }
        } 
        #endregion
    }
}
