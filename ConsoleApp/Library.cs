using System;
using System.Collections;
using System.Collections.Generic;

namespace LibraryExample
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({Year})";
        }
    }

    public class Library : IEnumerable<Book>
    {
        private List<Book> books = new();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Library library = new Library();
    //         library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
    //         library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
    //         library.AddBook(new Book("1984", "George Orwell", 1949));

    //         Console.WriteLine("Books in the library:");
    //         foreach (Book book in library)
    //         {
    //             Console.WriteLine(book);
    //         }
    //     }
    // }
}
