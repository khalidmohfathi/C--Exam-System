using Exam02.AnswerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.QuestionClasses
{
    internal class MCQ : Question
    {
        public MCQ(string header, string body, double mark)
            : base(header, body, mark)
        {
        }

        public override void BuildAnswers()
        {
            FillChoices();
            SetRightAnswer();
        }

        protected void FillChoices()
        {
            for (int i = 0; i < 3; i++)
            {
                Answers.Add(AddChoices(i + 1));
            }
        }

        protected Answer AddChoices(int id)
        {
            string text;
            do
            {
                Console.Write($"Choice ({id}) Body: ");
                text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Choice Body cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(text));

            return new Answer(id, text);
        }

        protected override void SetRightAnswer()
        {
            int choice;
            do
            {
                Console.Write("Please Enter The Right Choice Id: ");

            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3));
            this.RightAnswer = choice;
        }

        public override void ShowQuestion()
        {
            Console.Clear();
            Console.WriteLine($"{this.Header} \t Marks: {this.Mark} \n");
            Console.WriteLine($"{this.Body} \n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}- {Answers[i].Text}");
            }
            Console.WriteLine();
        }

    }
}
