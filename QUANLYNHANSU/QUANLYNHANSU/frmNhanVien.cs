using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ValueObject;
using BUS;
namespace QUANLYNHANSU
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        NhanVien nv = new NhanVien();
        NhanVienBUS nvbus = new NhanVienBUS();
        bool nutthem = false;
        void KhoaDieuKhien()
        {
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtDanToc.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtLuong.Enabled = false;
            txtQuaQuan.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
        void MoKhoaDieuKhien()
        {
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtDanToc.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtLuong.Enabled = true;
            txtQuaQuan.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        void XoaText()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDanToc.Text = "";
            txtGioiTinh.Text = "";
            txtLuong.Text = "";
            txtQuaQuan.Text = "";
            txtNgaySinh.Text = "";
            txtSDT.Text = "";
        }
        void HienThi()
        {
            dtgvData.DataSource = nvbus.GetData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            nutthem = true;
            XoaText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            txtMaNV.Enabled = false;
            nutthem = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("ban co muon xoa thong tin nay khong","Thong bao",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                try
                {
                    nvbus.XoaNV(txtMaNV.Text);
                    XtraMessageBox.Show("Đã xóa thành công");
                    XoaText();
                    KhoaDieuKhien();
                    HienThi();
                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            nv.MaNV1= txtMaNV.Text;
            nv.TenNV1 = txtTenNV.Text;
            nv.QueQuan1 = txtQuaQuan.Text;
            nv.GioiTinh1 = txtGioiTinh.Text;
            nv.SDT1 = txtSDT.Text;
            nv.NgaySinh1 =Convert.ToDateTime(txtNgaySinh.Text);
            nv.DanToc1 = txtDanToc.Text;
            if (nutthem==true)
            {
                //them
                nvbus.ThemNV(nv);
                XtraMessageBox.Show("da them moi nhan vien thanh cong");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
            else
            {
                //sua
                nvbus.SuaNV(nv);
                XtraMessageBox.Show("da sua nhan vien thanh cong");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }

        }

        private void dtgvData_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtMaNV.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns[0]).ToString();
                txtTenNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtDanToc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtGioiTinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txtSDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtQuaQuan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtNgaySinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
}