using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace winform_1
{
    public enum Direction
    {
        W,A,S,D
    }
    public  class Dsnake:IPaint
    {
        int pz=15;
        private Direction sdirection;
        public delegate Game Dgobj();
        public Dgobj Dgobjevent;
        public List<Point> snak = new List<Point>();//蛇的数组
        public Direction SDirection { get => sdirection; set => sdirection = value; }
        public Dsnake Dobj()
        {
            return this;
        }
        #region 绘制蛇
        public void Paints()
        {
            Graphics ga = Dgobjevent().CreateGraphics();
            Brush bush= new SolidBrush(Color.Purple);
            for (int i=0;i<snak.Count;i++)
            {
               
                if (i==0)
                {
                    bush = new SolidBrush(Color.Blue);//填充的颜色
                    ga.FillEllipse(bush, snak[i].X, snak[i].Y, 20, 20);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100
                }
                else
                {
                    bush = new SolidBrush(Color.GreenYellow);
                    ga.FillEllipse(bush, snak[i].X, snak[i].Y, 20, 20);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100
                }
               
            }
        }
        #endregion
        #region 控制蛇的移动
        public void SnakeRun(Direction direction)
        {
            this.SDirection = direction;
            int hx = 0;
            int hy = 0;
            hx = snak[0].X;
            hy = snak[0].Y;
            Sclear(snak[snak.Count - 1].X, snak[snak.Count - 1]. Y);
            switch (this.SDirection)
            {
                case Direction.W:
                    snak[snak.Count - 1] = new Point(hx,hy-pz);
                    break;
                case Direction.S:
                    snak[snak.Count - 1] = new Point(hx, hy +pz);
                    break;
                case Direction.A:
                    snak[snak.Count - 1] = new Point(hx-pz, hy);
                    break;
                case Direction.D:
                    snak[snak.Count - 1] = new Point(hx + pz, hy);
                    break;
            }
            snak.Insert(0, snak[snak.Count - 1]);
            snak.RemoveAt(snak.Count - 1);
            Paints();
        }
        #endregion
        #region 清除蛇尾巴
        public void Sclear(int x, int y)
        {
            Color bk = new Color();
            bk = Color.SeaShell;
            Graphics ga = Dgobjevent().CreateGraphics();
            Brush bush = new SolidBrush(bk);//填充的颜色
            ga.DrawRectangle(new Pen(bk, 1), x, y, 20, 20);
            ga.FillRectangle(bush, x, y, 20, 20);
        }
        #endregion
    }
}
