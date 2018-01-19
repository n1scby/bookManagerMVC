using System;
using System.Collections.Generic;
using System.Text;

namespace nb.BookLibrary
{
    public class BookRepository
    {
        static List<Book> Books = new List<Book>();
        static int nextNum = 0;


        public void Add(Book newBook)
        {
            newBook.Id = nextNum++;
            Books.Add(newBook);
        }

        public Book getBookById(int id)
        {
            return Books.Find(b => b.Id == id);
        }


        public void Delete(int id)
        {
            Book delBook = getBookById(id);
            Books.Remove(delBook);

        }

        public void Edit(Book editBook)
        {
            Book origBook = getBookById(editBook.Id);
            origBook.Title = editBook.Title;
            origBook.Author = editBook.Author;

        }

        public List<Book> ListBooks()
        {
            return Books;
        }
    }
}
