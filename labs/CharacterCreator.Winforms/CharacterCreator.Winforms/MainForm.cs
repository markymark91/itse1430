/*
 * ITSE 1430
 * Lab 3
 * Mark Dobbins
 */

using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent ();
            //Character character = new Character ();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad (e);

            _characters = new MemoryCharacterRoster ();
            var count = _characters.GetAll ().Count ();

            UpdateUI ();
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
                _characters.Add (form.Character);
                UpdateUI ();
            }
        }

        /// <summary>
        /// Updates the UI after a character is added, editted, or deleted
        /// </summary>
        private void UpdateUI ()
        {
            var characters = _characters.GetAll ()
                                        .OrderBy (c => c.Name)
                                        .ThenBy (c => c.Profession);
            _lstCharacters.DataSource = characters.ToArray();
        }


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
                _characters.Update (character.Id, form.Character);
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
            _characters.Delete (character.Id);
            UpdateUI ();
        }
        private ICharacterRoster _characters;
    }
}
