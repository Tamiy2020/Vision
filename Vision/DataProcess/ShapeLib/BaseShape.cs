using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using Vision.DataProcess.PositionLib;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 形状类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public abstract class BaseShape : MeasuringUnit//点，线，圆，矩形等形状类的基类
    {
        /// <summary>
        /// 水平定位
        /// </summary>
        protected internal BasePosition position_Horizontal;

        /// <summary>
        /// 垂直定位左
        /// </summary>
        protected internal BasePosition position_Vertical_L;

        /// <summary>
        /// 垂直定位右
        /// </summary>
        protected internal BasePosition position_Vertical_R;

        /// <summary>
        /// 水平变换矩阵
        /// </summary>
        protected internal HTuple hv_HomMat2DTranslat_H;

        /// <summary>
        /// 垂直变换矩阵左
        /// </summary>
        protected internal HTuple hv_HomMat2DTranslate_VL;

        /// <summary>
        /// 垂直变换矩阵右
        /// </summary>
        protected internal HTuple hv_HomMat2DTranslate_VR;



        /// <summary>
        /// 逆变矩阵
        /// </summary>
        protected internal HTuple hv_HomMat2DInvert;

        /// <summary>
        /// 形状颜色
        /// </summary>
        public string shapeColor;

        /// <summary>
        /// 形状对象
        /// </summary>
        [NonSerialized]//不序列化该字段
        protected HObject ho_Shape;

        public BaseShape()//构造函数
        {
            shapeColor = "blue";
            HOperatorSet.GenEmptyObj(out ho_Shape);//ho_Shape赋空值
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public virtual void SetPosition() { }

        /// <summary>
        /// 计算出变换矩阵
        /// </summary>
        public void GetHomMat2D()
        {
            HOperatorSet.HomMat2dIdentity(out HTuple hv_HomMat2D);//创建单位矩阵


            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DTranslat_H);
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DTranslate_VL);
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DTranslate_VR);



            HOperatorSet.HomMat2dIdentity(out  hv_HomMat2DInvert);
            if (position_Horizontal != null)
            {
                HOperatorSet.HomMat2dCompose(hv_HomMat2D, position_Horizontal.hv_HomMat2DTranslate, out hv_HomMat2DTranslat_H);//矩阵相乘


                HOperatorSet.HomMat2dCompose(hv_HomMat2D, position_Horizontal.hv_HomMat2DInvert, out hv_HomMat2DInvert);
            }
            if (position_Vertical_L !=null )
            {
                HOperatorSet.HomMat2dCompose(hv_HomMat2D, position_Vertical_L.hv_HomMat2DTranslate, out hv_HomMat2DTranslate_VL);
            }
            if (position_Vertical_R != null)
            {
                HOperatorSet.HomMat2dCompose(hv_HomMat2D, position_Vertical_R.hv_HomMat2DTranslate, out hv_HomMat2DTranslate_VR);
            }
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public virtual BaseShape GetShapeInvert()
        {
            GetHomMat2D();
            return null;
        }

        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public virtual BaseShape GetShapeReset()
        {
            return null;
        }

        /// <summary>
        /// 获取定位后的实例
        /// </summary>
        /// <returns></returns>
        public abstract BaseShape GetShapePositioned();

        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);
            Dispose();
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            window.DispObj(ho_Shape, shapeColor);//显示当前形状
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            window.DispObj(ho_Shape, shapeColor);//显示当前形状
        }

        public override void Dispose()//释放资源
        {
            if (ho_Shape != null) ho_Shape.Dispose();//释放ho_Shape资源
        }

    }
}
