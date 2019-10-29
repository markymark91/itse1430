using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itse1430.MovieLib
{
    /// <summary> Manages the movies in a database. </summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            //if (movie == null)
            //return null;

            //Validation
            //throw new Exception ("Movie is null");
            if (movie == null)
                throw new ArgumentNullException (nameof (movie));


            //if (!String.IsNullOrEmpty (movie.Validate ()))
            var results = ObjectValidator.TryValidateObject (movie);
            if (results.Count () > 0)
                //return null;
                throw new ValidationException (
                    results.FirstOrDefault().ErrorMessage
                    );

            //Name must be unique
            var existing = GetByNameCore (movie.Title);
            if (existing!= null)
                //return null;
                throw new InvalidOperationException ("Movie must be unique");

            return AddCore (movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException (nameof (id), "Id must be > 0");

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
                //return null;
                throw new ArgumentOutOfRangeException (nameof (id), "Id must be > 0");

            return GetCore (id);
        }

        protected abstract Movie GetCore ( int id );

        public void Update ( int id, Movie newMovie )
        {
            if (id <= 0)
                //return;
                throw new ArgumentOutOfRangeException (nameof (id), "Id must be > 0");
            if (newMovie == null)
                //return;
                throw new ArgumentNullException (nameof (newMovie));
            // if (!String.IsNullOrEmpty (newMovie.Validate()))
            //var context = new ValidationContext (newMovie);
            //var results = newMovie.Validate (context);
            var results = ObjectValidator.TryValidateObject (newMovie);
            if (results.Count () > 0)
                //return;
                throw new ValidationException (
                    results.FirstOrDefault ().ErrorMessage);

            var existing = GetByNameCore (newMovie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException ("Movie must be unique");

            UpdateCore (id, newMovie);
        }

        protected abstract Movie UpdateCore ( int id, Movie newMovie );

        protected abstract Movie GetByNameCore ( string name );

    }


}
