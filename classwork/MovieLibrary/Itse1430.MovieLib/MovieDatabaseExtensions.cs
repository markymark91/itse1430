using System;

namespace Itse1430.MovieLib
{
    public static class MovieDatabaseExtensions
    {
        public static void Seed (IMovieDatabase database)
        {
            database.Add (new Movie () {
                Title = "Airplane",
                ReleaseYear = 1993,
                Rating = "R",
            });
            database.Add (new Movie () {
                Title = "Jaws",
                ReleaseYear = 1979,
                Rating = "PG",
            });
            database.Add (new Movie () {
                Title = "Young Frankenstein",
                ReleaseYear = 1952,
                Rating = "R",
            });
        }
    }
}
