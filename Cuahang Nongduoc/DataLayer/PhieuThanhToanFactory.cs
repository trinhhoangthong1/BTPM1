using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuThanhToanFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachPhieuThanhToan()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THANH_TOAN ");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public bool Update(PhieuThanhToan P)
        {
            try
            {
                string Query = @"UPDATE PHIEU_THANH_TOAN SET 
                                ID_VC = @vc,
                                ID_PS = @ps,
                                NGAY_THANH_TOAN = @ngtt,
                                TONG_TIEN = @tt,
                                ID_KHACH_HANG = @idkh,
                                GHI_CHU = @gc,
                                GIAM_GIA = @gg,
                                CHIET_KHAU = @ck,
                                SO_TIEN = @st 
                            WHERE ID = @id";
                OleDbCommand cmd = new OleDbCommand(Query);
                
                cmd.Parameters.Add("vc", OleDbType.Integer).Value = P.VanChuyen.Id;
                cmd.Parameters.Add("ps", OleDbType.Integer).Value = P.ChiPhiPhatSinh.Id;
                cmd.Parameters.Add("ngtt", OleDbType.DBDate).Value = P.NgayNhap;
                cmd.Parameters.Add("tt", OleDbType.Integer).Value = P.TongTien;
                cmd.Parameters.Add("idkh", OleDbType.VarChar).Value = P.KhachHang.Id;
                cmd.Parameters.Add("gc", OleDbType.VarChar).Value = P.GhiChu;
                cmd.Parameters.Add("gg", OleDbType.Integer).Value = P.GiamGia;
                cmd.Parameters.Add("ck", OleDbType.Integer).Value = P.ChietKhau;
                cmd.Parameters.Add("st", OleDbType.Integer).Value = P.SoTien;
                cmd.Parameters.Add("id", OleDbType.VarChar).Value = P.Id;
                m_Ds.ExecuteNoneQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }
    public bool Delete(string id_phieu)
        {
            try
            {
                string Query = "DELETE FROM PHIEU_THANH_TOAN WHERE ID = @id";
                OleDbCommand cmd = new OleDbCommand(Query);
                cmd.Parameters.Add("id", OleDbType.VarChar).Value = id_phieu;
                m_Ds.ExecuteNoneQuery(cmd);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public void Store(PhieuThanhToan P)
        {
            string Query = @"INSERT INTO PHIEU_THANH_TOAN VALUES(@id,@vc,@ps,@ngtt,@tt,@idkh,@gc,@gg,@ck,@st)";
            OleDbCommand cmd = new OleDbCommand(Query);
            cmd.Parameters.Add("id", OleDbType.VarChar).Value = P.Id;
            cmd.Parameters.Add("vc", OleDbType.Integer).Value = P.VanChuyen.Id;
            cmd.Parameters.Add("ps", OleDbType.Integer).Value = P.ChiPhiPhatSinh.Id;
            cmd.Parameters.Add("ngtt", OleDbType.DBDate).Value = P.NgayNhap;
            cmd.Parameters.Add("tt", OleDbType.Integer).Value = P.TongTien;
            cmd.Parameters.Add("idkh", OleDbType.VarChar).Value = P.KhachHang.Id;
            cmd.Parameters.Add("gc", OleDbType.VarChar).Value = P.GhiChu;
            cmd.Parameters.Add("gg", OleDbType.Integer).Value = P.GiamGia;
            cmd.Parameters.Add("ck", OleDbType.Integer).Value = P.ChietKhau;
            cmd.Parameters.Add("st", OleDbType.Integer).Value = P.SoTien;
            m_Ds.ExecuteNoneQuery(cmd);
        }
        public DataTable DanhsachPhieuThanhToan_KH()
        {
            OleDbCommand cmd = new OleDbCommand(@"SELECT 
                                                        PHIEU_THANH_TOAN.ID, 
                                                        KHACH_HANG.HO_TEN,
                                                        PHIEU_THANH_TOAN.NGAY_THANH_TOAN,
                                                        PHIEU_THANH_TOAN.SO_TIEN,
                                                        VAN_CHUYEN.GIA_VC, 
                                                        CHI_PHI_PHAT_SINH.GIA_PS,
                                                        PHIEU_THANH_TOAN.CHIET_KHAU,
                                                        PHIEU_THANH_TOAN.GIAM_GIA,
                                                        PHIEU_THANH_TOAN.GHI_CHU,
                                                        PHIEU_THANH_TOAN.TONG_TIEN,
                                                        PHIEU_THANH_TOAN.ID_VC,
                                                        PHIEU_THANH_TOAN.ID_PS
                                                  FROM PHIEU_THANH_TOAN,KHACH_HANG,VAN_CHUYEN,CHI_PHI_PHAT_SINH
                                                  WHERE PHIEU_THANH_TOAN.ID_KHACH_HANG = KHACH_HANG.ID AND
                                                        PHIEU_THANH_TOAN.ID_VC = VAN_CHUYEN.ID_VC AND   
                                                        PHIEU_THANH_TOAN.ID_PS = CHI_PHI_PHAT_SINH.ID_PS");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable TimPhieuThanhToan(String kh, DateTime ngay)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THANH_TOAN WHERE ID_KHACH_HANG=@kh AND NGAY_THANH_TOAN = @ngay");
            cmd.Parameters.Add("kh", OleDbType.VarChar).Value = kh;
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = ngay;

            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable LayPhieuThanhToan(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THANH_TOAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }


        public static long LayTongTien(String kh, int thang, int nam)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(TONG_TIEN) FROM PHIEU_THANH_TOAN WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_THANH_TOAN)=@thang AND YEAR(NGAY_THANH_TOAN)= @nam");
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);

            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);
        }

        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
        public bool Save()
        {

            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
