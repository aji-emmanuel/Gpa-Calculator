using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Task
{
    class EnumAndGrades
    {
        enum Grades
        { A, B, C, D, E, F }


        public string courseGrade { get; set; }
        readonly Input input = new Input();

        /// <summary>
        /// Computes Course Grade from Course score.
        /// </summary>
        /// <returns></returns>

        public string CourseGrade()
        {
            int score = input.courseScore;
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
    }
}
