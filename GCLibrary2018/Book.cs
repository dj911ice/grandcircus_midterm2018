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
        public DateTime duedate { get; set; }
        public BookStatus status { get; set; }

        public Book(string Title, string Author, DateTime DueDate, BookStatus Status)
        {
            title = Title;
            author = Author;
            duedate = DueDate;
            status = Status;
        }

        public Book()
        {
            title = "";
            author = "";
            duedate = DateTime.MinValue;
            status = BookStatus.OnShelf;
        }
    }
}
