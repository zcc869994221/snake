using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO.Ports;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Media;
namespace winform_1
{
    public partial class Login : Form
    {
        public delegate User Fuobj();
        public delegate Game Fgobj();
        public  Fuobj Fuobjevent;//获取User对象
        public Fgobj Fgobjevent;//获取Game对象
        User user = new User();//给user赋值
        MysqlConn conn = new MysqlConn();//连接数据库对象
        SoundPlayer sp = new SoundPlayer("bgmusic.wav");//加载音效
        public Login()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowRegion();
            try
            {
                MySqlConnection con;
                con = conn.Opendatabase();
                con.Open();//打开通道，建立连接   
                if (con.State!=ConnectionState.Open)
                {
                    int i = 0;
                    while(i<3)
                    {
                        i++;
                        if (con.State == ConnectionState.Open)
                            break;
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            MessageBox.Show("无法连接到数据库,尝试第"+i+"次连接数据库");
                        }    
                    }
                    if(i==3)
                    {
                        MessageBox.Show("请检查你的网络，重新启动程序");
                        this.Close();
                    }
                }
                sp.PlayLooping();//循环播放
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请打开网络连接");
                this.Close();
                return;
            }
        }
        #region 窗体圆角的实现
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 50);
            this.Region = new Region(FormPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">窗体大小</param>
        /// <param name="radius">圆角大小</param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角

            arcRect.X = rect.Right - diameter;//右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion
        //登录按钮
        private void btn_login_Click(object sender, EventArgs e)
        {
            user = Fuobjevent();
            user.Username = un.Text.Trim();
            user.Password = pw.Text.Trim();
            switch (user.Logins())
            {
                case 0: MessageBox.Show("用户名或密码不能为空"); break;
                case 1: MessageBox.Show("用户名不存在"); break;
                case 2:
                    MessageBox.Show("登录成功");
                    Fgobjevent().Show();
                    sp.Stop();//停止
                    break;
                case 3: MessageBox.Show("密码错误"); break;
            }
        }
        //注册按钮
        private void btn_register_Click(object sender, EventArgs e)
        {
            user = Fuobjevent();
            user.Username = un.Text.Trim();
            user.Password = pw.Text.Trim();
            switch (user.Register())
            {
                case 0: MessageBox.Show("用户名或密码不能为空"); break;
                case 1: MessageBox.Show("用户名已存在"); break;
                case 2:
                    MessageBox.Show("注册成功");
                    break;
            }
        }
        #region 程序关闭
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}