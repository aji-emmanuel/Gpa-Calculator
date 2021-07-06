using System;


namespace Week1Task
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseApps app = new CourseApps();
            app.Welcome();
            app.Help();
            app.Execute();
           
        }
    }
}
