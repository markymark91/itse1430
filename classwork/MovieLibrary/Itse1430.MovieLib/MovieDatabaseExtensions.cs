using System;

namespace Itse1430.MovieLib
{
    public static class MovieDatabaseExtensions
    {
        public static void Seed (this IMovieDatabase source)
        {
            source.Add (new Movie () {
                Title = "Airplane",
                ReleaseYear = 1993,
                Rating = "R",
            });
            source.Add (new Movie () {
                Title = "Jaws",
                ReleaseYear = 1979,
                Rating = "PG",
            });
            source.Add (new Movie () {
                Title = "Young Frankenstein",
                ReleaseYear = 1952,
                Rating = "R",
            });
        }
    }
}
