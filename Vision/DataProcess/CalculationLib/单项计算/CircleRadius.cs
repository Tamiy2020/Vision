using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 圆半径计算
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class CircleRadius : BaseCal_Single
    {
        public CircleRadius(double k, Circle circle) : base(k)//构造函数
        {
            unit1 = circle;
            function = "圆半径";
            DP.hv_Column = circle.hv_Column;//设置数据显示点横坐标
            DP.hv_Row = circle.hv_Row;//设置数据显示点纵坐标
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            pStart = new Point((unit1 as Circle).hv_Column, (unit1 as Circle).hv_Row);//设置测量线起点
            pEnd = new Point((unit1 as Circle).hv_Column, (unit1 as Circle).hv_Row);//设置测量线终点
            hv_PxDistance = (unit1 as Circle).hv_Radius;//获取半径像素值
            hv_RealDistance = hv_PxDistance * kCx;//计算出半径实际值
            ComparingResults();//比较结果
            DP.hv_Column = (unit1 as Circle).hv_Column;//设置数据显示点横坐标
            DP.hv_Row = (unit1 as Circle).hv_Row;//设置数据显示点纵坐标
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
        }


        public override List<DataRow> GetDataTableRows(DataTable dataTable)//返回数据表格
        {
            List<DataRow> dataRows = base.GetDataTableRows(dataTable);
            dataRows[0]["测量类型"] = "圆半径";
            return dataRows;
        }
    }
}
