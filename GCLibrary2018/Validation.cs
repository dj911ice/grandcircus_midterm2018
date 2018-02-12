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
            Console.Clear();
            int z = 1;
            foreach (Book x in BookList)
            {
                Console.Write($"\n\t{z}..... {x.title} by {x.author}\n");
                z++;
            }

            Console.WriteLine("\n\n\tWhich book would you like to checkout? ( 1 - 12 )\n\n");
            string input = Console.ReadLine();
            int.TryParse(input, out int BookIndex);
            while (true)
            {
                if (BookIndex > 0 && BookIndex <= 12)
                    return BookList[BookIndex-1];
                else
                {
                    Console.WriteLine("\nI didn't understand. Try again!");
                    int.TryParse(Console.ReadLine(), out BookIndex);
                }
            }
        }

        public static Book ConfirmReturn(ref List<Book> BookList)
        {
            List<Book> CheckedOut = new List<Book>();
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].status == "Checked Out")
                {
                    CheckedOut.Add(BookList[i]);
                }
            }
            if (CheckedOut.Count == 0)
                return null;
            else
            {
                int z = 1;
                foreach (Book x in CheckedOut)
                {
                    Console.WriteLine($"\n{z}..... {x.title} by {x.author}\n");
                    z++;
                }
                Console.WriteLine($"\n\nWhich book would you like to return? ( 1 - {z-1} )\n\n");
                string input = Console.ReadLine();

                int.TryParse(input, out int BookIndex);
                while (true)
                {
                    if (BookIndex > 0 && BookIndex <= CheckedOut.Count)
                        return CheckedOut[BookIndex - 1];
                    else
                    {
                        Console.WriteLine("I didn't understand. Try again!");
                        int.TryParse(Console.ReadLine(), out BookIndex);
                    }
                }
            }  
        }

        public static void Search(ref List<Book>BookList)
        {
            Console.Clear();
            Console.WriteLine("\n\nDo you want to search by Title or Author? (t/a)\n");
            string TorA = Console.ReadLine().ToLower();
            if (Regex.IsMatch(TorA, "^(t|title)$"))
            {
                Console.WriteLine("\n\nPlease enter a title, word, or keyword!\n\n");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByTitleKeyword(ref BookList, Input));
            }

            if (Regex.IsMatch(TorA, "^(a|author)$"))
            {
                Console.WriteLine("\n\nPlease enter a name or keyword\n\n");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByAuthor(ref BookList, Input));
            }
        }
    }
}
