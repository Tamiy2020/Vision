using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess
{
    /// <summary>
    /// 直线方程类Ax+By+C=0
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class AxByC
    {
        /// <summary>
        /// 系数A
        /// </summary>
        public HTuple A;

        /// <summary>
        /// 系数B
        /// </summary>
        public HTuple B;

        /// <summary>
        /// 系数C
        /// </summary>
        public HTuple C;

        /// <summary>
        /// 斜率k
        /// </summary>
        public HTuple k;

        /// <summary>
        /// 是否是直线
        /// </summary>
        public bool IsLine { get; private set; }

        /// <summary>
        /// 通过直线计算直线方程
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public AxByC GetAxByC(Line line)
        {
            IsLine = true;
            if (line.hv_Column1 != null && line.hv_Row1 != null && line.hv_Column2 != null && line.hv_Row2 != null)
            {
                if (line.hv_Column1 < 0 || line.hv_Column2 < 0 || line.hv_Row1 < 0 || line.hv_Row2 < 0)
                {
                    IsLine = false;
                }
                this.A = line.hv_Row2 - line.hv_Row1;//y2-y1
                this.B = line.hv_Column1 - line.hv_Column2;//x1-x2
                this.C = line.hv_Column2 * line.hv_Row1 - line.hv_Column1 * line.hv_Row2;//x2y1-x1y2
                if (this.A.D == 0 && this.B.D == 0)
                {
                    this.A = null;
                    this.B = null;
                    this.C = null;
                    this.k = null;
                    IsLine = false;
                }
                if (line.hv_Column1.D == line.hv_Column2.D)
                {
                    this.k = null;
                }
                else
                {
                    this.k = (line.hv_Row2 - line.hv_Row1) / (line.hv_Column2 - line.hv_Column1);
                }
            }
            return this;
        }

        /// <summary>
        /// 通过点和斜率计算直线方程
        /// </summary>
        /// <param name="point"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public AxByC GetAxByC(Point point, HTuple k)
        {
            if (k == null)//X
            {
                this.k = null;
                this.B = 0;
                this.A = -1;
                this.C = point.hv_Column;
            }
            else if (k.D == 0)//Y
            {
                this.k = 0;
                this.A = 0;
                this.B = -1;
                this.C = point.hv_Row;
            }
            else
            {
                this.k = k;
                this.A = this.k;
                this.B = -1;
                this.C = point.hv_Row - (k * point.hv_Column);//y-kx
            }
            return this;
        }
    }
}
