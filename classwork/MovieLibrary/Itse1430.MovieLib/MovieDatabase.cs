using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    /// <summary> Manages the movies in a database. </summary>
    public class MovieDatabase
    {
        public MovieDatabase ()
        {
            _movies = new List<Movie> () {
                new Movie () {
                Id = ++_id,
                Title = "Airplane",
                ReleaseYear = 1993,
                Rating = "R",
            },
                new Movie () {
                Id = ++_id,
                Title = "Jaws",
                ReleaseYear = 1979,
                Rating = "PG",
            },
                new Movie () {
                Id = ++_id,
                Title = "Young Frankenstein",
                ReleaseYear = 1952,
                Rating = "R",
            }

        };
            //var movie = new Movie () {
            //    Id = ++_id,
            //    Title = "Jaws",
            //    ReleaseYear = 1979,
            //    Rating = "PG", 
            //};
            ////Add (movie);
            //_movies.Add (movie);

            //movie = new Movie () {
            //    Id = ++_id,
            //    Title = "Young Frankenstein",
            //    ReleaseYear = 1952,
            //    Rating = "R",
            //};
            ////Add (movie);
            //_movies.Add (movie);

            ///*
            //movie = new Movie () {
            //    Id = ++_id,
            //    Title = "Airplane",
            //    ReleaseYear = 1993,
            //    Rating = "R",
            //};*/
            ////Add (movie);
            //_movies.Add (movie);
        }
        public Movie Add ( Movie movie )
        {
            //TODO: Validation
            if (movie == null)
                return null;
            if (!String.IsNullOrEmpty (movie.Validate ()))
                return null;

            //Name must be unique
            var existing = FindMovie (movie.Title);
            if (existing!= null)
                return null;

            //Add movie
            movie.Id = ++_id;
            var newMovie = Clone (new Movie (), movie);
            _movies.Add (newMovie);

            return movie;
        }

        public void Remove ( int id )
        {
            var movie = FindMovie (id);
            if(movie != null)
                _movies.Remove (movie);
        }

        public Movie[] GetAll ()
        {
            ////filter out empty movies
            //var count = 0;
            //foreach (var movie in _movies)
            //    if (movie != null)
            //        ++count;

            var index = 0;
            var movies = new Movie[_movies.Count];
            foreach (var movie in _movies)
                if (movie != null)
                    movies[index++] = Clone (new Movie (), movie);

            return movies;
        }

        public Movie Get (int id)
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            var movie = FindMovie (id);
            return movie != null ? Clone (new Movie (), movie) : null;
        }

        public void Update( int id, Movie newMovie)
        {
            if (id <= 0)
                return;
            if (newMovie == null)
                return;
            if (!String.IsNullOrEmpty (newMovie.Validate()))
                return;

            var existing = FindMovie (newMovie.Title);
            if (existing != null && existing.Id != id)
                return;

            existing = FindMovie (id);
            if (existing == null)
                return;//TODO: Error

            //update existing movie
            newMovie.Id = id;
            Clone (existing, newMovie);

            //_movies.Remove (movie);
            //_movies.Add (movie);
        }

        private Movie Clone (Movie target, Movie source)
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

        private Movie FindMovie(int id)
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }
        private Movie FindMovie ( string name )
        {
            foreach (var movie in _movies)
                if (String.Compare(movie.Title, name, true) == 0)
                    return movie;

            return null;
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie> ();

        private int _id = 0;
    }

    
}
