using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Task
{
    class GpaCalculator
    {
        //public int gradeUnit { get; set; }
        public int TotalCourseUnit { get; set; }
        public double TotalWeigthPoint { get; set; }
        public int CourseWeigthPoint { get; set; }

        readonly List<CourseItems> items = new List<CourseItems>();
        readonly EnumAndGrades unit = new EnumAndGrades();
        readonly Input input = new Input();

        /// <summary>
        /// Computes grade unit from Course unit and Course Grade.
        /// </summary>
        /// <returns></returns>

        
        public int WeigthPoint()
        {
            CourseWeigthPoint = input.CourseUnit * unit.CourseGradeUnit;
            return CourseWeigthPoint;
        }

       


        public void ComputeTotalCourseUnit()
        {
            TotalCourseUnit = 0;
            foreach (var item in items)
            {
                TotalCourseUnit += item.CourseUnit;
            }
            Console.WriteLine($"\n\n     Total Course Unit registered is {TotalCourseUnit}.");
        }

        public void GradeUnitPassed()
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

        public void TotalweigthPoint()
        {
            TotalWeigthPoint = 0;
            foreach (var item in items)
            {
                TotalWeigthPoint += item.WeightPoint;
            }
            Console.WriteLine($"     Total Weight Point is {TotalWeigthPoint}.");
        }

        public void Gpa()
        {
            double gpa = TotalWeigthPoint / TotalCourseUnit;
            string gpaDecimal = String.Format(" {0:0.00}", gpa);
            Console.WriteLine("     Your GPA is " + gpaDecimal);
        }
       
    }
}
