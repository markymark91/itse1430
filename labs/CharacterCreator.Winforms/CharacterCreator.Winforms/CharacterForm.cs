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
                return;

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
    }
}
