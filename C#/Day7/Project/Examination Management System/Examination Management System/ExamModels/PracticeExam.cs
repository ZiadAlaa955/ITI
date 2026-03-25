using Examination_Management_System.AnswerModel;
using Examination_Management_System.QuestionModel;
using Examination_Management_System.SubjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.ExamModel
{
    internal class PracticeExam : Exam
    {
        #region Constructor
        public PracticeExam(int time, int numOfQuestions, Subject subject, ExamMode mode)
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
            ShowCorrectAnswers();
            ShowFinalGrade();
        }
        public void ShowStudentAnswers()
        {
            Console.WriteLine("--Student Answers--");
            foreach (var item in QuestionAnswerDictionary)
            {
                Console.WriteLine(item.Value);
            }
        }
        public void ShowCorrectAnswers()
        {
            Console.WriteLine("--Correct Answers--");
            foreach (var item in QuestionAnswerDictionary)
            {
                Console.WriteLine(item.Key.CorrectAnswer);
            }
        }
        public void ShowFinalGrade()
        {
            int totalGrades = 0, studentGrades = 0;
            for (int i = 0; i < Questions.Length; i++)
            {

            }
            foreach (var item in QuestionAnswerDictionary)
            {
                totalGrades += item.Key.Marks;

                if (item.Key.CheckAnswer(item.Value))
                    studentGrades += item.Key.Marks;

                //Console.WriteLine($"Student Answer: {item.Value}");
                //Console.WriteLine($"Correct Answer: {item.Key.CorrectAnswer}");
            }
            Console.WriteLine($"Final Grade: {studentGrades}/{totalGrades}");
        }
        #endregion

    }
}
