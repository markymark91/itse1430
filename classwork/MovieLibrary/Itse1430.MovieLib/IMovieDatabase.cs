using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie );
        Movie Get ( int id );

        /// <summary> Gets all movies. </summary>
        /// <returns> Returns the movies. </returns>
        IEnumerable<Movie> GetAll ();
        void Remove ( int id );
        void Update ( int id, Movie newMovie );
    }
}