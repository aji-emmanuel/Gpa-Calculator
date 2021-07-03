using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace Week1Task
{
    class CourseApps
    {
       
        public void Welcome()
        {
            Console.WriteLine("\n               WELCOME TO YOUR GRADE POINT AVERAGE (GPA) CALCULATOR\n");
        }

        public void Help()
        {
            Console.WriteLine("     Enter 1 to add new Course Code, Grade Unit and Score." +
                              "\n     Enter 2 to exit from the app.");

            Console.Write("\n>>");       // Write a command line terminal symbol.
        }



        public string AddCourseCode()
        {
            Console.Write("Input Course Code: ");
            string courseCode = Console.ReadLine();
            return courseCode;
        }

        public int AddCourseUnit()
        {
            Console.Write("Input Course Unit: ");
            int courseUnit = int.Parse(Console.ReadLine());
            return courseUnit;
        }

        public int AddCourseScore()
        {
            Console.Write("Input Course Score: ");
            int courseScore = int.Parse(Console.ReadLine());
            return courseScore;
        }


        enum Grades
        { A, B, C, D, E, F }

        public string CourseGrade()
        {
            int score = this.AddCourseScore();
            var courseGrade = Grades.F;
            if (score <= 100 && score >= 70)
            {
                courseGrade = Grades.A;
            }

            else if (score < 69 && score >= 60)
            {
                courseGrade = Grades.B;
            }

            else if (score < 59 && score >= 50)
            {
                courseGrade = Grades.C;
            }

            else if (score < 49 && score >= 45)
            {
                courseGrade = Grades.D;
            }

            else if (score < 44 && score >= 40)
            {
                courseGrade = Grades.E;
            }

            else
                courseGrade = Grades.F;
            return courseGrade.ToString();
        }

        public int GradeUnit()
        {
            string courseGrade = this.CourseGrade();
            int gradeUnit;
            if (courseGrade == "A")
            {
                gradeUnit = 5;
            }
            else if (courseGrade == "B")
            {
                gradeUnit = 4;
            }
            else if (courseGrade == "C")
            {
                gradeUnit = 3;
            }
            else if (courseGrade == "D")
            {
                gradeUnit = 2;
            }
            else if (courseGrade == "E")
            {
                gradeUnit = 1;
            }
            else
            {
                gradeUnit = 0;
            }
            return gradeUnit;
        }

        public int WeigthPoint()
        {
            int courseUnit = this.AddCourseUnit();
            int gradeUnit = this.GradeUnit();
            int weigthPoint = courseUnit * gradeUnit;
            return weigthPoint;
        }

        public string Remarks()
        {
            string courseGrade = this.CourseGrade();
            string remark;
            if (courseGrade == "A")
            {
                remark = "Excellent";
            }
            else if (courseGrade == "B")
            {
                remark = "Very Good";
            }
            else if (courseGrade == "C")
            {
                remark = "Good";
            }
            else if (courseGrade == "D")
            {
                remark = "Fair";
            }
            else if (courseGrade == "E")
            {
                remark = "Pass";
            }
            else
            {
                remark = "Fail";
            }
            return remark;
        }





        List<CourseItems> items = new List<CourseItems>();
        public void Add()
        {
            string courseCode = AddCourseCode();
            int courseUnit = AddCourseUnit();
            string courseGrade = CourseGrade();
            int gradeUnit = GradeUnit();
            int weigthPoint = WeigthPoint();
            string remarks = Remarks();
            

            CourseItems newItem = new CourseItems(courseCode, courseUnit,
                         courseGrade, gradeUnit, weigthPoint, remarks);
            items.Add(newItem);
            Console.WriteLine("Item added successfully.");
        }

        /*
        public void Print()
        {
            PrintTable table = new PrintTable();
            if (items.Count == 0)
            {
                Console.WriteLine("There is no items in list");
            }
            else
            {
                Console.Clear();
                table.PrintLine();
                table.PrintRow("Course Code", "Course Unit", "Grade", "Grade-Unit", "Weigth Pt.", "Remark");
                table.PrintLine();
                table.PrintRow("", "", "", "","","");
                table.PrintRow("", "", "", "","","");
                table.PrintLine();
                Console.ReadLine();
            }
            */

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("There is no items in list");
            }
            else
            {
                var table = new ConsoleTable("Course Code", " Course Unit", "Course Grade", "Grade Unit", "Weigth Pt.", "Remark");

                foreach (CourseItems item in items)
                {
                    table.AddRow($"{item.CourseCode}", $"      {item.CourseUnit}       ", $"{item.CourseGrade}", $"{item.GradeUnit}" , $"{item.WeightPoint}", $"{item.Remarks}");          // Print all items in the todo list
                }

                table.Write();
            }
        }
        

    }
}
