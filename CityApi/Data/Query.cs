using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityApi.Data
{
    public class Query
    {
        public SqlConnection GetConnection()
        {
            string connection = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();

            return new SqlConnection(connection);
        }

        public DataTable GetCity(string param)
        {
            var con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            if(string.IsNullOrEmpty(param))
            {
                cmd.CommandText = "select * from Cities";
            }
            else
            {
                cmd.CommandText = "select * from Cities where CityName like '%' + @param + '%'";
                cmd.Parameters.AddWithValue("@param", param);
            }
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Adp.Fill(dt);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return dt;
        }
    }
}