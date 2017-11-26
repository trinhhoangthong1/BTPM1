using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace CuahangNongduoc.DataLayer
{
    class VanChuyenFactory
    {
        DataService m_Ds = new DataService();
        public DataTable DanhSachVanChuyen()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM VAN_CHUYEN");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public int LayGiaVanChuyen(int id_van_chuyen)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT GIA_VC FROM VAN_CHUYEN WHERE ID_VC = @id");
            cmd.Parameters.Add("id", OleDbType.Integer, 50).Value = id_van_chuyen;
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
