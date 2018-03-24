using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using System.Data;
namespace DAL
{
    public class NhanVienDAL : dbConnect
    {
        dbConnect db = new dbConnect();
        public DataTable GetData()
        {
            return db.GetData("SP_SelectAllNV", null);
        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para = { new SqlParameter("ID", id) };
            return db.GetData("SP_SelectAllNV_ByID", para);
        }
        public int ThemNV(NhanVien obj)
        {
            SqlParameter[] para =
            {
                    new SqlParameter("MaNV", obj.MaNV1),
                    new SqlParameter("TenNV", obj.TenNV1),
                    new SqlParameter("DanToc", obj.DanToc1),
                    new SqlParameter("GioiTinh", obj.GioiTinh1),
                    new SqlParameter("SDT", obj.SDT1),
                    new SqlParameter("QueQuan", obj.QueQuan1),
                    new SqlParameter("NgaySinh", obj.NgaySinh1)
            };
            return db.ExecuteSQL("SP_ThemNV",para);
        }
        public int SuaNV(NhanVien obj)
        {
            SqlParameter[] para =
            {
                    new SqlParameter("MaNV", obj.MaNV1),
                    new SqlParameter("TenNV", obj.TenNV1),
                    new SqlParameter("DanToc", obj.DanToc1),
                    new SqlParameter("GioiTinh", obj.GioiTinh1),
                    new SqlParameter("SDT", obj.SDT1),
                    new SqlParameter("QueQuan", obj.QueQuan1),
                    new SqlParameter("NgaySinh", obj.NgaySinh1)
            };
            return db.ExecuteSQL("SP_SuaNV", para);
        }
        public int XoaNV(string id)
        {
            SqlParameter[] para =
            {
                    new SqlParameter("MaNV", id)
            };
            
            return db.ExecuteSQL("SP_XoaNV", para);
        }
    }
}
