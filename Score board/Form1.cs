using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Score_board
{
    public partial class Login : Form
    {

        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCommand;
        private DataTable sqlDT = new DataTable();
        private DataSet DS = new DataSet();
        private SQLiteDataAdapter DB;


        public  Login()
        {
            InitializeComponent();
        }

        private void SetConnection()
        {
            sqlConn = new SQLiteConnection("Data Source=C:\\Users\\Terrence\\Documents\\Visual Studio 2015\\Projects\\Scoreboard.db");
        }

        private void exceuteQuery(String stringQuery)
        {
            SetConnection();
            sqlConn.Open();
            sqlCommand = sqlConn.CreateCommand();
            sqlCommand.CommandText = stringQuery;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConn.Close();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetConnection();
            sqlConn.Open();
            String CommandText = "select * from users WHERE Username='"+ txtUsername.Text +"' AND Password='"+ txtPassword.Text +"'";
            DB = new SQLiteDataAdapter(CommandText, sqlConn);
            DS.Reset();
            DB.Fill(DS);

            if(DS.Tables[0].Rows.Count > 0)
            {
                this.Hide();
                var form2 = new frmDashboard();
                form2.Closed += (s, args) => this.Close();
                form2.Show();


            }
            else
            {
                MessageBox.Show("Unfortunately User doesn't exist", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            sqlConn.Close();

            
        }
    } 

}
