using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forpractice1
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close(); //برای خروج از فرم
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formmoshtari frm1 = new formmoshtari(); // برای نمایش فرم
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1(); //برای نمایش فرم
            form.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            formmoshtari frm1 = new formmoshtari(); // برای نمایش فرم
            frm1.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
