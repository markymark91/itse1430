using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent ();
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad (e);

            if(Character!= null)
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

        private void OnSave (object sender, EventArgs e)
        {
            if (!ValidateChildren ())
                return;
            var character = new Character ();
            character.Name = _txtName.Text;
            character.Description = _txtDescription.Text;
            character.Strength = GetAsInt32 (_txtStrength);
            character.Intelligence = GetAsInt32 (_txtIntelligence);
            character.Dexterity = GetAsInt32 (_txtDexterity);
            character.Piety = GetAsInt32 (_txtPiety);
            character.Vitality = GetAsInt32 (_txtVitality);
            character.Race = cbRace.Text;
            character.Profession = cbProfession.Text;

            var message = character.Validate ();
            if (!String.IsNullOrEmpty (message))
            {
                MessageBox.Show (this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Character = character;

            DialogResult = DialogResult.OK;
            Close ();

        }

        private int GetAsInt32 (TextBox control)
        {
            if (Int32.TryParse (control.Text, out var result))
                return result;
            return 0;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close ();
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Name is required");
            }

        }
        private void OnValidatingRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Race is required");
            }
        }
        private void OnValidatingProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (control.Text == "")
            {
                e.Cancel = true;
                _errors.SetError (control, "Profession is required");
            }
        }
        private void OnValidatingStat ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetAsInt32 (control);
            if (value < 0 || value > 100)
            {
                e.Cancel = true;
                _errors.SetError (control, "Your stat can't be lower than 0 or greater than 100");
            }
        }
    }
}
/*private void OnValidatingRunLength ( object sender, CancelEventArgs e )
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
*/