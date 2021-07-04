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

            

            while (options !="3")
            {
                if(options=="1")
                {
                    app.Add();
                    app.Print();
                    app.Help();
                }
                else if(options=="2")
                {
                    app.Print();
                    app.Help1();
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
