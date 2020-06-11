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
    
    public partial class frmChek : Form
    {
        int cnt=1;
        int Tag;
        public frmChek()
        {
            InitializeComponent();
        }

        private void frmChek_Load(object sender, EventArgs e)
        {
            Tag=int.Parse((this.Owner as Form1).textBox1.Tag.ToString());

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            textBox5.Text = pc.GetYear(DateTime.Now).ToString();
            textBox4.Text = pc.GetMonth(DateTime.Now).ToString();
            textBox2.Text = pc.GetDayOfMonth(DateTime.Now).ToString();
           

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void frmChek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
           
           if (e.KeyCode == Keys.Enter )
           {
               if (cnt < Tag)
               {

                   (this.Owner as Form1).textBox1.Tag = "Saeed";
                   cnt += 1;
                   lblnum.Text = cnt.ToString();
               }else{this.Close();}

           }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }
    }
}
