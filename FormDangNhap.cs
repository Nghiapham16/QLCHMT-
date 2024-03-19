using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLCHMT.Class;


namespace QLCHMT
{
    public partial class FormDangNhap : Form
    {
        
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9BTIAHO\SQLEXPRESS;Initial Catalog=QLcuahangmaytinh;Integrated Security=True");
            SqlDataAdapter dap = new SqlDataAdapter("select * from tblDangNhap Where TenTaiKhoan = N'"+textBox1.Text+"'and MatKhau = N'"+textBox2.Text+"'",con);
            DataTable dtt = new DataTable();
            dap.Fill(dtt);
            if(dtt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 frm = new Form1(dtt.Rows[0][0].ToString(), dtt.Rows[0][1].ToString(), dtt.Rows[0][2].ToString(), dtt.Rows[0][3].ToString());
                frm.Show();
                
            }
            else
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Sai", "Thông Báo");
                textBox1.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;

            }
            else
            {
                textBox2.PasswordChar = '*';

            }
        }
    }
}
