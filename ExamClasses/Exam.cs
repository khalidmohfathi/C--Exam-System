using Exam02.QuestionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02.ExamClasses
{
    internal abstract class Exam
    {
        protected double TotalExamMark {  get; set; }
        protected int Time { get; set; }
        protected int NumOfQuestions { get; set; }
        protected List<Question> Questions { get; set; }

        protected Exam(int time, int num)
        {
            this.TotalExamMark = 0;
            this.Time = time;
            this.NumOfQuestions = num;
            this.Questions = new List<Question>();
        }

        public void FillExam()
        {
            for (int i = 0; i < NumOfQuestions; i++)
            {
                AddQuestion();
            }
        }

        public abstract void TakeExam();

        public abstract void ShowResults();

        protected abstract void AddQuestion();

        protected abstract string AddQuestionBody();

        protected abstract double AddQuestionMark();

    }
}
