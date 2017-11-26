using CuahangNongduoc.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmChiPhiVanChuyen : Form
    {
        VanChuyenController ctrl = new VanChuyenController();
        public frmChiPhiVanChuyen()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Chi phí vận chuyển", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bindingNavigator.BindingSource.RemoveCurrent();
                }
                catch (Exception)
                {
                }
            }
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
            bindingNavigator.BindingSource.MoveLast();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Chi phí vận chuyển", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void frmChiPhiVanChuyen_Load(object sender, EventArgs e)
        {
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Tên CPVC";
            dataGridView.Columns[2].HeaderText = "Giá CPVC";
        }
    }
}
