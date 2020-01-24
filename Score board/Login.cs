using System;
using System.Data;
using System.Windows.Forms;


namespace Score_board
{
    public partial class Login : Form
    {
        private model.User user = new model.User();
        public  Login()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            if (user.IsUser(txtUsername.Text,txtPassword.Text))
            {
                this.Hide();
                var form2 = new frmDashboard();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Unfortunately User doesn't exist", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                  
        }
    } 

}
