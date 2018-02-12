using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GCLibrary2018
{
    class Menu
    {
        // prints menu options
        public static string GCLMenu ()
        {
            Console.WriteLine("\n\t\t\t\t\t\t\t\t    Enter a number to make a selection!");
            Console.WriteLine("\n\n\t\t\t   [1] Display Library [2] Search Library [3] Checkout a Book [4] Return a Book [5] Donate a book [6] Exit Library");
            
            string UserInput = Console.ReadLine();
            return UserInput;
        }

        // prints info of books matched by searching
        public static void PrintTitles (List<Book>BookList)
        {
            if (BookList.Count != 0)
            {
                foreach (Book b in BookList)
                {
                    Console.WriteLine($"\t\t\t\t\t  {b.title} by {b.author}");
                }
            }
            else
                Console.WriteLine("\nNo books matched that search!\n");
        }

        // updates Library.txt when exiting program
        public static void WriteToFile(ref List<Book> BookList)
        {
            StreamWriter Writer = new StreamWriter("../../Library.txt");
            foreach (Book book in BookList)
            {
                Writer.WriteLine($"{book.title},{book.author},{book.duedate},{book.status}");
            }
            Writer.Close();
        }
    }
}
