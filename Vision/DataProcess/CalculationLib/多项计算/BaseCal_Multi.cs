using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 多边计算类的基类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class BaseCal_Multi : MeasuringUnit
    {

        /// <summary>
        /// 单位像素长度(k)
        /// </summary>
        public HTuple kCx;

        /// <summary>
        /// 竖直方向单位像素长度(该版本用不到)
        /// </summary>
        public HTuple kRy;

        /// <summary>
        /// 最大值
        /// </summary>
        public double maxValue;

        /// <summary>
        /// 最小值
        /// </summary>
        public double minValue;

        /// <summary>
        /// 测量结果的像素距离
        /// </summary>
        public HTuple hv_PxDistance;

        /// <summary>
        /// 测量结果的实际距离(像素距离×k)
        /// </summary>
        public HTuple hv_RealDistance;

        /// <summary>
        /// 基准线
        /// </summary>
        public Line baseLine;

        /// <summary>
        /// 线组
        /// </summary>
        public GetSetOfLines lines;

        /// <summary>
        /// 计算组
        /// </summary>
        public List<BaseCal_Single> calList;


        protected BaseCal_Multi(double k)//构造函数
        {
            //初始化一些字段的默认值
            name = "多边计算";
            kCx = k;
            calList = new List<BaseCal_Single>();

        }

        /// <summary>
        /// 获取所有计算组
        /// </summary>
        /// <returns></returns>
        public object[] GetAllCal()
        {
            List<object> names = new List<object>();
            for (int i = 0; i < calList.Count; i++)
            {
                names.Add(i + 1);
            }
            return names.ToArray();
        }

        /// <summary>
        /// 设置所有k值
        /// </summary>
        /// <param name="k"></param>
        public void SetAllK(double k)
        {
            kCx = k;
            foreach (var item in calList)
            {
                item.kCx = k;
            }
        }

        /// <summary>
        /// 设置所有最大值
        /// </summary>
        /// <param name="value"></param>
        public void SetAllMaxValue(double value)
        {
            maxValue = value;
            foreach (var item in calList)
            {
                item.maxValue = value;
            }
        }

        /// <summary>
        /// 设置所有最小值
        /// </summary>
        /// <param name="value"></param>
        public void SetAllMinValue(double value)
        {
            minValue = value;
            foreach (var item in calList)
            {
                item.minValue = value;
            }
        }

        /// <summary>
        /// 创建计算列队
        /// </summary>
        /// <returns></returns>
        public virtual bool CreateDistanceList()
        {
            return true;
        }


        /// <summary>
        /// 创建计算列队
        /// </summary>
        /// <param name="calList"></param>
        /// <returns></returns>
        public virtual bool CreateDistanceList(List<BaseCal_Single> calList)
        {
            return true;
        }

        /// <summary>
        /// 比较得出结果
        /// </summary>
        public void ComparingResults()
        {
            measureResult = Result.NG;//NG
            color = "red";
            if (minValue <= hv_RealDistance && hv_RealDistance <= maxValue)//?OK
            {
                color = "green";
                measureResult = Result.OK;//OK
            }
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            if (baseLine != null && !baseLine.MeasureDone)
                baseLine.Measure(ho_Image);
            if (lines != null && !lines.MeasureDone)
                lines.Measure(ho_Image);
            if (baseLine != null && lines != null && !(this is PinDistance) && lines.CountOfLine == calList.Count)
            {
                for (int i = 0; i < lines.CountOfLine; i++)
                {
                    calList[i].unit1 = baseLine;
                    calList[i].unit2 = lines.LineList[i];
                }
            }
            else if (baseLine != null && lines != null && (this is PinDistance) && lines.CountOfLine - 1 == calList.Count)
            {
                for (int i = 0; i < lines.LineList.Count - 1; i++)
                {
                    calList[i].unit1 = lines.LineList[i];
                    calList[i].unit2 = lines.LineList[i + 1];
                }
            }
            else if (baseLine != null && lines != null)
            {
                CreateDistanceList(calList);
            }
            return 1;
        }



        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            for (int i = 0; i < calList.Count; i++)
            {
                calList[i].name = name + " " + (i + 1).ToString();
            }
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            for (int i = 0; i < calList.Count; i++)
            {
                calList[i].name = name + " " + (i + 1).ToString();
            }
        }

        public override void Dispose() { }
       
    }
}
