﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 斗地主
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DdzMian());
            
        }
    }
}