using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace winform_1
{
    class MysqlConn
    {
        static string ConString = System.Configuration.ConfigurationManager.AppSettings["ConString"];
        MySqlConnection con = new MySqlConnection(ConString);
        #region 查询数据库中的数据并返回数据
        public DataTable Selectdatabase(string sql)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, con);
            dataAdapter.Fill(dt);
            return dt;
        }
        #endregion
        #region 更新数据库
        public int Updatedatabase(string sql)
        {
            con.Open();
            MySqlCommand command = new MySqlCommand(sql, con);
            int i = command.ExecuteNonQuery();
            con.Close();
            return i;
        }
        #endregion
        #region 打开数据库
        public MySqlConnection Opendatabase()
        {
            return con;
        }
        #endregion
    }
}
