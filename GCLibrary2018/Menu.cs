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
        public static string GCLMenu ()
        {
            Console.WriteLine("\t\t\t\t\tEnter a number to perform an action!");
            Console.WriteLine("\n\t\t\t\t\t\t[1] Display Library\n\n\t\t\t\t\t\t[2] Search Library\n\n\t\t\t\t\t\t[3] Checkout a Book\n\n\t\t\t\t\t\t[4] Return a Book\n\n\t\t\t\t\t\t[5] Exit Library");
            
            string UserInput = Console.ReadLine();
            return UserInput;
        }

        public static void PrintTitles (List<Book>BookList)
        {
            if (BookList.Count != 0)
            {
                foreach (Book b in BookList)
                {
                    Console.WriteLine($"{b.title} by {b.author}");
                }
            }
            else
                Console.WriteLine("\nNo books matched that search!\n");
        }

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
