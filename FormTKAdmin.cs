using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QLCHMT.Class; //Sử dụng class Functions.cs

namespace QLCHMT
{
    public partial class FormTKAdmin : Form
    {
        DataTable TKA;
        

        public FormTKAdmin()
        {
            InitializeComponent();
          

        }

        private void FormTKAdmin_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Enabled = false;
            txtNguoiDung.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblDangNhap";
            TKA = Class.Functions.GetDataToDatatable(sql); //Đọc dữ liệu từ bảng
            dgvTaiKhoan.DataSource = TKA; //Nguồn dữ liệu            
            dgvTaiKhoan.Columns[1].HeaderText = "TenTaiKhoan";
            dgvTaiKhoan.Columns[2].HeaderText = "MatKhau";
            dgvTaiKhoan.Columns[3].HeaderText = "Quyen";
            dgvTaiKhoan.Columns[0].HeaderText = "TenNguoiDung";
            dgvTaiKhoan.Columns[0].Width = 100;
            dgvTaiKhoan.Columns[1].Width = 300;
            dgvTaiKhoan.Columns[2].Width = 300;
            dgvTaiKhoan.Columns[3].Width = 300;
            dgvTaiKhoan.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            if (TKA.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells["TenTaiKhoan"].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtQuyen.Text = dgvTaiKhoan.CurrentRow.Cells["Quyen"].Value.ToString();
            txtNguoiDung.Text = dgvTaiKhoan.CurrentRow.Cells["TenNguoiDung"].Value.ToString();
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
                txtTaiKhoan.Enabled = true; //cho phép nhập mới
                txtTaiKhoan.Focus();
                txtNguoiDung.Enabled = true;
            
        }
        private void ResetValue()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtQuyen.Text = "";
            txtNguoiDung.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string sql; //Lưu lệnh sql
            if (txtTaiKhoan.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập Tên Tài Khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            if (txtQuyen.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập Quyền ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuyen.Focus();
                return;
            }
            if (txtNguoiDung.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNguoiDung.Focus();
                return;
            }
            sql = "Select * From tblDangNhap where TenTaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Tên tài khoản  này đã có, bạn phải nhập  khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            sql = "INSERT INTO tblDangNhap VALUES(N'" + txtNguoiDung.Text + "',N'" + txtTaiKhoan.Text + "',N'" + txtMatKhau.Text + "',N'" + txtQuyen.Text + "')";
            Class.Functions.RunSQl(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtNguoiDung.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (TKA.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTaiKhoan.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập Mật Khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtQuyen.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNguoiDung.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblDangNhap SET MatKhau=N'" +
                txtMatKhau.Text.ToString() +
                "' WHERE TenTaiKhoan=N'" + txtTaiKhoan.Text + "'";
            Class.Functions.RunSQl(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (TKA.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTaiKhoan.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblDangNhap WHERE TenTaiKhoan=N'" + txtTaiKhoan.Text + "'";
                Class.Functions.RunSQl(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtNguoiDung.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
