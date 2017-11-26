using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace CuahangNongduoc.DataLayer
{
    class ChiPhiPhatSinhFactory
    {
        DataService m_Ds = new DataService();
        public DataTable DanhSachChiPhi()
        {
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM CHI_PHI_PHAT_SINH");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public int LayGiaChiPhi(int id_chi_phi)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT GIA_PS FROM CHI_PHI_PHAT_SINH WHERE ID_PS = @id");
            cmd.Parameters.Add("id", OleDbType.Integer, 50).Value = id_chi_phi;
            object obj = ds.ExecuteScalar(cmd);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);

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
