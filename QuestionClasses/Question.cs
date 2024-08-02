using Exam02.AnswerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.QuestionClasses
{
    internal abstract class Question
    {
        protected double mark;
        protected string Header { get; set; }
        protected string Body { get; set; }
        public double Mark { get { return mark; } }
        protected List<Answer> Answers { get; set; }
        protected int RightAnswer { get; set; }
        protected int ChosenAnswer { get; set; }

        protected Question(string header, string body, double mark)
        {
            this.Header = header;
            this.Body = body;
            this.mark = mark;
            this.Answers = new List<Answer>();
        }

        public bool ValidateAnswer()
        {
            return this.RightAnswer == this.ChosenAnswer;
        }
        public abstract void BuildAnswers();
        public abstract void ShowQuestion();
        public void SetChosenAnswer()
        {
            int choice;
            do
            {
                Console.Write("Please Enter Your Choice Id: ");

            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3));
            this.ChosenAnswer = choice;
        }
        public void QuestionResult(int i)
        {
            Console.WriteLine($"Question {i}: {this.Body}");
            Console.WriteLine($"Your Answer => {this.ChosenAnswer}");
            Console.WriteLine($"Right Answer => {this.RightAnswer}");
            Console.WriteLine();
        }
        protected abstract void SetRightAnswer();
    }
}
