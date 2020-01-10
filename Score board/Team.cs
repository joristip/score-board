using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_board
{


    public class Team
    {
        private int ID;
        private String Name;
        private String Image;
        private String Status;
        private int Score;

        public Team(int iD, string name, string image, string status, int score)
        {
            ID = iD;
            Name = name;
            Image = image;
            Status = status;
            Score = score;
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

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
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
    }
}
