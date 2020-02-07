using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Forpractice1
{
    public partial class formlostejoo : Form
    {
        public formlostejoo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try//برای مدیریت خطا
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select * from table1 where id=" + textBox1.Text + "";
                OleDbDataReader dr;
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(dr["name"].ToString() + "\n" + dr["family"].ToString() + "\n" + dr["mobile"].ToString(), "»»»»»");

                }
                else
                {
                    MessageBox.Show("موجود نمی باشد", "«««««");
                }
            }
            catch  //برای مدیریت خطا
            {
                MessageBox.Show("خطا در اتصال به بانک اطلاعاتی");
            }
            
        }

        private void formlostejoo_Load(object sender, EventArgs e)
        {

        }
    }
}
