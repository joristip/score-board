using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Score_board
{

   public class Database
    {
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        private SQLiteDataAdapter DB;
        private DataTable sqlDT = new DataTable();
        private DataSet DS = new DataSet();


        public Database()
        {
            this.SqlConn = new SQLiteConnection(Util.databaseConnection);
        }


        public SQLiteConnection SqlConn
        {
            get
            {
                return this.sqlConn;
            }

            set
            {
                this.sqlConn = value; 
            }
        }

        public SQLiteCommand SqlCmd
        {
            get
            {
                return this.sqlCmd;
            }

            set
            {
                sqlCmd = value;
            }
        }

        public DataSet DS1
        {
            get
            {
                return DS;
            }

            set
            {
                DS = value;
            }
        }

        public DataTable loadData(String Query)
        {
            this.sqlConn.Open();
            this.DB = new SQLiteDataAdapter(Query, sqlConn);
            
            DS.Reset();
            DB.Fill(DS);
            this.sqlConn.Close();
            return this.DS.Tables[0];
        }

        public void executeQuery(String stringQuery)
        {

            this.SqlConn.Open();
            this.SqlCmd = this.SqlConn.CreateCommand();
            this.SqlCmd.CommandText = stringQuery;
            this.SqlCmd.ExecuteNonQuery();
            this.SqlCmd.Dispose();
            this.SqlConn.Close();

        }
    }
}
