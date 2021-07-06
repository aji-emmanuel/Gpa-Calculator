using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Week1Task
{
    class CourseApps
    {
        readonly List<CourseItems> items = new List<CourseItems>();
        readonly GpaCalculator calculator = new GpaCalculator();
        readonly EnumAndGrades grade = new EnumAndGrades();
        readonly PrintTable print = new PrintTable();
        readonly Input input = new Input();

        /// <summary>
        /// Prints a welcome message to the user.
        /// </summary>

        public void Welcome()
        {
            Console.WriteLine("\n               WELCOME TO YOUR GRADE POINT AVERAGE (GPA) CALCULATOR\n");
        }

       


        public void Execute()
        {
            string options = Console.ReadLine();

            while (options != "3")
            {
                if (options == "1")
                {
                    Add();
                    print.Print();
                    Help();
                }
                else if (options == "2")
                {
                    Console.Clear();
                    print.Print();
                    Help();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n   Invalid option.");
                    Console.ResetColor();
                    Help();
                }
                options = Console.ReadLine();        // Read new input (options).
            }
        }








        


        public void Add()
        {
            input.GetUserInput();

           
           
            //string remark = calculator.Remarks();

           /* CourseItems courseItems = new CourseItems();
            courseItems.CourseCode = input.AddCourseCode();
            courseItems.CourseUnit = input.AddCourseUnit();

            input.CourseScore = input.AddCourseScore();

            courseItems.CourseGrade = grade.CourseGrade();
            courseItems.GradeUnit = calculator.GradeUnit();
            courseItems.WeightPoint = calculator.WeigthPoint();
            courseItems.Remarks = calculator.Remarks();
           */

            CourseItems newItem = new CourseItems(input.CourseCode, input.CourseUnit,
                          grade.CourseGrade, grade.CourseGradeUnit, calculator.CourseWeigthPoint, grade.Remark);


            items.Add(newItem);
            Console.Clear();
            Console.WriteLine("Item added successfully.");
        }

        

        public void Help()
        {
            Console.WriteLine("\nEnter 1 to add Course Code, Grade Unit and Score." +
                              "\nEnter 2 to print table of added courses." +
                              "\nEnter 3 to exit from the app.");
            Console.Write("\n>>");                                              // Write a command line terminal symbol.
        }
    }
}
