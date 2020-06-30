using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace winform_1
{
   public  class Food:IPaint
    {
        private int x;
        private int y;
        public Food foodobj()
        {
            return this;
        }
        public delegate Game Fgobj();
        public Fgobj fgobjevent;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Paints()
        {
            Game game = this.fgobjevent();
            game.Controls.Remove(game.foods);
            int left = 20;//随机数可取该下界值
            int right = game.Width - 150;//随机数不能取该上界值
            int top = 20;
            int bottom = game.Height - 20;
            Random rNumber = new Random();//实例化一个随机数对象
            X = rNumber.Next(left, right);//产生一个1到1000之间的任意一个数
            Y = rNumber.Next(top, bottom);//产生一个1到1000之间的任意一个数
            game.Controls.Remove(game.foods);
            game.foods.BackgroundImageLayout = ImageLayout.Stretch;//采用Stretch布局
            game.foods.Image = Image.FromFile(@"head.png");
            game.foods.Size = new System.Drawing.Size(20, 20);
            game.foods.Location = new System.Drawing.Point(X, Y);//重新绘制按钮
            game.Controls.Add(game.foods);
        }
    }
    
}
