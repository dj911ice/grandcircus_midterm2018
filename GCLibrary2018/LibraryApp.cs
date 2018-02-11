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
                DateTime dt = DateTime.Now;
                Book newBook = new Book(BookInfo[0], BookInfo[1], BookInfo[2], BookInfo[3]);
                
                Booklist.Add(newBook);
                CurrentLine = Reader.ReadLine(); 
            }
            Reader.Close(); 
            return Booklist;
        }

        public static void PrintBookList(ref List<Book> BookList)
        {
            Console.WriteLine(new string('=', 120));
            Console.Clear();
            foreach (Book thisBook in BookList)
            {
                if (thisBook.status == "On Shelf")
                    Console.WriteLine($"\n\t{thisBook.title} by {thisBook.author} Status: {thisBook.status}\n");
                else
                    Console.WriteLine($"\n\t{thisBook.title} by {thisBook.author} Due: {thisBook.duedate}\n");
            }
            Console.WriteLine(new string('=', 120));
        }

        public static List<Book> LookByAuthor(ref List<Book> BookList, string Author)
        {
            List<Book> authorbooks = new List<Book>();
            foreach (Book book in BookList)
            {
                if (book.author.ToLower().Contains(Author))
                    authorbooks.Add(book);   
            }
            return authorbooks;
        }

        public static List<Book> LookByTitleKeyword (ref List<Book> BookList, string keyword)
        {
            List<Book> titlebooks = new List<Book>();
            foreach (Book book in BookList)
            {
                if (book.title.ToLower().Contains(keyword))
                    titlebooks.Add(book);
            }
            return titlebooks;
        }

        public static void CheckOutBook (Book book)
        {
            if (book.status == "Checked Out")
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n\n\n\t\t\t\tSorry this book is checked out, the return day is {book.duedate}\n\n\n\n");
            }
                
            else
            {
                Console.Clear();
                DateTime dt = DateTime.Today.AddDays(14);
                book.status = "Checked Out";
                book.duedate = String.Format("{0:MM/dd/yyyy}", dt);
                Console.WriteLine($"\n\t\t\t\t\t  {book.title} is due back on {book.duedate}\n");
            }
        }

        public static void ReturnBook (Book book)
        {
            book.status = "On Shelf";
            book.duedate = DateTime.Today.ToString();
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\tThank you for not stealing our book!\n\n\n");
        }
    }
}