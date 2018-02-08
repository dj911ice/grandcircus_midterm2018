using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCLibrary2018
{

    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string duedate { get; set; }
        public BookStatus status { get; set; }

        public Book(string Title, string Author, DateTime dt, BookStatus Status)
        {
            title = Title;
            author = Author;
            duedate = String.Format("{0:MM/dd/yyyy}", dt);
            status = Status;
        }

        public Book()
        {
            title = "";
            author = "";
            duedate = DateTime.Now.ToString();
            status = BookStatus.OnShelf;
        }
    }
}
