using System;
using System.Collections.Generic;
using System.Text;

namespace CuahangNongduoc.BusinessObject
{
    public class VanChuyen
    {
        public VanChuyen() { }
        public VanChuyen(int id)
        {
            Id = id;
        }

        private int m_Id;
        private string m_Ten;
        private int m_Gia;

        public int Gia
        {
            get
            {
                return m_Gia;
            }

            set
            {
                m_Gia = value;
            }
        }


        public int Id
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

        public string Ten
        {
            get
            {
                return m_Ten;
            }

            set
            {
                m_Ten = value;
            }
        }
    }
}