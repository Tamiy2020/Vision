using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    /// <summary>
    /// 最后结果枚举
    /// </summary>
    [Serializable]
    public enum Result
    {
        NG=0,
        OK=1,
        无料 = -1
    }


    /// <summary>
    /// 线类型枚举
    /// </summary>
    public enum LineStyle
    {
        灰度抓取,
        边缘检测,
        边缘拟合
    }
}
