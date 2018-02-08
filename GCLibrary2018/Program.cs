using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GCLibrary2018
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
            ContinueProgram();
            Console.WriteLine("Goodbye!");
        }
        public static void RunProgram()
        {
            Menu.GCLMenu(); 
            Console.WriteLine("Please enter a menu number");
            string Input = Console.ReadLine();
            Console.WriteLine($"Enter Custom Text Here {Input}");

            // Code
            // Method calls
        }

        public static void ContinueProgram()
        {
            Console.WriteLine("Would you like to perform another action? Y/N");
            string Continue = Console.ReadLine();
            if (Validation.Continue(Continue) == true)
                RunProgram();
        }
    }
}
