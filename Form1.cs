using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMT
{
    public partial class Form1 : Form
    {
        String TenNguoiDung = "", TenTaiKhoan = "", MatKhau = "", Quyen = "";

        public Form1(String TenNguoiDung, String TenTaiKhoan, String MatKhau, String Quyen)
        {
            InitializeComponent();
            this.TenNguoiDung = TenNguoiDung;
            this.TenTaiKhoan = TenTaiKhoan;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); //Mở kết nối
            
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mnuLoaiMT_Click(object sender, EventArgs e)
        {
            FormDMLoaiMayTinh frm = new FormDMLoaiMayTinh(); //Khởi tạo đối tượng
            frm.ShowDialog(); //Hiển thị
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FormDMNhanVien frm = new FormDMNhanVien();
            frm.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FormDmKhachHang frm = new FormDmKhachHang();
            frm.ShowDialog();
        }

        private void mnuMayTinh_Click(object sender, EventArgs e)
        {
            FormDMHang frm = new FormDMHang();
            frm.ShowDialog();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            FormHoaDon frm = new FormHoaDon();
            frm.Show();
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            FormTimHoaDon frm = new FormTimHoaDon();
            frm.ShowDialog();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDangNhap frm = new FormDangNhap();
            frm.Show();

        }

        private void mnuBCDanhThu_Click(object sender, EventArgs e)
        {
            FormBaoCao frm = new FormBaoCao();
            frm.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void loạiMáyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
                FormDMLoaiMayTinh frm = new FormDMLoaiMayTinh();
                frm.ShowDialog();
            }
            
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
                FormDMNhanVien f = new FormDMNhanVien();
                f.ShowDialog();
            }
            
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
                FormDmKhachHang f = new FormDmKhachHang();
                f.ShowDialog();
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

           
            FormTKAdmin f = new FormTKAdmin();
            f.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormHoaDon f = new FormHoaDon();
            f.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormDmKhachHang f = new FormDmKhachHang();
            f.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
                FormHoaDon f = new FormHoaDon();
                f.ShowDialog();
            }
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
         
                FormTKAdmin f = new FormTKAdmin();
                f.ShowDialog();
            }
            
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "User")
            {
                MessageBox.Show("Bạn Không Có Quyền Truy Cập", "Thông Báo");
            }
            else
            {
                FormBaoCao f = new FormBaoCao();
                f.ShowDialog();
            }
        }
            
    }
}
