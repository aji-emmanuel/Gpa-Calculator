using System;
namespace Week1Task
{
    class CourseItems
    {
        public CourseItems(string courseCode, int courseUnit,
            string courseGrade, int gradeUnit, int weightPoint, string remark)
        {
            CourseCode = courseCode;
            CourseUnit = courseUnit;
            CourseGrade = courseGrade;
            GradeUnit = gradeUnit;
            WeightPoint = weightPoint;
            Remarks = remark;
        }

        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public string CourseGrade { get; set; }
        public int GradeUnit { get; set; }
        public int WeightPoint { get; set; }
        public string Remarks { get; set; }

    }
}
