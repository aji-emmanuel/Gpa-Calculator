using System;
using System.Collections.Generic;

namespace Week1Task
{
    class CourseApps
    {
        public string CourseGrade { get; set; }
        public int GradeUnit { get; set; }
        public int TotalCourseUnit { get; set; }
        public double TotalWeigthPoint { get; set; }

        readonly List<CourseItems> items = new List<CourseItems>();
        readonly UserInput input = new UserInput();

        /// <summary>
        /// Prints a welcome message to the user.
        /// </summary>

        public void Welcome()
        {
            Console.WriteLine("\n               WELCOME TO YOUR GRADE POINT AVERAGE (GPA) CALCULATOR\n");
        }

        /// <summary>
        /// Prints the various options available to the User.
        /// </summary>

        public void Help()
        {
            Console.WriteLine("\nEnter 1 to add Course Code, Grade Unit and Score." +
                              "\nEnter 2 to print table of added courses." +
                              "\nEnter 3 to exit from the app.");
            Console.Write("\n>>");                                              // Write a command line terminal symbol.
        }

        /// <summary>
        /// Executes the app options chosen by the User.
        /// </summary>

        public void Execute()
        {
            string options = Console.ReadLine();

            while (options != "3")
            {
                if (options == "1")
                {
                    Add();
                    Print();
                    Help();
                }
                else if (options == "2")
                {
                    Console.Clear();
                    Print();
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

        /// <summary>
        /// Adds the Course Details to CourseItems List.
        /// </summary>
        
        public void Add()
        {
            input.CourseCode = input.AddCourseCode();
            int courseUnit = input.AddCourseUnit();
            input.CourseScore = input.AddCourseScore();
            string courseGrade = ComputeGrade();
            int gradeUnit = ComputeScoreGradeUnit();
            int weigthPoint = ComputeWeigthPoint();
            string remarks = Remarks();

            CourseItems newItem = new CourseItems(input.CourseCode, courseUnit,
                         courseGrade, gradeUnit, weigthPoint, remarks);
            if(items.Contains(newItem)==true)
            {
                Console.WriteLine("You have a Course with same Course Name!");
            }
            else
            {
                items.Add(newItem);
                Console.Clear();
                Console.WriteLine("Item added successfully.");
            }
        }

        /// <summary>
        /// This calculates the Course Grade based on the Course Score.
        /// </summary>
        /// <returns></returns>

        public string ComputeGrade()
        {
            int score = input.CourseScore;
            CourseGrade = GradeEnum.F.ToString();
            if (score <= 100 && score >= 70)
            {
                CourseGrade = GradeEnum.A.ToString();
            }
            else if (score < 69 && score >= 60)
            {
                CourseGrade = GradeEnum.B.ToString();
            }
            else if (score < 59 && score >= 50)
            {
                CourseGrade = GradeEnum.C.ToString();
            }
            else if (score < 49 && score >= 45)
            {
                CourseGrade = GradeEnum.D.ToString();
            }
            else if (score < 44 && score >= 40)
            {
                CourseGrade = GradeEnum.E.ToString();
            }
            else
            {
                CourseGrade = GradeEnum.F.ToString();
            }
            return CourseGrade;
        }

        /// <summary>
        /// Computes Grade unit from Course Grade.
        /// </summary>
        /// <returns></returns>

        public int ComputeScoreGradeUnit()
        {
            GradeUnit = CourseGrade switch
            {
                "A" => 5,
                "B" => 4,
                "C" => 3,
                "D" => 2,
                "E" => 1,
                _ => 0,
            };
            return GradeUnit;
        }

        /// <summary>
        /// Calculates the Weigth Point using Course Unit and Grade Unit
        /// </summary>
        /// <returns></returns>

        public int ComputeWeigthPoint()
        {
            int weigthPoint = input.CourseUnit * GradeUnit;
            return weigthPoint;
        }

        /// <summary>
        /// Calculates the Total Unit entered by the User.
        /// </summary>

        public void ComputeTotalUnit()
        {
            TotalCourseUnit = 0;
            foreach (var item in items)
            {
                TotalCourseUnit += item.CourseUnit;
            }
            Console.WriteLine($"\n\n     Total Course Unit registered is {TotalCourseUnit}.");
        }

        /// <summary>
        /// Calculates the Total Grade Unit passed.
        /// </summary>

        public void ComputeGradeUnitPassed()
        {
            int gradeUnitPassed = TotalCourseUnit;
            foreach (var item in items)
            {
                if (item.CourseGrade == "F")
                {
                    gradeUnitPassed -= item.CourseUnit;
                }
            }
            Console.WriteLine($"     Total Course Unit passed is {gradeUnitPassed}.");
        }

        /// <summary>
        /// Calculates the Total Weigth point of all Courses entered by user.
        /// </summary>

        public void ComputeTotalweigthPoint()
        {
            TotalWeigthPoint = 0;
            foreach (var item in items)
            {
                TotalWeigthPoint += item.WeightPoint;
            }
            Console.WriteLine($"     Total Weight Point is {TotalWeigthPoint}.");
        }

        /// <summary>
        /// Calculates the Gpa as the quotient of Total Weigth Point and Total Course Unit.
        /// </summary>

        public void ComputeGpa()
        {
            double gpa = TotalWeigthPoint / TotalCourseUnit;
            string gpaDecimal = String.Format(" {0:0.00}", gpa);
            Console.Write("     Your GPA is ");
            if (double.Parse(gpaDecimal) >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(gpaDecimal + "\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(gpaDecimal + "\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Attaches a remark to each Course Grade.
        /// </summary>
        /// <returns></returns>

        public string Remarks()
        {
            string remark;
            if (CourseGrade == "A")
            {
                remark = "Excellent";
            }
            else if (CourseGrade == "B")
            {
                remark = "Very Good";
            }
            else if (CourseGrade == "C")
            {
                remark = "Good";
            }
            else if (CourseGrade == "D")
            {
                remark = "Fair";
            }
            else if (CourseGrade == "E")
            {
                remark = "Pass";
            }
            else
            {
                remark = "Fail";
            }
            return remark;
        }

        /// <summary>
        /// Prints out the Course details entered by the User and the computed GPA metrics.
        /// </summary>

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have not added any Course");
            }
            else
            {
                TableModel.PrintLines();
                TableModel.PrintHeadings("Course Code", " Course Unit", "Course Grade", "Grade Unit", "Weigth Pt.", "Remark");
                TableModel.PrintLines();

                foreach (var item in items)
                {
                    if (item.CourseGrade == "A")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        TableModel.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        TableModel.PrintLines();
                    }
                    else if (item.CourseGrade == "F")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        TableModel.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        Console.ResetColor();
                        TableModel.PrintLines();
                    }
                    else
                    {
                        TableModel.PrintHeadings(item.CourseCode, item.CourseUnit.ToString(), item.CourseGrade, item.GradeUnit.ToString(), item.WeightPoint.ToString(), item.Remarks);
                        TableModel.PrintLines();
                    }
                }
            }
            ComputeTotalUnit();                 // Prints out Total unit registered.
            TableModel.PrintLines();
            ComputeGradeUnitPassed();           // Prints out Total Grade Unit passed.
            TableModel.PrintLines();
            ComputeTotalweigthPoint();          // Prints out Total Weigth Point.
            TableModel.PrintLines();
            ComputeGpa();                       // Prints out the calculated GPA.
            TableModel.PrintLines();
        }
    }
}
