using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace winform_1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Food food = new Food();
            User us = new User();
            Game ga = new Game();
            Login fo = new Login();
            Dsnake ds = new Dsnake();
            ga.Gfobjevent=food.foodobj;
            fo.Fgobjevent = ga.Obj;
            fo.Fuobjevent = us.Obj;
            ga.Guobjevent = us.Obj;
            ga.Gdobjevent = ds.Dobj;
            ds.Dgobjevent = ga.Obj;
            food.fgobjevent = ga.Obj;
            Application.EnableVisualStyles();
            Application.Run(fo);
        }
    }
}
