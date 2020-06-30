using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewROI.Config
{
    /// <summary>
    /// 显示xld和region 带有颜色
    /// </summary>
    class HObjectWithColor
    {
        private HObject hObject;
        private string color;
        private string draw;
        private HobjectString hobjectString;

        public HObjectWithColor(HObject _hbj, string _color)
        {
            hObject = _hbj;
            color = _color;
        }
        public HObjectWithColor(HObject _hbj, string _color, string _drow)
        {
            hObject = _hbj;
            color = _color;
            draw = _drow;
        }
        public HObjectWithColor(HobjectString _hobjectString, string _color)
        {
            hobjectString = _hobjectString;
            color = _color;
        }
        public HobjectString HobjectString
        {
            get { return hobjectString; }
            set { hobjectString = value; }
        }

        public HObject HObject
        {
            get { return hObject; }
            set { hObject = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Draw
        {
            get { return draw; }
            set { draw = value; }
        }
    }
}
