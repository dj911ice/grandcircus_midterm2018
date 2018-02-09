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
            Console.WriteLine("Welcome to the Grand Circus Library!\n\n");
            RunProgram();
            Console.WriteLine("Goodbye!");
        }

        public static void RunProgram()
        {
            while (true)
            {
                Menu.GCLMenu();
                Console.WriteLine("Enter a number to perform an action!");
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
                {
                    Menu.WriteToFile(ref BookList);
                    break;
                }
                else
                {
                    Console.WriteLine("That's not an option! Try again!");
                    Input = Console.ReadLine();
                }
            }
        }
    }
}
