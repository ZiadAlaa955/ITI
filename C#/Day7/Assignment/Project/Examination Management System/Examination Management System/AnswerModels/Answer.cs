using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.AnswerModel
{
    public class Answer : IComparable<Answer>
    {
        #region Properties
        public int ID { get; set; }
        public string Text { get; set; }
        #endregion

        #region Constructor
        public Answer(int id, string text) { ID = id; Text = text; }
        #endregion

        #region System.Object Override
        public override string ToString()
        {
            return $"{ID}.{Text}";
        }
        public override bool Equals(object obj)
        {
            if(obj is Answer Right)
            {
                return Right.ID == ID && Right.Text == Text;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID,Text);
        }
        #endregion

        #region CompareTo
        public int CompareTo(Answer Right)
        {
            if (Right != null)
            {
                return ID.CompareTo(Right.ID);
            }
            return 1;
        }

        #endregion
    }
}
