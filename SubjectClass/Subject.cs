using Exam02.ExamClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.SubjectClass
{
    internal class Subject
    {
        private string Name { get; set; }
        private Exam Exam { get; set; }

        public Subject(string name)
        {
            this.Name = name;
        }

        public void BuildExam()
        {
            int type = ChooseExamType();
            int time = ChooseExamTime();
            int num = ChooseNumberOfQuestions();
            InitializeExam(type, time, num);
            Exam.FillExam();
        }

        public void TakeExam()
        {
            Exam.TakeExam();
            Exam.ShowResults();
        }

        private int ChooseExamType()
        {
            int type;
            do
            {
                Console.Clear();
                Console.Write("Please Enter Type Of Exam (1 For Practical | 2 For Final): ");

            } while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2));
            return type;
        }

        private int ChooseExamTime()
        {
            int time;
            do
            {
                Console.Clear();
                Console.Write("Please Enter Time Of Exam From (30 min to 180 min): ");

            } while (!int.TryParse(Console.ReadLine(), out time) || !(time >= 30 && time <= 180));
            return time;
        }

        private int ChooseNumberOfQuestions()
        {
            int num;
            do
            {
                Console.Clear();
                Console.Write("Please Enter Number Of Questions: ");

            } while (!int.TryParse(Console.ReadLine(), out num));
            return num;
        }

        private void InitializeExam(int type , int time , int num)
        {
            switch (type)
            {
                case 1:
                    this.Exam = new Practical(time, num);
                    break;
                case 2:
                    this.Exam = new Final(time, num);
                    break;
            }
        }
    }
}
