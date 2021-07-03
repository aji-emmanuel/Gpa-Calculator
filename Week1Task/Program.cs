using System;
using System.Text;
using System.Linq;

namespace Week1Task
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseApps app = new CourseApps();

            app.Welcome();
            app.Help();

            string options = Console.ReadLine();

            

            while (options !="2")
            {
                if(options=="1")
                {
                   // Console.Clear();
                   // app.AddCourseCode();
                   // app.AddCourseUnit();
                   // app.AddCourseScore();
                    app.Add();
                    app.Print();
                    app.Help();





                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("     Invalid option.\n");
                    app.Help();
                }
                options = Console.ReadLine();        // Read new input (options).
            }
        }
    }
}
