using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Task
{
    class GpaCalculator
    {
        public int gradeUnit { get; set; }
        public int totalCourseUnit { get; set; }
        public double totalWeigthPoint { get; set; }


        readonly EnumAndGrades grade = new EnumAndGrades();
        List<CourseItems> items = new List<CourseItems>();
        readonly Input input = new Input();

        /// <summary>
        /// Computes grade unit from Course unit and Course Grade.
        /// </summary>
        /// <returns></returns>

        public int GradeUnit()
        {
            gradeUnit = grade.courseGrade switch
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
            int weigthPoint = input.courseUnit * gradeUnit;
            return weigthPoint;
        }

        public string Remarks()
        {
            string remark;
            if (grade.courseGrade == "A")
            {
                remark = "Excellent";
            }
            else if (grade.courseGrade == "B")
            {
                remark = "Very Good";
            }
            else if (grade.courseGrade == "C")
            {
                remark = "Good";
            }
            else if (grade.courseGrade == "D")
            {
                remark = "Fair";
            }
            else if (grade.courseGrade == "E")
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
            Console.WriteLine($"\n\n     Total Course Unit registered is {totalCourseUnit}.");
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
            string gpaDecimal = String.Format(" {0:0.00}", gpa);
            Console.WriteLine("     Your GPA is " + gpaDecimal);
        }

    }
}
