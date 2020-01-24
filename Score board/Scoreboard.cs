using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Score_board
{
    public partial class frmScoreboard : System.Windows.Forms.Form
    {

        private model.Team team = new model.Team();
        private DataTable sqlDT = new DataTable();

        private int teams = 0;
        private string absolutepath;

        public Panel teamPane1 = new Panel();
        public Panel teamPane2 = new Panel();
        public Panel teamPane3 = new Panel();
        public Panel teamPane4 = new Panel();
        public Panel teamPane5 = new Panel();
        public Panel teamPane6 = new Panel();
        public Panel teamPane7 = new Panel();
        public Panel teamPane8 = new Panel();

        public PictureBox teamPictureBox1 = new PictureBox();
        public PictureBox teamPictureBox2 = new PictureBox();
        public PictureBox teamPictureBox3 = new PictureBox();
        public PictureBox teamPictureBox4 = new PictureBox();
        public PictureBox teamPictureBox5 = new PictureBox();
        public PictureBox teamPictureBox6 = new PictureBox();
        public PictureBox teamPictureBox7 = new PictureBox();
        public PictureBox teamPictureBox8 = new PictureBox();

        public Label teamLabelName1 = new Label();
        public Label teamLabelName2 = new Label();
        public Label teamLabelName3 = new Label();
        public Label teamLabelName4 = new Label();
        public Label teamLabelName5 = new Label();
        public Label teamLabelName6 = new Label();
        public Label teamLabelName7 = new Label();
        public Label teamLabelName8 = new Label();

        
        public Label teamLabelScore1 = new Label();
        public Label teamLabelScore2 = new Label();
        public Label teamLabelScore3 = new Label();
        public Label teamLabelScore4 = new Label();
        public Label teamLabelScore5 = new Label();
        public Label teamLabelScore6 = new Label();
        public Label teamLabelScore7 = new Label();
        public Label teamLabelScore8 = new Label();
        public int info = 0;
        public String lblTeam1;
        public String lblTeamScore1;

        public frmScoreboard()
        {
            this.teams = 0;
            InitializeComponent();
            this.Load += new EventHandler(frmScoreboard_Load);
        }




        private void frmScoreboard_Load(System.Object sender, System.EventArgs e)
        {
            LoadData();     
            SetUpTeamNameLabels();
            SetUpPictureBoxes();
            SetUpPanels();
           
        }



        private void LoadData()
        {


            this.sqlDT = team.All();
            this.teams = this.sqlDT.Rows.Count;
            this.lblTeam1 = this.sqlDT.Rows[0][1].ToString();
            this.lblTeamScore1 = this.sqlDT.Rows[0][3].ToString();
        }


        private  void SetUpTeamNameLabels()
        {

            if (this.teams > 0)
            {
                this.Controls.Add(teamLabelName1);
                this.Controls.Add(teamLabelName2);

                // 
                // Label Name 1
                // 
                teamLabelName1.AutoSize = true;
                teamLabelName1.Location = new System.Drawing.Point(92, 151);
                teamLabelName1.Name = "lblTeamName" + this.sqlDT.Rows[0][1].ToString();
                teamLabelName1.Font = new Font(teamLabelName1.Font, FontStyle.Bold);
                teamLabelName1.Size = new System.Drawing.Size(200, 200);
                teamLabelName1.TabIndex = 1;
                teamLabelName1.Text = this.lblTeam1;
                // 
                // Label Score 1
                // 
                teamLabelScore1.AutoSize = true;
                teamLabelScore1.Location = new System.Drawing.Point(96, 177);
                teamLabelScore1.Name = this.sqlDT.Rows[0][3].ToString();
                teamLabelScore1.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore1.Font = new Font(teamLabelScore1.Font, FontStyle.Bold);
                teamLabelScore1.Size = new System.Drawing.Size(200, 200);
                teamLabelScore1.TabIndex = 2;
                teamLabelScore1.Text = this.lblTeamScore1;

            }

            if (this.teams > 1)
            {
                this.Controls.Add(teamLabelName3);
                this.Controls.Add(teamLabelName4);

                // 
                // Label Name 2
                // 
                teamLabelName2.AutoSize = true;
                teamLabelName2.Location = new System.Drawing.Point(97, 151);
                teamLabelName2.Name     = "lblTeamName" + this.sqlDT.Rows[1][1].ToString();
                teamLabelName2.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelName2.Font = new Font(teamLabelScore1.Font, FontStyle.Bold);
                teamLabelName2.Size = new System.Drawing.Size(200, 200);
                teamLabelName2.TabIndex = 3;
                teamLabelName2.Text     = this.sqlDT.Rows[1][1].ToString();
                // 
                // Label Score 2 
                // 
                teamLabelScore2.AutoSize = true;
                teamLabelScore2.Location = new System.Drawing.Point(100, 177);
                teamLabelScore2.Name     = "lblTeamScore" + this.sqlDT.Rows[1][1].ToString();
                teamLabelScore2.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore2.Font = new Font(teamLabelScore1.Font, FontStyle.Bold);
                teamLabelScore2.Size = new System.Drawing.Size(200, 200);
                teamLabelScore2.TabIndex = 4;
                teamLabelScore2.Text     = this.sqlDT.Rows[1][3].ToString();
            }

            if (this.teams > 2)
            {
                this.Controls.Add(teamLabelName5);
                this.Controls.Add(teamLabelName6);

                // 
                // Label Name 3
                // 
                teamLabelName3.AutoSize = true;
                teamLabelName3.Location = new System.Drawing.Point(106, 151);
                teamLabelName3.Name     = "lblTeamName" + this.sqlDT.Rows[2][1].ToString();
                teamLabelName3.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelName3.Font = new Font(teamLabelName3.Font, FontStyle.Bold);
                teamLabelName3.Size = new System.Drawing.Size(200, 200);
                teamLabelName3.TabIndex = 5;
                teamLabelName3.Text     = this.sqlDT.Rows[2][1].ToString();
                // 
                // Label Score 3
                // 
                teamLabelScore3.AutoSize = true;
                teamLabelScore3.Location = new System.Drawing.Point(106, 177);
                teamLabelScore3.Name     = "lblTeamScore" + this.sqlDT.Rows[2][1].ToString();
                teamLabelScore3.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore3.Font = new Font(teamLabelScore3.Font, FontStyle.Bold);
                teamLabelScore3.Size = new System.Drawing.Size(200, 200);
                teamLabelScore3.TabIndex = 6;
                teamLabelScore3.Text     = this.sqlDT.Rows[2][3].ToString();
            }

            if (this.teams > 3)
            {
                this.Controls.Add(teamLabelName7);
                this.Controls.Add(teamLabelName8);

                // 
                // Label Name 4
                // 
                teamLabelName4.AutoSize = true;
                teamLabelName4.Location = new System.Drawing.Point(99, 151);
                teamLabelName4.Name     = "lblTeamName" + this.sqlDT.Rows[3][1].ToString();
                teamLabelName4.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelName4.Font = new Font(teamLabelName4.Font, FontStyle.Bold);
                teamLabelName4.Size = new System.Drawing.Size(200, 200);
                teamLabelName4.TabIndex = 7;
                teamLabelName4.Text     = this.sqlDT.Rows[3][1].ToString();
                // 
                // Label Score 4
                // 
                teamLabelScore4.AutoSize = true;
                teamLabelScore4.Location = new System.Drawing.Point(99, 177);
                teamLabelScore4.Name     = "lblTeamScore" + this.sqlDT.Rows[3][1].ToString();
                teamLabelScore4.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore4.Font = new Font(teamLabelScore4.Font, FontStyle.Bold);
                teamLabelScore4.Size = new System.Drawing.Size(200, 200);
                teamLabelScore4.TabIndex = 8;
                teamLabelScore4.Text     = this.sqlDT.Rows[3][3].ToString();
            }

            if (this.teams > 4)
            {
                this.Controls.Add(teamLabelScore1);
                this.Controls.Add(teamLabelScore2);

                // 
                // Label Name 5
                // 
                teamLabelName5.AutoSize = true;
                teamLabelName5.Location = new System.Drawing.Point(92, 151);
                teamLabelName5.Name     = "lblTeamName" + this.sqlDT.Rows[4][1].ToString();
                teamLabelName5.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelName5.Font      = new Font(teamLabelName5.Font, FontStyle.Bold);
                teamLabelName5.Size     = new System.Drawing.Size(200, 200);
                teamLabelName5.TabIndex = 9;
                teamLabelName5.Text     = this.sqlDT.Rows[4][1].ToString();
                // 
                // Label Score 5
                // 
                teamLabelScore5.AutoSize  = true;
                teamLabelScore5.Location  = new System.Drawing.Point(95, 176);
                teamLabelScore5.Name      = "lblTeamScore" + this.sqlDT.Rows[4][1].ToString();
                teamLabelScore5.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore5.Font      = new Font(teamLabelScore5.Font, FontStyle.Bold);
                teamLabelScore5.Size      = new System.Drawing.Size(200, 200);
                teamLabelScore5.TabIndex  = 10;
                teamLabelScore5.Text      = this.sqlDT.Rows[4][3].ToString();

            }

            if (this.teams > 5)
            {
                this.Controls.Add(teamLabelScore3);
                this.Controls.Add(teamLabelScore4);

                // 
                // Label Name 6
                // 
                teamLabelName6.AutoSize   = true;
                teamLabelName6.Location   = new System.Drawing.Point(97, 151);
                teamLabelName6.Name       = "lblTeamName" + this.sqlDT.Rows[5][1].ToString();
                teamLabelName6.TextAlign  = ContentAlignment.MiddleCenter;
                teamLabelName6.Font       = new Font(teamLabelName6.Font, FontStyle.Bold);
                teamLabelName6.Size       = new System.Drawing.Size(200, 200);
                teamLabelName6.TabIndex   = 11;
                teamLabelName6.Text       = this.sqlDT.Rows[5][1].ToString();
                // 
                // Label Score 6
                // 
                teamLabelScore6.AutoSize  = true;
                teamLabelScore6.Location  = new System.Drawing.Point(100, 176);
                teamLabelScore6.Name      = "lblTeamScore" + this.sqlDT.Rows[5][1].ToString();
                teamLabelScore6.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore6.Font      = new Font(teamLabelScore6.Font, FontStyle.Bold);
                teamLabelScore6.Size      = new System.Drawing.Size(200, 200);
                teamLabelScore6.TabIndex  = 12;
                teamLabelScore6.Text      = this.sqlDT.Rows[5][3].ToString();

            }

            if (this.teams > 6)
            {
                this.Controls.Add(teamLabelScore5);
                this.Controls.Add(teamLabelScore6);

                // 
                // Label Name 7
                // 
                teamLabelName7.AutoSize   = true;
                teamLabelName7.Location   = new System.Drawing.Point(100, 150);
                teamLabelName7.Name       = "lblTeamName" + this.sqlDT.Rows[6][1].ToString();
                teamLabelName7.TextAlign  = ContentAlignment.MiddleCenter;
                teamLabelName7.Font       = new Font(teamLabelName7.Font, FontStyle.Bold);
                teamLabelName7.Size       = new System.Drawing.Size(200, 200);
                teamLabelName7.TabIndex   = 13;
                teamLabelName7.Text       = this.sqlDT.Rows[6][1].ToString();
                // 
                // Label Score 7
                // 
                teamLabelScore7.AutoSize  = true;
                teamLabelScore7.Location  = new System.Drawing.Point(105, 176);
                teamLabelScore7.Name      = "lblTeamScore" + this.sqlDT.Rows[6][1].ToString();
                teamLabelScore7.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore7.Font      = new Font(teamLabelScore7.Font, FontStyle.Bold);
                teamLabelScore7.Size      = new System.Drawing.Size(200, 200);
                teamLabelScore7.TabIndex  = 14;
                teamLabelScore7.Text      = this.sqlDT.Rows[6][3].ToString();

            }

            if (this.teams > 7)
            {
                this.Controls.Add(teamLabelScore7);
                this.Controls.Add(teamLabelScore8);

                // 
                // Label Name 8
                // 
                teamLabelName8.AutoSize  = true;
                teamLabelName8.Location  = new System.Drawing.Point(99, 150);
                teamLabelName8.Name      = "lblTeamName" + this.sqlDT.Rows[7][1].ToString();
                teamLabelName8.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelName8.Font      = new Font(teamLabelName8.Font, FontStyle.Bold);
                teamLabelName8.Size      = new System.Drawing.Size(200, 200);
                teamLabelName8.TabIndex  = 15;
                teamLabelName8.Text      = this.sqlDT.Rows[7][1].ToString();
                // 
                // Label Score 8
                // 
                teamLabelScore8.AutoSize  = true;
                teamLabelScore8.Location  = new System.Drawing.Point(104, 176);
                teamLabelScore8.Name      = "lblTeamScore" + this.sqlDT.Rows[7][1].ToString();
                teamLabelScore8.TextAlign = ContentAlignment.MiddleCenter;
                teamLabelScore8.Font      = new Font(teamLabelScore8.Font, FontStyle.Bold);
                teamLabelScore8.Size      = new System.Drawing.Size(200, 200);
                teamLabelScore8.TabIndex  = 16;
                teamLabelScore8.Text      = this.sqlDT.Rows[7][3].ToString();

            }

        }

        public void SetUpPictureBoxes()
        {
           

            if (this.teams > 0)
            {
                this.Controls.Add(teamPictureBox1);
                // 
                // pictureBox1
                // 
                string absolutepath1 = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + this.sqlDT.Rows[0][2].ToString() + "");
                teamPictureBox1.Location = new System.Drawing.Point(68, 44);
                teamPictureBox1.Name = "teamPictureBox1";
                teamPictureBox1.Size = new System.Drawing.Size(90, 90);
                teamPictureBox1.TabIndex = 1;
                teamPictureBox1.TabStop = false;
                teamPictureBox1.Image = System.Drawing.Image.FromFile(absolutepath1);
                Console.WriteLine(absolutepath1);
            }

            if (this.teams > 1)
            {
                this.Controls.Add(teamPictureBox2);
                // 
                // pictureBox2
                //
                string absolutepath2 = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + this.sqlDT.Rows[1][2].ToString() + "");
                teamPictureBox2.Location = new System.Drawing.Point(71, 44);
                teamPictureBox2.Name = "teamPictureBox2";
                teamPictureBox2.Size = new System.Drawing.Size(90, 90);
                teamPictureBox2.TabIndex = 2;
                teamPictureBox2.TabStop = false;
                teamPictureBox2.Image = System.Drawing.Image.FromFile(absolutepath2);
            }

            if (this.teams > 2)
            {
                this.Controls.Add(teamPictureBox3);
                // 
                // pictureBox3
                //
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[2][2].ToString() + "");
                teamPictureBox3.Location = new System.Drawing.Point(78, 44);
                teamPictureBox3.Name = "teamPictureBox3";
                teamPictureBox3.Size = new System.Drawing.Size(90, 90);
                teamPictureBox3.TabIndex = 3;
                teamPictureBox3.TabStop = false;
                teamPictureBox3.Image = System.Drawing.Image.FromFile(absolutepath);
            }
            if (this.teams > 3)
            {
                this.Controls.Add(teamPictureBox4);
                // 
                // pictureBox4
                //
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[3][2].ToString() + "");
                teamPictureBox4.Location = new System.Drawing.Point(71, 44);
                teamPictureBox4.Name = "teamPictureBox4";
                teamPictureBox4.Size = new System.Drawing.Size(90, 90);
                teamPictureBox4.TabIndex = 4;
                teamPictureBox4.TabStop = false;
                teamPictureBox4.Image = System.Drawing.Image.FromFile(absolutepath);
            }
            if (this.teams > 4)
            {
                this.Controls.Add(teamPictureBox5);
                // 
                // pictureBox5
                // 
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[4][2].ToString() + "");
                teamPictureBox5.Location = new System.Drawing.Point(68, 38);
                teamPictureBox5.Name = "teamPictureBox5";
                teamPictureBox5.Size = new System.Drawing.Size(90, 90);
                teamPictureBox5.TabIndex = 5;
                teamPictureBox5.TabStop = false;
                teamPictureBox5.Image = System.Drawing.Image.FromFile(absolutepath);
            }

            if (this.teams > 5)
            {
                this.Controls.Add(teamPictureBox6);
                // 
                // pictureBox6
                // 
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[5][2].ToString() + "");
                teamPictureBox6.Location = new System.Drawing.Point(71, 38);
                teamPictureBox6.Name = "teamPictureBox6";
                teamPictureBox6.Size = new System.Drawing.Size(90, 90);
                teamPictureBox6.TabIndex = 6;
                teamPictureBox6.TabStop = false;
                teamPictureBox6.Image = System.Drawing.Image.FromFile(absolutepath);
            }

            if (this.teams > 6)
            {
                this.Controls.Add(teamPictureBox7);
                // 
                // pictureBox7
                // 
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[6][2].ToString() + "");
                teamPictureBox7.Location = new System.Drawing.Point(78, 38);
                teamPictureBox7.Name = "teamPictureBox7";
                teamPictureBox7.Size = new System.Drawing.Size(90, 90);
                teamPictureBox7.TabIndex = 7;
                teamPictureBox7.TabStop = false;
                teamPictureBox7.Image = System.Drawing.Image.FromFile(absolutepath);
            }
            if (this.teams > 7)
            {
                this.Controls.Add(teamPictureBox8);
                // 
                // pictureBox8
                // 
                absolutepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Images\" + sqlDT.Rows[7][2].ToString() + "");
                teamPictureBox8.Location = new System.Drawing.Point(80, 38);
                teamPictureBox8.Name = "teamPictureBox8";
                teamPictureBox8.Size = new System.Drawing.Size(90, 90);
                teamPictureBox8.TabIndex = 8;
                teamPictureBox8.TabStop = false;
                teamPictureBox8.Image = System.Drawing.Image.FromFile(absolutepath);
            }

        }


        public void SetUpPanels()
        {
            if (this.info == 1) {
                LoadData();
                SetUpTeamNameLabels();
                SetUpPictureBoxes();
                SetUpPanels();
            }

            this.Controls.Add(teamPane1);
            this.Controls.Add(teamPane2);
            this.Controls.Add(teamPane3);
            this.Controls.Add(teamPane4);
            this.Controls.Add(teamPane5);
            this.Controls.Add(teamPane6);
            this.Controls.Add(teamPane7);
            this.Controls.Add(teamPane8);

            // 
            // panel1
            // 
            teamPane1.BackColor = System.Drawing.Color.Bisque;
            teamPane1.Controls.Add(teamPictureBox1);
            teamPane1.Controls.Add(teamLabelName1);
            teamPane1.Controls.Add(teamLabelScore1);
            teamPane1.Location = new Point(61, 24);
            teamPane1.Name = "teamPane1";
            teamPane1.Size = new Size(235, 235);
            teamPane1.TabIndex = 0;
            // 
            // panel2
            // 
            teamPane2.BackColor = System.Drawing.Color.Bisque;
            teamPane2.Controls.Add(teamPictureBox2);
            teamPane2.Controls.Add(teamLabelName2);
            teamPane2.Controls.Add(teamLabelScore2);
            teamPane2.Location = new Point(336, 24);
            teamPane2.Name = "teamPane2";
            teamPane2.Size = new Size(235, 235);
            teamPane2.TabIndex = 1;
            // 
            // panel3
            // 
            teamPane3.BackColor = System.Drawing.Color.Bisque;
            teamPane3.Controls.Add(teamPictureBox3);
            teamPane3.Controls.Add(teamLabelName3);
            teamPane3.Controls.Add(teamLabelScore3);
            teamPane3.Location = new Point(616, 24);
            teamPane3.Name = "teamPane3";
            teamPane3.Size = new Size(235, 235);
            teamPane3.TabIndex = 2;
            // 
            // panel4
            // 
            teamPane4.BackColor = System.Drawing.Color.Bisque;
            teamPane4.Controls.Add(teamPictureBox4);
            teamPane4.Controls.Add(teamLabelName4);
            teamPane4.Controls.Add(teamLabelScore4);
            teamPane4.Location = new Point(900, 24);
            teamPane4.Name = "teamPane4";
            teamPane4.Size = new Size(235, 235);
            teamPane4.TabIndex = 3;
            // 
            // panel5
            // 
            teamPane5.BackColor = System.Drawing.Color.Bisque;
            teamPane5.Controls.Add(teamPictureBox5);
            teamPane5.Controls.Add(teamLabelName5);
            teamPane5.Controls.Add(teamLabelScore5);
            teamPane5.Location = new Point(900, 310);
            teamPane5.Name = "teamPane5";
            teamPane5.Size = new Size(235, 235);
            teamPane5.TabIndex = 7;
            // 
            // panel6
            // 
            teamPane6.BackColor = System.Drawing.Color.Bisque;
            teamPane6.Controls.Add(teamPictureBox6);
            teamPane6.Controls.Add(teamLabelName6);
            teamPane6.Controls.Add(teamLabelScore6);
            teamPane6.Location = new Point(616, 310);
            teamPane6.Name = "teamPane6";
            teamPane6.Size = new Size(235, 235);
            teamPane6.TabIndex = 6;
            // 
            // panel7
            // 
            teamPane7.BackColor = System.Drawing.Color.Bisque;
            teamPane7.Controls.Add(teamPictureBox7);
            teamPane7.Controls.Add(teamLabelName7);
            teamPane7.Controls.Add(teamLabelScore7);
            teamPane7.Location = new Point(336, 310);
            teamPane7.Name = "teamPane7";
            teamPane7.Size = new Size(235, 235);
            teamPane7.TabIndex = 5;
            // 
            // panel8
            // 
            teamPane8.BackColor = System.Drawing.Color.Bisque;
            teamPane8.Controls.Add(teamPictureBox8);
            teamPane8.Controls.Add(teamLabelName8);
            teamPane8.Controls.Add(teamLabelScore8);
            teamPane8.Location = new Point(61, 310);
            teamPane8.Name = "teamPane8";
            teamPane8.Size = new Size(235, 235);
            teamPane8.TabIndex = 4;

        }

        private void frmScoreboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmScoreboard.info = null;
        }
    }
}
