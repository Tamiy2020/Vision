using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using Vision.DataProcess.ParameterLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess
{
    /// <summary>
    /// 系统操作类
    /// </summary>
    public class Func_System
    {
        public static int GetIndex(List<MeasuringUnit> measuringUnits, MeasuringUnit unit)
        {
            for (int i = 0; i < measuringUnits.Count; i++)
                if (measuringUnits[i].iD == unit.iD)
                    return i;
            return -1;
        }

        public static int GetIndex(List<Line> measuringUnits, MeasuringUnit unit)
        {
            for (int i = 0; i < measuringUnits.Count; i++)
                if (measuringUnits[i].iD == unit.iD)
                    return i;
            return -1;
        }

        public static int GetIndex(List<GetSetOfLines> measuringUnits, MeasuringUnit unit)
        {
            for (int i = 0; i < measuringUnits.Count; i++)
                if (measuringUnits[i].iD == unit.iD)
                    return i;
            return -1;
        }

        public static MeasuringUnit GetUnit(List<MeasuringUnit> measuringUnits, int id)
        {
            foreach (var item in measuringUnits)
            {
                if (item.iD == id)
                    return item;
            }
            return null;
        }

        public static MeasuringUnit GetUnit(List<Line> measuringUnits, int id)
        {
            foreach (var item in measuringUnits)
            {
                if (item.iD == id)
                    return item;
            }
            return null;
        }

        public static MeasuringUnit GetUnit(List<GetSetOfLines> measuringUnits, int id)
        {
            foreach (var item in measuringUnits)
            {
                if (item.iD == id)
                    return item;
            }
            return null;
        }
    }

    /// <summary>
    /// 几何计算/变换类
    /// </summary>
    public static class Func_Mathematics
    {
        /// <summary>
        /// 求已知直线过已知点的垂线
        /// </summary>
        /// <param name="Line1">已知直线</param>
        /// <param name="line2sPoint">已知点</param>
        /// <returns></returns>
        public static Line LineVerticalLine(Line Line1, Point line2sPoint)
        {
            Line line2 = new Line();
            Line1.AxByC0 = Line1.AxByC0.GetAxByC(Line1);
            if (Line1.AxByC0.k == null)
            {
                line2.AxByC0 = line2.AxByC0.GetAxByC(line2sPoint, 0);
            }
            else if (Line1.AxByC0.k.D == 0)
            {
                line2.AxByC0 = line2.AxByC0.GetAxByC(line2sPoint, null);
            }
            else
            {
                line2.AxByC0 = line2.AxByC0.GetAxByC(line2sPoint, -1 / Line1.AxByC0.k);
            }
            return line2;
        }

        /// <summary>
        /// 两条直线交点
        /// </summary>
        /// <param name="Line1"></param>
        /// <param name="Line2"></param>
        /// <returns></returns>
        public static Point TwoLineIntersection(Line Line1, Line Line2)
        {
            Point point = new Point(0, 0);
            if (Line1.AxByC0.A != null && Line2.AxByC0.A != null)
            {
                point.hv_Column = (Line1.AxByC0.B * Line2.AxByC0.C - Line2.AxByC0.B * Line1.AxByC0.C) / (Line1.AxByC0.A * Line2.AxByC0.B - Line2.AxByC0.A * Line1.AxByC0.B);
                point.hv_Row = (Line2.AxByC0.A * Line1.AxByC0.C - Line1.AxByC0.A * Line2.AxByC0.C) / (Line1.AxByC0.A * Line2.AxByC0.B - Line2.AxByC0.A * Line1.AxByC0.B);
            }
            return point;
        }

        /// <summary>
        /// √（x2-x1）^2+（y2-y1）^2 计算两个点的距离
        /// </summary>
        /// <param name="Cx1">起点Cx坐标</param>
        /// <param name="Ry1">起点Ry坐标</param>
        /// <param name="Cx2">终点Cx坐标</param>
        /// <param name="Ry2">终点Ry坐标</param>
        /// <returns></returns>
        public static HTuple P1_P2_To_Distance(HTuple Cx1, HTuple Ry1, HTuple Cx2, HTuple Ry2)
        {
            return ((Cx2 - Cx1).TupleMult(Cx2 - Cx1) + (Ry2 - Ry1).TupleMult(Ry2 - Ry1)).TupleSqrt();
        }

        /// <summary>
        /// √（x2-x1）^2+（y2-y1）^2 计算两个点的距离
        /// </summary>
        /// <param name="P1">点1</param>
        /// <param name="P2">点2</param>
        /// <returns></returns>
        public static HTuple P1_P2_To_Distance(Point P1, Point P2)
        {
            return ((P2.hv_Column - P1.hv_Column).TupleMult(P2.hv_Column - P1.hv_Column) + (P2.hv_Row - P1.hv_Row).TupleMult(P2.hv_Row - P1.hv_Row)).TupleSqrt();
        }

        /// <summary>
        /// 根据两个点计算Phi
        /// </summary>
        /// <param name="Cx1">起点Cx坐标</param>
        /// <param name="Ry1">起点Ry坐标</param>
        /// <param name="Cx2">终点Cx坐标</param>
        /// <param name="Ry2">终点Ry坐标</param>
        /// <returns></returns>
        public static HTuple P1_P2_To_Phi(HTuple Cx1, HTuple Ry1, HTuple Cx2, HTuple Ry2)
        {
            HTuple result;
            if ((double)(Cx1 - Cx2) == 0)
            {
                result = null;
            }
            else
            {
                result = ((Ry2 - Ry1) / (double)(Cx2 - Cx1)).TupleAtan();
            }
            return result;
        }

        /// <summary>
        /// 根据两个点计算Phi
        /// </summary>
        /// <param name="P1">点1</param>
        /// <param name="P2">点2</param>
        /// <returns></returns>
        public static HTuple P1_P2_To_Phi(Point P1, Point P2)
        {
            HTuple result;
            if ((double)(P1.hv_Column - P2.hv_Column) == 0)
            {
                result = null;
            }
            else
            {
                result = ((P2.hv_Row - P1.hv_Row) / (double)(P2.hv_Column - P1.hv_Column)).TupleAtan();
            }
            return result;
        }

        /// <summary>
        /// 根据(角度)，(起点坐标)及(长度)计算与角度相差90°的[终点坐标]
        /// </summary>
        /// <param name="Cx1">起点Cx坐标</param>
        /// <param name="Ry1">起点Ry坐标</param>
        /// <param name="Phi">角度对应的弧度</param>
        /// <param name="Length">长度</param>
        /// <param name="Cx2">输出终点Cx坐标</param>
        /// <param name="Ry2">输出终点Ry坐标</param>
        public static void Phi_P1_Length_To_P2(HTuple Cx1, HTuple Ry1, HTuple Phi, HTuple Length, out HTuple Cx2, out HTuple Ry2)
        {
            HTuple DCx, DRy;
            if (Phi == null)
            {
                Cx2 = Cx1 + Length;
                Ry2 = Ry1;
            }
            else
            {
                if (Phi > 0)
                {
                    Phi = Phi - 1.5707964;
                    DCx = Length * Phi.TupleCos();
                    DRy = Length * Phi.TupleSin();
                    Cx2 = Cx1 + DCx;
                    Ry2 = Ry1 + DRy;
                }
                else if (Phi < 0)
                {
                    Phi = Phi + 1.5707964;
                    DCx = Length * Phi.TupleCos();
                    DRy = Length * Phi.TupleSin();
                    Cx2 = Cx1 + DCx;
                    Ry2 = Ry1 + DRy;
                }
                else
                {
                    Cx2 = Cx1;
                    Ry2 = Ry1 + Length;
                }
            }
        }

        /// <summary>
        /// 根据(角度)，(起点坐标)及(长度)计算与角度相差90°的[终点坐标]
        /// </summary>
        /// <param name="Phi">角度对应的弧度</param>
        /// <param name="P1">起点坐标</param>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public static Point Phi_P1_Length_To_P2(HTuple Phi, Point P1, HTuple Length)
        {
            HTuple DCx, DRy;
            Point P2 = new Point();
            if (Phi == null)
            {
                P2.hv_Column = P1.hv_Column + Length;
                P2.hv_Row = P1.hv_Row;
            }
            else
            {
                if (Phi > 0)
                {
                    Phi = Phi - 1.5707964;
                    DCx = Length * Phi.TupleCos();
                    DRy = Length * Phi.TupleSin();
                    P2.hv_Column = P1.hv_Column + DCx;
                    P2.hv_Row = P1.hv_Row + DRy;
                }
                else if (Phi < 0)
                {
                    Phi = Phi + 1.5707964;
                    DCx = Length * Phi.TupleCos();
                    DRy = Length * Phi.TupleSin();
                    P2.hv_Column = P1.hv_Column + DCx;
                    P2.hv_Row = P1.hv_Row + DRy;
                }
                else
                {
                    P2.hv_Column = P1.hv_Column;
                    P2.hv_Row = P1.hv_Row + Length;
                }
            }
            return P2;
        }

        /// <summary>
        /// 根据线，线上的点和长度求与该线垂直的线
        /// </summary>
        /// <param name="line"></param>
        /// <param name="point"></param>
        /// <param name="hv_Length"></param>
        /// <returns></returns>
        public static Line Line_Point_Length_To_VerticalLine(Line line, Point point, HTuple hv_Length)
        {
            HTuple hv_Phi = P1_P2_To_Phi(line.hv_Column1, line.hv_Row1, line.hv_Column2, line.hv_Row2);
            Point ps = Phi_P1_Length_To_P2(hv_Phi, point, hv_Length);
            Point pe = new Point(point.hv_Column - (ps.hv_Column - point.hv_Column), point.hv_Row - (ps.hv_Row - point.hv_Row));
            Line resultLine = new Line(ps.hv_Column, ps.hv_Row, pe.hv_Column, pe.hv_Row);
            return resultLine;
        }

        /// <summary>
        /// 求点到线的距离
        /// </summary>
        /// <param name="PCx1">点的Cx坐标</param>
        /// <param name="PRy1">点的Ry坐标</param>
        /// <param name="LCx1">线的起点Cx坐标</param>
        /// <param name="LRy1">线的起点Ry坐标</param>
        /// <param name="LCx2">线的终点Cx坐标</param>
        /// <param name="LRy2">线的终点Ry坐标</param>
        /// <returns></returns>
        public static HTuple Distance_P1_To_Line(HTuple PCx1, HTuple PRy1, HTuple LCx1, HTuple LRy1, HTuple LCx2, HTuple LRy2)
        {
            HTuple result;
            if ((double)(LCx1 - LCx2) == 0)
            {
                result = PCx1 - LCx1;
                result = Math.Abs((double)result);
            }
            else
            {
                HTuple hv_PhiBig = P1_P2_To_Phi(LCx1, LRy1, LCx2, LRy2);
                HTuple hv_PhiSmall = P1_P2_To_Phi(PCx1, PRy1, LCx1, LRy1);
                HTuple Length = P1_P2_To_Distance(PCx1, PRy1, LCx1, LRy1);
                result = Length * (hv_PhiBig - hv_PhiSmall).TupleSin();
                result = Math.Abs((double)result);
            }
            return result;
        }

        /// <summary>
        /// 求点到线的距离
        /// </summary>
        /// <param name="P1">点</param>
        /// <param name="Line1">线</param>
        /// <returns></returns>
        public static HTuple Distance_P1_To_Line(Point P1, Line Line1)
        {
            HTuple result;
            if ((Line1.hv_Column1 - Line1.hv_Column2).D == 0)
            {
                result = P1.hv_Column - Line1.hv_Column1;
                result = Math.Abs((double)result);
            }
            else
            {
                HTuple hv_PhiBig = P1_P2_To_Phi(Line1.hv_Column1, Line1.hv_Row1, Line1.hv_Column2, Line1.hv_Row2);
                HTuple hv_PhiSmall = P1_P2_To_Phi(P1.hv_Column, P1.hv_Row, Line1.hv_Column1, Line1.hv_Row1);
                HTuple Length = P1_P2_To_Distance(P1.hv_Column, P1.hv_Row, Line1.hv_Column1, Line1.hv_Row1);
                result = Length * (hv_PhiBig - hv_PhiSmall).TupleSin();
                result = Math.Abs((double)result);
            }
            return result;
        }

        /// <summary>
        /// 求一组点的平面度
        /// </summary>
        /// <param name="points">一组点</param>
        /// <param name="horizontalOrVertical">true 为求垂直方向平面度</param>
        /// <returns></returns>
        public static HTuple Flatness(List<Point> points, bool horizontalOrVertical)
        {
            return null;
        }
        public static Rectangle2 ToRectangle2(Rectangle1 rectangle1)
        {
            Rectangle2 rectangle2 = new Rectangle2();
            rectangle2.hv_Length1 = (rectangle1.hv_Column2 - rectangle1.hv_Column1) / 2;
            rectangle2.hv_Length2 = (rectangle1.hv_Row2 - rectangle1.hv_Row1) / 2;
            rectangle2.hv_Phi = 0;
            rectangle2.hv_Column = (rectangle1.hv_Column2 + rectangle1.hv_Column1) / 2;
            rectangle2.hv_Row = (rectangle1.hv_Row1 + rectangle1.hv_Row2) / 2;
            return rectangle2;
        }
        public static Rectangle1 ToRectangle1(Rectangle2 rectangle2)
        {
            if (rectangle2.hv_Phi.D == 0)
            {
                Rectangle1 rectangle1 = new Rectangle1();
                rectangle1.hv_Column1 = rectangle2.hv_Column - rectangle2.hv_Length1;
                rectangle1.hv_Column2 = rectangle2.hv_Column + rectangle2.hv_Length1;
                rectangle1.hv_Row1 = rectangle2.hv_Row - rectangle2.hv_Length2;
                rectangle1.hv_Row2 = rectangle2.hv_Row + rectangle2.hv_Length2;
                return rectangle1;
            }
            return null;
        }

    }//end of class


    //-----------------------------------------------------------------------------


    /// <summary>
    /// halcon算子简单封装类
    /// </summary>
    public static class Func_HalconFunction
    {
        /// <summary>
        /// 画点
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <returns></returns>
        public static Point DrawPoint(HTuple hv_ExpDefaultWinHandle)
        {
            Point point = new Point();
            HOperatorSet.DrawPoint(hv_ExpDefaultWinHandle, out point.hv_Row, out point.hv_Column);
            return point;
        }

        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <returns></returns>
        public static Line DrawLine(HTuple hv_ExpDefaultWinHandle)
        {
            Line line = new Line();
            HOperatorSet.DrawLine(hv_ExpDefaultWinHandle, out line.hv_Row1, out line.hv_Column1, out line.hv_Row2, out line.hv_Column2);
            return line;
        }

        /// <summary>
        /// 重画线
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <param name="line">线</param>
        /// <returns></returns>
        public static Line DrawLineMod(HTuple hv_ExpDefaultWinHandle, Line line)
        {
            HOperatorSet.DrawLineMod(hv_ExpDefaultWinHandle, line.hv_Row1, line.hv_Column1, line.hv_Row2, line.hv_Column2, out line.hv_Row1, out line.hv_Column1, out line.hv_Row2, out line.hv_Column2);
            return line;
        }

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <returns></returns>
        public static Circle DrawCircle(HTuple hv_ExpDefaultWinHandle)
        {
            Circle circle = new Circle();
            HOperatorSet.DrawCircle(hv_ExpDefaultWinHandle, out circle.hv_Row, out circle.hv_Column, out circle.hv_Radius);
            return circle;
        }

        /// <summary>
        /// 重画圆
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <param name="circle">圆</param>
        /// <returns></returns>
        public static Circle DrawCircleMod(HTuple hv_ExpDefaultWinHandle, Circle circle)
        {
            HOperatorSet.DrawCircleMod(hv_ExpDefaultWinHandle, circle.hv_Row, circle.hv_Column, circle.hv_Radius, out circle.hv_Row, out circle.hv_Column, out circle.hv_Radius);
            return circle;
        }

        /// <summary>
        /// 画矩形1
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <returns></returns>
        public static Rectangle1 DrawRectangle1(HTuple hv_ExpDefaultWinHandle)
        {
            Rectangle1 rectangle1 = new Rectangle1();
            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
            HOperatorSet.DrawRectangle1(hv_ExpDefaultWinHandle, out rectangle1.hv_Row1, out rectangle1.hv_Column1, out rectangle1.hv_Row2, out rectangle1.hv_Column2);
            return rectangle1;
        }

        /// <summary>
        /// 重画矩形1
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <param name="rectangle1">矩形1</param>
        /// <returns></returns>
        public static Rectangle1 DrawRectangle1Mod(HTuple hv_ExpDefaultWinHandle, Rectangle1 rectangle1)
        {
            //画矩形
            HOperatorSet.DrawRectangle1Mod(hv_ExpDefaultWinHandle,
                rectangle1.hv_Row1,
                rectangle1.hv_Column1,
                rectangle1.hv_Row2,
                rectangle1.hv_Column2,
                out rectangle1.hv_Row1,
                out rectangle1.hv_Column1,
                out rectangle1.hv_Row2,
                out rectangle1.hv_Column2);
            //画矩形
            return rectangle1;
        }

        /// <summary>
        /// 画矩形2
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <returns></returns>
        public static Rectangle2 DrawRectangle2(HTuple hv_ExpDefaultWinHandle)
        {
            Rectangle2 rectangle2 = new Rectangle2();
            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
            HOperatorSet.DrawRectangle2(hv_ExpDefaultWinHandle, out rectangle2.hv_Row, out rectangle2.hv_Column, out rectangle2.hv_Phi, out rectangle2.hv_Length1, out rectangle2.hv_Length2);
            return rectangle2;
        }

        /// <summary>
        /// 重画矩形2
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">窗口句柄</param>
        /// <param name="rectangle2">矩形2</param>
        /// <returns></returns>
        public static Rectangle2 DrawRectangle2Mod(HTuple hv_ExpDefaultWinHandle, Rectangle2 rectangle2)
        {
            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
            HOperatorSet.DrawRectangle2Mod(hv_ExpDefaultWinHandle, rectangle2.hv_Row, rectangle2.hv_Column, rectangle2.hv_Phi, rectangle2.hv_Length1, rectangle2.hv_Length2, out rectangle2.hv_Row, out rectangle2.hv_Column, out rectangle2.hv_Phi, out rectangle2.hv_Length1, out rectangle2.hv_Length2);
            return rectangle2;
        }

        /// <summary>
        /// 创建矩形1
        /// </summary>
        /// <param name="rectangle1">矩形1</param>
        /// <returns></returns>
        public static HObject GenRectangle1(Rectangle1 rectangle1)
        {
            HOperatorSet.GenRectangle1(out HObject ho_Rectangle1, rectangle1.hv_Row1, rectangle1.hv_Column1, rectangle1.hv_Row2, rectangle1.hv_Column2);
            return ho_Rectangle1;
        }

        /// <summary>
        /// 创建矩形2
        /// </summary>
        /// <param name="rectangle2">矩形2</param>
        /// <returns></returns>
        public static HObject GenRectangle2(Rectangle2 rectangle2)
        {
            HOperatorSet.GenRectangle2(out HObject ho_Rectangle2, rectangle2.hv_Row, rectangle2.hv_Column, rectangle2.hv_Phi, rectangle2.hv_Length1, rectangle2.hv_Length2);
            return ho_Rectangle2;
        }

        /// <summary>
        /// 创建一个矩形形状的XLD轮廓
        /// </summary>
        /// <param name="rectangle2">矩形2</param>
        /// <returns></returns>
        public static HObject GenRectangle2ContourXld(Rectangle2 rectangle2)
        {
            HOperatorSet.GenRectangle2ContourXld(out HObject ho_Rectangle2, rectangle2.hv_Row, rectangle2.hv_Column, rectangle2.hv_Phi, rectangle2.hv_Length1, rectangle2.hv_Length2);
            return ho_Rectangle2;
        }

        /// <summary>
        /// 创建线
        /// </summary>
        /// <param name="line">线</param>
        /// <returns></returns>
        public static HObject GenRegionLine(Line line)
        {
            HOperatorSet.GenRegionLine(out HObject ho_Line, line.hv_Row1, line.hv_Column1, line.hv_Row2, line.hv_Column2);
            return ho_Line;
        }

        /// <summary>
        /// 创建点
        /// </summary>
        /// <param name="point">点</param>
        /// <returns></returns>
        public static HObject GenRegionPoints(Point point)
        {
            HOperatorSet.GenRegionPoints(out HObject ho_Point, point.hv_Row, point.hv_Column);
            return ho_Point;
        }

        /// <summary>
        /// 创建圆
        /// </summary>
        /// <param name="circle">圆</param>
        /// <returns></returns>
        public static HObject GenCircle(Circle circle)
        {
            HOperatorSet.GenCircle(out HObject ho_Circle, circle.hv_Row, circle.hv_Column, circle.hv_Radius);
            return ho_Circle;
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="ho_Image">图像</param>
        /// <param name="rectangle2">矩形2</param>
        /// <returns></returns>
        public static HObject ReduceImage(HObject ho_Image, Rectangle2 rectangle2)
        {
            HObject ho_rectangle2 = GenRectangle2(rectangle2);
            HOperatorSet.ReduceDomain(ho_Image, ho_rectangle2, out HObject ho_ImageReduced);
            ho_rectangle2.Dispose();
            return ho_ImageReduced;
        }

    }//end of class

    //--------------------------------------------------------------------------------------------------------



    /// <summary>
    /// 简单图像处理类
    /// </summary>
    public static class Func_ImageProcessing //简单图像处理类
    {
        /// <summary>
        /// 选择最大的区域
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="ho_ROI"></param>
        /// <param name="hv_MinGray"></param>
        /// <param name="hv_MaxGray"></param>
        /// <returns></returns>
        public static HObject Threshold_SelectMaxRegion(HObject ho_Image, HObject ho_ROI, HTuple hv_MinGray, HTuple hv_MaxGray)
        {
            //参数赋值区//参数赋值区//参数赋值区//参数赋值区//参数赋值区//参数赋值区

            ////消除噪声
            //HObject ho_ImageMean;
            //HOperatorSet.MeanImage(ho_Image, out ho_ImageMean, 5, 5);

            ////抑制小斑点或者细线
            //HObject ho_ImageMedian;
            //HOperatorSet.MedianImage(ho_ImageMean, out ho_ImageMedian, "circle", 1, "mirrored");

            ////平滑
            //HObject ho_ImageSmooth;
            //HOperatorSet.SmoothImage(ho_ImageMedian, out ho_ImageSmooth, "deriche2", 0.5);

            //切割图片
            HObject ho_ImageReduced;
            HOperatorSet.ReduceDomain(ho_Image, ho_ROI, out ho_ImageReduced);

            //灰度处理
            HObject ho_Region;
            HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, hv_MinGray, hv_MaxGray);

            //分割区域
            HObject ho_ConnectedRegions;
            HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);

            //计算中心和面积
            HTuple hv_Area, a, s;
            HOperatorSet.AreaCenter(ho_ConnectedRegions, out hv_Area, out a, out s);
            //选出最大面积
            //HTuple MaxArea = hv_Area[0];
            HTuple MaxArea = hv_Area.TupleMax();
            //for (int n = 0; n < hv_Area.Length; n++)
            //{
            //    if (MaxArea < hv_Area[n])
            //    {
            //        MaxArea = hv_Area[n];
            //    }
            //}
            //面积选择
            HObject ho_SelectedRegions;
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
                "and", MaxArea, MaxArea);
            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_ConnectedRegions.Dispose();
            //int objCount = ho_SelectedRegions.CountObj();
            //if (objCount > 1)
            //    return ho_SelectedRegions.SelectObj(1);
            return ho_SelectedRegions.SelectObj(1);
        }


        /// <summary>
        /// 从区域得到点
        /// </summary>
        /// <param name="ho_SelectedRegions"></param>
        /// <param name="TD"></param>
        /// <returns></returns>
        public static Point getPoint_FromRegion(HObject ho_SelectedRegions, HTuple TD)
        {
            Point resultPoint = new Point();

            //形状变换（矩形）
            HObject ho_RegionTrans;


            HOperatorSet.ShapeTrans(ho_SelectedRegions, out ho_RegionTrans, "rectangle1");
            HTuple hv_Row1, hv_Column1, hv_Row2, hv_Column2;
            //区域左上角行坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "row1", out hv_Row1);
            //区域左上角列坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "column1", out hv_Column1);
            //区域右下角行坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "row2", out hv_Row2);
            //区域右下角列坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "column2", out hv_Column2);
            switch (TD.I)
            {
                case 1:
                    resultPoint.hv_Column = hv_Column1[0];
                    resultPoint.hv_Row = hv_Row1[0];
                    break;
                case 2:
                    resultPoint.hv_Column = hv_Column2[0];
                    resultPoint.hv_Row = hv_Row2[0];
                    break;
                default:
                    break;
            }

            return resultPoint;
        }

        /// <summary>
        /// 从区域中获得线
        /// </summary>
        /// <param name="ho_SelectedRegions"></param>
        /// <param name="TPLR"></param>
        /// <param name="b"></param>
        /// <param name="angularPoint"></param>
        /// <returns></returns>
        public static Line getLine_FromRegion(HObject ho_SelectedRegions, HTuple TPLR, HTuple b, bool angularPoint)
        {
            Line resultLine = new Line();
            //形状变换（矩形）
            HObject ho_RegionTrans;

            HTuple hv_Rows = null, hv_Columns = null, hv_sel = null;
            if (angularPoint)
            {
                HOperatorSet.GetRegionPoints(ho_SelectedRegions, out hv_Rows, out hv_Columns);
            }

            HOperatorSet.ShapeTrans(ho_SelectedRegions, out ho_RegionTrans, "rectangle1");
            HTuple hv_Row1, hv_Column1, hv_Row2, hv_Column2, hv_RP = null, hv_CP = null;
            //区域左上角行坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "row1", out hv_Row1);
            //区域左上角列坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "column1", out hv_Column1);
            //区域右下角行坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "row2", out hv_Row2);
            //区域右下角列坐标
            HOperatorSet.RegionFeatures(ho_RegionTrans, "column2", out hv_Column2);

            switch (TPLR.I)
            {
                case 1://上
                    if (angularPoint)
                    {
                        try
                        {
                            HOperatorSet.DistancePl(hv_Rows, hv_Columns, hv_Row1, hv_Column1, hv_Row1, hv_Column2, out HTuple hv_Distance);
                            hv_sel = hv_Distance.TupleFind(hv_Distance.TupleMin());
                            HOperatorSet.ProjectionPl(((hv_Rows.TupleSelect(hv_sel))).TupleSelect(0), ((hv_Columns.TupleSelect(
            hv_sel))).TupleSelect(0), hv_Row1, hv_Column1, hv_Row1, hv_Column2, out hv_RP, out hv_CP);
                            resultLine.hv_Column1 = hv_CP[0] + b;
                            resultLine.hv_Row1 = hv_RP[0];
                            resultLine.hv_Column2 = hv_CP[0] + b;
                            resultLine.hv_Row2 = hv_Row2[0];
                        }
                        catch (Exception)
                        {
                            resultLine.hv_Column1 = -1;
                            resultLine.hv_Row1 = 0;
                            resultLine.hv_Column2 = -1;
                            resultLine.hv_Row2 = -1;

                        }
                    }
                    else
                    {
                        resultLine.hv_Column1 = hv_Column1[0];
                        resultLine.hv_Row1 = hv_Row1[0] + b;
                        resultLine.hv_Column2 = hv_Column2[0];
                        resultLine.hv_Row2 = hv_Row1[0] + b;
                    }

                    break;
                case 2://下
                    if (angularPoint)
                    {
                        try
                        {
                            HOperatorSet.DistancePl(hv_Rows, hv_Columns, hv_Row2, hv_Column1, hv_Row2, hv_Column2, out HTuple hv_Distance);
                            hv_sel = hv_Distance.TupleFind(hv_Distance.TupleMin());
                            HOperatorSet.ProjectionPl(((hv_Rows.TupleSelect(hv_sel))).TupleSelect(0), ((hv_Columns.TupleSelect(
            hv_sel))).TupleSelect(0), hv_Row2, hv_Column1, hv_Row2, hv_Column2, out hv_RP, out hv_CP);
                            resultLine.hv_Column1 = hv_CP[0] + b;
                            resultLine.hv_Row1 = hv_RP[0];
                            resultLine.hv_Column2 = hv_CP[0] + b;
                            resultLine.hv_Row2 = hv_Row1[0];
                        }
                        catch (Exception)
                        {

                            resultLine.hv_Column1 = -1;
                            resultLine.hv_Row1 = 0;
                            resultLine.hv_Column2 = -1;
                            resultLine.hv_Row2 = -1;
                        }
                    }
                    else
                    {
                        resultLine.hv_Column1 = hv_Column1[0];
                        resultLine.hv_Row1 = hv_Row2[0] + b;
                        resultLine.hv_Column2 = hv_Column2[0];
                        resultLine.hv_Row2 = hv_Row2[0] + b;
                    }

                    break;
                case 3://左
                    if (angularPoint)
                    {
                        try
                        {
                            HOperatorSet.DistancePl(hv_Rows, hv_Columns, hv_Row1, hv_Column1, hv_Row2, hv_Column1, out HTuple hv_Distance);
                            hv_sel = hv_Distance.TupleFind(hv_Distance.TupleMin());
                            HOperatorSet.ProjectionPl(((hv_Rows.TupleSelect(hv_sel))).TupleSelect(0), ((hv_Columns.TupleSelect(
            hv_sel))).TupleSelect(0), hv_Row1, hv_Column1, hv_Row2, hv_Column1, out hv_RP, out hv_CP);
                            resultLine.hv_Column1 = hv_CP;
                            resultLine.hv_Row1 = hv_RP[0] + b;
                            resultLine.hv_Column2 = hv_Column2;
                            resultLine.hv_Row2 = hv_RP[0] + b;
                        }
                        catch (Exception)
                        {
                            resultLine.hv_Column1 = 0;
                            resultLine.hv_Row1 = -1;
                            resultLine.hv_Column2 = -1;
                            resultLine.hv_Row2 = -1;
                        }
                    }
                    else
                    {
                        resultLine.hv_Column1 = hv_Column1[0] + b;
                        resultLine.hv_Row1 = hv_Row1[0];
                        resultLine.hv_Column2 = hv_Column1[0] + b;
                        resultLine.hv_Row2 = hv_Row2[0];
                    }

                    break;
                case 4://右
                    if (angularPoint)
                    {
                        try
                        {
                            HOperatorSet.DistancePl(hv_Rows, hv_Columns, hv_Row1, hv_Column2, hv_Row2, hv_Column2, out HTuple hv_Distance);
                            hv_sel = hv_Distance.TupleFind(hv_Distance.TupleMin());
                            HOperatorSet.ProjectionPl(((hv_Rows.TupleSelect(hv_sel))).TupleSelect(0), ((hv_Columns.TupleSelect(
            hv_sel))).TupleSelect(0), hv_Row1, hv_Column2, hv_Row2, hv_Column2, out hv_RP, out hv_CP);
                            resultLine.hv_Column1 = hv_CP;
                            resultLine.hv_Row1 = hv_RP[0] + b;
                            resultLine.hv_Column2 = hv_Column1;
                            resultLine.hv_Row2 = hv_RP[0] + b;
                        }
                        catch (Exception)
                        {
                            resultLine.hv_Column1 = 0;
                            resultLine.hv_Row1 = -1;
                            resultLine.hv_Column2 = -1;
                            resultLine.hv_Row2 = -1;
                        }
                    }
                    else
                    {
                        resultLine.hv_Column1 = hv_Column2[0] + b;
                        resultLine.hv_Row1 = hv_Row1[0];
                        resultLine.hv_Column2 = hv_Column2[0] + b;
                        resultLine.hv_Row2 = hv_Row2[0];
                    }
                    break;
                case 5:
                    resultLine.hv_Column1 = (hv_Column1[0] + hv_Column2[0]) / 2 + b;
                    resultLine.hv_Row1 = hv_Row1[0];
                    resultLine.hv_Column2 = (hv_Column1[0] + hv_Column2[0]) / 2 + b;
                    resultLine.hv_Row2 = hv_Row2[0];
                    break;
                default:
                    break;
            }
            ho_RegionTrans.Dispose();
            GC.Collect();
            return resultLine;
        }

        /// <summary>
        /// 边缘拟合获得线
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="CannyParas"></param>
        /// <param name="rectangle2"></param>
        /// <returns></returns>
        public static Line getLine_FromCanny(HObject ho_Image, Canny CannyParas, Rectangle2 rectangle2)
        {
            Line resultLine = new Line();
            //创建ROI矩形
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle2(rectangle2);
            //裁切图片
            HObject ho_ImageReduced;
            HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);
            //抓取边缘
            HObject ho_Edges;
            HOperatorSet.EdgesSubPix(ho_ImageReduced, out ho_Edges, "canny", CannyParas.hv_Alpha, CannyParas.hv_Low, CannyParas.hv_High);
            //轮廓分割
            HObject ho_ContoursSplit;
            HOperatorSet.SegmentContoursXld(ho_Edges, out ho_ContoursSplit, "lines_circles",
                5, 10, 5);
            //**************************************************************************************
            HTuple hv_Number = null, hv_NumberCircles = null, hv_j = null, hv_Attrib = new HTuple();
            HObject ho_ObjectSelected;
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            //准备一个空项目
            HObject ho_CircularArcs;
            HOperatorSet.GenEmptyObj(out ho_CircularArcs);
            //统计一个元组中的对象
            HOperatorSet.CountObj(ho_ContoursSplit, out hv_Number);
            hv_NumberCircles = 0;
            hv_j = 1;
            HTuple end_val17 = hv_Number;
            HTuple step_val17 = 1;
            for (hv_j = 1; hv_j.Continue(end_val17, step_val17); hv_j = hv_j.TupleAdd(step_val17))
            {
                //从一个目标元组中选择目标
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(ho_ContoursSplit, out ho_ObjectSelected, hv_j);
                //得到一段XLD轮廓的全局特征
                HOperatorSet.GetContourGlobalAttribXld(ho_ObjectSelected, "cont_approx", out hv_Attrib);
                if ((int)(new HTuple(hv_Attrib.TupleEqual(-1))) != 0)
                {
                    //合并区域
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_CircularArcs, ho_ObjectSelected, out ExpTmpOutVar_0
                            );
                        ho_CircularArcs.Dispose();
                        ho_CircularArcs = ExpTmpOutVar_0;
                    }
                }
            }
            //**************************************************************************************
            //共线连接
            HObject ho_UnionContours;
            HOperatorSet.UnionCollinearContoursXld(ho_CircularArcs, out ho_UnionContours,
                10, 1, 2, 0.1, "attr_keep");
            //拟合直线
            HTuple hv_RowBegin, hv_ColBegin, hv_RowEnd, hv_ColEnd, hv_Nr, hv_Nc, hv_Dist;
            HOperatorSet.FitLineContourXld(ho_UnionContours, "tukey", -1, 0, 5, 2, out hv_RowBegin,
                out hv_ColBegin, out hv_RowEnd, out hv_ColEnd, out hv_Nr, out hv_Nc, out hv_Dist);
            //测量结束

            ho_Rectangle.Dispose();
            ho_ImageReduced.Dispose();
            ho_Edges.Dispose();
            ho_ContoursSplit.Dispose();
            ho_CircularArcs.Dispose();
            ho_ObjectSelected.Dispose();
            ho_UnionContours.Dispose();

            //结果处理，找出最长的线段,没有结果全赋值0
            if (hv_RowBegin.Length > 0)
            {
                if (hv_RowBegin.Length > 1)
                {
                    HTuple MaxDistance = Func_Mathematics.P1_P2_To_Distance(hv_ColBegin[0], hv_RowBegin[0], hv_ColEnd[0], hv_RowEnd[0]);
                    for (int n = 0; n < hv_RowBegin.Length; n++)
                    {
                        if (MaxDistance < Func_Mathematics.P1_P2_To_Distance(hv_ColBegin[n], hv_RowBegin[n], hv_ColEnd[n], hv_RowEnd[n]))
                        {
                            hv_ColBegin[0] = hv_ColBegin[n];
                            hv_RowBegin[0] = hv_RowBegin[n];
                            hv_ColEnd[0] = hv_ColEnd[n];
                            hv_RowEnd[0] = hv_RowEnd[n];
                        }
                    }
                    //计算与该基准线垂直的线的Phi值
                }
            }
            else
            {
                hv_ColBegin = 0;
                hv_RowBegin = 0;
                hv_ColEnd = 0;
                hv_RowEnd = 0;
            }
            ////结果处理，找出最长的线段,没有结果全赋值0
            //data_GetBaseLine.getBaseLineResult.hv_Phi = Func_Mathematics.P1_P2_To_Phi(hv_ColBegin[0], hv_RowBegin[0], hv_ColEnd[0], hv_RowEnd[0]);

            //结果赋值
            resultLine.hv_Row1 = hv_RowBegin[0];
            resultLine.hv_Column1 = hv_ColBegin[0];
            resultLine.hv_Row2 = hv_RowEnd[0];
            resultLine.hv_Column2 = hv_ColEnd[0];
            //结果赋值
            if (hv_ColEnd[0] < hv_ColBegin[0])
            {
                resultLine.hv_Row2 = hv_RowBegin[0];
                resultLine.hv_Column2 = hv_ColBegin[0];
                resultLine.hv_Row1 = hv_RowEnd[0];
                resultLine.hv_Column1 = hv_ColEnd[0];
            }
            return resultLine;
        }


        public static Line getLine_FromMetrology(HObject ho_Image, Metrology metrologyParams, Line line, out HXLDCont contours, out HXLDCont cross)
        {

            Line resultLine = new Line();
            HTuple measureSigma = 1;
            HTuple genParamName = new HTuple();
            HTuple genParamValue = new HTuple();

            HMetrologyModel h_MetrologyModel = new HMetrologyModel();

            HTuple result = new HTuple();


            try
            {

                h_MetrologyModel.AddMetrologyObjectLineMeasure(line.hv_Row1, line.hv_Column1, line.hv_Row2, line.hv_Column2, metrologyParams.measureLength1
                          , metrologyParams.measureLength2, measureSigma, metrologyParams.measureThreshold, genParamName, genParamValue);


                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_distance", metrologyParams.measureDistance);

                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_select", metrologyParams.measureSelect);

                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_transition", metrologyParams.measureTransition);
            }
            catch (Exception)
            {


            }

            HOperatorSet.ApplyMetrologyModel(ho_Image, h_MetrologyModel);


            try
            {

                contours = h_MetrologyModel.GetMetrologyObjectMeasures(0, "all", out HTuple row, out HTuple column);
                cross = new HXLDCont();
                cross.GenCrossContourXld(row, column, 6, 0.785398);

                result = h_MetrologyModel.GetMetrologyObjectResult(0, "all", "result_type",
                    new HTuple(new string[] { "row_begin", "column_begin", "row_end", "column_end" }));
            }
            catch (Exception)
            {
                contours = new HXLDCont();
                cross = new HXLDCont();
            }

            if (result.Length > 0)
            {
                resultLine.hv_Row1 = result[0];
                resultLine.hv_Column1 = result[1];
                resultLine.hv_Row2 = result[2];
                resultLine.hv_Column2 = result[3];
            }
            else
            {
                resultLine.hv_Column1 = -1;
                resultLine.hv_Row1 = 0;
                resultLine.hv_Column2 = -1;
                resultLine.hv_Row2 = -1;
            }


            h_MetrologyModel.Dispose();
            GC.Collect();

            return resultLine;
        }

        /// <summary>
        /// 从区域中得到圆
        /// </summary>
        /// <param name="ho_RegionUnion"></param>
        /// <returns></returns>
        public static Circle getCircle_FromRegion(HObject ho_RegionUnion)
        {

            //区域变换
            HObject ho_RegionTrans;
            HOperatorSet.ShapeTrans(ho_RegionUnion, out ho_RegionTrans, "outer_circle");

            //计算中心
            HTuple hv_Area, hv_Row, hv_Column;
            HOperatorSet.AreaCenter(ho_RegionTrans, out hv_Area, out hv_Row, out hv_Column);

            //计算半径
            HTuple hv_Radius;
            hv_Radius = ((hv_Area / 3.1415926)).TupleSqrt();

            //结果赋值
            Circle resultCircle = new Circle();
            resultCircle.hv_Column = hv_Column[0];
            resultCircle.hv_Row = hv_Row[0];
            resultCircle.hv_Radius = hv_Radius[0];

            //释放资源
            ho_RegionTrans.Dispose();

            return resultCircle;
        }

        public static Circle getCircle_FromMetrology(HObject ho_Image, Metrology metrologyParams, Circle circle, out HXLDCont contours, out HXLDCont cross)
        {

            Circle resultCircle = new Circle();
            HTuple measureSigma = 1;
            HTuple genParamName = new HTuple();
            HTuple genParamValue = new HTuple();

            HMetrologyModel h_MetrologyModel = new HMetrologyModel();

            HTuple result = new HTuple();


            try
            {

                h_MetrologyModel.AddMetrologyObjectCircleMeasure(circle.hv_Row, circle.hv_Column, circle.hv_Radius, metrologyParams.measureLength1
                          , metrologyParams.measureLength2, measureSigma, metrologyParams.measureThreshold, genParamName, genParamValue);


                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_distance", metrologyParams.measureDistance);

                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_select", metrologyParams.measureSelect);

                h_MetrologyModel.SetMetrologyObjectParam(0, "measure_transition", metrologyParams.measureTransition);

                h_MetrologyModel.SetMetrologyObjectParam(0, "min_score", 0.5);

                h_MetrologyModel.SetMetrologyObjectParam(0, "num_instances", 4);




            }
            catch (Exception)
            {


            }

            HOperatorSet.ApplyMetrologyModel(ho_Image, h_MetrologyModel);


            try
            {

                contours = h_MetrologyModel.GetMetrologyObjectMeasures(0, "all", out HTuple row, out HTuple column);
                cross = new HXLDCont();
                cross.GenCrossContourXld(row, column, 6, 0.785398);

                result = h_MetrologyModel.GetMetrologyObjectResult(0, "all", "result_type", new HTuple(new string[] { "row","column","radius"}));


            }
            catch (Exception)
            {
                contours = new HXLDCont();
                cross = new HXLDCont();
            }

            if (result.Length > 0)
            {
             
                resultCircle.hv_Row = result[0];
                resultCircle.hv_Column = result[1];
                resultCircle.hv_Radius = result[2];
            }
            else
            {
                resultCircle.hv_Row = 0;
                resultCircle.hv_Column = 0;
                resultCircle.hv_Radius = 0;
            }


            h_MetrologyModel.Dispose();
            GC.Collect();

            return resultCircle;
        }

        /// <summary>
        /// 边缘检测点
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Point getPoint(HObject ho_Image, Measure_Pos parameters)
        {
            Point resultPoint = new Point();

            HTuple hv_AmplitudeThreshold = parameters.hv_AmplitudeThreshold;    //最小边缘幅度0-255           //默认40
            HTuple hv_RoiWidthLen2 = parameters.hv_RoiWidthLen2;                //ROI宽       0-127          //默认5
            HTuple hv_Sigma = parameters.hv_Sigma;                              //平滑       （4-320）/10   //默认10/10
            Line line = parameters.line.GetShapePositioned() as Line;           //获取定位后的线
            HTuple hv_LineRowStart_Measure_01_0 = line.hv_Row1;                 //起点y/行
            HTuple hv_LineColumnStart_Measure_01_0 = line.hv_Column1;           //起点x/  列
            HTuple hv_LineRowEnd_Measure_01_0 = line.hv_Row2;                   //终点y/行
            HTuple hv_LineColumnEnd_Measure_01_0 = line.hv_Column2;             //终点x/  列
            HTuple hv_Transition = parameters.hv_Transition;                    //'positive'/'negative'

            HTuple hv_Width = null;
            HTuple hv_Height = null;

            HTuple hv_Row_Measure_01_0 = null;
            HTuple hv_Column_Measure_01_0 = null;
            HTuple hv_Amplitude_Measure_01_0 = null;
            HTuple hv_Distance_Measure_01_0 = null;

            HTuple hv_TmpCtrl_Row = null;
            HTuple hv_TmpCtrl_Column = null;
            HTuple hv_TmpCtrl_Dr = null;
            HTuple hv_TmpCtrl_Dc = null;
            HTuple hv_TmpCtrl_Phi = null;
            HTuple hv_TmpCtrl_Len1 = null;
            HTuple hv_MsrHandle_Measure_01_0 = null;

            //获取图片尺寸
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            HOperatorSet.SetSystem("int_zooming", "true");
            hv_TmpCtrl_Row = 0.5 * (hv_LineRowStart_Measure_01_0 + hv_LineRowEnd_Measure_01_0);
            hv_TmpCtrl_Column = 0.5 * (hv_LineColumnStart_Measure_01_0 + hv_LineColumnEnd_Measure_01_0);
            hv_TmpCtrl_Dr = hv_LineRowStart_Measure_01_0 - hv_LineRowEnd_Measure_01_0;
            hv_TmpCtrl_Dc = hv_LineColumnEnd_Measure_01_0 - hv_LineColumnStart_Measure_01_0;
            hv_TmpCtrl_Phi = hv_TmpCtrl_Dr.TupleAtan2(hv_TmpCtrl_Dc);
            hv_TmpCtrl_Len1 = 0.5 * ((((hv_TmpCtrl_Dr * hv_TmpCtrl_Dr) + (hv_TmpCtrl_Dc * hv_TmpCtrl_Dc))).TupleSqrt());
            try
            {
                HOperatorSet.GenMeasureRectangle2(hv_TmpCtrl_Row, hv_TmpCtrl_Column, hv_TmpCtrl_Phi,
    hv_TmpCtrl_Len1, hv_RoiWidthLen2, hv_Width, hv_Height, "nearest_neighbor",
    out hv_MsrHandle_Measure_01_0);
                if (hv_Sigma > 12)
                {
                    hv_Sigma = 12;
                }
                try
                {
                    //Sigma超范围会报异常
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure_01_0, hv_Sigma, hv_AmplitudeThreshold,
                        hv_Transition, "all", out hv_Row_Measure_01_0, out hv_Column_Measure_01_0,
                        out hv_Amplitude_Measure_01_0, out hv_Distance_Measure_01_0);
                    //Sigma超范围会报异常
                }
                catch (Exception)
                {
                    hv_Row_Measure_01_0 = null;
                    hv_Column_Measure_01_0 = null;
                    hv_Amplitude_Measure_01_0 = 0;
                    hv_Distance_Measure_01_0 = 0;
                }
                HOperatorSet.CloseMeasure(hv_MsrHandle_Measure_01_0);
            }
            catch (Exception)
            {
                hv_Row_Measure_01_0 = null;
                hv_Column_Measure_01_0 = null;
                hv_Amplitude_Measure_01_0 = 0;
                hv_Distance_Measure_01_0 = 0;
            }
            if (hv_Row_Measure_01_0 != null && hv_Row_Measure_01_0.Length != 0)
            {
                resultPoint.hv_Column = hv_Column_Measure_01_0[0];
                resultPoint.hv_Row = hv_Row_Measure_01_0[0];
            }
            else
            {
                resultPoint.hv_Column = 0;
                resultPoint.hv_Row = 0;
            }
            return resultPoint;
        }

        /// <summary>
        /// 根据点得到线
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Line getLine_FromPoint(HObject ho_Image, Measure_Pos parameters)
        {
            Line resultLine = new Line();
            Point point = new Point();
            point = getPoint(ho_Image, parameters);
            if (point.hv_Row == null)
            {
                resultLine.hv_Column1 = 0;
                resultLine.hv_Row1 = 0;
                resultLine.hv_Column2 = 0;
                resultLine.hv_Row2 = 0;
            }
            else
            {
                {
                    //根据一个点，一个弧度，一个长度，得一条线段使该线段长等于已知长度，该线段角度对应的弧度与已知弧度相差90°，已知点过该线段中点。
                    HTuple phi = Func_Mathematics.P1_P2_To_Phi(parameters.line.hv_Column1, parameters.line.hv_Row1, parameters.line.hv_Column2, parameters.line.hv_Row2);
                    Point P2 = Func_Mathematics.Phi_P1_Length_To_P2(phi, point, parameters.hv_RoiWidthLen2);
                    HTuple dCx, dRy;
                    dCx = P2.hv_Column - point.hv_Column;
                    dRy = P2.hv_Row - point.hv_Row;
                    resultLine.hv_Column1 = point.hv_Column + dCx;
                    resultLine.hv_Row1 = point.hv_Row + dRy;
                    resultLine.hv_Column2 = point.hv_Column - dCx;
                    resultLine.hv_Row2 = point.hv_Row - dRy;
                }
            }
            return resultLine;
        }

        public static Line getLine(HObject ho_Image, object parameters)
        {
            Line resuLtline = new Line();
            if (parameters is GLineUThresholdParas)
            {
                GLineUThresholdParas getLineParameters = parameters as GLineUThresholdParas;
                //创建ROI区域(增加了定位偏移量)
                HObject ho_ROI;
                HOperatorSet.GenRectangle1(out ho_ROI, getLineParameters.Rectangle1.hv_Row1 + getLineParameters.deltaPoint.hv_Row, getLineParameters.Rectangle1.hv_Column1 + getLineParameters.deltaPoint.hv_Column, getLineParameters.Rectangle1.hv_Row2 + getLineParameters.deltaPoint.hv_Row, getLineParameters.Rectangle1.hv_Column2 + getLineParameters.deltaPoint.hv_Column);
                //灰度处理选出最大面积
                HObject ho_SelectedRegions = Threshold_SelectMaxRegion(ho_Image, ho_ROI, getLineParameters.hv_MinGray, getLineParameters.hv_MaxGray);
                //通过选出的最大面积区域得出需要的线段
                resuLtline = getLine_FromRegion(ho_SelectedRegions, getLineParameters.TDLR, getLineParameters.b, getLineParameters.AngularPoint);
                ho_ROI.Dispose();
                ho_SelectedRegions.Dispose();
            }

            return resuLtline;
        }
        public static Line getLineDisplay(HObject ho_Image, HWindow_Final hWindow_Final, GLineUThresholdParas parameters)
        {
            Line resuLtline = new Line();

            if (parameters is GLineUThresholdParas)
            {
                GLineUThresholdParas getLineParameters = parameters as GLineUThresholdParas;
                //创建ROI区域(增加了定位偏移量)
                HObject ho_ROI;
                HOperatorSet.GenRectangle1(out ho_ROI, getLineParameters.Rectangle1.hv_Row1 + getLineParameters.deltaPoint.hv_Row, getLineParameters.Rectangle1.hv_Column1 + getLineParameters.deltaPoint.hv_Column, getLineParameters.Rectangle1.hv_Row2 + getLineParameters.deltaPoint.hv_Row, getLineParameters.Rectangle1.hv_Column2 + getLineParameters.deltaPoint.hv_Column);
                //灰度处理选出最大面积
                HObject ho_SelectedRegions = Threshold_SelectMaxRegion(ho_Image, ho_ROI, getLineParameters.hv_MinGray, getLineParameters.hv_MaxGray);
                //显示选出的最大面积区域
                hWindow_Final.DispObj(ho_SelectedRegions, "green", "fill");
                //通过选出的最大面积区域得出需要的线段
                resuLtline = getLine_FromRegion(ho_SelectedRegions, getLineParameters.TDLR, getLineParameters.b, getLineParameters.AngularPoint);
            }
            return resuLtline;
        }
        public static Circle getCircle(HObject ho_Image, List<Threshold> getCircleParametersList)
        {
            HObject ho_RegionUnion;
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            foreach (var item in getCircleParametersList)
            {
                //创建ROI区域
                HObject ho_ROI;
                HOperatorSet.GenRectangle2(out ho_ROI, item.rectangle2.hv_Row, item.rectangle2.hv_Column, item.rectangle2.hv_Phi, item.rectangle2.hv_Length1, item.rectangle2.hv_Length2);
                //灰度处理选出最大面积
                HObject ho_SelectedRegions = Threshold_SelectMaxRegion(ho_Image, ho_ROI, item.hv_MinGray, item.hv_MaxGray);
                //联合区域
                HOperatorSet.Union2(ho_RegionUnion, ho_SelectedRegions.Clone(), out ho_RegionUnion);
                ho_SelectedRegions.Dispose();
            }
            return getCircle_FromRegion(ho_RegionUnion);
        }
        public static Circle getCircleDisplay(HObject ho_Image, HWindow_Final hWindow_Final, List<Threshold> getCircleParametersList)
        {
            HObject ho_RegionUnion;
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            foreach (var item in getCircleParametersList)
            {
                //创建ROI区域
                HObject ho_ROI;
                HOperatorSet.GenRectangle2(out ho_ROI, item.rectangle2.hv_Row, item.rectangle2.hv_Column, item.rectangle2.hv_Phi, item.rectangle2.hv_Length1, item.rectangle2.hv_Length2);
                //灰度处理选出最大面积
                HObject ho_SelectedRegions = Threshold_SelectMaxRegion(ho_Image, ho_ROI, item.hv_MinGray, item.hv_MaxGray);
                //联合区域
                HOperatorSet.Union2(ho_RegionUnion, ho_SelectedRegions.Clone(), out ho_RegionUnion);
                ho_SelectedRegions.Dispose();
            }
            //显示选出的最大面积区域
            hWindow_Final.DispObj(ho_RegionUnion, "green", "fill");
            //计算出圆
            Circle resultCircle = getCircle_FromRegion(ho_RegionUnion);
            //释放资源
            ho_RegionUnion.Dispose();
            return resultCircle;
        }
    }

}//end of namespace
