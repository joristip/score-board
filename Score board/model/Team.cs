using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_board.model
{


    class Team
    {
        private int ID;
        private String team;
        private String Image;
        private int Score;
        private String Status;

        private Database database = new Database();

        public Team()
        {
            new Team(0,"","",0,"");
        }

        public Team(int iD, string team, string image, int score, string status)
        {
            this.ID = iD;
            this.team = team;
            this.Image = image;
            this.Score = score;
            this.Status = status;
        }

        public DataTable read(String id)
        {
            String query = "SELECT * FROM " + Util.teamsTable + " WHERE ID="+id;
            return database.loadData(query);
        }

        public DataTable All()
        {
            String query = "SELECT * FROM " + Util.teamsTable + " WHERE Status = 'Enabled' ORDER BY Score DESC";
           return  database.loadData(query);
        }

        public Boolean DiableEnable(String status, String id)
        {
            String query = "UPDATE teams SET Status='" + status + "' WHERE ID=" + id;
            return database.executeQuery(query);
        }

        public Boolean update(String team,String status, String points, String id)
        {
            String query = "UPDATE teams SET Team='" + team + "', Status ='" + status + "', Score = " + points + " WHERE ID=" + id;
            return database.executeQuery(query);
        }
        public Boolean UpdatePicture(String image, String Id)
        {
            String query = "UPDATE " + Util.teamsTable + " SET Image='" + image + "' WHERE ID=" + Id;
            return database.executeQuery(query);
        }

        public Boolean ResetUpdate()
        {
            String query = "UPDATE " + Util.teamsTable + " SET Status ='Enabled', Score = 0";
            return database.executeQuery(query);
        }

        public Boolean Addoints(String points, String Id)
        {

            String query = "UPDATE "+ Util.teamsTable  + " SET Score = Score + " + points + " WHERE ID = " + Id;
            return database.executeQuery(query);

        }
        public void update()
        {

        }

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public string Team1
        {
            get
            {
                return team;
            }

            set
            {
                team = value;
            }
        }

        public string Image1
        {
            get
            {
                return Image;
            }

            set
            {
                Image = value;
            }
        }

        public int Score1
        {
            get
            {
                return Score;
            }

            set
            {
                Score = value;
            }
        }

        public string Status1
        {
            get
            {
                return Status;
            }

            set
            {
                Status = value;
            }
        }
    }
}
