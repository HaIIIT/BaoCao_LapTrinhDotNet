using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public class Connection
    {
        string connStr = "server= HWI; database=QLChungCU; uid=sa; pwd=hieu1234";
        public SqlConnection conn { get; set; }
        public SqlCommand cmd { get; set; }
        public Connection()
        {
            conn = new SqlConnection(connStr);
        }
        public bool moketnoi()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }
        public bool dongketnoi()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đóng kết nối: " + ex.Message);
                return false;
            }
        }
        public SqlDataReader truyvan(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }   
        public int capnhat(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

    }
}
