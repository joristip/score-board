using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_board.model
{
    class User
    {
        private int ID;
        private String username;
        private String firstName;
        private String lastName;
        private String password;
        private String email;
        private String nickName;
        private int userLevel;
        private String photo;
        private String phoneNumber;
        private String workEmail;
        private String otherEmail;

        private Database database = new Database();

        public User(int ID, string username, string firstName, string lastName)
        {
            this.ID = ID;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;

        }
        public User(int ID, string username, string firstName, string lastName, string password, string email, string nickName, int userLevel, string photo, string phoneNumber, string workEmail, string otherEmail)
        {
            this.ID = ID;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.email = email;
            this.nickName = nickName;
            this.userLevel = userLevel;
            this.photo = photo;
            this.phoneNumber = phoneNumber;
            this.workEmail = workEmail;
            this.otherEmail = otherEmail;
        }

        public User()
        {

        }

        public Boolean IsUser(String username, String password)
        {
            String query = "SELECT * FROM users WHERE Username='"+ username + "' AND Password ='"+ password + "'";
            DataTable dt = database.loadData(query);
            return dt.Rows.Count > 0 ? true : false;
        }

        public User find(int ID)
        {
            String query = "SELECT * FROM users WHERE ID=" + ID;
            DataTable dt = database.loadData(query);
            return dt.Rows.Count > 0 ? new User(Convert.ToInt32(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(),dt.Rows[0][3].ToString()) : new User();
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickName;
            }

            set
            {
                nickName = value;
            }
        }

        public int UserLevel
        {
            get
            {
                return userLevel;
            }

            set
            {
                userLevel = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string WorkEmail
        {
            get
            {
                return workEmail;
            }

            set
            {
                workEmail = value;
            }
        }

        public string OtherEmail
        {
            get
            {
                return otherEmail;
            }

            set
            {
                otherEmail = value;
            }
        }
    }
}
