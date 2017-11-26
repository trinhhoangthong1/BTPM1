using CuahangNongduoc.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc.Controller
{
    class VanChuyenController
    {
        VanChuyenFactory factory = new VanChuyenFactory();
        public void HienthiDataGridview(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = factory.DanhSachVanChuyen();
            bs.DataSource = tbl;
            bn.BindingSource = bs;
            dg.DataSource = bs;
        }
        public void HienThiLenComboBox(ComboBox cbb)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = factory.DanhSachVanChuyen();
            cbb.DataSource = bs;
            cbb.DisplayMember = "TEN_VC";
            cbb.ValueMember = "ID_VC";
        }
        public void HienThiLenTextBox(TextBox txt,int id_van_chuyen)
        {
            try
            {
                int gia = factory.LayGiaVanChuyen(id_van_chuyen);
                txt.Text = gia.ToString();
            }
            catch 
            {
            }
        }
        public void HienThiCbbVanChuyenDGV(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhSachVanChuyen();
            cmb.DisplayMember = "TEN_VC";
            cmb.ValueMember = "ID_VC";
            cmb.DataPropertyName = "ID_VAN_CHUYEN";
            cmb.HeaderText = "Vận chuyển";
        }
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
    }
}
