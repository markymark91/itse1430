/*
 * ITSE 1430
 * Lab 4
 * Mark Dobbins
 * CharacterForm.cs
 */

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        //Constructor
        public CharacterForm ()
        {
            InitializeComponent ();
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad (e);

            if(Character != null)
            {
                _txtName.Text = Character.Name;
                _txtDescription.Text = Character.Description;
                _txtDexterity.Text = Character.Dexterity.ToString ();
                _txtIntelligence.Text = Character.Intelligence.ToString ();
                _txtStrength.Text = Character.Strength.ToString ();
                _txtPiety.Text = Character.Piety.ToString ();
                _txtVitality.Text = Character.Vitality.ToString ();
                cbProfession.Text = Character.Profession;
                cbRace.Text = Character.Race;
            };
        }

        /// <summary>
        /// When the user selects Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren ())
                return;

            var character = new Character () 
            {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Strength = GetAsInt32 (_txtStrength),
                Intelligence = GetAsInt32 (_txtIntelligence),
                Dexterity = GetAsInt32 (_txtDexterity),
                Piety = GetAsInt32 (_txtPiety),
                Vitality = GetAsInt32 (_txtVitality),
                Race = cbRace.Text,
                Profession = cbProfession.Text
            };

            if (!Validate (character))
                return;

            Character = character;

            DialogResult = DialogResult.OK;
            Close ();

        }

        private bool Validate(IValidatableObject character)
        {
            var results = ObjectValidator.TryValidateObject (character);
            if(results.Count() > 0)
            {
                foreach (var result in results)
                {
                    MessageBox.Show (this, result.ErrorMessage, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                };
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the string and converts to integer
        /// </summary>
        private int GetAsInt32 (TextBox control)
        {
            if (Int32.TryParse (control.Text, out var result))
                return result;
            return 0;
        }

        /// <summary>
        /// //When the user selects Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close ();
        }

        /// <summary>
        ///  //Name Validation to ensure user entered a Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Name is required");
            } 
            else
            {
                _errors.SetError (control, "");
            }

        }

        /// <summary>
        /// Race Validation to ensure user selected a Race
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Race is required");
            } 
            else
            {
                _errors.SetError (control, "");
            }
        }

        /// <summary>
        /// Profession validation to ensure the user selected a Profession
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Profession is required");
            } 
            else
            {
                _errors.SetError (control, "");
            }
        }

        /// <summary>
        /// Stat validation to ensure user entered a value no greater than 100 or less than 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingStat ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetAsInt32 (control);
            if (value < 0 || value > 100)
            {
                e.Cancel = true;
                _errors.SetError (control, "Your stat can't be lower than 0 or greater than 100");
            } 
            else
            {
                _errors.SetError (control, "");
            }
        }
    }
}
