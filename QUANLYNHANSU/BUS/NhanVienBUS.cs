using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using ValueObject;
namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAL nvdao = new NhanVienDAL();
        public DataTable GetData()
        {
            return nvdao.GetData();
        }
        public DataTable GetDataByID(string id)
        {
            return nvdao.GetDataByID(id);
        }
        public int ThemNV(NhanVien obj)
        {
            return nvdao.ThemNV(obj);
        }
        public int SuaNV(NhanVien obj)
        {
            return nvdao.SuaNV(obj);
        }
        public int XoaNV(string id)
        {
            return nvdao.XoaNV(id);
        }
    }
}
