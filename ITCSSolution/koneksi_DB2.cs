using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCSSolution
{
    class koneksi_DB2 : koneksi_DB1
    {

        private string conn;
        private OracleConnection connect;
        public OracleCommand cmdx;

        public void db_connection()
        {
            try
            {
                string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
                DbUserIdServer = new cetak_DbUserIdServer();
                DbPasswdServer = new cetak_DbPasswdServer();
                DbDataSourceServer = new cetak_DbDataSourceServer();
                conn = ("User ID=" + DbUserIdServer + ";Password=" + DbPasswdServer + ";Data Source='" + DbDataSourceServer + "';");
                connect = new OracleConnection(conn);
                connect.Open();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void db_connectiondg()
        {
            string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
            DbUserIdServer = new cetak_DbUserIdServer();
            DbPasswdServer = new cetak_DbPasswdServer();
            DbDataSourceServer = new cetak_DbDataSourceServer();
            using (OracleConnection conn = new OracleConnection("User ID=" + DbUserIdServer + ";Password =" + DbPasswdServer + ";Data Source'" + DbDataSourceServer + "';"));
        }

        public int query_db(string query)
        {
            string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
            DbUserIdServer = new cetak_DbUserIdServer();
            DbPasswdServer = new cetak_DbPasswdServer();
            DbDataSourceServer = new cetak_DbDataSourceServer();

            string database = ("User ID=" + DbUserIdServer + ";Password = " + DbPasswdServer + ";Data Source = '" + "'");
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
            {

            }

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
            {
                result = false;
            }
            return result;\
        }
    }
}
