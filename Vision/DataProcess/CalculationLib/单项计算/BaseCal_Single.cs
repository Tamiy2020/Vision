using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 单项计算类的基类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class BaseCal_Single : MeasuringUnit
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
        /// 起始测量单元的引用
        /// </summary>
        public MeasuringUnit unit1;

        /// <summary>
        /// 终点测量单元的引用
        /// </summary>
        public MeasuringUnit unit2;


        /// <summary>
        /// 测量起点和终点
        /// </summary>
        [NonSerialized]//不序列化该字段
        protected Point pStart, pEnd;


        public BaseCal_Single(double k)//构造函数
        {
            //初始化一些字段的默认值
            function = "距离测量";
            DP = new Point();
            kCx = k;
            kRy = k;
            maxValue = 0;
            minValue = 0;
            pStart = new Point(0, 0);
            pEnd = new Point(0, 0);
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            if (unit1 != null && !unit1.MeasureDone)//？unit1不为空且自身还未进行测量
                unit1.Measure(ho_Image);//unit1自身执行测量方法
            if (unit2 != null && !unit2.MeasureDone)//？unit2不为空且自身还未进行测量
                unit2.Measure(ho_Image);//unit2自身执行测量方法
            return 1;
        }


        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            if (unit1 != null) unit1.DisplayDetail(window);//显示unit1形状的详细信息
            if (unit2 != null) unit2.DisplayDetail(window);//显示unit2形状的详细信息
            window.DispString(DP.hv_Column, DP.hv_Row - StringHeight, name, color);//显示名称
            window.DispString(DP.hv_Column, DP.hv_Row, ((double)hv_PxDistance).ToString("f3"), color);//显示像素距离
            window.DispString(DP.hv_Column, DP.hv_Row + StringHeight, ((double)hv_RealDistance).ToString("f3"), color);//显示实际距离

            Line line = new Line(pStart.hv_Column, pStart.hv_Row, pEnd.hv_Column, pEnd.hv_Row);//创建结果线
            HObject ho_Line = Func_HalconFunction.GenRegionLine(line);//创建结果线
            window.DispObj(ho_Line, color, "fill");//显示结果线
            ho_Line.Dispose();//释放ho_Line
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            window.DispString(DP.hv_Column, DP.hv_Row + StringHeight, ((double)hv_RealDistance).ToString("f3"), color);//显示实际距离
        }


        public override object[] GetResultDetail()//返回详细信息
        {
            return new object[] { name, function, minValue.ToString(), maxValue.ToString(), hv_RealDistance.D.ToString("f3") };
        }

        public override List<DataRow> GetDataTableRows(DataTable dataTable)
        {
            List<DataRow> dataRows = new List<DataRow>();
            string result = "OK";
            if (measureResult == Result.NG) result = "NG";
            DataRow dataRow = dataTable.NewRow();
            dataRow["名称"] = name;
            dataRow["功能"] = "距离测量";
            dataRow["下限"] = minValue;
            dataRow["上限"] = maxValue;
            dataRow["测量值"] = hv_RealDistance.D.ToString("f3");
            dataRow["结果"] = result;
            dataRow["时间"] = DateTime.Now;
            dataRows.Add(dataRow);
            return dataRows;
        }

        /// <summary>
        /// 比较得出结果
        /// </summary>
        public void ComparingResults()
        {
            measureResult = Result.NG;//NG
            color = "red";//设置显示颜色为红
            if (minValue <= hv_RealDistance && hv_RealDistance <= maxValue)//?OK
            {
                color = "green";//设置显示颜色为绿
                measureResult = Result.OK;//OK
            }
        }

        public override void Dispose()
        {
            if (unit1 != null) unit1.Dispose();
            if (unit2 != null) unit2.Dispose();
        }
    }
}
