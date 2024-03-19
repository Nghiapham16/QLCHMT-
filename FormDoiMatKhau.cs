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
    public partial class FormDoiMatKhau : Form
    {
        DataTable DMK;
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtNhapLai.PasswordChar = '*';
        }
        private void ResetValue()
        {
            txtTaiKhoan.Text = "";
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLai.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM tblDangNhap";
            DMK = Class.Functions.GetDataToDatatable(sql);
            errorProvider1.Clear();
            if (txtTaiKhoan.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập Tên Tài Khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }            
            if (txtMatKhauCu.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập Mật Khẩu Cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập Mật Khẩu Mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            if (txtNhapLai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật Khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhapLai.Focus();
                return;
            }
            sql = "Select * From tblDangNhap where TenTaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Tên tài khoản này chưa  đã có, bạn phải nhập  khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            sql = "Select * From tblDangNhap where MatKhau=N'" + txtMatKhauCu.Text.Trim() + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mật Khẩu này không đúng, bạn phải nhập  lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }
            else
            {
                sql = "Select count (*) From tblDangNhap where TenTaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "' and MatKhau=N'" + txtMatKhauCu.Text.Trim() + "' ";
               
                    if (txtMatKhauMoi.Text.Trim() == txtNhapLai.Text.Trim())
                    {
                        sql = "Update tblDangNhap set MatKhau=N'" + txtMatKhauMoi.Text.Trim() + "' where TenTaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "' and MatKhau=N'" + txtMatKhauCu.Text.Trim() + "'";
                        Class.Functions.RunSQl(sql);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công ", "Thông Báo");
                    ResetValue();
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Nhập Lại Không Trùng", "Thông Báo");
                    }
                
            }
           
            if(txtMatKhauCu.Text.Trim() == txtMatKhauMoi.Text.Trim())
            {
                MessageBox.Show("Mật Khẩu Cũ Trùng Với Mật Khẩu Mới", "Thông Báo");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMatKhauCu.PasswordChar = (char)0;
                txtMatKhauMoi.PasswordChar = (char)0;
                txtNhapLai.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhauCu.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar = '*';
                txtNhapLai.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
