using Exam02.AnswerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.QuestionClasses
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, double mark)
            : base(header, body, mark)
        {
        }

        public override void BuildAnswers()
        {
            SetRightAnswer();
        }

        public override void ShowQuestion()
        {
            Console.Clear();
            Console.WriteLine($"{this.Header} \t Marks: {this.Mark} \n");
            Console.WriteLine($"{this.Body} \n");
            Console.WriteLine("1- True");
            Console.WriteLine("2- False");
            Console.WriteLine();
        }

        protected override void SetRightAnswer()
        {
            int choice;
            do
            {
                Console.Write("Please Enter The Right Choice Id (1 for True | 2 for False): ");

            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));
            this.RightAnswer = choice;
        }
    }
}
