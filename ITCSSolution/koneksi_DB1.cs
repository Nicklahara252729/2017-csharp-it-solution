using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCSSolution
{
    class koneksi_DB1
    {
        string DbUserIdServer, DbPasswdServer, DbDatasourceServer;
        string database = "provider = Microsoft.ACE.OLEDB.12.0;Data Source = Setting.accdb;";
        public OleDbConnection koneksi;
        public void connect()
        {
            koneksi = new OleDbConnection(database);
            koneksi.Open();
        }

        public void disconnect()
        {
            koneksi = new OleDbConnection(database);
            koneksi.Close();
        }

        public void tampil()
        {
            string sql = "select * from setting";
            try
            {
                connect();
                OleDbCommand cmd = new OleDbCommand(sql, koneksi);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Read();
                DbUserIdServer = dr["DbUserIdServer"].ToString();
                DbPasswdServer = dr["DbPasswdServer"].ToString();
                DbDatasourceServer = dr["DbDatasourceServer"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string cetak_DbUserIdServer()
        {
            this.tampil();
            return DbUserIdServer;
        }

        public string cetak_DbPasswdServer()
        {
            this.tampil();
            return DbPasswdServer;
        }

        public string cetak_DbDataSourceServer()
        {
            this.tampil();
            return DbDatasourceServer;
        }
    }
}
