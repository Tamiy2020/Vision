using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DataProcess;
using Vision.DataProcess.ParameterLib;
using Vision.DataProcess.PositionLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_Circle : Form
    {
        private HObject ho_Image;

        private Frm_Edit form;

        private MeasureManager measureManager;

        /// <summary>
        /// 圆单元
        /// </summary>
        private Circle circle;

        /// <summary>
        /// 抓圆测单元
        /// </summary>
        private GetCircleUseThreshold getCircleUseThreshold;

        /// <summary>
        /// 灰度区域检测单元
        /// </summary>
        private GetRegionUseThreshold getRegionUseThreshold;



        /// <summary>
        /// 测量单元
        /// </summary>
        private MeasuringUnit data;

        /// <summary>
        /// 旧测量单元
        /// </summary>
        private MeasuringUnit oldData;

        /// <summary>
        /// 可以执行测量方法的标志
        /// </summary>
        private bool prepared;

        /// <summary>
        /// 编辑模式
        /// </summary>
        public bool EditMode { get; }


        /// <summary>
        /// 垂直定位列队
        /// </summary>
        private List<MeasuringUnit> verticalPositions;

        /// <summary>
        /// 水平定位列队
        /// </summary>
        private List<MeasuringUnit> horizontalPositions;



        public Ufrm_Circle(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Circle(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }

        private void DrawMode(bool enable)
        {
            HOperatorSet.SetColor(hWindow_Final1.hWindowControl.HalconWindow, "blue");//设置显示颜色-蓝色
            hWindow_Final1.hWindowControl.Focus();//聚焦到窗口
            hWindow_Final1.DrawModel = enable;//禁止缩放平移
            splitContainer1.Panel2.Enabled = !enable;

        }

        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
        }

        private void RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                data.Measure(ho_Image);
                data.DisplayDetail(hWindow_Final1);
            }

        }


        private void Ufrm_Circle_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            List<MeasuringUnit> translations = measureManager.ListAllTranslation();//所有平移跟踪

            verticalPositions = new List<MeasuringUnit>();
            horizontalPositions = new List<MeasuringUnit>();
            for (int i = translations.Count - 1; i >= 0; i--)
            {


                if ((translations[i] as TranslationTracking).line.AxByC0.k == null)
                {
                    horizontalPositions.Add(translations[i]);
                    cmb_HorizontalTracking.Items.Add(translations[i].name);
                }

                else if ((translations[i] as TranslationTracking).line.AxByC0.k.D == 0)//？是水平线
                {
                    verticalPositions.Add(translations[i]);//添加垂直定位
                    cmb_VerticalTracking_L.Items.Add(translations[i].name);//添加垂直跟踪

                }
            }

            if (EditMode)//编辑模式
            {
                txt_Name.Text = data.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字

                if (data is GetCircleUseThreshold)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    getCircleUseThreshold = data as GetCircleUseThreshold;
                   // nud_MaxGray.Value = trb_MaxGray.Value = (getCircleUseThreshold.RegionList[0] as GetRegionUseThreshold).parameter.hv_MaxGray;
                    //nud_MinGray.Value = trb_MinGray.Value = (getCircleUseThreshold.RegionList[0] as GetRegionUseThreshold).parameter.hv_MinGray;
                    tabControl1.SelectedTab = tabPage2;


                    cmb_slg_SelectItem.Items.AddRange(getCircleUseThreshold.GetRegionsName());//添加combobox项
                }
                else
                {
                    circle = data as Circle;
                    nud_Circle_x.Value = (decimal)circle.hv_Column.D;
                    nud_Circle_y.Value = (decimal)circle.hv_Row.D;
                    nud_Radius.Value = (decimal)circle.hv_Radius.D;

                    if (circle.position_Horizontal != null)
                    {
                        cmb_HorizontalTracking.SelectedItem = circle.position_Horizontal.name;
                    }

                    if (circle.position_Vertical_L != null)
                    {
                        cmb_VerticalTracking_L.SelectedItem = circle.position_Vertical_L.name;
                    }


                    tabControl1.SelectedTab = tabPage1;
                    tabControl1.TabPages.Remove(tabPage2);
                }
                prepared = true;
            }
            else
            {
                circle = new Circle();
                data = circle;
            }
            RunOnce();


        }

        //画圆
        private void btn_DrawCircle_Click(object sender, EventArgs e)
        {
            if (circle == null)
            {
                circle = new Circle();
                data = circle;
            }

            hWindow_Final1.HobjectToHimage(ho_Image);//刷新显示区
            DrawMode(true);//绘制模式开启
            circle.SetCircle(Func_HalconFunction.DrawCircle(hWindow_Final1.hWindowControl.HalconWindow));//画圆编辑模式
            DrawMode(false);//绘制模式关闭

            getCircleUseThreshold = null;
            nud_Circle_x.Value = (decimal)circle.hv_Column.D;//赋值
            nud_Circle_y.Value = (decimal)circle.hv_Row.D;//赋值
            nud_Radius.Value = (decimal)circle.hv_Radius.D;//赋值
           // PositionAssigment();//跟踪赋值
           // SetShapeInvert();
            prepared = true;//可以运行
            RunOnce();//运行一次
        }

        //半径
        private void nud_Radius_ValueChanged(object sender, EventArgs e)
        {
            circle.hv_Radius = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }

        //圆心x
        private void nud_Circle_x_ValueChanged(object sender, EventArgs e)
        {
            circle.hv_Column = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }

        //圆心y
        private void nud_Circle_y_ValueChanged(object sender, EventArgs e)
        {
            circle.hv_Row = (double)(sender as NumericUpDown).Value;
            RunOnce();

        }

        //框选区域
        private void btn_DrawROIs_Click(object sender, EventArgs e)
        {
            if (getCircleUseThreshold == null)
            {
                getCircleUseThreshold = new GetCircleUseThreshold();
                data = getCircleUseThreshold;
                circle = null;
            }
            getCircleUseThreshold.RemoveAll();//删除所有项
            hWindow_Final1.HobjectToHimage(ho_Image);//刷新图片
            hWindow_Final1.ContextMenuStrip = contextMenuStrip1;//启用右键菜单
            DrawMode(true);//绘制模式开启
            Rectangle2 rectangle2 = Func_HalconFunction.DrawRectangle2(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
            DrawMode(false);//绘制模式关闭
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle2(rectangle2);//创建矩形
            hWindow_Final1.DispObj(ho_Rectangle, "blue");//显示矩形
            getCircleUseThreshold.AddRegion(new GetRegionUseThreshold(new Threshold(rectangle2)));//添加该项
        }

        //下一个
        private void tsmi_Next_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启
            Rectangle2 rectangle2 = Func_HalconFunction.DrawRectangle2(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
            DrawMode(false);//绘制模式关闭
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle2(rectangle2);//创建矩形
            hWindow_Final1.DispObj(ho_Rectangle, "blue");//显示矩形
            getCircleUseThreshold.AddRegion(new GetRegionUseThreshold(new Threshold(rectangle2)));//添加该项
        }

        //完成
        private void tsmi_Done_Click(object sender, EventArgs e)
        {
            hWindow_Final1.ContextMenuStrip = null;//禁用右键菜单
            cmb_slg_SelectItem.Items.Clear();//清空cmbobox
            cmb_slg_SelectItem.Items.AddRange(getCircleUseThreshold.GetRegionsName());//添加combobox项
            //cmb_slg_SelectItem.SelectedIndex = 0;
            prepared = true;
            RunOnce();//运行测试
        }

        //取消
        private void tsmi_Cancel_Click(object sender, EventArgs e)
        {

            hWindow_Final1.ContextMenuStrip = null;//禁用右键菜单
            RunOnce();//运行测试
        }

        //整体最小灰度滑条
        private void trb_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MinGray.Value > trb_MaxGray.Value)
            {
                trb_MaxGray.Value = trb_MinGray.Value;
                nud_MaxGray.Value = trb_MaxGray.Value;
            }
            nud_MinGray.Value = trb_MinGray.Value;
        }

        //整体最小灰度数字
        private void nud_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MinGray.Value > nud_MinGray.Value)
            {
                nud_MaxGray.Value = nud_MinGray.Value;
                trb_MaxGray.Value = (int)nud_MaxGray.Value;
            }
            trb_MinGray.Value = (int)nud_MinGray.Value;
            if (getCircleUseThreshold != null)
            {
                for (int i = 0; i < getCircleUseThreshold.RegionList.Count; i++)
                {
                    (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
                    if ((getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MinGray > (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MaxGray)
                        (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;

                }
            }

            RunOnce();//运行测试
        }

        //整体最大灰度滑条
        private void trb_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MaxGray.Value < trb_MinGray.Value)
            {
                trb_MinGray.Value = trb_MaxGray.Value;
                nud_MinGray.Value = trb_MinGray.Value;
            }
            nud_MaxGray.Value = trb_MaxGray.Value;
        }

        //整体最大灰度数字
        private void nud_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MaxGray.Value < nud_MinGray.Value)
            {
                nud_MinGray.Value = nud_MaxGray.Value;
                trb_MinGray.Value = (int)nud_MinGray.Value;
            }
            trb_MaxGray.Value = (int)nud_MaxGray.Value;
            if (getCircleUseThreshold != null)
            {
                for (int i = 0; i < getCircleUseThreshold.RegionList.Count; i++)
                {
                    (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
                    if ((getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MinGray > (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MaxGray)
                        (getCircleUseThreshold.RegionList[i] as GetRegionUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;

                }
            }
            RunOnce();//运行测试
        }

        //选择单项
        private void cmb_slg_SelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_slg_SelectItem.SelectedItem == null)
            {
                btn_slg_ReDrowROI.Enabled = false;

                return;
            }
            if (getCircleUseThreshold != null)
            {
                getRegionUseThreshold = getCircleUseThreshold.GetRegion(Convert.ToInt32(cmb_slg_SelectItem.SelectedItem.ToString()) - 1) as GetRegionUseThreshold;
            }
            trb_slg_MaxGray.Value = getRegionUseThreshold.parameter.hv_MaxGray.I;
            trb_slg_MinGray.Value = getRegionUseThreshold.parameter.hv_MinGray.I;
            nud_slg_MaxGray.Value = getRegionUseThreshold.parameter.hv_MaxGray.I;
            nud_slg_MinGray.Value = getRegionUseThreshold.parameter.hv_MinGray.I;
            btn_slg_ReDrowROI.Enabled = true;
        }

        //重画
        private void btn_slg_ReDrowROI_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启
            getRegionUseThreshold.parameter.rectangle2 = Func_HalconFunction.DrawRectangle2Mod(hWindow_Final1.hWindowControl.HalconWindow, getRegionUseThreshold.parameter.rectangle2);
            DrawMode(false);//绘制模式关闭
            RunOnce();//运行测试
        }

        //单项最小灰度滑条
        private void trb_slg_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_slg_MinGray.Value > trb_slg_MaxGray.Value)
            {
                trb_slg_MaxGray.Value = trb_slg_MinGray.Value;
                nud_slg_MaxGray.Value = trb_slg_MaxGray.Value;
            }
            nud_slg_MinGray.Value = trb_slg_MinGray.Value;
        }

        //单项最小灰度数字
        private void nud_slg_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_slg_MinGray.Value > nud_slg_MinGray.Value)
            {
                nud_slg_MaxGray.Value = nud_slg_MinGray.Value;
                trb_slg_MaxGray.Value = (int)nud_slg_MaxGray.Value;
            }
            trb_slg_MinGray.Value = (int)nud_slg_MinGray.Value;
            if (getRegionUseThreshold != null)
            {
                getRegionUseThreshold.parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
            }

            RunOnce();//运行测试
        }

        //单项最大灰度滑条
        private void trb_slg_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_slg_MaxGray.Value < trb_slg_MinGray.Value)
            {
                trb_slg_MinGray.Value = trb_slg_MaxGray.Value;
                nud_slg_MinGray.Value = trb_slg_MinGray.Value;
            }
            nud_slg_MaxGray.Value = trb_slg_MaxGray.Value;
        }

        //单项最大灰度数字
        private void nud_slg_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_slg_MaxGray.Value < nud_slg_MinGray.Value)
            {
                nud_slg_MinGray.Value = nud_slg_MaxGray.Value;
                trb_slg_MinGray.Value = (int)nud_slg_MinGray.Value;
            }
            trb_slg_MaxGray.Value = (int)nud_slg_MaxGray.Value;
            if (getRegionUseThreshold != null) getRegionUseThreshold.parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
            RunOnce();//运行测试
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!EditMode)//非编辑模式
            {
                if (txt_Name.Text.Trim() == "无")
                {
                    MessageBox.Show("名字不能命名为无！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Name.Focus();
                    return;
                }
                if (txt_Name.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("名字不能为空，请您输入名字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Name.Focus();
                    return;
                }
                foreach (var item in measureManager.GetMeasuringUnitListName())
                {
                    if (item == txt_Name.Text.Trim())
                    {
                        MessageBox.Show("您输入的名字与其它测量项重复，请重新输入名字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Name.Focus();
                        return;
                    }
                }
            }

            FinalAssessment();
            string result;
            if (EditMode)//编辑模式
            {
                //改--
                result = measureManager.ModifyMeasuringUnit(data);
                if (result == null)
                {
                    //修改成功，关闭窗口                   
                    Close();
                    return;
                }
                //修改失败
                MessageBox.Show(result);
                return;
            }
            //增--
            measureManager.AddMeasuringUnit(data);
            //添加成功，关闭窗口
            Close();
            return;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
           // if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }

        private void cmb_HorizontalTracking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {


                (data as BaseShape).position_Horizontal = horizontalPositions[cmb_HorizontalTracking.SelectedIndex] as BasePosition;
              //  (data as BaseShape).SetPosition();
                RunOnce();


            }
        }

        private void cmb_VerticalTracking_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                (data as BaseShape).position_Vertical_L = verticalPositions[cmb_VerticalTracking_L.SelectedIndex] as BasePosition;
             //   (data as BaseShape).SetPosition();
                RunOnce();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
    }
}
