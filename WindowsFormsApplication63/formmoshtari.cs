using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;  //برای گزارش گیری

namespace Forpractice1
{
    public partial class formmoshtari : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database.accdb");  //کدهای اتصال به پایگاه داده ها
        DataSet dd = new DataSet();
         
        string str1;
        public formmoshtari()
        {
            InitializeComponent();
        }


        public void str(string a)
        {
            str1 = a.ToString();


        }


        private void formmoshtari_Load(object sender, EventArgs e)
        {
            
            try //برای مدیریت خطا
            {
                con.Open();
                ReportDocument rp1 = new ReportDocument();
                //rp1.FileName = "CrystalReport1.rpt";
                rp1.Load(System.Windows.Forms.Application.StartupPath + "\\CrystalReport1.rpt");


                crystalReportViewer1.ReportSource = rp1;
                crystalReportViewer1.Show();


                OleDbDataAdapter dA = new OleDbDataAdapter("select * from table1 where id="+str1, con);
                dA.Fill(dd, "table1");
                showreport();
                con.Close();
            }
            catch  //برای مدیریت خطا
            {
                MessageBox.Show("خطا در اتصال به بانک اطلاعاتی");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //بستن فرم مورد نظر
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void showreport()
        {
            try
            {
                ReportDocument r = new ReportDocument();
                r.FileName = "CrystalReport1.rpt";
                r.SetDataSource(dd);
                crystalReportViewer1.ReportSource = r;
                crystalReportViewer1.Show();
            }
            catch
            {
                MessageBox.Show("خطا در نمایش گزارش");
            }
        }
    }
}
