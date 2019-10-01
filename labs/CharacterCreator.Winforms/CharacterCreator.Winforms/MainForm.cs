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

            if (form.ShowDialog (this) == DialogResult.OK)
            {
                AddCharacter (form.Character);
                UpdateUI ();
            }
        }
        private void UpdateUI ()
        {
            var characters = GetCharacters ();
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

        private void RemoveCharacter ( Character character )
        {
            //Remove from array
            for (var index = 0; index < _characters.Length; ++index)
            {
                //This won't work
                if (_characters[index] == character)
                {
                    _characters[index] = null;
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

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            //Get selected movie
            var character = GetSelectedCharacter ();
            if (character == null)
                return;

            var form = new CharacterForm ();
            form.Text = "Edit Character";
            form.Character = character;

            if (form.ShowDialog (this) == DialogResult.OK)
            {
                //TODO: Change to update
                RemoveCharacter (character);
                //RemoveMovie (form.Movie);
                AddCharacter (form.Character);
                UpdateUI ();
            };
        }
        private Character GetSelectedCharacter ()
        {
            var item = _lstCharacters.SelectedItem;
            return item as Character;
        }
    }
}
