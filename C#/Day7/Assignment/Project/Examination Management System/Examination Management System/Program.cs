using Examination_Management_System.AnswerModel;
using Examination_Management_System.ExamModel;
using Examination_Management_System.QuestionModel;
using Examination_Management_System.StudentModel;
using Examination_Management_System.SubjectModel;

namespace Examination_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("C#");
            Student student1 = new Student("Ziad", 1);
            Student student2 = new Student("Ahmed", 2);
            Student student3 = new Student("Omar", 3);

            subject.Enroll(student1);
            subject.Enroll(student2);
            subject.Enroll(student3);

            PracticeExam practiceExam = new PracticeExam(60, 5, subject, ExamMode.Queued);
            FinalExam finalExam = new FinalExam(60, 5, subject, ExamMode.Queued);

            #region Question 1
            AnswerList answerList1 = new AnswerList(2);
            answerList1.Add(new Answer(1, "True"));
            answerList1.Add(new Answer(2, "False"));
            Question q1 = new TrueFalseQuestion("True/False", "C# is an object-oriented programming language",1,answerList1,new Answer(1,"True"));
            #endregion
            #region Question 2
            AnswerList answerList2 = new AnswerList(2);
            answerList2.Add(new Answer(1, "True"));
            answerList2.Add(new Answer(2, "False"));
            Question q2 = new TrueFalseQuestion("True/False", "An abstract class can be instantiated directly using the 'new' keyword", 1, answerList2, new Answer(2, "False"));
            #endregion
            #region Question 3
            AnswerList answerList3 = new AnswerList(4);
            answerList3.Add(new Answer(1, "System.String"));
            answerList3.Add(new Answer(2, "System.Object"));
            answerList3.Add(new Answer(3, "System.Base"));
            answerList3.Add(new Answer(4, "System.Root"));
            Question q3 = new ChooseOneQuestion("Multiple Choice", "Which of the following is the root base class for all types in C# ?", 1, answerList3, new Answer(2, "System.Object"));
            #endregion
            #region Question 4
            AnswerList answerList4 = new AnswerList(4);
            answerList4.Add(new Answer(1, "static"));
            answerList4.Add(new Answer(2, "abstract"));
            answerList4.Add(new Answer(3, "sealed"));
            answerList4.Add(new Answer(4, "readonly"));
            Question q4 = new ChooseOneQuestion("Multiple Choice", "Which keyword is used to prevent a class from being inherited?", 3, answerList4, new Answer(3, "sealed"));
            #endregion
            #region Question 5
            AnswerList chooseAllList = new AnswerList();
            chooseAllList.Add(new Answer(1, "int"));
            chooseAllList.Add(new Answer(2, "string"));
            chooseAllList.Add(new Answer(3, "bool"));
            chooseAllList.Add(new Answer(4, "class"));
            Question q5 = new ChooseAllQuestion("Choose All That Apply", "Which of the following are Value Types in C#?", 5, chooseAllList, new Answer(0, "1,3"));
            #endregion

            QuestionList myQuestionLog = new QuestionList("ExamQuestionLog.txt");
            myQuestionLog.Add(q1);
            myQuestionLog.Add(q2);
            myQuestionLog.Add(q3);
            myQuestionLog.Add(q4);
            myQuestionLog.Add(q5);

            practiceExam.Questions[0] = q1;
            practiceExam.Questions[1] = q2;
            practiceExam.Questions[2] = q3;
            practiceExam.Questions[3] = q4;
            practiceExam.Questions[4] = q5;

            finalExam.Questions[0] = q1;
            finalExam.Questions[1] = q2;
            finalExam.Questions[2] = q3;
            finalExam.Questions[3] = q4;
            finalExam.Questions[4] = q5;

            bool flag = false;
            do
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("Choose the exam Type (1 OR 2):");
                Console.WriteLine("1) Practice");
                Console.WriteLine("2) Final");
                Console.WriteLine("====================================================");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        practiceExam.Mode = ExamMode.Starting;
                        practiceExam.ShowExam();
                        practiceExam.Mode = ExamMode.Finished;
                        flag = false;
                        break;
                    case 2:
                        finalExam.Mode = ExamMode.Starting;
                        finalExam.ShowExam();
                        finalExam.Mode = ExamMode.Finished;
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice...");
                        flag = true;
                        break;
                }
            } while (flag);
        }
    }
}
