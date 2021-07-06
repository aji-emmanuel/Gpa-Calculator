using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Task
{
    class EnumAndGrades
    {
        enum Grades
        { A, B, C, D, E, F }


        public string CourseGrade { get; set; }
        public int CourseGradeUnit { get; set; }
        public string Remark { get; set; }
        readonly Input input = new Input();

        /// <summary>
        /// Computes Course Grade from Course score.
        /// </summary>
        /// <returns></returns>

        public string Grade()
        {
            int score = input.CourseScore;
            CourseGrade = Grades.F.ToString();
            if (score <= 100 && score >= 70)
            {
                CourseGrade = Grades.A.ToString();
            }
            else if (score < 69 && score >= 60)
            {
                CourseGrade = Grades.B.ToString();
            }
            else if (score < 59 && score >= 50)
            {
                CourseGrade = Grades.C.ToString();
            }
            else if (score < 49 && score >= 45)
            {
                CourseGrade = Grades.D.ToString();
            }
            else if (score < 44 && score >= 40)
            {
                CourseGrade = Grades.E.ToString();
            }
            else
            {
                CourseGrade = Grades.F.ToString();
            }
            return CourseGrade;
        }

        /// <summary>
        /// Computes Course GradeUnit using the Course Grade.
        /// </summary>
        /// <returns></returns>

        public int GradeUnit()
        {
            CourseGradeUnit = CourseGrade switch
            {
                "A" => 5,
                "B" => 4,
                "C" => 3,
                "D" => 2,
                "E" => 1,
                _ => 0,
            };
            return CourseGradeUnit;
        }

        /// <summary>
        /// Determines the remark for a Course based on the Course Grade.
        /// </summary>
        /// <returns></returns>

        public string Remarks()
        {
            
            if (CourseGrade == "A")
            {
                Remark = "Excellent";
            }
            else if (CourseGrade == "B")
            {
                Remark = "Very Good";
            }
            else if (CourseGrade == "C")
            {
                Remark = "Good";
            }
            else if (CourseGrade == "D")
            {
                Remark = "Fair";
            }
            else if (CourseGrade == "E")
            {
                Remark = "Pass";
            }
            else
            {
                Remark = "Fail";
            }
            return Remark;
        }
    }
}
