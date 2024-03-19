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
    public partial class FormNhaCC : Form
    {
        DataTable tblNCC;
        public FormNhaCC()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormNhaCC_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView(); 
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblNhaCC";
            tblNCC = Class.Functions.GetDataToDatatable(sql); 
            dgvLoaiMT.DataSource = tblNCC;           
            dgvLoaiMT.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvLoaiMT.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
            dgvLoaiMT.Columns[2].HeaderText = "Địa Chỉ";
            dgvLoaiMT.Columns[3].HeaderText = "Mã Số Thuế";
            dgvLoaiMT.Columns[4].HeaderText = "Tài Khoản";
            dgvLoaiMT.Columns[5].HeaderText = "Số Điện Thoại";
            dgvLoaiMT.Columns[0].Width = 100;
            dgvLoaiMT.Columns[1].Width = 300;
            dgvLoaiMT.Columns[2].Width = 300;
            dgvLoaiMT.Columns[3].Width = 300;
            dgvLoaiMT.Columns[4].Width = 300;
            dgvLoaiMT.Columns[5].Width = 300;
            dgvLoaiMT.AllowUserToAddRows = false; 
            dgvLoaiMT.EditMode = DataGridViewEditMode.EditProgrammatically; 
        }

        private void dgvLoaiMT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaChatLieu.Text = dgvLoaiMT.CurrentRow.Cells["MaNhaCC"].Value.ToString();
            txtTenLoaiMayTinh.Text = dgvLoaiMT.CurrentRow.Cells["TenNhaCC"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaChatLieu.Enabled = true; //cho phép nhập mới
            txtMaChatLieu.Focus();
        }
        private void ResetValue()
        {
            txtMaChatLieu.Text = "";
            txtTenLoaiMayTinh.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaChatLieu.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenLoaiMayTinh.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiMayTinh.Focus();
                return;
            }
            sql = "Select MaLoaiMayTinh From tblLoaiMayTinh where MaLoaiMaytinh=N'" + txtMaChatLieu.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                return;
            }

            sql = "INSERT INTO tblLoaiMayTinh VALUES(N'" +
                txtMaChatLieu.Text + "',N'" + txtTenLoaiMayTinh.Text + "')";
            Class.Functions.RunSQl(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }
    }
}
