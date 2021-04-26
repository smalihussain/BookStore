using System;
using System.Linq;

namespace BookStore
{
    class Program
    {
        static int tableWidth = 90;
        static void Main(string[] args)
        {
            int[] orderBookIds = { 1, 3, 4, 6, 7 };
            double totalPrice = 0.0;
            double deliveryFee = 5.95;

            var bookList = Book.GetAllBooks().Join(Genre.GetAllGenre(),  
                                      book => book.GenreId, 
                                      genre => genre.GenreId, 
                                      (book, genre) => new 
                                      {
                                          BookId = book.BookId,
                                          Title = book.BookTitle,
                                          Author = book.Author,
                                          GenreType = genre.GenreType,
                                          UnitPrice = book.UnitPrice,
                                          Discount = genre.discount
                     
                                      }).ToList();
            // Display

            Console.Clear();
            Console.WriteLine("Welcome to Insight Book Store");
            Console.WriteLine("Your Order Summary");
            PrintLine();
            PrintRow("Title", "Quantity", "Price(ex Gst)", "Price(Inc Gst)");
            PrintLine();
            foreach(var bookId in orderBookIds)
            {
                var book = bookList.Where(b => b.BookId == bookId).FirstOrDefault();
                double price = book.UnitPrice  - Math.Round((book.UnitPrice * book.Discount/100),2);
                double priceIncGst = Math.Round(price * 1.1,2);
                PrintRow(book.Title, "1", "$"+ price.ToString(), "$" + priceIncGst.ToString());

                totalPrice += priceIncGst;
            }           
            PrintLine();
            if (totalPrice < 20)
            {
                totalPrice = totalPrice + deliveryFee;
                Console.WriteLine("Delivery Fee : " + "$" + deliveryFee);
                Console.WriteLine("Total Order Price : " + "$" + Math.Round(totalPrice,2));
            }
            else
            {
                Console.WriteLine("Total Order Price : " + "$" + Math.Round(totalPrice,2));
                Console.WriteLine("No Delivery Fee charge on order above $20 ");
            }
            Console.ReadLine();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
