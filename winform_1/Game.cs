using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;
using System.Media;

namespace winform_1
{
    public partial class Game : Form
    {
        public delegate Food GfObj();
        public delegate User GuObj();
        public delegate Dsnake GdObj();
        public GfObj Gfobjevent;//获取食物Food对象
        public GuObj Guobjevent;//获取Use对象
        public GdObj Gdobjevent;//获取Dsnake对象
        public Game()
        {
            InitializeComponent();
        }
        int x = 200;//初始化蛇的位置
        int y = 200;//初始化蛇的位置
        int pz=14;
        int sum = 0;//记录成绩
        bool start = true;//记录游戏开始
        MysqlConn conn = new MysqlConn();
        public Label foods = new Label();
        string xml_FilePath = "login.xml";//用来记录当前打开文件的路径的 可删
        Dsnake dsnake;
        List<Point> snak;
        User us1;
        private void Game_Load(object sender, EventArgs e)
        {
            dsnake = Gdobjevent();
            Ranking();
            snak = dsnake.snak;
            for(int i=0;i<3;i++)
            {
                snak.Add(new Point(x+=20,y));
                
            }
            dsnake.Paints();
            Gfobjevent().Paints();
            DisplayUse();
            user.Enabled = true;
            exit.Visible = false;
        }
        #region 监听键盘按键
        private void rssm_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.W))
            {
                dsnake.SDirection = Direction.W;
            }
            else if (e.KeyCode == (Keys.S))
            {
                dsnake.SDirection = Direction.S;
            }
            else if (e.KeyCode == (Keys.D))
            {
                dsnake.SDirection = Direction.D;
            }
            else if (e.KeyCode == (Keys.A))
            {
                dsnake.SDirection = Direction.A;
            }
        }
        #endregion
        #region 更新蛇的坐标，判断与食物的距离,判断游戏结束
        private void snposition_Tick(object sender, EventArgs e)
        {
                if (Over(snak[0].X, snak[0].Y) || Myover())
                {
                SoundPlayer sp = new SoundPlayer("gameover.wav");//应该是wav格式的音频
                sp.Play();//播放单次
                this.KeyPreview = false;
                    snposition.Enabled = false;
                    run.Enabled = false;
                    MessageBox.Show("游戏结束");
                    us1.Score = sum;
                    Save();
                    sum = 0;
                    gscore.Text = sum.ToString();
                    Ranking();
                    snak.Clear();
                    button1.Visible = true;
                    exit.Visible = true;
                    return;
                }
                if ((Math.Abs(snak[0].Y - Gfobjevent().Y) < 15 && Math.Abs(snak[0].X - Gfobjevent().X) < 15))
                {
                SoundPlayer sp = new SoundPlayer("eatfood.wav");//应该是wav格式的音频
                sp.Play();//播放单次
                snak.Add(new Point());
                snak[snak.Count - 1] = new Point(snak[snak.Count - 2].X, snak[snak.Count - 2].Y + 15);
                //dsnake.Paints();
                Gfobjevent().Paints();
                sum += 1;
                gscore.Text = sum.ToString();
            }
        }
        #endregion
        #region 重新开始游戏
        private void button1_Click(object sender, EventArgs e)
        {
           button1.Visible = false;
           exit.Visible = false;
           x = 150;//初始化蛇的位置
           y = 150;//初始化蛇的位置
           sum = 0;
            for (int i = 0; i <= 2; i++)
            {
                snak.Add(new Point(x += 20, y));
            }
            KeyPreview = true;
            Sclear();
            dsnake.Paints();
            Gfobjevent().Paints();
            snposition.Enabled = true;
            run.Enabled = true;
        }
        #endregion
        #region 游戏结束判断
        public bool Over(int x,int y)
        {
            if (y > this.Height - 20 || y < 10)
            {
                return true;
            }
            else if (x > this.Width - 150 || x < 10)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
        public Game Obj()
        {
            return this;
        }
        #region 保存用户分数
        public void Save()
        {
            #region 将用户成绩保存到xml中
            //User us1 = Gobjevent();
            //XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
            //xmlDocument.Load(xml_FilePath);//载入路径这个xml
            //XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("UserInfo").ChildNodes;//选择class为根结点并得到旗下所有子节点
            //foreach (XmlNode xmlNode in xmlNodeList)//遍历class的所有节点
            //{
            //    XmlElement xmlElement = (XmlElement)xmlNode;//对于任何一个元素，其实就是每一个<student>
            //    //旗下的子节点<name>和<number>分别放入dataGridView3
            //        if (us1.Username == xmlElement.ChildNodes.Item(0).InnerText)
            //        {
            //            if (us1.Score > Convert.ToInt16(xmlElement.ChildNodes.Item(2).InnerText))
            //            {
            //                xmlElement.ChildNodes.Item(2).InnerText = us1.Score.ToString();
            //                xmlDocument.Save(@"login.xml");//保存xml文件
            //            }
            //            break;
            //        }

            //}
            #endregion
            #region 将用户成绩保存到数据库中
            string _selectusname = "select score from usereport where usname='"+us1.Username+"'";
            string _updatasc = "UPDATE usereport SET score = '"+ us1.Score + "' WHERE usname = '"+us1.Username+"'";
            if (Convert.ToInt32(conn.Selectdatabase(_selectusname).Rows[0][0].ToString()) < us1.Score)
                conn.Updatedatabase(_updatasc);
            #endregion
        }
        #endregion
        #region 排行榜
        public void Ranking()
        {
            #region xml导出排行榜
            //XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
            //xmlDocument.Load(xml_FilePath);//载入路径这个xml
            //XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("UserInfo").ChildNodes;//选择class为根结点并得到旗下所有子节点

            //User[] uses = new User[xmlNodeList.Count];
            //int i = 0;
            //foreach (XmlNode xmlNode in xmlNodeList)//遍历class的所有节点
            //{
            //    XmlElement xmlElement = (XmlElement)xmlNode;//对于任何一个元素，其实就是每一个<student>
            //    uses[i] = new User();
            //    uses[i].Username = xmlElement.ChildNodes.Item(0).InnerText;
            //    uses[i].Score = Convert.ToInt16(xmlElement.ChildNodes.Item(2).InnerText);
            //    i++;
            //}
            //User temp = new User();
            //for (int j = 1; j < uses.Length; j++)
            //{
            //    for (int k = 0; k < uses.Length - j; k++)
            //    {
            //        if (uses[k].Score < uses[k + 1].Score)
            //        {
            //            temp = uses[k];
            //            uses[k] = uses[k + 1];
            //            uses[k + 1] = temp;
            //        }

            //    }
            //}
            //string x = null;
            //for (int j = 0; j < uses.Length; j++)
            //{
            //    x+= uses[j].Username + "  " + uses[j].Score + "\r\n";
            //}
            //paihang.Text = x;
            #endregion
            #region 数据库导出排行榜
            string _selectussc = "select usname,score from usereport";
            DataTable dt=conn.Selectdatabase(_selectussc);
            User[] uses = new User[dt.Rows.Count];//后期冒泡排序使用
            for (int j = 0; j < dt.Rows.Count; j++)
            {
               
                uses[j] = new User();
                uses[j].Username = dt.Rows[j][0].ToString();
                uses[j].Score = Convert.ToInt32( dt.Rows[j][1].ToString());//转换成int类型，方便冒泡排序
            }
            User temp = new User();
            for (int j = 1; j < uses.Length; j++)
            {
                for (int k = 0; k < uses.Length - j; k++)
                {
                    if (uses[k].Score < uses[k + 1].Score)
                    {
                        temp = uses[k];
                        uses[k] = uses[k + 1];
                        uses[k + 1] = temp;
                    }
                }
            }
            string x = null;
            for (int j = 0; j < uses.Length; j++)
            {
                x += uses[j].Username + "  " + uses[j].Score + "\r\n";
            }
            paihang.Text = x;
            #endregion
        }
        #endregion
        #region 清除图形
        public void Sclear()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
        }
        #endregion
        #region 判断自身死亡
        public bool Myover()
        {
            bool t=false;
            for (int i = 1; i < snak.Count; i++)
            {
                if (snak[0].X == snak[i].X && snak[0].Y == snak[i].Y)
                {
                    t = true;
                    break;
                }
            }
            return t;
        }
        #endregion
        #region 显示当前用户
        public void DisplayUse()
        {
            us1 = Guobjevent();
            label1.Text = us1.Username;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #region 刷新显示用户
        private void user_Tick(object sender, EventArgs e)
        {
            DisplayUse();
        }
        #endregion
        #region 蛇体一直移动
        private void zw_Tick(object sender, EventArgs e)
        {
            snposition.Enabled = true;
            if (start == true)
            {
                dsnake.SDirection = Direction.D;
                btn_start.Visible = false;
                run.Enabled = true;
                start = false;
            }
            switch (dsnake.SDirection)
            {
                case Direction.W:
                    dsnake.SnakeRun(Direction.W);
                    break;
                case Direction.S:
                    dsnake.SnakeRun(Direction.S);
                    break;
                case Direction.A:
                    dsnake.SnakeRun(Direction.A);
                    break;
                case Direction.D:
                    dsnake.SnakeRun(Direction.D);
                    break;
            }
        }
        #endregion
    }
}

