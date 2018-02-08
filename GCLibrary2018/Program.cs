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
        }

        public static void RunProgram()
        {
            
            Menu.GCLMenu();
            //Console.WriteLine("Enter Custom Text Here");
            string Input = Console.ReadLine();
            Console.WriteLine($"Enter Custom Text Here {Input}");

            // Code
            // Method calls
        }

        public static void ContinueProgram()
        {
            Console.WriteLine("Enter Custom Text Here? Y/N");
            string Continue = Console.ReadLine();

            while (Regex.Match(Continue, @"^[Y|y]$").Success)
            {
                RunProgram();
                Continue = "";
                Console.WriteLine("Enter Custom Text Here? Y/N");
                Continue = Console.ReadLine();
            }
            Console.WriteLine("Enter Custom Text Here");
            Console.ReadLine();
        }
    }
}
