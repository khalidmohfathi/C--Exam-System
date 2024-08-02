using Exam02.QuestionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam02.ExamClasses
{
    internal class Practical : Exam
    {
        public Practical(int time, int num) : base(time, num)
        {
        }

        protected override void AddQuestion()
        {
            Console.Clear();
            string header = "MCQ Question";
            Console.WriteLine(header);
            string body = AddQuestionBody();
            double mark = AddQuestionMark();
            Questions.Add(new MCQ(header, body, mark));
            Questions.Last().BuildAnswers();
        }

        protected override string AddQuestionBody()
        {
            string body;
            do
            {
                Console.Write("Please Enter Question Body: ");
                body = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(body))
                {
                    Console.WriteLine("Question Body cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(body));
            return body;
        }

        protected override double AddQuestionMark()
        {
            int mark;
            do
            {
                Console.Write("Please Enter Question Mark: ");

            } while (!int.TryParse(Console.ReadLine(), out mark));
            return mark;
        }

        public override void TakeExam()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].ShowQuestion();
                Questions[i].SetChosenAnswer();
                this.TotalExamMark += Questions[i].Mark;
            }
        }

        public override void ShowResults()
        {
            Console.Clear();
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].ValidateAnswer())
                {
                    Console.WriteLine($"Question {i+1} : Correct");
                }
                else
                {
                    Console.WriteLine($"Question {i + 1} : Wrong");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
