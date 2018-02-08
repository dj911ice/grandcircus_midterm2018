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
        public static List<Book> BookList = LibraryApp.CreateBookList("../../Library.txt");
        static void Main(string[] args)
        {
            RunProgram();
            ContinueProgram();
        }

        public static void RunProgram()
        {
            while (true)
            {
                Menu.GCLMenu();
                //Console.WriteLine("Enter Custom Text Here");
                string Input = Console.ReadLine();
                if (Input == "1")
                    LibraryApp.PrintBookList(ref BookList);
                else if (Input == "2")
                    Validation.Search(ref BookList);
                else if (Input == "3")
                    LibraryApp.CheckOutBook(Validation.ConfirmBook(ref BookList));
                else if (Input == "4")
                    LibraryApp.ReturnBook(Validation.ConfirmBook(ref BookList));
                else if (Input == "5")
                    Menu.WriteToFile(ref BookList);
                else
                {
                    Console.WriteLine("That's not an option! Try again!");
                    Input = Console.ReadLine();
                }
            }
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
