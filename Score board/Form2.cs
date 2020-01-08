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
using System.IO;



namespace Score_board
{
    public partial class frmDashboard : Form
    {

        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        private DataTable sqlDT = new DataTable();
        private DataSet DS = new DataSet();
        private SQLiteDataAdapter DB;
        private string absolutepath;
        private frmScoreboard scoreboard = new frmScoreboard();
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void SetConnection()
        {
            sqlConn = new SQLiteConnection("Data Source=C:\\Users\\Terrence\\Documents\\Visual Studio 2015\\Projects\\Scoreboard.db");
        }

        private void LoadData()
        {
            SetConnection();
            sqlConn.Open();
            String CommandText = "select * from teams ORDER BY Score DESC";
            DB = new SQLiteDataAdapter(CommandText, sqlConn);
            DS.Reset();
            DB.Fill(DS);
            this.sqlDT = DS.Tables[0];
            dataGridView1.DataSource = DS.Tables[0];
            sqlConn.Close();
        }

        private void executeQuery(String stringQuery)
        {

            SetConnection();
            sqlConn.Open();
            sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = stringQuery;
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Dispose();
            sqlConn.Close();

        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {

            for (int i = -5; i <= 20; i++)
            {
                this.cmbAddPoints.Items.Add(i);
            }
            LoadData();
        }

        private void loadToTextBoxes(String Team)
        {
            SetConnection();
            sqlConn.Open();
            DB = new SQLiteDataAdapter(Team, sqlConn);
            DS.Reset();
            DB.Fill(DS);
            txtScore.Text = DS.Tables[0].Rows[0][3].ToString();
            cmbStatus.Text = DS.Tables[0].Rows[0][4].ToString();
            sqlConn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
                {
                    txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtTeam.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtScore.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    cmbStatus.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    //String absolutePath = absolutePath()
                    absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "");


                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                    txtTeam.Text = dataGridView1.Rows[e.RowIndex].Cells["Team"].FormattedValue.ToString();
                    txtScore.Text = dataGridView1.Rows[e.RowIndex].Cells["Score"].FormattedValue.ToString();
                    cmbStatus.Text = dataGridView1.Rows[e.RowIndex].Cells["Status"].FormattedValue.ToString();

                    absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + dataGridView1.Rows[e.RowIndex].Cells["Image"].FormattedValue.ToString() + "");
                }

                Console.WriteLine(absolutepath);
                pictureBox2.Image = System.Drawing.Image.FromFile(absolutepath);

            }
            catch (Exception)
            {

            }
        }

        private void txtTeam_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (cmbAddPoints.SelectedIndex != -1 || !string.IsNullOrEmpty(cmbAddPoints.Text))
                {
                    String pointsQuery = "UPDATE teams SET Score = Score+" + cmbAddPoints.Text + " WHERE ID=" + txtID.Text;
                    executeQuery(pointsQuery);

                    loadToTextBoxes("select * from teams where ID=" + txtID.Text);
                    LoadData();
                    reloadScoreboard();
                }
                else
                {

                    MessageBox.Show("Please assign points first", "Points Not Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Please Select Team First From Table!", "Team Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DiableEnableTeam(String status)
        {

            String enableDiableTeamQuery = "UPDATE teams SET Status='" + status + "' WHERE ID=" + txtID.Text;
            executeQuery(enableDiableTeamQuery);

            loadToTextBoxes("select * from teams where ID=" + txtID.Text);
            LoadData();

        }

        private void btnDisable_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                DiableEnableTeam("Disabled");
            }
            else
            {
                MessageBox.Show("Please Select Team From Table First", "Team Not Selected Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                DiableEnableTeam("Enabled");
            }
            else
            {
                MessageBox.Show("Please Select Team From Table First", "Team Not Selected Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(opnfd.FileName);
                String name = Path.GetFileName(opnfd.FileName);
                File.Copy(opnfd.FileName, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + name + ""), true);
                String stringUpdatePicture = "UPDATE teams SET Image='" + name + "' WHERE ID=" + txtID.Text;
                executeQuery(stringUpdatePicture);
                loadToTextBoxes("select * from teams where ID=" + txtID.Text);
                LoadData();
            }
        }

        private void reloadScoreboard()
        {


            this.scoreboard.teamLabelScore1.Text = this.sqlDT.Rows[0][3].ToString();
            this.scoreboard.teamLabelScore2.Text = this.sqlDT.Rows[1][3].ToString();
            this.scoreboard.teamLabelScore3.Text = this.sqlDT.Rows[2][3].ToString();
            this.scoreboard.teamLabelScore4.Text = this.sqlDT.Rows[3][3].ToString();
            this.scoreboard.teamLabelScore5.Text = this.sqlDT.Rows[4][3].ToString();
            this.scoreboard.teamLabelScore6.Text = this.sqlDT.Rows[5][3].ToString();
            this.scoreboard.teamLabelScore7.Text = this.sqlDT.Rows[6][3].ToString();
            this.scoreboard.teamLabelScore8.Text = this.sqlDT.Rows[7][3].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (cmbAddPoints.SelectedIndex != -1 || !string.IsNullOrEmpty(cmbAddPoints.Text))
                {
                    String updateQuery = "UPDATE teams SET Team='" + txtTeam.Text + "', Status ='" + cmbStatus.Text + "', Score = " + cmbAddPoints.Text + " WHERE ID=" + txtID.Text;
                    executeQuery(updateQuery);

                    loadToTextBoxes("SELECT * FROM  teams WHERE ID=" + txtID.Text);
                    LoadData();
                    reloadScoreboard();

                }
                else
                {

                    MessageBox.Show("Please assign points first", "Points Not Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Please Select Team First From Table!", "Team Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //clearAllText(this);

            txtTeam.Text = "";
            cmbStatus.Text = "";
            cmbAddPoints.Text = "";
            txtTeam.Text = "";
            dataGridView1.ClearSelection();

            String updateQuery = "UPDATE teams SET Status ='Enabled', Score = 0";
            executeQuery(updateQuery);
            LoadData();
            reloadScoreboard();
            ResetOrSet(true);

        }

    private void ResetOrSet(Boolean Status)
        {
            this.scoreboard.teamPane2.Visible = Status; 
            this.scoreboard.teamPane3.Visible = Status; 
            this.scoreboard.teamPane4.Visible = Status; 
            this.scoreboard.teamPane5.Visible = Status; 
            this.scoreboard.teamPane6.Visible = Status;
            this.scoreboard.teamPane7.Visible = Status;
            this.scoreboard.teamPane8.Visible = Status;


            this.scoreboard.teamPictureBox2.Visible = Status;
            this.scoreboard.teamPictureBox3.Visible = Status;
            this.scoreboard.teamPictureBox4.Visible = Status;
            this.scoreboard.teamPictureBox5.Visible = Status;
            this.scoreboard.teamPictureBox6.Visible = Status;
            this.scoreboard.teamPictureBox7.Visible = Status;
            this.scoreboard.teamPictureBox8.Visible = Status;


            this.scoreboard.teamLabelName2.Visible = Status;
            this.scoreboard.teamLabelName3.Visible = Status;
            this.scoreboard.teamLabelName4.Visible = Status;
            this.scoreboard.teamLabelName5.Visible = Status;
            this.scoreboard.teamLabelName6.Visible = Status;
            this.scoreboard.teamLabelName7.Visible = Status;
            this.scoreboard.teamLabelName8.Visible = Status;


            this.scoreboard.teamLabelScore2.Visible = Status;
            this.scoreboard.teamLabelScore3.Visible = Status;
            this.scoreboard.teamLabelScore4.Visible = Status;
            this.scoreboard.teamLabelScore5.Visible = Status;
            this.scoreboard.teamLabelScore6.Visible = Status;
            this.scoreboard.teamLabelScore7.Visible = Status;
            this.scoreboard.teamLabelScore8.Visible = Status;
        }
        private void btnShowScoreboard_Click(object sender, EventArgs e)
        {

                this.scoreboard = new frmScoreboard();
                this.scoreboard.Show();
   
            
        }

        private void btnShowWinner_Click(object sender, EventArgs e)
        {

            ResetOrSet(false);

        }
    }

    
}
