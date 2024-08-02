using Exam02.QuestionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.ExamClasses
{
    internal class Final : Exam
    {
        protected double ExamMark { get; set; }
        public Final(int time, int num) : base(time, num)
        {
            ExamMark = 0;
        }

        protected override void AddQuestion()
        {
            Console.Clear();
            int type = ChooseQuestionType();
            Console.Clear();
            string header = AddQuestionHeader(type);
            string body = AddQuestionBody();
            double mark = AddQuestionMark();
            switch (type)
            {
                case 1:
                    Questions.Add(new MCQ(header, body, mark));
                    break;
                case 2:
                    Questions.Add(new TrueOrFalse(header, body, mark));
                    break;
            }
            Questions.Last().BuildAnswers();
        }

        protected int ChooseQuestionType()
        {
            int type;
            do
            {
                Console.Clear();
                Console.Write("Please Enter Type Of Question (1 For [MCQ] | 2 For [True or False]): ");

            } while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2));
            return type;
        }

        protected string AddQuestionHeader(int type)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine("MCQ Question");
                    return "MCQ Question";
                case 2:
                    Console.WriteLine("True or False Question");
                    return "True or False Question";
            }
            return "";
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
            double mark;
            do
            {
                Console.Write("Please Enter Question Mark: ");

            } while (!double.TryParse(Console.ReadLine(), out mark));
            return mark;
        }

        public override void TakeExam()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].ShowQuestion();
                Questions[i].SetChosenAnswer();
                this.TotalExamMark += Questions[i].Mark;
                if (Questions[i].ValidateAnswer())
                {
                    this.ExamMark += Questions[i].Mark;
                }
            }
        }

        public override void ShowResults()
        {
            Console.Clear();
            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].QuestionResult(i + 1);
            }
            Console.WriteLine($"Your Grade is {this.ExamMark} of {this.TotalExamMark}");
            Console.WriteLine("Thank You \n \n");
        }
    }
}
