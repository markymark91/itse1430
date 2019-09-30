using System;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent ();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close ();
        }

        private void AboutToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            var form = new AboutForm ();
            form.ShowDialog (this);
        }
    }
}
