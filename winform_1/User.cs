using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace winform_1
{
    public class User
    {
        private string _username;
        private string _password;
        private int _score;
        private MysqlConn conn = new MysqlConn();
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #region 用户登录判断 
        public int Logins()
        {
            int j = 0;
            if (Username == "" || Password == "")
            {
                j = 0;
                return j;
            }
            else
            {
                #region 数据库判断用户登录
                string _selectuserpw = "select usname,password from usereport";
                DataTable dt = conn.Selectdatabase(_selectuserpw);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Username != dt.Rows[i][0].ToString())
                    {
                        j = 1;
                    }
                    else if (Username == dt.Rows[i][0].ToString() && Password == dt.Rows[i][1].ToString())
                    {
                        // MessageBox.Show("登录成功");
                        j = 2;
                        break;
                    }
                    else if (Username == dt.Rows[i][0].ToString() && Password != dt.Rows[i][1].ToString())
                    {
                        // MessageBox.Show("密码错误");
                        j = 3;
                        break;
                    }
                }
                return j;
                #endregion
            }
    }
        #endregion
        #region 用户注册

        #endregion
        #region 注册用户判断
        public int Register()
        {
            #region 将用户信息存储到数据库
            if (Username == "" || Password == "")
            {
               
                 return 0;
            }
            else
            {
                if (Searchuse())
                {
                    return 1;
                }
                else
                {
                    string _insertsql = "insert into usereport(usname,password)values('" + Username + "','" + Password + "')";
                    conn.Updatedatabase(_insertsql);
                    return 2;
                }
            }
            #endregion
        }
        #endregion
        #region 注册时判断用户名是否使用过
        public bool Searchuse()
        {
            string _usersearch = "select usname from usereport";
            DataTable dt = conn.Selectdatabase(_usersearch);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Username == dt.Rows[i][0].ToString())
                    return true;
            }
            return false;
        }
        #endregion
        public User Obj()
        {
            return this;
        }
    }
}
