using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer1
{
    class Koneksi_DB2 : Koneksi_DB1
    {
        private string conn;
        private OracleConnection connect;
        public OracleCommand cmdx;

        public void db_connection()
        {
            try
            {
                string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
                DbUserIdServer = base.cetak_DbUserIdServer();
                DbPasswdServer = base.cetak_DbPasswdServer();
                DbDataSourceServer = base.cetak_DbDataSourceServer();
                conn = ("User ID =" + DbUserIdServer + ";Password = " + DbPasswdServer +
                    ";Data Source = '" + DbDataSourceServer + "';");
                connect = new OracleConnection(conn);
                connect.Open();
            }
            catch (Exception ex)
            { throw; }
        }

        public void db_connectiondg()
        {
            string DbUserIdServer, DbPasswordServer, DbDataSourceServer;
            DbUserIdServer = base.cetak_DbUserIdServer();
            DbPasswordServer = base.cetak_DbPasswdServer();
            DbDataSourceServer = base.cetak_DbDataSourceServer();
            using(OracleConnection conn = new OracleConnection("User ID ="+
                DbUserIdServer + ";Password ="+ DbPasswordServer + ";DataSource='"+
                DbDataSourceServer+"';"));
        }

        public int query_db(string query)
        {
            string DbUserIdServer, DbPasswordServer, DbDataSourceServer;
            DbUserIdServer = base.cetak_DbUserIdServer();
            DbPasswordServer = base.cetak_DbPasswdServer();
            DbDataSourceServer = base.cetak_DbDataSourceServer();

            string database = ("User ID=" + DbUserIdServer + ";Password =" +
                DbPasswordServer + ";Data Source='" + DbDataSourceServer + "';");

            OracleConnection koneksi;
            OracleCommand cmd;
            int a = 0;

            koneksi = new OracleConnection(database);

            try
            {
                koneksi.Open();
                cmd = new OracleCommand(query, koneksi);
                a = cmd.ExecuteNonQuery();
                koneksi.Close();
            }
            catch (Exception ex)
            { }
            finally 
            {
                koneksi.Close();
            }
            return a;
        }

        public bool check_connection(string conn)
        {
            bool result = false;
            OracleConnection connection = new OracleConnection(conn);
            try
            {
                connection.Open();
                result = true;
                connection.Close();
            }
            catch
            { result = false; }
            return result;
        }
    }
}
