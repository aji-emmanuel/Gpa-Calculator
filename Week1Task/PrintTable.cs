using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Task
{
    class PrintTable
    {
        List<CourseItems> list = new List<CourseItems>();
        readonly GpaCalculator calculator = new GpaCalculator();

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n    You have not added any Course");
                Console.ResetColor();
            }
            else
            {
                Table.PrintLines();
                Table.PrintHeadings("Course Code", " Course Unit", "Course Grade", "Grade Unit", "Weigth Pt.", "Remark");
                Table.PrintLines();

                foreach (var item in list)
                {
                    if (item.CourseGrade == "A")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Table.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        Table.PrintLines();
                    }
                    /*
                    else if (item.CourseGrade == "B")
                    {
                        //Console.ForegroundColor = ConsoleColor.Blue;
                        Table.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        //Console.ResetColor();
                        Table.PrintLines();
                    }
                    else if (item.CourseGrade == "C")
                    {
                       // Console.ForegroundColor = ConsoleColor.Yellow;
                        Table.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                       // Console.ResetColor();
                        Table.PrintLines();
                    }

                    */
                    else if (item.CourseGrade == "F")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        Table.PrintLines();
                    }
                    else
                    {
                        Table.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Table.PrintLines();
                    }
                }
                calculator.TotalCourseUnit();
                Table.PrintLines();
                calculator.GradeUnitPassed();
                Table.PrintLines();
                calculator.TotalweigthPoint();
                Table.PrintLines();
                calculator.Gpa();
                Table.PrintLines();

            }
        }
    }
}
