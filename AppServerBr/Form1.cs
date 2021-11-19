using ClientServer1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppServerBr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting Server DB
            string DbUserIdServer, DbPasswdServer, DbDataSourceServer;
            Koneksi_DB1 kon = new Koneksi_DB1();
            DbUserIdServer = kon.cetak_DbUserIdServer();
            DbPasswdServer = kon.cetak_DbPasswdServer();
            DbDataSourceServer = kon.cetak_DbDataSourceServer();

            label8.Text = DbUserIdServer;
            label9.Text = DbPasswdServer;
            label10.Text = DbDataSourceServer;
        }

        public void clear()
        {
            TxtIdSiswa.Clear();
            TxtNamaSiswa.Clear();
            TxtUmurSiswa.Clear();
            CmbJKelamin.Text = "Pilih Item !";
            CmbAgama.Text = "Pilih Item !";
            TxtAlamat.Clear();
            TxtTglLahir.Clear();
            CmbStatus.Text = "Pilih Item !";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtIdSiswa.Text != "" && TxtNamaSiswa.Text != "" && TxtUmurSiswa.Text != "" &&
                CmbJKelamin.Text != "" && CmbAgama.Text != "" && TxtAlamat.Text != "" &&
                TxtTglLahir.Text != "" && CmbStatus.Text != "")
            {
                Koneksi_DB2 smsconn = new Koneksi_DB2();
                if (smsconn.query_db("Insert into tbluser values('" + this.TxtIdSiswa.Text +
                    "','" + this.TxtNamaSiswa.Text + "','" + this.TxtUmurSiswa.Text +
                    "','" + this.CmbJKelamin.Text + "','" + this.CmbAgama.Text +
                    "','" + this.TxtAlamat.Text + "','" + this.TxtTglLahir.Text + "','" +
                    this.CmbStatus.Text + "')") != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Berhasil diSimpan", "App IT Solution",
                        MessageBoxButtons.OK);
                    clear();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Gagal diSimpan", "App IT Solution",
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Inputan tidak lengkap", "App IT Solution",
                            MessageBoxButtons.OK);
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {

        }

        private void DgvView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
