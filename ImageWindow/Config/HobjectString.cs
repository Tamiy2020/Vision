using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace ViewROI.Config
{
    /// <summary>
    /// 显示文字带有坐标
    /// </summary>
    public class HobjectString
    {
        public HTuple X;
        public HTuple Y;
        public string str;
        public HobjectString(HTuple x, HTuple y, string str)
        {
            this.X = x;
            this.Y = y;
            this.str = str;
        }
    }
}
