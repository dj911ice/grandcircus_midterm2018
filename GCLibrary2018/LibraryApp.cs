using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace GCLibrary2018
{
    class LibraryApp
    {
        // creates list of books in library from Library.txt
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

        // prints all books in library
        public static void PrintBookList(ref List<Book> BookList) 
        {
            Console.WriteLine(new string('=', 168));
            Console.Clear();
            foreach (Book thisBook in BookList)
            {
                if (thisBook.status == "On Shelf")
                    Console.WriteLine($"\n\t\t\t\t\t\t  {thisBook.title} by {thisBook.author} Status: {thisBook.status}");
                else
                    Console.WriteLine($"\n\t\t\t\t\t\t  {thisBook.title} by {thisBook.author} Due: {thisBook.duedate}");
            }
            Console.WriteLine(new string('=', 168));
        }

        // searches library by author keyword and
        // returns list of books with specified substring in author name
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

        // searches library by title keyword and
        // returns list of books with specified substring in title
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

        // changes status of book from On Shelf to Checked Out
        public static void CheckOutBook (Book book) 
        {
            if (book.status == "Checked Out")
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t\t\t\t\tSorry this book is checked out, the return day is {book.duedate}\n\n");
            }
            else
            {
                Console.Clear();
                DateTime dt = DateTime.Today.AddDays(14);
                book.status = "Checked Out";
                book.duedate = String.Format("{0:MM/dd/yyyy}", dt);
                Console.WriteLine($"\n\t\t\t\t\t\t\t\t    {book.title} is due back on {book.duedate}\n");
            }
        }

        // changes status of book from Checked Out to On Shelf
        public static void ReturnBook (Book book) 
        {
            book.status = "On Shelf";
            book.duedate = DateTime.Today.ToString();
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t    Thank you for not stealing our book!\n");
        }

        // adds donated book to library
        public static void DonateBook(ref List<Book> BookList)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\tPlease enter the title of the book\n\n");
            string DonateTitle = Console.ReadLine();
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t Please enter the author's name\n\n");
            string DonateAuthor = Console.ReadLine();

            Book Donated = new Book();
            Donated.title = DonateTitle;
            Donated.author = DonateAuthor;
            BookList.Add(Donated);

            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\tThank you for your donation!");
        }
    }
}