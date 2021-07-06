using System;
using System.Text.RegularExpressions;

namespace Week1Task
{
    class Input
    {
        public int courseUnit { get; set; }
        public int courseScore { get; set; }

        /// <summary>
        /// Prompts user for Course Code and validates it.
        /// </summary>
        /// <returns></returns>

        public string AddCourseCode()
        {
            Console.Write("Input Course Code: ");
            string courseCode = Console.ReadLine();

            string pattern = "^[A-Z]{3}[0-9]{3}";

            bool match = Regex.IsMatch(courseCode, pattern);

            if (match == false || courseCode.Length != 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Invalid Course Code.  Course Code should consist of 3 uppercase alphabets and 3 digits with no space between them.");
                Console.ResetColor();
                AddCourseCode();
            }
            return courseCode;
        }

        /// <summary>
        /// Prompts users for Course unit and validates it.
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// Prompts user for course Score and validates it.
        /// </summary>
        /// <returns></returns>

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
    }
}
