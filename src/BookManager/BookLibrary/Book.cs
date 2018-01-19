using System;

namespace nb.BookLibrary
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string getBookInfo()
        {
            return $"Id: {Id}  Title: {Title}  Author: {Author}";
        }

    }
}
