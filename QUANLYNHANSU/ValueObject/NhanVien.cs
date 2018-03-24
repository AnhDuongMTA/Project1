using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject
{
    public class NhanVien
    {
        private string MaNV, TenNV, GioiTinh, Luong, DanToc, SDT, QueQuan;
        private DateTime NgaySinh;

        public string DanToc1
        {
            get
            {
                return DanToc;
            }

            set
            {
                DanToc = value;
            }
        }

        public string GioiTinh1
        {
            get
            {
                return GioiTinh;
            }

            set
            {
                GioiTinh = value;
            }
        }

        public string Luong1
        {
            get
            {
                return Luong;
            }

            set
            {
                Luong = value;
            }
        }

        public string MaNV1
        {
            get
            {
                return MaNV;
            }

            set
            {
                MaNV = value;
            }
        }

        public DateTime NgaySinh1
        {
            get
            {
                return NgaySinh;
            }

            set
            {
                NgaySinh = value;
            }
        }

        public string QueQuan1
        {
            get
            {
                return QueQuan;
            }

            set
            {
                QueQuan = value;
            }
        }

        public string SDT1
        {
            get
            {
                return SDT;
            }

            set
            {
                SDT = value;
            }
        }

        public string TenNV1
        {
            get
            {
                return TenNV;
            }

            set
            {
                TenNV = value;
            }
        }
    }
}
