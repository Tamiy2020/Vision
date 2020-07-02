using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess
{
    /// <summary>
    /// 图像处理接口
    /// </summary>
    public interface IDataProcess
    {
        /// <summary>
        /// 测量完成
        /// </summary>
        bool MeasureDone { get; set; }

        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        int Measure(HObject ho_Image);

        /// <summary>
        /// 显示详细信息
        /// </summary>
        /// <param name="window"></param>
        void DisplayDetail(HWindow_Final window);


        /// <summary>
        /// 显示简单信息
        /// </summary>
        /// <param name="window"></param>
        void DisplayResult(HWindow_Final window);


        /// <summary>
        /// 返回详细信息字符串
        /// </summary>
        /// <returns></returns>
        string GetResultDetail();

        /// <summary>
        /// 返回数据表格
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        List<DataRow> GetDataTableRows(DataTable dataTable);



    }
}
