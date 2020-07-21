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
    /// 通过灰度抓圆类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetCircleUseThreshold : Circle
    {
        /// <summary>
        /// 区域列表
        /// </summary>
        public List<Region> RegionList;

        /// <summary>
        /// 最大ID
        /// </summary>
        private int maxId;

        public GetCircleUseThreshold()//构造函数
        {
            maxId = 1;
            RegionList = new List<Region>();
            function = "抓圆";
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            GetHomMat2D();
            return this;
        }


        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
            return this;
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            foreach (BaseShape item in RegionList)
            { 
                item.position_Horizontal = position_Horizontal;
                item.position_Vertical = position_Vertical;
                item.SetPosition();
            }
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="region"></param>
        public void AddRegion(Region region)
        {
            region.iD = maxId++;//分配ID
            region.name = region.iD.ToString();//分配name
            RegionList.Add(region);
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="index"></param>
        public void RemoveRegion(int index)
        {
            RegionList.Remove(RegionList[index]);
        }

        /// <summary>
        /// 删除所有项
        /// </summary>
        public void RemoveAll()
        {
            maxId = 1;
            if (RegionList.Count > 0)
            {
                RegionList.Clear();
            }
        }

        /// <summary>
        /// 获取所有线的名字
        /// </summary>
        /// <returns></returns>
        public string[] GetRegionsName()
        {
            List<string> regionsName = new List<string>();
            foreach (var item in RegionList)
            {
                regionsName.Add(item.name);
            }
            return regionsName.ToArray();
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Region GetRegion(int index)
        {
            return RegionList[index];
        }

        public override int Measure(HObject ho_Image)
        {
            HObject ho_RegionUnion;
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            foreach (var item in RegionList)
            {
                item.Measure(ho_Image);//每一项执行测量
                HOperatorSet.Union2(ho_RegionUnion, item.Ho_Region, out ho_RegionUnion);//联合成一个大区域
            }
            SetCircle(Func_ImageProcessing.getCircle_FromRegion(ho_RegionUnion));//从区域获取最大外接圆
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            foreach (var item in RegionList)
            {
                window.DispObj(item.Ho_Region, "green", "fill");//区域
            }
            base.DisplayDetail(window);
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            base.DisplayResult(window);
        }



    }
}
