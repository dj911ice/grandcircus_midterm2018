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
        public static bool Continue(string Input)
        {
            while (true)
            {
                if (Regex.Match(Input, "^(y|yes|Y|Yes)$").Success)
                {
                    return true;
                }
                else if (Regex.Match(Input, "^(n|no|N|No)$").Success)
                    return false;
                else
                {
                    Console.WriteLine("I didn't understand that. Try again!");
                    Input = Console.ReadLine();
                }
            }
        }
        public static void Search(ref List<Book>BookList)
        {
            Console.WriteLine("Do you want to search by Title or Author?");
            if (Console.ReadLine().ToLower()=="title")
            {
                Console.WriteLine("Please enter a title...");
                string Input = Console.ReadLine();
                LibraryApp.LookByTitleKeyword(ref BookList, Input);
            }
            else if (Console.ReadLine().ToLower()=="author")
            {
                Console.WriteLine("Please enter an author...");
                string Input = Console.ReadLine();
                LibraryApp.LookByAuthor(ref BookList, Input);
            }
        }
    }
}
