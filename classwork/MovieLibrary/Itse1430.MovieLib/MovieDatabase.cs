using System;
using System.Collections.Generic;
using System.Linq;

namespace Itse1430.MovieLib
{
    /// <summary> Manages the movies in a database. </summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            //TODO: Validation
            if (movie == null)
                return null;


            //if (!String.IsNullOrEmpty (movie.Validate ()))
            var results = ObjectValidator.TryValidateObject (movie);
            if (results.Count () > 0)
                return null;

            //Name must be unique
            var existing = GetByNameCore (movie.Title);
            if (existing!= null)
                return null;

            return AddCore (movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Remove ( int id )
        {
                RemoveCore (id);
        }

        protected abstract void RemoveCore ( int id );

        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore ();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();
        public Movie Get ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            return GetCore (id);
        }

        protected abstract Movie GetCore ( int id );

        public void Update ( int id, Movie newMovie )
        {
            if (id <= 0)
                return;
            if (newMovie == null)
                return;
            // if (!String.IsNullOrEmpty (newMovie.Validate()))
            //var context = new ValidationContext (newMovie);
            //var results = newMovie.Validate (context);
            var results = ObjectValidator.TryValidateObject (newMovie);
            if (results.Count () > 0)
                return;

            var existing = GetByNameCore (newMovie.Title);
            if (existing != null && existing.Id != id)
                return;

            UpdateCore (id, newMovie);
        }

        protected abstract Movie UpdateCore ( int id, Movie newMovie );

        protected abstract Movie GetByNameCore ( string name );

    }


}
