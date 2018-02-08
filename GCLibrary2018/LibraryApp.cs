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
                DateTime dt = DateTime.Now;
                Book newBook = new Book(BookInfo[0], BookInfo[1], dt, Test);
                
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

        public static List<Book> LookByAuthor(List<Book> Books,string Author)
        {
            List<Book> authorbooks = new List<Book>();
            foreach (var book in Books)
            {
                if (book.author.Contains(Author))
                    authorbooks.Add(book);   
            }
            return authorbooks;
        }

        public static List<Book> LookByTitleKeyword (List<Book> Books, string keyword)
        {
            List<Book> authorbooks = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.title.Contains(keyword))
                    authorbooks.Add(book);
            }
            return authorbooks;
        }

        public static void IwantTheBook (Book book)
        {
            if (book.status == BookStatus.CheckedOut)
                Console.WriteLine($"Sorry this book is checked out, the return day is {book.duedate}");
            else
            {
                DateTime duedate = DateTime.Now;
                book.status = BookStatus.CheckedOut;
                book.duedate = duedate.AddDays(14);
            }
        }



    }
}