using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Week1Task
{
    class CourseApps
    {
        public string courseGrade { get; set; }
        public int courseUnit { get; set; }
        public int courseScore { get; set; }
        public int gradeUnit { get; set; }
        public int totalCourseUnit { get; set; }
        public double totalWeigthPoint { get; set; }

        List<CourseItems> items = new List<CourseItems>();

        public void Welcome()
        {
            Console.WriteLine("\n               WELCOME TO YOUR GRADE POINT AVERAGE (GPA) CALCULATOR\n");
        }

        public string AddCourseCode()
        {
            Console.Write("Input Course Code: ");
            string courseCode = Console.ReadLine();

            string pattern = "^[A-Z]{3}[0-9]{3}";
            
            bool match = Regex.IsMatch(courseCode, pattern);

            if (match == false || courseCode.Length!=6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Invalid Course Code.  Course Code should consist of 3 uppercase alphabets and 3 digits with no space between them.");
                Console.ResetColor();
                AddCourseCode();
            }
            return courseCode;
        }

        public int AddCourseUnit()
        {
            Console.Write("Input Course Unit: ");
            try
            {
                courseUnit = int.Parse(Console.ReadLine());
                while (courseUnit < 1 || courseUnit > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Invalid Course unit.  Course Unit should be a number between 1 and 5.");
                    Console.ResetColor();
                    AddCourseUnit();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Invalid Course unit.  Course Unit should be a number between 1 and 5.");
                Console.ResetColor();
                AddCourseUnit();
            }
            return courseUnit;
        }

        public int AddCourseScore()
        {
            Console.Write("Input Course Score: ");
            try
            {
                courseScore = int.Parse(Console.ReadLine());
                while (courseScore < 0 || courseScore > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Invalid Course score.  Course score should be a number between 0 and 100.");
                    Console.ResetColor();
                    AddCourseScore();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Invalid Course score.  Course score should be a number between 0 and 100.");
                Console.ResetColor();
                AddCourseScore();
            }
            return courseScore;
        }


        enum Grades
        { A, B, C, D, E, F }

        public string CourseGrade()
        {
            int score = courseScore;
            courseGrade = Grades.F.ToString();
            if (score <= 100 && score >= 70)
            {
                courseGrade = Grades.A.ToString();
            }
            else if (score < 69 && score >= 60)
            {
                courseGrade = Grades.B.ToString();
            }
            else if (score < 59 && score >= 50)
            {
                courseGrade = Grades.C.ToString();
            }
            else if (score < 49 && score >= 45)
            {
                courseGrade = Grades.D.ToString();
            }
            else if (score < 44 && score >= 40)
            {
                courseGrade = Grades.E.ToString();
            }
            else
            {
                courseGrade = Grades.F.ToString();
            }
            return courseGrade;
        }

        public int GradeUnit()
        {
            gradeUnit = courseGrade switch
            {
                "A" => 5,
                "B" => 4,
                "C" => 3,
                "D" => 2,
                "E" => 1,
                _ => 0,
            };
            return gradeUnit;
        }
        public int WeigthPoint()
        {
            int weigthPoint = courseUnit * gradeUnit;
            return weigthPoint;
        }

        public string Remarks()
        {
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


        public void TotalCourseUnit()
        {
            totalCourseUnit = 0;
            foreach (var item in items)
            {
                totalCourseUnit += item.CourseUnit;
            }
            Console.WriteLine($"\n     Total Course Unit registered is {totalCourseUnit}.");
        }

        public void GradeUnitPassed()
        {
            int gradeUnitPassed = totalCourseUnit;
            foreach (var item in items)
            {
                if (item.CourseGrade == "F")
                {
                    gradeUnitPassed -= item.CourseUnit;
                }
            }
            Console.WriteLine($"     Total Course Unit passed is {gradeUnitPassed}.");
        }

        public void TotalweigthPoint()
        {
            totalWeigthPoint = 0;
            foreach (var item in items)
            {
                totalWeigthPoint += item.WeightPoint;
            }
            Console.WriteLine($"     Total Weight Point is {totalWeigthPoint}.");
        }

        public void Gpa()
        {
            double gpa = totalWeigthPoint / totalCourseUnit;
            Console.WriteLine($"     Your GPA is = {Math.Round(gpa,2)}.");
        }


        public void Add()
        {
            string courseCode = AddCourseCode();
            int courseUnit = AddCourseUnit();
            courseScore = AddCourseScore();
            string courseGrade = CourseGrade();
            int gradeUnit = GradeUnit();
            int weigthPoint = WeigthPoint();
            string remarks = Remarks();

            CourseItems newItem = new CourseItems(courseCode, courseUnit,
                         courseGrade, gradeUnit, weigthPoint, remarks);
            items.Add(newItem);
            Console.Clear();
            Console.WriteLine("Item added successfully.");
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have not added any Course");
            }
            else
            {
                PrintTable.PrintLines();
                PrintTable.PrintHeadings("Course Code", " Course Unit", "Course Grade", "Grade Unit", "Weigth Pt.", "Remark");
                PrintTable.PrintLines();

                foreach (var item in items)
                {
                    if (item.CourseGrade == "A")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        PrintTable.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        PrintTable.PrintLines();
                    }
                    else if (item.CourseGrade == "B")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        PrintTable.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        PrintTable.PrintLines();
                    }
                    else if (item.CourseGrade == "C")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        PrintTable.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        PrintTable.PrintLines();
                    }
                    else if (item.CourseGrade == "F")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        PrintTable.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        PrintTable.PrintLines();
                    }
                    else
                    {
                        PrintTable.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        PrintTable.PrintLines();
                    }
                }
            }
            TotalCourseUnit();
            GradeUnitPassed();
            TotalweigthPoint();
            Gpa();
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
