using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    /// <summary> Manages the movies in a database. </summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //Add movie
            movie.Id = ++_id;
            var newMovie = Clone (new Movie (), movie);
            _movies.Add (newMovie);

            return movie;
        }

        protected override void RemoveCore ( int id )
        {
            var movie = FindMovie (id);
            if (movie != null)
                _movies.Remove (movie);
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            foreach (var movie in _movies)
                yield return Clone (new Movie (), movie);
        }

        protected override Movie GetCore ( int id )
        {
            var movie = FindMovie (id);
            return movie != null ? Clone (new Movie (), movie) : null;
        }
        protected override Movie UpdateCore ( int id, Movie newMovie )
        {
            var existing = FindMovie (id);
            if (existing == null)
                return null;//TODO: Error

            //update existing movie
            newMovie.Id = id;
            Clone (existing, newMovie);

            return newMovie;
            //_movies.Remove (movie);
            //_movies.Add (movie);}
        }
        private Movie Clone ( Movie target, Movie source )
        {
            target.Id = source.Id;
            target.Description = source.Description;
            target.HasSeen = source.HasSeen;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.Title = source.Title;

            return target;
        }

        private Movie FindMovie ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        protected override Movie GetByNameCore ( string name )
        {
            foreach (var movie in _movies)
                if (String.Compare (movie.Title, name, true) == 0)
                return movie;

            return null;
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie> ();

        private int _id = 0;
    }


}
