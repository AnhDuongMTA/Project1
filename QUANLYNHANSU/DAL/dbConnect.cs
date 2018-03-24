using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class dbConnect
    {
        SqlConnection connect = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QLNhanSu;Integrated Security=True");
        public DataTable GetData(string strSQL)//select
        {
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            return dt;
        }
        public DataTable GetData(string procName,SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand(procName,connect);
            cmd.CommandType = CommandType.StoredProcedure;
            if (para!=null)
            {
                cmd.Parameters.AddRange(para);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            connect.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            return dt;
        }
        public int ExecuteSQL(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, connect);
            connect.Open();
            int row = cmd.ExecuteNonQuery();
            connect.Close();
            return row;
        }
        public int ExecuteSQL(string strSQL, SqlParameter[] para)
        {
            
            SqlCommand cmd = new SqlCommand(strSQL, connect);
            connect.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
            {
                cmd.Parameters.AddRange(para);
            }
            int row = cmd.ExecuteNonQuery();
            connect.Close();
            return row;
            

        }


    }




}
