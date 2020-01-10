using System;
using System.Data;
using System.Windows.Forms;


namespace Score_board
{
    public partial class Login : Form
    {
        private Database database = new Database();
        public  Login()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            String CommandText = "select * from users WHERE Username='"+ txtUsername.Text +"' AND Password='"+ txtPassword.Text +"'";

            DataTable DS = database.loadData(CommandText);

            if (DS.Rows.Count > 0)
            {
                this.Hide();
                var form2 = new frmDashboard();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Unfortunately User doesn't exist", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            database.SqlConn.Close();

            
        }
    } 

}
