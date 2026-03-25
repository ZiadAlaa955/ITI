using Examination_Management_System.AnswerModel;
using Examination_Management_System.QuestionModel;
using Examination_Management_System.SubjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.ExamModel
{
    internal class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(int time, int numOfQuestions, Subject subject, ExamMode mode)
            : base(time, numOfQuestions, subject, mode) { }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.WriteLine("----Practice Exam------");
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].Display();
                Answer studentAnswer;

                if (Questions[i] is ChooseAllQuestion)
                {
                    Console.WriteLine("Enter Your answers(separated by \",\"): ");
                    string IDs = Console.ReadLine();

                    studentAnswer = new Answer(0, IDs);
                }
                else
                {
                    Console.WriteLine("Enter Your answers: ");
                    int ID = int.Parse(Console.ReadLine());

                    studentAnswer = Questions[i].Answers.GetById(ID);

                    if (studentAnswer == null)
                        studentAnswer = new(ID, "Invalid Answer");
                }
                QuestionAnswerDictionary.Add(Questions[i], studentAnswer);
            }

            ShowStudentAnswers();
        }
        public void ShowStudentAnswers()
        {
            Console.WriteLine("--Student Answers--");
            foreach (var item in QuestionAnswerDictionary)
            {
                Console.WriteLine(item.Value);
            }
        }
        #endregion
    }
}
