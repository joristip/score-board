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

        
        private string absolutepath;
        private Database database = new Database();
        private DataTable dt = new DataTable();
        private frmScoreboard scoreboard = new frmScoreboard();

        
        public frmDashboard()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            this.dt = database.loadData("SELECT * FROM "+ Util.teamsTable + " WHERE Status = 'Enabled' ORDER BY Score DESC");
            Console.Write(dt.Rows[1][2].ToString());
            dataGridView1.DataSource = this.dt;
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

            this.dt = database.loadData(Team);
            txtScore.Text = dt.Rows[0][3].ToString();
            cmbStatus.Text = dt.Rows[0][4].ToString();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             String directoryPath = Path.GetDirectoryName(Application.ExecutablePath);

            try
            {

                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
                {
                    txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtTeam.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtScore.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    cmbStatus.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                    absolutepath = Path.Combine(directoryPath, @Util.picturesDirectory + dataGridView1.SelectedRows[0].Cells[2].Value.ToString());


                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                    txtTeam.Text = dataGridView1.Rows[e.RowIndex].Cells["Team"].FormattedValue.ToString();
                    txtScore.Text = dataGridView1.Rows[e.RowIndex].Cells["Score"].FormattedValue.ToString();
                    cmbStatus.Text = dataGridView1.Rows[e.RowIndex].Cells["Status"].FormattedValue.ToString();

                    absolutepath = Path.Combine(directoryPath, @Util.picturesDirectory + dataGridView1.Rows[e.RowIndex].Cells["Image"].FormattedValue.ToString());
                }

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
                    String pointsQuery = "UPDATE "+ Util.teamsTable  + " SET Score = Score+" + cmbAddPoints.Text + " WHERE ID=" + txtID.Text;
                    database.executeQuery(pointsQuery);
                    loadToTextBoxes("select * from "+ Util.teamsTable  + " where ID=" + txtID.Text);
                    reloadScoreboard();
                    LoadData();
                   
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
            database.executeQuery(enableDiableTeamQuery);
            loadToTextBoxes("select * from "+ Util.teamsTable + " where ID=" + txtID.Text);
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
                String stringUpdatePicture = "UPDATE "+ Util.teamsTable  + " SET Image='" + name + "' WHERE ID=" + txtID.Text;
                database.executeQuery(stringUpdatePicture);
                loadToTextBoxes("select * from "+ Util.teamsTable  + " where ID=" + txtID.Text);
            }
        }

        private void reloadScoreboard()
        {

            DataTable dt = database.loadData("SELECT * FROM teams WHERE Status = 'Enabled' ORDER BY Score DESC");
            this.scoreboard.teamLabelScore1.Text = dt.Rows[0][3].ToString();
            this.scoreboard.teamLabelScore2.Text = dt.Rows[1][3].ToString();
            this.scoreboard.teamLabelScore3.Text = dt.Rows[2][3].ToString();
            this.scoreboard.teamLabelScore4.Text = dt.Rows[3][3].ToString();
            this.scoreboard.teamLabelScore5.Text = dt.Rows[4][3].ToString();
            this.scoreboard.teamLabelScore6.Text = dt.Rows[5][3].ToString();
            this.scoreboard.teamLabelScore7.Text = dt.Rows[6][3].ToString();
            this.scoreboard.teamLabelScore8.Text = dt.Rows[7][3].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (cmbAddPoints.SelectedIndex != -1 || !string.IsNullOrEmpty(cmbAddPoints.Text))
                {
                    String updateQuery = "UPDATE teams SET Team='" + txtTeam.Text + "', Status ='" + cmbStatus.Text + "', Score = " + cmbAddPoints.Text + " WHERE ID=" + txtID.Text;
                    database.executeQuery(updateQuery);

                    loadToTextBoxes("SELECT * FROM  "+ Util.teamsTable  + " WHERE ID=" + txtID.Text);
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
            txtTeam.Text = "";
            cmbStatus.Text = "";
            cmbAddPoints.Text = "";
            txtTeam.Text = "";
            dataGridView1.ClearSelection();

            String updateQuery = "UPDATE "+ Util.teamsTable + " SET Status ='Enabled', Score = 0";
            database.executeQuery(updateQuery);       
            reloadScoreboard();
            LoadData();
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
