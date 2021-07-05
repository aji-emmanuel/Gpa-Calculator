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

            string options = Console.ReadLine();

            while (options !="3")
            {
                if(options=="1")
                {
                    app.Add();
                    app.Print();
                    app.Help();
                }
                else if (options == "2")
                {
                    Console.Clear();
                    app.Print();
                    app.Help();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n   Invalid option.");
                    Console.ResetColor();
                    app.Help();
                }
                options = Console.ReadLine();        // Read new input (options).
            }
        }
    }
}
