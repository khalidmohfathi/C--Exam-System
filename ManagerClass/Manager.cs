using Exam02.SubjectClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam02.ManagerClass
{
    internal static class Manager
    {
        private static Subject Subject { get; set; }

        private static void InitializeSubject()
        {
            string Name;
            do
            {
                Console.Clear();
                Console.Write("Please Enter Subject Name: ");
                Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("Subject name cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(Name));

            Subject = new Subject(Name);
        }

        public static void Run()
        {
            int menu;
            Console.WriteLine("Welcome to Exam System !!! \n");
            while (true)
            {
                do
                {
                    Console.WriteLine("1- Create Exam");
                    Console.WriteLine("2- Take Exam");
                    Console.WriteLine("3- Exit \n");
                    Console.Write("Please Enter Your Choice: ");
                } while (!int.TryParse(Console.ReadLine(), out menu) || (menu != 1 && menu != 2 && menu != 3));

                if (menu == 1)
                {
                    InitializeSubject();
                    Subject.BuildExam();
                    Console.Clear();
                }
                else if (menu == 2)
                {
                    Subject.TakeExam();
                }
                else
                {
                    break;
                }
            }

        }
    }
}
