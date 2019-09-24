using System;
using System.Windows.Forms;

namespace Itse1430.MovieLib.Host
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            //int x = 10;
            InitializeComponent ();
            //Itse1430.MovieLib.Movie

            Movie movie = new Movie ();
            movie.Title = "Jaws";
            movie.Description = movie.Title;
        }

        
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm ();

            //Modeless - does not block main window
            //form.Show();

            //Show the new movie form modally
            if(form.ShowDialog (this) == DialogResult.OK)
            //TODO: Save it
            _movie = form.Movie;
        }

        private Movie _movie;

        private void OnMovieEdit ( object sender, EventArgs e )
        {

        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {

        }

        private void OnFileExit ( object sender, EventArgs e )
        {

        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {

        }
    }
}
