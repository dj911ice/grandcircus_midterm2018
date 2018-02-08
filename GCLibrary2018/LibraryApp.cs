using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GCLibrary2018
{
    class LibraryApp
    {
        public static List<Book> CreateBookList(string FileName)
        {
            List<Book> Booklist = new List<Book>();
            StreamReader Reader = new StreamReader(FileName);
            string CurrentLine = Reader.ReadLine();
            string[] BookInfo;

            while (CurrentLine != null) 
            {
                BookInfo = CurrentLine.Split(',');
                Enum.TryParse(BookInfo[3], out BookStatus Test);
                Book newBook = new Book(BookInfo[0], BookInfo[1], DateTime.Parse(BookInfo[2]), Test);
                
                Booklist.Add(newBook);
                CurrentLine = Reader.ReadLine(); 
            }
            Reader.Close(); 
            return Booklist;
        }

        public static void PrintBookList(List<Book> BookList)
        {
            Console.WriteLine(new string('x', 40));

            foreach (Book thisBook in BookList)
            {
                if (thisBook.status == BookStatus.OnShelf)
                    Console.WriteLine($"{thisBook.title} by {thisBook.author} Status: {thisBook.status}");
                else
                    Console.WriteLine($"{thisBook.title} by {thisBook.author} Due: {thisBook.duedate}");
            }
        }
    }
}