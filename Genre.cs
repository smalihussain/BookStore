using System.Collections.Generic;

namespace BookStore
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreType { get; set; }
        public double discount { get; set; }

        public static List<Genre> GetAllGenre()
        {
            return new List<Genre>()
            {
                new Genre() { GenreId = 1, GenreType = "Crime", discount = 5.0 },
                new Genre() { GenreId = 2, GenreType = "Romance", discount = 0.0 },
                new Genre() { GenreId = 3, GenreType = "Fantasy", discount = 0.0 }
            };
        }

        public bool AddGenre(Genre genre)
        {
            return true;
        }
    }
}