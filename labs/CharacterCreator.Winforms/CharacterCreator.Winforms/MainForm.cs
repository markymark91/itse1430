using System;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent ();
            Character character = new Character ();
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

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterForm ();

            //Modeless - does not block main window
            //form.Show();

            //Show the new movie form modally
            if (form.ShowDialog (this) == DialogResult.OK)
            {
                AddCharacter (form.Character);
                UpdateUI ();
            }
        }
        private void UpdateUI ()
        {
            var characters = GetCharacters ();

            /*Programmatic approach 
            _lstMovies.Items.Clear ();
            _lstMovies.Items.AddRange (movies);
            */

            _lstCharacters.DataSource = characters;

        }
        private void AddCharacter ( Character character )
        {
            //Add to array
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == null)
                {
                    _characters[index] = character;
                    return;
                };
            };
        }
        private Character[] GetCharacters ()
        {
            //filter out empty movies
            var count = 0;
            foreach (var movie in _characters)
                if (movie != null)
                    ++count;

            var index = 0;
            var movies = new Character[count];
            foreach (var movie in _characters)
                if (movie != null)
                    movies[index++] = movie;

            return movies;
        }

        private Character[] _characters = new Character[100];
    }
}
