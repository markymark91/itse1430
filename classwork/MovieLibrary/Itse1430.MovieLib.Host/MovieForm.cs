using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itse1430.MovieLib.Host
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent ();
        }

        //must be a property
        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad (e);

            if(Movie!= null)
            {
                _txtName.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();
                cbRating.Text = Movie.Rating;
                chkHasSeen.Checked = Movie.HasSeen;
            };
        }
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren ())
                return;
            var movie = new Movie ();
            //movie.set_title(_txtName.Text); below is same thing
            movie.Title = _txtName.Text;
            movie.Description = txtDescription.Text;
            movie.ReleaseYear = GetAsInt32 (_txtReleaseYear);
            movie.RunLength = GetAsInt32 (_txtRunLength);
            movie.Rating = cbRating.Text;
            movie.HasSeen = chkHasSeen.Checked;

            //Validate
            var message = movie.Validate ();
            if (!String.IsNullOrEmpty (message))
            {
                MessageBox.Show (this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //TODO: Error
            }

            //TODO: Save It
            Movie = movie;

            DialogResult = DialogResult.OK;
            Close ();
        }

        private int GetAsInt32(TextBox control)
        {
            if (Int32.TryParse (control.Text, out var result))
                return result;
            return 0;
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close ();
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (control.Text == "")
                e.Cancel = true;
        }

        private void OnValidatingReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetAsInt32 (control);
            if (value < 1900)
                e.Cancel = true;
        }

        private void OnValidatingRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetAsInt32 (control);
            if (value < 0)
                e.Cancel = true;
        }
        private void OnValidatingRating ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (control.SelectedText == "")
                e.Cancel = true;
        }
    }
}
