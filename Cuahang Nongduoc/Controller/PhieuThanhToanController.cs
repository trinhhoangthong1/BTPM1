using System;
using System.Collections.Generic;
using System.Text;
using CuahangNongduoc.DataLayer;
using CuahangNongduoc.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace CuahangNongduoc.Controller
{
    
    public class PhieuThanhToanController
    {
        PhieuThanhToanFactory factory = new PhieuThanhToanFactory();


        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public void Save()
        {
            factory.Save();
        }

        public PhieuThanhToan LayPhieuThanhToan(String id)
        {
            PhieuThanhToan ph = null;
            DataTable tbl = factory.LayPhieuThanhToan(id);
            if (tbl.Rows.Count > 0 )
            {
                ph = new PhieuThanhToan();
                ph.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                KhachHangController ctrlKH = new KhachHangController();
                ph.KhachHang = ctrlKH.LayKhachHang(Convert.ToString(tbl.Rows[0]["ID_KHACH_HANG"]));
                ph.NgayNhap = Convert.ToDateTime(tbl.Rows[0]["NGAY_THANH_TOAN"]);
                ph.TongTien = Convert.ToInt64(tbl.Rows[0]["TONG_TIEN"]);
                ph.GhiChu = Convert.ToString(tbl.Rows[0]["GHI_CHU"]);
            }
            return ph;
        }
        
        public void HienthiPhieuThanhToan(DataGridView dgv)
        {

            try
            {
                dgv.DataSource = factory.DanhsachPhieuThanhToan_KH();
                dgv.Columns["ID"].HeaderText = "Mã Phiếu";
                dgv.Columns["HO_TEN"].HeaderText = "Tên KH";
                dgv.Columns["NGAY_THANH_TOAN"].HeaderText = "Ngày TT";
                dgv.Columns["SO_TIEN"].HeaderText = "Số Tiền";
                dgv.Columns["GIA_VC"].HeaderText = "Phí VC";
                dgv.Columns["GIA_PS"].HeaderText = "Phí PS";
                dgv.Columns["CHIET_KHAU"].HeaderText = "Chiết Khấu";
                dgv.Columns["GIAM_GIA"].HeaderText = "Giảm Giá";
                dgv.Columns["TONG_TIEN"].HeaderText = "Tổng Tiền";
                dgv.Columns["GHI_CHU"].HeaderText = "Ghi Chú";
                dgv.Columns["ID_VC"].Visible = false;
                dgv.Columns["ID_PS"].Visible = false;
            }
            catch 
            {
            }
        }
        public bool Delete(string id_phieu)
        {
            return factory.Delete(id_phieu);
        }
        public void Store(PhieuThanhToan phieu)
        {
            int PhanTramGiam = phieu.GiamGia + phieu.ChietKhau;
            long so_tien_giam = phieu.SoTien * PhanTramGiam / 100;
            long tong_chi_phi = phieu.VanChuyen.Gia + phieu.ChiPhiPhatSinh.Gia;
            phieu.TongTien = phieu.SoTien + tong_chi_phi - so_tien_giam;
            factory.Store(phieu);
        }
        public bool Update(PhieuThanhToan phieu)
        {
            int PhanTramGiam = phieu.GiamGia + phieu.ChietKhau;
            long so_tien_giam = phieu.SoTien * PhanTramGiam / 100;
            long tong_chi_phi = phieu.VanChuyen.Gia + phieu.ChiPhiPhatSinh.Gia;
            phieu.TongTien = phieu.SoTien + tong_chi_phi - so_tien_giam;
            return factory.Update(phieu);
        }

        public void TimPhieuThanhToan(BindingNavigator bn, DataGridView dg, ComboBox cmb, TextBox txt, DateTimePicker dt, NumericUpDown numTongTien, TextBox txtGhichu,
            String idKH, DateTime dtNgayThu)
        {
            
            BindingSource bs = new BindingSource();
            bs.DataSource = factory.TimPhieuThanhToan(idKH, dtNgayThu);
            bn.BindingSource = bs;
            dg.DataSource = bs;


            txt.DataBindings.Clear();
            txt.DataBindings.Add("Text", bs, "ID");

            cmb.DataBindings.Clear();
            cmb.DataBindings.Add("SelectedValue", bs, "ID_KHACH_HANG");

            dt.DataBindings.Clear();
            dt.DataBindings.Add("Value", bs, "NGAY_THANH_TOAN");

            numTongTien.DataBindings.Clear();
            numTongTien.DataBindings.Add("Value", bs, "TONG_TIEN");

            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", bs, "GHI_CHU");
        }

        
    }
}
