using CuahangNongduoc.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc.Controller
{
    class ChiPhiPhatSinhController
    {
        ChiPhiPhatSinhFactory factory = new ChiPhiPhatSinhFactory();

        public void HienthiDataGridview(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = factory.DanhSachChiPhi();
            bs.DataSource = tbl;
            bn.BindingSource = bs;
            dg.DataSource = bs;
        }
        public void HienThiLenComboBox(ComboBox cbb)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = factory.DanhSachChiPhi();
            cbb.DataSource = bs;
            cbb.DisplayMember = "TEN_PS";
            cbb.ValueMember = "ID_PS";
        }
        public void HienThiLenTextBox(TextBox txt, int id_chi_phi)
        {
            try
            {
                int gia = factory.LayGiaChiPhi(id_chi_phi);
                txt.Text = gia.ToString();
            }
            catch
            {
            }
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
