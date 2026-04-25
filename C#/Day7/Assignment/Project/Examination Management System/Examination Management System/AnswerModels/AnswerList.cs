using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.AnswerModel
{
    public class AnswerList
    {
        #region Properties
        Answer[] answers;
        public int Count { get; private set; }
        #endregion

        #region Constructor
        public AnswerList(int size = 5) { answers = new Answer[size]; Count = 0; }
        #endregion

        #region Methods
        public void Add(Answer answer)
        {
            if (Count == answers.Length) Array.Resize(ref answers, answers.Length * 2);
            answers[Count] = answer;
            Count++;
        }
        public Answer GetById(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                if (answers[i].ID == id)
                {
                    return answers[i];
                }
            }
            return null;
        }
        public Answer this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("This index not valid");
                }
                else
                {
                    return answers[index];
                }
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("This index not valid");
                }
                else
                {
                    answers[index] = value;
                }
            }
        }
        #endregion
    }
}
