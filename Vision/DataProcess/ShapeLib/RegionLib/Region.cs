using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 区域类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Region : BaseShape
    {

        /// <summary>
        /// 面积
        /// </summary>
        public HTuple hv_Area;

        /// <summary>
        /// 中心点
        /// </summary>
        public Point centerPoint=new Point ();


        /// <summary>
        /// 区域
        /// </summary>
        public HObject Ho_Region
        {
            get { return ho_Shape; }
        }

        public override BaseShape GetShapePositioned()//获取定位后的实例
        {
            return this;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            window .DispObj(ho_Shape, "green", "fill");//区域
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
           
        }

        public override object[] GetResultDetail()
        {
            return null;
        }


    }
}
