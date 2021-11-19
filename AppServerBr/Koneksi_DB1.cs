using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer1
{
    class Koneksi_DB1
    {
        string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
        string database = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=Setting.accdb;";
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
            string sql = "SELECT * FROM Setting";
            try
            {
                connect();
                OleDbCommand cmd = new OleDbCommand(sql, koneksi);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Read();
                DbUserIdServer = dr["DbUserIdServer"].ToString();
                DbPasswdServer = dr["DbPasswdServer"].ToString();
                DbDataSourceServer = dr["DbDataSourceServer"].ToString();
            }
            catch (Exception ex)
            {  }
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
            return DbDataSourceServer;
        }
    }
}
