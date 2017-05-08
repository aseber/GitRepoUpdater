using System;
using System.Windows.Forms;

namespace GitRepoUpdater.Gui
{
    public partial class LoginDialog : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClicked(object sender, EventArgs e)
        {
            Username = usernameTextField.Text;
            Password = passwordTextField.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
