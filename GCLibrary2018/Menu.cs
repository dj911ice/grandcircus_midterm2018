using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCLibrary2018
{
    class Menu
    {
        public static void GCLMenu ()
        {
            Console.WriteLine("Welcome to the Grand Circus Library!\n\n[1] Display Library\n[2] Search Library\n[3] Checkout a Book\n[4] Return a Book\n[5] Exit Library");
        }

        public static void PrintTitles (List<Book>BookList)
        {
            foreach (Book b in BookList)
            {
                Console.WriteLine(b.title);
            }
        }
    }
}
