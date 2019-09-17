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
            movie.title = "Jaws";
            movie.description = movie.title;
        }

        private void AddToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            var form = new MovieForm ();

            form.ShowDialog ();
        }
    }
}
