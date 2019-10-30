using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib.IO
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase(string filePath)
        {
            //TODO: Validation
            _filePath = filePath;
        }
        protected override Movie AddCore ( Movie movie )
        {
            var movies = GetAllCore ().ToList();

            //figure out highest ID
            if (movies.Any ())
                movie.Id = movies.Max (m => m.Id) + 1;
            else
                movie.Id = 1;

            movies.Add (movie);
            SaveMovies (movies);

            return movie;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            if (File.Exists (_filePath))
            {
                var lines = File.ReadAllLines (_filePath);
                foreach (var line in lines)
                {

                };
            };
            yield return new Movie ();
        }

        private readonly string _filePath;
        protected override Movie GetByNameCore ( string name )
        { throw new NotImplementedException (); }

        protected override Movie GetCore ( int id )
        { throw new NotImplementedException (); }

        protected override void RemoveCore ( int id )
        { throw new NotImplementedException (); }

        protected override Movie UpdateCore ( int id, Movie newMovie )
        { throw new NotImplementedException (); }
        private void SaveMovies (IEnumerable<Movie> items)
        {
            var lines = items.Select (i => SaveMovie (i)).ToArray();
            File.WriteAllLines (_filePath, lines);
        }

        private string SaveMovie(Movie item)
        {
            //Field,Field2,...
            return $"{item.Id},\"{item.Title}\",\"{item.Description}\"," +
                $"{item.Rating},{item.ReleaseYear}," +
                $"{item.RunLength},{item.HasSeen}";
        }
    }
}
