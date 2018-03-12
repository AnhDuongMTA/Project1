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

namespace QLNhanSu.View
{
    public partial class frmPhongBan : Form
    {
        private int flagLuu = 0;
        public frmPhongBan()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ADMIN_PC\SQLEXPRESS;Initial Catalog=QuanLyNhanVien1;Integrated Security=True");
        private void HienThi()
        {
            try
            {
                string sql = "SELECT * FROM PhongBan";          // lấy hết dữ liệu ở bảng nhân viên
                SqlCommand cm = new SqlCommand(sql, conn);      // bắt đầu truy vấn
                cm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cm);     //vận chuyển dữ liệu về
                DataTable dt = new DataTable();                 //tạo 1 kho ảo để chứa dữ liệu
                da.Fill(dt);
                dgvPB.DataSource = dt;//hiển thị dữ liệu     
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("loi ket noi" + ex.Message);
            }
             
        }
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            conn.Open();
            HienThi();
            DisEnl(false);
        }
        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtMa.Enabled = e;
            txtTen.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSdt.Enabled = e ;
        }
        private void clearData()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            clearData();
            DisEnl(true);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flagLuu == 0)
            {     
                SqlCommand cmd = new SqlCommand("Them_PB", conn);
                // Khai báo kiểu thực thi là Thực thi thủ tục
                cmd.CommandType = CommandType.StoredProcedure;
                // Khai báo và gán giá trị cho các tham số đầu vào của thủ tục
                // Khai báo tham số thứ nhất @Ma - là tên tham số được tạo trong thủ tục
                SqlParameter p = new SqlParameter("@Ma", txtMa.Text);
                cmd.Parameters.Add(p);
                // Khởi tạo tham số thứ 2 trong thủ tục là @Ten
                p = new SqlParameter("@Ten", txtTen.Text);
                cmd.Parameters.Add(p);
                // Thực thi thủ tục
                p = new SqlParameter("@Diachi", txtDiaChi.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Sdt", txtSdt.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Thêm mới thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    HienThi();
                }
                else { MessageBox.Show("Không thể thêm mới","Lỗi!",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            }

           if(flagLuu==1)
            {
                SqlCommand cmd = new SqlCommand("SUA_PB", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", txtMa.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@Ten", txtTen.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@Sdt", txtSdt.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Sửa thành công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    HienThi();
                }
                else MessageBox.Show("Không sửa được!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Information);;
            }
            conn.Close();  
            frmPhongBan_Load(sender, e);
                   
        }
        private void dgvPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMa.Text = Convert.ToString(dgvPB.CurrentRow.Cells["MaPB"].Value);
                txtTen.Text = Convert.ToString(dgvPB.CurrentRow.Cells["TenPB"].Value);
                txtDiaChi.Text = Convert.ToString(dgvPB.CurrentRow.Cells["DiaChi"].Value);
                txtSdt.Text = Convert.ToString(dgvPB.CurrentRow.Cells["SDT"].Value);
            }
        }
        private void dgvPB_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvPB.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                HienThi();
                DisEnl(false);       
            }
            else
                return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("Xoa_PB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@Ma", txtMa.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    HienThi();
                    txtMa.Text = "";
                    txtTen.Text = "";
                    txtDiaChi.Text = "";
                    txtSdt.Text = "";
                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");              
            }
            conn.Close();
            frmPhongBan_Load(sender, e);
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                HienThi();
                DisEnl(false);
            }
        }
    }
}
