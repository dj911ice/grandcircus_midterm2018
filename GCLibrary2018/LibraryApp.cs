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
    }
}