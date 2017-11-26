using System;
using System.Collections.Generic;
using System.Text;
namespace CuahangNongduoc.BusinessObject
{
    public class PhieuThanhToan
    {
        public PhieuThanhToan()
        {
            VanChuyen = new VanChuyen();
            ChiPhiPhatSinh = new ChiPhiPhatSinh();
            KhachHang = new KhachHang();
        }

        private String m_Id;
        private DateTime m_NgayNhap;
        private long m_TongTien;
        private KhachHang m_KH;
        private String m_GhiChu;
        private long m_SoTien;
        private VanChuyen m_VanChuyen;
        private ChiPhiPhatSinh m_ChiPhiPhatSinh;
        private int m_ChietKhau;
        private int m_GiamGia;

        public int GiamGia
        {
            get
            {
                return m_GiamGia;
            }

            set
            {
                m_GiamGia = value;
            }
        }


        public string Id
        {
            get
            {
                return m_Id;
            }

            set
            {
                m_Id = value;
            }
        }

        public DateTime NgayNhap
        {
            get
            {
                return m_NgayNhap;
            }

            set
            {
                m_NgayNhap = value;
            }
        }

        public long TongTien
        {
            get
            {
                return m_TongTien;
            }

            set
            {
                m_TongTien = value;
            }
        }

        public KhachHang KhachHang
        {
            get
            {
                return m_KH;
            }

            set
            {
                m_KH = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return m_GhiChu;
            }

            set
            {
                m_GhiChu = value;
            }
        }

        public long SoTien
        {
            get
            {
                return m_SoTien;
            }

            set
            {
                m_SoTien = value;
            }
        }

        public VanChuyen VanChuyen
        {
            get
            {
                return m_VanChuyen;
            }

            set
            {
                m_VanChuyen = value;
            }
        }

        public ChiPhiPhatSinh ChiPhiPhatSinh
        {
            get
            {
                return m_ChiPhiPhatSinh;
            }

            set
            {
                m_ChiPhiPhatSinh = value;
            }
        }

        public int ChietKhau
        {
            get
            {
                return m_ChietKhau;
            }

            set
            {
                m_ChietKhau = value;
            }
        }
    }
}