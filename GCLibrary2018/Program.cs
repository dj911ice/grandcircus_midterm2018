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
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t    Welcome to the Grand Circus Library!\n\n");
            RunProgram();
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t  Thank you for visiting the Grand Circus Library\n\n\n\t\t\t\t\t\t\t\t\tHave a great Day!\n\n\t\t\t\t\t\t\t\t\t    Goodbye!");
        }

        public static void RunProgram()
        {
            string Input = Menu.GCLMenu();

            while (true)
            {
                if (Input == "1")
                {
                    LibraryApp.PrintBookList(ref BookList);
                    Input = Menu.GCLMenu();
                }
                else if (Input == "2")
                {
                    Validation.Search(ref BookList);
                    Input = Menu.GCLMenu();
                }
                else if (Input == "3")
                {
                    LibraryApp.CheckOutBook(Validation.ConfirmBook(ref BookList));
                    Input = Menu.GCLMenu();
                }
                else if (Input == "4")
                {
                    List<Book> ReturnList = Validation.CreateReturnList(ref BookList);
                    if (ReturnList.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t     There are no books to return!\n\n");
                        Input = Menu.GCLMenu();
                    } 
                    else
                    {
                        LibraryApp.ReturnBook(Validation.ConfirmReturn(ReturnList));
                        Input = Menu.GCLMenu();
                    }
                    
                }
                else if (Input == "5")
                {
                    LibraryApp.DonateBook(ref BookList);
                    Input = Menu.GCLMenu();
                }
                else if (Input == "6")
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
