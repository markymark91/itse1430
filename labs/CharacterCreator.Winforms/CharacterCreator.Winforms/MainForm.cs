/*
 * ITSE 1430
 * Lab 2
 * Mark Dobbins
 */

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

        //When the user selects Exit
        private void OnFileExit ( object sender, EventArgs e )
        {
            Close ();
        }

        //When the user selects About
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutForm ();
            form.ShowDialog (this);
        }

        //When the user selects New to create a new character
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterForm ();

            if (form.ShowDialog (this) == DialogResult.OK)
            {
                AddCharacter (form.Character);
                UpdateUI ();
            }
        }

        /// <summary>
        /// Updates the UI after a character is added, editted, or deleted
        /// </summary>
        private void UpdateUI ()
        {
            var characters = GetCharacters ();
            _lstCharacters.DataSource = characters;
        }

        /// <summary>
        /// Adds a character to the _characters array
        /// </summary>
        /// <param name="character"></param>
        private void AddCharacter ( Character character )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == null)
                {
                    _characters[index] = character;
                    return;
                };
            };
        }

        /// <summary>
        /// Removes a character from the _characters array by setting it to null
        /// </summary>
        /// <param name="character"></param>
        private void RemoveCharacter ( Character character )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == character)
                {
                    _characters[index] = null;
                    return;
                };
            };
        }

        /// <summary>
        /// Gets the current list of characters. Used whenever UI is updated
        /// </summary>
        /// <returns></returns>
        private Character[] GetCharacters ()
        {
            var count = 0;
            foreach (var character in _characters)
                if (character != null)
                    ++count;

            var index = 0;
            var characters = new Character[count];
            foreach (var character in _characters)
                if (character != null)
                    characters[index++] = character;

            return characters;
        }

        //Array of characters, with a max number of characters set to 100
        private Character[] _characters = new Character[100];

        /// <summary>
        /// When the user edits a character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter ();
            if (character == null)
                return;
            //Changes the name of the form to Edit Character and auto fills the fields with that character's information
            var form = new CharacterForm ();
            form.Text = "Edit Character";
            form.Character = character;

            if (form.ShowDialog (this) == DialogResult.OK)
            {
                RemoveCharacter (character);
                AddCharacter (form.Character);
                UpdateUI ();
            };
        }

        /// <summary>
        /// Gets the character the user wishes to select
        /// </summary>
        /// <returns> returns the character selected by the user </returns>
        private Character GetSelectedCharacter ()
        {
            var item = _lstCharacters.SelectedItem;
            return item as Character;
        }

        /// <summary>
        /// When the user wants to delete a character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter ();
            if (character == null)
                return;

            //Confirmation
            var msg = $"Are you sure you want to delete {character.Name}?";
            var result = MessageBox.Show (msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //Delete
            RemoveCharacter (character);
            UpdateUI ();
        }
    }
}
