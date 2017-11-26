using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc
{
    public partial class frmThanhToan : Form
    {
        KhachHangController ctrlKH = new KhachHangController();
        PhieuThanhToanController ctrl = new PhieuThanhToanController();
        VanChuyenController ctrlVC = new VanChuyenController();
        ChiPhiPhatSinhController ctrlPS = new ChiPhiPhatSinhController();
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            ctrlVC.HienThiLenComboBox(cbbChiPhiVC);
            ctrlPS.HienThiLenComboBox(cbbChiPhiPS);

            ctrlKH.HienthiChungAutoComboBox(cmbKhachHang);
            //ctrlKH.HienthiKhachHangChungDataGridviewComboBox(colKhachHang);
            //ctrl.HienthiPhieuThanhToan(bindingNavigator, dataGridView, cmbKhachHang, txtMaPhieu, dtNgayThanhToan, numTongTien, txtGhiChu);
            ctrl.HienthiPhieuThanhToan(dataGridView);
            //bindingNavigator.BindingSource.AddingNew += new AddingNewEventHandler(BindingSource_AddingNew);
        }

        void BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                long maphieu = ThamSo.LayMaPhieuThanhToan()+1;
                ThamSo.GanMaPhieuThanhToan(maphieu + 1);

                PhieuThanhToan phieuthanhtoan = new PhieuThanhToan();
                phieuthanhtoan.Id = maphieu.ToString();
                phieuthanhtoan.VanChuyen.Id = int.Parse(cbbChiPhiVC.SelectedValue.ToString());
                phieuthanhtoan.VanChuyen.Ten = cbbChiPhiVC.Text;
                phieuthanhtoan.VanChuyen.Gia = int.Parse(txtChiPhiVC.Text);
                phieuthanhtoan.ChiPhiPhatSinh.Id = int.Parse(cbbChiPhiPS.SelectedValue.ToString());
                phieuthanhtoan.ChiPhiPhatSinh.Ten = cbbChiPhiPS.Text;
                phieuthanhtoan.ChiPhiPhatSinh.Gia = int.Parse(txtChiPhiPS.Text);
                phieuthanhtoan.NgayNhap = DateTime.Now;
                phieuthanhtoan.KhachHang.Id = cmbKhachHang.SelectedValue.ToString();
                phieuthanhtoan.GhiChu = txtGhiChu.Text;
                phieuthanhtoan.ChietKhau = int.Parse(numChietKhau.Value.ToString());
                phieuthanhtoan.GiamGia = int.Parse(numGiamGia.Value.ToString());
                phieuthanhtoan.SoTien = long.Parse(numTongTien.Value.ToString());
                ctrl.Store(phieuthanhtoan);
                ctrl.HienthiPhieuThanhToan(dataGridView);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //bindingNavigator.BindingSource.MoveLast();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phiếu thanh toán này không?", "Phieu Thanh Toan",   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string id_phieu = dataGridView.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Bạn chắc chắn xóa phiếu có ID = "+id_phieu, "Phiếu Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if(ctrl.Delete(id_phieu))
                {
                    MessageBox.Show("Đã xóa");
                    ctrl.HienthiPhieuThanhToan(dataGridView);
                }
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuThanhToan phieuthanhtoan = new PhieuThanhToan();
                phieuthanhtoan.Id = txtMaPhieu.Text;
                phieuthanhtoan.VanChuyen.Id = int.Parse(cbbChiPhiVC.SelectedValue.ToString());
                phieuthanhtoan.VanChuyen.Ten = cbbChiPhiVC.Text;
                phieuthanhtoan.VanChuyen.Gia = int.Parse(txtChiPhiVC.Text);
                phieuthanhtoan.ChiPhiPhatSinh.Id = int.Parse(cbbChiPhiPS.SelectedValue.ToString());
                phieuthanhtoan.ChiPhiPhatSinh.Ten = cbbChiPhiPS.Text;
                phieuthanhtoan.ChiPhiPhatSinh.Gia = int.Parse(txtChiPhiPS.Text);
                phieuthanhtoan.NgayNhap = DateTime.Now;
                phieuthanhtoan.KhachHang.Id = cmbKhachHang.SelectedValue.ToString();
                phieuthanhtoan.GhiChu = txtGhiChu.Text;
                phieuthanhtoan.ChietKhau = int.Parse(numChietKhau.Value.ToString());
                phieuthanhtoan.GiamGia = int.Parse(numGiamGia.Value.ToString());
                phieuthanhtoan.SoTien = long.Parse(numTongTien.Value.ToString());
                if(ctrl.Update(phieuthanhtoan))
                {
                    MessageBox.Show("Cập nhật phiếu thành công");
                    ctrl.HienthiPhieuThanhToan(dataGridView);
                }
            }
            catch
            {
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row != null)
            {
                PhieuThanhToanController ctrlTT = new PhieuThanhToanController();
                String ma_phieu = row["ID"].ToString();
                BusinessObject.PhieuThanhToan ph = ctrlTT.LayPhieuThanhToan(ma_phieu);
                frmInPhieuThanhToan PhieuThanhToan = new frmInPhieuThanhToan(ph);
                PhieuThanhToan.Show();
            }
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimPhieuThu Tim = new frmTimPhieuThu();
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            Tim.Location = p;
            Tim.ShowDialog();
            if (Tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimPhieuThanhToan(bindingNavigator, dataGridView, cmbKhachHang, txtMaPhieu, dtNgayThanhToan, numTongTien, txtGhiChu,
                    Tim.cmbKhachHang.SelectedValue.ToString(), Tim.dtNgayThu.Value.Date);
            }
        }
        private void cbbChiPhiVC_ValueMemberChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cbbChiPhiVC.SelectedValue.ToString());
                ctrlVC.HienThiLenTextBox(txtChiPhiVC, id);
            }
            catch { }
        }

        private void cbbChiPhiVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbChiPhiVC_ValueMemberChanged(null, null);
        }

        private void cbbChiPhiPS_ValueMemberChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cbbChiPhiPS.SelectedValue.ToString());
                ctrlPS.HienThiLenTextBox(txtChiPhiPS, id);
            }
            catch { }
        }

        private void cbbChiPhiPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbChiPhiPS_ValueMemberChanged(null, null);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaPhieu.Text = dataGridView.CurrentRow.Cells["ID"].Value.ToString();
                cmbKhachHang.Text = dataGridView.CurrentRow.Cells["HO_TEN"].Value.ToString();
                numTongTien.Value = int.Parse(dataGridView.CurrentRow.Cells["SO_TIEN"].Value.ToString());
                dtNgayThanhToan.Value = DateTime.Parse(dataGridView.CurrentRow.Cells["NGAY_THANH_TOAN"].Value.ToString());
                txtGhiChu.Text = dataGridView.CurrentRow.Cells["GHI_CHU"].Value.ToString();
                cbbChiPhiPS.SelectedValue = dataGridView.CurrentRow.Cells["ID_PS"].Value;
                cbbChiPhiVC.SelectedValue = dataGridView.CurrentRow.Cells["ID_VC"].Value;
                numChietKhau.Value = int.Parse(dataGridView.CurrentRow.Cells["CHIET_KHAU"].Value.ToString());
                numGiamGia.Value = int.Parse(dataGridView.CurrentRow.Cells["GIAM_GIA"].Value.ToString());
            }
            catch 
            {

            }
        }

        private void btnChiTietVC_Click(object sender, EventArgs e)
        {
            frmChiPhiVanChuyen frmChiPhiVanChuyen = new frmChiPhiVanChuyen();
            frmChiPhiVanChuyen.ShowDialog();
            ctrlVC.HienThiLenComboBox(cbbChiPhiVC);
        }
        private void btnChiTietPPS_Click(object sender, EventArgs e)
        {
            frmChiPhiPhatSinh frmChiPhiPhatSinh = new frmChiPhiPhatSinh();
            frmChiPhiPhatSinh.ShowDialog();
            ctrlPS.HienThiLenComboBox(cbbChiPhiPS);
        }
    }
}