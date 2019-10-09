using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Itse1430.MovieLib.Host
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent ();

            //Itse1430.MovieLib.Movie
            Movie movie = new Movie ();
            movie.Title = "Jaws";
            movie.Description = movie.Title;
        }

        //Called when Movie\Add selected
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm ();

            //Modeless - does not block main window
            //form.Show();

            //Show the new movie form modally
            if (form.ShowDialog (this) == DialogResult.OK)
            {
                _movies.Add (form.Movie);
                UpdateUI ();
            }
        }

        private Movie GetSelectedMovie ()
        {
            var item = _lstMovies.SelectedItem;
            //if (item == null)
            //    return null;
            //return _movies[0];
            //Movie or null
            return item as Movie;

            /*other approaches
             * c-style cast
             * (Movie)item;
             * 
             * if (item is Movie;)
             * {
             *  var i = (Movie)item;
             *  //do something with movie
             * }
             */

            /*pattern matching
             * if(item is Movie movie)
             * {
             * };
             */
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie ();
            if (movie == null)
                return;

            var form = new MovieForm ();
            form.Movie = movie;

            if (form.ShowDialog (this) == DialogResult.OK)
            {
                _movies.Update (movie.Id, form.Movie);
                UpdateUI ();
            };
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //demo
            var menuItem = sender as Button;
            //this will crash if menuItem is null
            //var text = menuItem.Text;

            //handle null
            var text = "";
            if (menuItem != null)
                text = menuItem.Text;
            else
                text = "";

            //as expression
            var text2 = (menuItem != null) ? menuItem.Text : "";

            //null coalescing. menuItem ?? "";
            //null conditional operator
            var text3 = menuItem?.Text ?? "";

            var movie = GetSelectedMovie ();
            if (movie == null)
                return;

            //Confirmation
            var msg = $"Are you sure you want to delete {movie.Title}?";
            var result = MessageBox.Show (msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //Delete it
            _movies.Remove (movie.Id);
            UpdateUI ();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close ();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutForm ();
            form.ShowDialog (this);
        }


        private void UpdateUI()
        {
            var movies = _movies.GetAll ();

            /*Programmatic approach 
            _lstMovies.Items.Clear ();
            _lstMovies.Items.AddRange (movies);
            */

            _lstMovies.DataSource = movies;

        }

        //private Movie[] _movies = new Movie[100];
        private MovieDatabase _movies = new MovieDatabase ();
    }
}
