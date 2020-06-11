using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

 

namespace Forpractice1
{
    public partial class Form1 : Form
    {
        string intToPass;
        string noe;
        
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
            
            //try  //برای مدیریت خطا
            //{
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها
            con.Open();
            OleDbCommand com = new OleDbCommand();
            //if (naghd.Checked)
            //{
            //    noe = "نقد";

            //}
            //else
            //{
            //    noe = "چک";

            //}
            if (comboBoxEx1.SelectedIndex == 0)
            {
                noe = "نقد";
            }
            else if (comboBoxEx1.SelectedIndex == 1)
            {
                noe = "نقد و چک";
            }

            com.CommandText = "insert into table1(name,family,mobile,codemeli,noebime,Price,noepardakht,baghimande) values('" + txtname.Text + "','" + txtfamily.Text + "','" + txtmobile.Text + "','" + Codemeli.Text + "','" + txtnobime.Text + "','" + Price.Text + "','" + noe + "','" +  textBox2.Text + "')"; // کد درج در پایگاه داده ها
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
           // textBox1.Clear();
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
            intToPass = "0";
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            year.Text = pc.GetYear(DateTime.Now).ToString();
            month.Text = pc.GetMonth(DateTime.Now).ToString();
            day.Text=pc.GetDayOfMonth(DateTime.Now).ToString();
            comboBoxEx1.SelectedIndex = 0;
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
                    btnnamayesh_Click(sender, e);

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
            intToPass = label10.Text;


            //txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txtfamily.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            try //برای مدیریت خطا
            {
                //int a = int.Parse(txtcount .Text);
                int c = int.Parse(Price.Text);
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

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
               // int myInt = int.Parse(Price.Text) - int.Parse(textBox1.Text);
               // textBox2.Text = myInt.ToString();
            }
            catch
            {
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //groupBox3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" || textBox4.Text != "")
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها  
                OleDbDataAdapter da = new OleDbDataAdapter("select * from table1 where name='" + textBox5.Text + "' OR family='" + textBox4.Text + "'", con); // کدهای نمایش در دیتا گرید ویو
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





        }

        private void button4_Click(object sender, EventArgs e)
        {
            formmoshtari frm = new formmoshtari(); // برای نمایش فرم
            frm.str(intToPass);
            frm.Show();
        }





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtfamily.Focus();
            }

        }
        private void txtfamily_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Codemeli.Focus();
            }
        }

        private void Codemeli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnobime.Focus();
            }
        }

        private void txtnobime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Price.Focus();
            }
        }

        private void btnsabt_Click_1(object sender, EventArgs e)
        {
            btnsabt_Click(sender,e);
        }

        private void btnnamayesh_Click_1(object sender, EventArgs e)
        {
            btnnamayesh_Click(sender, e);
        }

        private void btnhazf_Click_1(object sender, EventArgs e)
        {
            btnhazf_Click(sender, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void tcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (tcheck.Checked == true)
            {
                labelX1.Enabled = false;
                labelX2.Enabled = false;

                textBox4.Enabled = false;
                textBox5.Enabled = false;
                day.Enabled = true;
                month.Enabled = true;
                year.Enabled = true;
                labelX12.Enabled = true;
            }
            else
            {
                labelX1.Enabled = true;
                labelX2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                day.Enabled = false;
                month.Enabled = false;
                year.Enabled = false;

                labelX12.Enabled = false;

            }

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button3_Click(sender, e); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmobile.Focus();
            }

        }

        private void comboBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //textBox1.Focus();
            }
        }
        private void comboBoxEx1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex == 0)
            {
                comboBoxEx2.Enabled = false;
                textBox1.Enabled = true;

            }
            else if (comboBoxEx1.SelectedIndex == 1)
            {
                comboBoxEx2.Enabled = true;
                textBox1.Enabled = true;

            }
            else if (comboBoxEx1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                comboBoxEx2.Enabled = true;

            }



        }

        private void txtmobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxEx1.Focus();
            }
            
        }

        private void comboBoxEx1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (comboBoxEx1.SelectedIndex == 0 && e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
            else if (comboBoxEx1.SelectedIndex == 1 && e.KeyCode == Keys.Enter)
            {
                comboBoxEx2.Focus();
            }
            else if (comboBoxEx1.SelectedIndex == 2 && e.KeyCode == Keys.Enter)
            {
                comboBoxEx2.Focus();
            }

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int t;
                t = int.Parse(Price.Text) - int.Parse(textBox1.Text);
                textBox2.Text = t.ToString();
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsabt_Click(sender, e);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void comboBoxEx2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmChek frm = new frmChek();
                frm.Owner = this;
                textBox1.Tag = comboBoxEx2.SelectedText;
                frm.Show();
            }
        }

    }


}