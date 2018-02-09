using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GCLibrary2018
{
    class Validation
    {
        public static Book ConfirmBook(ref List<Book> BookList)
        {
            int z = 1;
            foreach (Book x in BookList)
            {
                Console.Write($"{z}..... {x.title} by {x.author}\n");
                z++;
            }

            Console.WriteLine("Which book are you referring to? (1-12)");
            string input = Console.ReadLine();
            int.TryParse(input, out int BookIndex);
            while (true)
            {
                if (BookIndex > 0 && BookIndex <= 12)
                    return BookList[BookIndex-1];
                else
                {
                    Console.WriteLine("I didn't understand. Try again!");
                    int.TryParse(Console.ReadLine(), out BookIndex);
                }
            }
        }

        public static Book ConfirmReturn(ref List<Book> BookList)
        {
            int z = 1;
            foreach (Book x in BookList)
            {
                if (x.status == "Checked Out")
                {
                    Console.WriteLine($"{z}..... {x.title} by {x.author}\n");
                    z++;
                }
            }

            Console.WriteLine($"Which book would you like to return? (1-{z})");
            string input = Console.ReadLine();
            int.TryParse(input, out int BookIndex);
            while (true)
            {
                if (BookIndex > 0 && BookIndex <= 12)
                    return BookList[BookIndex - 1];
                else
                {
                    Console.WriteLine("I didn't understand. Try again!");
                    int.TryParse(Console.ReadLine(), out BookIndex);
                }
            }
        }

        public static void Search(ref List<Book>BookList)
        {
            Console.WriteLine("Do you want to search by Title or Author?");
            string TorA = Console.ReadLine().ToLower();
            if (TorA=="title")
            {
                Console.WriteLine("Please enter a title...");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByTitleKeyword(ref BookList, Input));
            }

            if (TorA=="author")
            {
                Console.WriteLine("Please enter an author...");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByAuthor(ref BookList, Input));
            }
        }
    }
}
