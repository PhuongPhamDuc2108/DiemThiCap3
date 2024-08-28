using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLon
{
    public class ProcessDataBase
    {
        string strConnect = "Data Source=DESKTOP-HFJKU31;Initial Catalog=QLDiemThiCap3;Integrated Security=True";
        SqlConnection sqlConnect = null;
        void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect); //để trỏ vào CSDL nào
            if(sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }
        void CloseConnect()
        {
            if(sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
            sqlConnect.Dispose(); //sqlConnect = null
        }

        //Ham thuc thi lenh Select tu DB
        public DataTable ReadTable(string sql)
        {
            DataTable dt = new DataTable(); //biến local tạm để lưu trữ dữ liệu từ CSDL
            OpenConnect(); //tro den CSDL dang can lam viec
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnect); //dẫn lệnh SQL vào CSDL nào, sqlDataAdapter đang mang theo 1 dữ liệu dạng DataTable
            sqlDataAdapter.Fill(dt);
            CloseConnect();
            sqlDataAdapter.Dispose();
            return dt;
        }

        //Ham thuc thi cac lenh Insert, Update, Delete tu DB
        public void DataUpdate(string sql)
        {
            OpenConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConnect; // chỉ đường dẫn vào CSDL nào
            sqlComm.CommandText = sql;      // gán lệnh SQL
            
            sqlComm.ExecuteNonQuery(); //thực hiện lệnh SQL
            CloseConnect();
            sqlComm.Dispose();
        }
    }
}
