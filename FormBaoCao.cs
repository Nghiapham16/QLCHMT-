using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QLCHMT.Class; //Sử dụng class Functions.cs


namespace QLCHMT
{
    public partial class FormBaoCao : Form
    {
        DataTable tblBC;
        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
           

            string sql;
            sql = "select * from tblHDBan ";
            tblBC = Class.Functions.GetDataToDatatable(sql);
            Class.Functions.RunSQl(sql);
            DataSet ds = new DataSet();
            chart1.DataSource = tblBC;
            chart1.Series["chart1"].XValueMember = "NgayBan";
            chart1.Series["chart1"].YValueMembers = "TongTien";
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            sql = "select * from tblHang";
            tblBC = Class.Functions.GetDataToDatatable(sql);
            Class.Functions.RunSQl(sql);
            DataSet dst = new DataSet();
            chart2.DataSource = tblBC;
            chart2.Series["MT"].XValueMember = "TenHang";
            chart2.Series["MT"].YValueMembers = "DonGiaBan";
            chart2.Series[0].ChartType = SeriesChartType.Pie;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
