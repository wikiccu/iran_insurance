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
            string noe;
            //try  //برای مدیریت خطا
            //{
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها
                con.Open();
                OleDbCommand com = new OleDbCommand();
                if (naghd.Checked)
                {
                     noe = "نقد";

                }
                else
                {
                     noe = "چک";

                }
                com.CommandText = "insert into table1(name,family,mobile,codemeli,noebime,Price,noepardakht,pardakhti,baghimande) values('" + txtname.Text + "','" + txtfamily.Text + "','" + txtmobile.Text + "','" + Codemeli.Text + "','" + txtnobime.Text + "','" + Price.Text + "','" + noe +"','"+textBox1.Text+"','"+textBox2.Text+"')"; // کد درج در پایگاه داده ها
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("داده ها با موفقیت ثبت شدند");
                txtname.Clear();  //پاک کردن تکست باکس ها
                txtfamily.Clear();
                txtmobile.Clear();
                txtnobime.Clear();
                Codemeli.Clear();
                Price.Clear();
                textBox1.Clear();
                textBox2.Clear();
            //}
            //catch  //برای مدیریت خطا
            //{
            //    MessageBox.Show("خطا در اتصال به بانک اطلاعاتی");
            //}
            
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
            dataGridView1.Columns[0].HeaderText = "کد";
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[3].HeaderText = "موبایل";
            dataGridView1.Columns[4].HeaderText = "کد ملی";
            dataGridView1.Columns[5].HeaderText = "نوع بیمه";
            dataGridView1.Columns[6].HeaderText = "مبلغ";
            dataGridView1.Columns[7].HeaderText = "نوع پرداخت";
            dataGridView1.Columns[8].HeaderText = "پرداختی";
            dataGridView1.Columns[9].HeaderText = "باقی مانده";

            

        }

        private void btnhazf_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها  
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                int item;
                com.CommandText = "select count(id) from table1 where id=" + label10.Text + "";
                con.Open();
                item = (int)com.ExecuteScalar();
                con.Close();
                if (item != 0)
                {
                    com.CommandText = "delete from table1 where id=" + label10.Text + "";   //کدهای حذف از پایگاه داده ها
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("حذف با موفقیت انجام شد");
                    btnnamayesh_Click(sender,e);

                }
                //txtid.Clear();
                txtname.Clear();
                txtfamily.Clear();
            }
            catch
            {
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txtfamily.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            try //برای مدیریت خطا
            {
               //int a = int.Parse(txtcount .Text);
               int c = int.Parse(Price .Text);
               //int sum = (a * c);
                //txttotalprice .Text = sum.ToString();
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

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfamily_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                int myInt = int.Parse(Price.Text) - int.Parse(textBox1.Text);
                textBox2.Text = myInt.ToString();
            }
            catch
            {
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        
       

        
    }
}
