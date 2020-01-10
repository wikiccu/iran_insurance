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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close(); //بستن فرم 
        }

        private void btnsabt_Click(object sender, EventArgs e)
        {
            try  //برای مدیریت خطا
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.CommandText = "insert into table1(id,name,family,mobile,comodity,price,totalprice,tedad) values('" + txtid.Text + "','" + txtname.Text + "','" + txtfamily.Text + "','" + txtmobile.Text + "','" + txtcomodity.Text + "','" + txtprice.Text + "','" + txttotalprice.Text + "','" + txtcount.Text + "')"; // کد درج در پایگاه داده ها
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("داده ها با موفقیت ثبت شدند");
                txtname.Clear();  //پاک کردن تکست باکس ها
                txtfamily.Clear();
                txtmobile.Clear();
                txtcomodity.Clear();
                txtcount.Clear();
                txtprice.Clear();
                txttotalprice.Clear();
                txtid.Clear();
            }
            catch  //برای مدیریت خطا
            {
                MessageBox.Show("خطا در اتصال به بانک اطلاعاتی");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Table1' table. You can move, or remove it, as needed.
            

        }

        private void btnnamayesh_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها  
            OleDbDataAdapter da = new OleDbDataAdapter("select * from table1", con); // کدهای نمایش در دیتا گرید ویو
            DataSet ds = new DataSet();
            da.Fill(ds, "table1");
            dataGridView1.DataSource = ds.Tables["table1"].DefaultView;
            con.Close();
        }

        private void btnhazf_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها  
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            int item;
            com.CommandText = "select count(id) from table1 where id=" + txtid.Text + "";
            con.Open();
            item = (int)com.ExecuteScalar();
            con.Close();
            if (item != 0)
            {
                com.CommandText = "delete from table1 where id=" + txtid.Text + "";   //کدهای حذف از پایگاه داده ها
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حذف با موفقیت انجام شد");

            }
            txtid.Clear();
            txtname.Clear();
            txtfamily.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtfamily.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            try //برای مدیریت خطا
            {
               int a = int.Parse(txtcount .Text);
               int c = int.Parse(txtprice .Text);
               int sum = (a * c);
                txttotalprice .Text = sum.ToString();
            }
            catch //برای مدیریت خطا
            {
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= '0' || e.KeyChar >= '9') //برای وارد نکردن حروف
            {
                e.Handled = true;
            }
        }

        
       

        
    }
}
