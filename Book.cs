using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public double UnitPrice { get; set; }
        public static List<Book> GetAllBooks()
        {
            return new List<Book>()
            {
                new Book {  BookId = 1,
                            BookTitle = "Unsolved murders",
                            GenreId = 1,
                            Author = "Emily G. Thompson, Amber Hunt",
                            UnitPrice = 10.99 },
                new Book {  BookId = 2,
                            BookTitle = "Alice in Wonderland",
                            GenreId = 3,
                            Author = "Lewis Carroll",
                            UnitPrice = 5.99 },
                new Book {  BookId = 3,
                            BookTitle = "A Little Love Story",
                            GenreId = 2,
                            Author = "Roland Merullo",
                            UnitPrice = 2.4 },
                new Book {  BookId = 4,
                            BookTitle = "Heresy",
                            GenreId = 3,
                            Author = "S J Parris",
                            UnitPrice = 6.8 },
                new Book {  BookId = 5,
                            BookTitle = "The Neverending Story",
                            GenreId = 3,
                            Author = "Michael Ende",
                            UnitPrice = 7.99 },
                new Book {  BookId = 6,
                            BookTitle = "Jack the Ripper",
                            GenreId = 1,
                            Author = "Philip Sugden",
                            UnitPrice = 16.00 },
                new Book {  BookId = 7,
                            BookTitle = "The Tolkien Years",
                            GenreId = 3,
                            Author = "Greg Hildebrandt",
                            UnitPrice = 22.90}
            };
        }
    }
}
