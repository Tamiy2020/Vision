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
using Vision.DataProcess.PositionLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_Line : Form
    {
        private HObject ho_Image;

        private Frm_Edit form;

        private MeasureManager measureManager;

        /// <summary>
        /// 线
        /// </summary>
        private Line line;

        /// <summary>
        /// 线类型标志
        /// </summary>
        private LineStyle sign;


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


        public Ufrm_Line(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Line(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }

        private void Ufrm_Line_Load(object sender, EventArgs e)
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


            //判断是否编辑模式进入
            if (EditMode)
            {
                line = data as Line;
                txt_Name.Text = data.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                if (data is GetLineUseThreshold)
                {

                    GetLineUseThreshold getLine = data as GetLineUseThreshold;

                    nud_MaxGray.Value = trb_MaxGray.Value = getLine.parameter.hv_MaxGray;
                    nud_MinGray.Value = trb_MinGray.Value = getLine.parameter.hv_MinGray;
                    nud_slg_b_pex.Value = (decimal)getLine.b.D;
                    if (2 == getLine.TPLR)
                    {
                        rdo_DownEdge.Checked = true;
                    }
                    if (3 == getLine.TPLR)
                    {
                        rdo_LeftEdge.Checked = true;
                    }
                    if (4 == getLine.TPLR)
                    {
                        rdo_RightEdge.Checked = true;
                    }
                    if (true == getLine.AngularPoint)
                    {
                        checkBox1.Checked = true;
                    }

                    if (getLine.position_Horizontal != null)
                    {
                        cmb_HorizontalTracking.SelectedItem = getLine.position_Horizontal.name;
                    }

                    if (getLine.position_Vertical_L != null)
                    {
                        cmb_VerticalTracking_L.SelectedItem = getLine.position_Vertical_L.name;
                    }



                    tabControl1.SelectedTab = tp_Threshold;
                    tabControl1.TabPages.Remove(tp_Canny);

                    tabControl1.TabPages.Remove(tp_Measure_Pos);

                    sign = LineStyle.灰度抓取;
                }
                else if (data is GetLineUseMeasure_Pos)
                {
                    GetLineUseMeasure_Pos getLine = data as GetLineUseMeasure_Pos;
                    trb_AmplitudeThreshold.Value = getLine.parameter.hv_AmplitudeThreshold;
                    nud_AmplitudeThreshold.Value = (decimal)getLine.parameter.hv_AmplitudeThreshold.D;
                    trb_Sigma.Value = getLine.parameter.hv_Sigma;
                    nud_Sigma.Value = (decimal)getLine.parameter.hv_Sigma.D;
                    trb_RoiWidthLen.Value = getLine.parameter.hv_RoiWidthLen2;
                    nud_RoiWidthLen.Value = (decimal)getLine.parameter.hv_RoiWidthLen2.D;
                    if (getLine.parameter.hv_Transition == "positive")
                    {
                        rdo_TranslationPositive.Checked = true;
                        rdo_TranslationNegative.Checked = false;
                    }
                    else
                    {
                        rdo_TranslationPositive.Checked = false;
                        rdo_TranslationNegative.Checked = true;
                    }
                    tabControl1.SelectedTab = tp_Measure_Pos;

                    tabControl1.TabPages.Remove(tp_Threshold);
                    tabControl1.TabPages.Remove(tp_Canny);

                    sign = LineStyle.边缘检测;
                }
                else if (data is GetLineUseCanny)
                {
                    GetLineUseCanny getLine = data as GetLineUseCanny;
                    nud_Alpha.Value = (decimal)getLine.parameter.hv_Alpha.D;
                    nud_High.Value = (decimal)getLine.parameter.hv_High.D;
                    nud_Low.Value = (decimal)getLine.parameter.hv_Low.D;
                    trb_High.Value = getLine.parameter.hv_High.I;
                    trb_Low.Value = getLine.parameter.hv_Low.I;
                    tabControl1.SelectedTab = tp_Canny;


                    if (getLine.position_Horizontal != null)
                    {
                        cmb_HorizontalTracking.SelectedItem = getLine.position_Horizontal.name;
                    }

                    if (getLine.position_Vertical_L != null)
                    {
                        cmb_VerticalTracking_L.SelectedItem = getLine.position_Vertical_L.name;
                    }






                    tabControl1.TabPages.Remove(tp_Threshold);
                    tabControl1.TabPages.Remove(tp_Measure_Pos);

                    sign = LineStyle.边缘拟合;
                }


                prepared = true;


            }

            else
            {
                line = new GetLineUseThreshold();
                data = line;
                sign = LineStyle.灰度抓取;

            }
            RunOnce();

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

        private void btn_Draw_Click(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);//刷新
            TabPage tabPage = tabControl1.SelectedTab;
            if (tabPage != null)
            {
                if (tabPage.Name == "tp_Threshold")
                {
                    if (!(line is GetLineUseThreshold))
                    {
                        line = new GetLineUseThreshold();
                        data = line;
                    }
                    if (chk_Angle.Checked)
                    {
                        DrawMode(true);//绘制模式开启
                        (line as GetLineUseThreshold).parameter.rectangle2 = Func_HalconFunction.DrawRectangle2(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
                        DrawMode(false);//绘制模式关闭
                    }
                    else
                    {
                        DrawMode(true);//绘制模式开启
                        Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
                        DrawMode(false);//绘制模式关闭
                        (line as GetLineUseThreshold).parameter.rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);//ROI矩形赋值
                    }
                    sign = LineStyle.灰度抓取;
                }
                if (tabPage.Name == "tp_Measure_Pos")
                {
                    if (!(line is GetLineUseMeasure_Pos))//？不是GetLineUseMeasure_Pos
                    {
                        line = new GetLineUseMeasure_Pos();
                        data = line;
                    }
                    DrawMode(true);//绘制模式开启
                    (line as GetLineUseMeasure_Pos).parameter.line.SetLine(Func_HalconFunction.DrawLine(hWindow_Final1.hWindowControl.HalconWindow));//画ROI线
                    DrawMode(false);//绘制模式关闭
                    if (!chk_Angle.Checked)
                    {
                        double dx = (line as GetLineUseMeasure_Pos).parameter.line.hv_Column1 - (line as GetLineUseMeasure_Pos).parameter.line.hv_Column2;
                        double dy = (line as GetLineUseMeasure_Pos).parameter.line.hv_Row1 - (line as GetLineUseMeasure_Pos).parameter.line.hv_Row2;
                        double mx = ((line as GetLineUseMeasure_Pos).parameter.line.hv_Column1 + (line as GetLineUseMeasure_Pos).parameter.line.hv_Column2) / 2;
                        double my = ((line as GetLineUseMeasure_Pos).parameter.line.hv_Row1 + (line as GetLineUseMeasure_Pos).parameter.line.hv_Row2) / 2;
                        if (Math.Abs(dx) > Math.Abs(dy))//？横向距离长
                        {
                            (line as GetLineUseMeasure_Pos).parameter.line.hv_Row1 = (int)my;
                            (line as GetLineUseMeasure_Pos).parameter.line.hv_Row2 = (int)my;
                        }
                        else//？纵向距离长
                        {
                            (line as GetLineUseMeasure_Pos).parameter.line.hv_Column1 = (int)mx;
                            (line as GetLineUseMeasure_Pos).parameter.line.hv_Column2 = (int)mx;
                        }
                    }
                    sign = LineStyle.边缘检测;


                }
                if (tabPage.Name == "tp_Canny")
                {
                    if (!(line is GetLineUseCanny))//？不是GetLineUseMeasure_Pos
                    {
                        line = new GetLineUseCanny();
                        data = line;
                    }
                    if (chk_Angle.Checked)
                    {
                        DrawMode(true);//绘制模式开启
                        (line as GetLineUseCanny).parameter.rectangle2 = Func_HalconFunction.DrawRectangle2(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
                        DrawMode(false);//绘制模式关闭
                    }
                    else
                    {
                        DrawMode(true);//绘制模式开启
                        Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
                        DrawMode(false);//绘制模式关闭
                        (line as GetLineUseCanny).parameter.rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);//ROI矩形赋值
                    }
                    sign = LineStyle.边缘拟合;
                }
                // PositionAssigment();//跟踪赋值
                // SetShapeInvert();
                prepared = true;
                RunOnce();
            }
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

        // 最小灰度滑条
        private void trb_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MinGray.Value > trb_MaxGray.Value)
            {
                trb_MaxGray.Value = trb_MinGray.Value;
                nud_MaxGray.Value = trb_MaxGray.Value;
            }
            nud_MinGray.Value = trb_MinGray.Value;
        }

        //最小灰度数字
        private void nud_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                if (nud_MinGray.Value > nud_MinGray.Value)
                {
                    nud_MaxGray.Value = nud_MinGray.Value;
                    trb_MaxGray.Value = (int)nud_MaxGray.Value;
                }
                trb_MinGray.Value = (int)nud_MinGray.Value;
                (line as GetLineUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        // 最大灰度滑条
        private void trb_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MaxGray.Value < trb_MinGray.Value)
            {
                trb_MinGray.Value = trb_MaxGray.Value;
                nud_MinGray.Value = trb_MinGray.Value;
            }
            nud_MaxGray.Value = trb_MaxGray.Value;
        }

        //最大灰度数字
        private void nud_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                if (nud_MaxGray.Value < nud_MinGray.Value)
                {
                    nud_MinGray.Value = nud_MaxGray.Value;
                    trb_MinGray.Value = (int)nud_MinGray.Value;
                }
                trb_MaxGray.Value = (int)nud_MaxGray.Value;
                (line as GetLineUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        //上
        private void rdo_UpEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                (line as GetLineUseThreshold).TPLR = 1;
                RunOnce();//运行测试
            }

        }

        //下
        private void rdo_DownEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                (line as GetLineUseThreshold).TPLR = 2;
                RunOnce();//运行测试
            }
        }

        //左
        private void rdo_LeftEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                (line as GetLineUseThreshold).TPLR = 3;
                RunOnce();//运行测试
            }
        }

        //右
        private void rdo_RightEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                (line as GetLineUseThreshold).TPLR = 4;
                RunOnce();//运行测试
            }
        }

        //角点功能
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                if (checkBox1.Checked)
                {
                    (line as GetLineUseThreshold).AngularPoint = true;
                }
                else
                {
                    (line as GetLineUseThreshold).AngularPoint = false;
                }
                RunOnce();//运行测试
            }
        }

        //最小边缘幅度滑条
        private void trb_AmplitudeThreshold_Scroll(object sender, EventArgs e)
        {
            nud_AmplitudeThreshold.Value = trb_AmplitudeThreshold.Value;
        }

        //最小边缘幅度数字
        private void nud_AmplitudeThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘检测)
            {
                trb_AmplitudeThreshold.Value = (int)nud_AmplitudeThreshold.Value;
                (line as GetLineUseMeasure_Pos).parameter.hv_AmplitudeThreshold = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        //平滑滑条
        private void trb_Sigma_Scroll(object sender, EventArgs e)
        {
            nud_Sigma.Value = trb_Sigma.Value;
        }

        //平滑数字
        private void nud_Sigma_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘检测)
            {
                trb_Sigma.Value = (int)nud_Sigma.Value;
                (line as GetLineUseMeasure_Pos).parameter.hv_Sigma = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        // ROI宽滑条
        private void trb_RoiWidthLen_Scroll(object sender, EventArgs e)
        {
            nud_RoiWidthLen.Value = trb_RoiWidthLen.Value;
        }

        // ROI宽数字
        private void nud_RoiWidthLen_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘检测)
            {
                trb_RoiWidthLen.Value = (int)nud_RoiWidthLen.Value;
                (line as GetLineUseMeasure_Pos).parameter.hv_RoiWidthLen2 = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        // 由黑到白
        private void rdo_TranslationPositive_CheckedChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘检测)
            {
                if ((sender as RadioButton).Checked)
                {
                    (line as GetLineUseMeasure_Pos).parameter.hv_Transition = "positive";
                }
                else
                {
                    (line as GetLineUseMeasure_Pos).parameter.hv_Transition = "negative";
                }
                RunOnce();//运行测试
            }
        }

        // Low滑条
        private void trb_Low_Scroll(object sender, EventArgs e)
        {
            if (trb_Low.Value > trb_High.Value)
            {
                trb_High.Value = trb_Low.Value;
                nud_High.Value = trb_High.Value;
            }
            nud_Low.Value = trb_Low.Value;
        }

        // Low数字
        private void nud_Low_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘拟合)
            {
                if (nud_Low.Value > nud_Low.Value)
                {
                    nud_High.Value = nud_Low.Value;
                    trb_High.Value = (int)nud_High.Value;
                }
                trb_Low.Value = (int)nud_Low.Value;
                (line as GetLineUseCanny).parameter.hv_Low = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        //High滑条
        private void trb_High_Scroll(object sender, EventArgs e)
        {
            if (trb_Low.Value > trb_High.Value)
            {
                trb_Low.Value = trb_High.Value;
                nud_Low.Value = trb_Low.Value;
            }
            nud_High.Value = trb_High.Value;
        }

        //High数字
        private void nud_High_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘拟合)
            {
                if (nud_High.Value < nud_Low.Value)
                {
                    nud_Low.Value = nud_High.Value;
                    trb_Low.Value = (int)nud_Low.Value;
                }
                trb_High.Value = (int)nud_High.Value;
                (line as GetLineUseCanny).parameter.hv_High = (int)(sender as NumericUpDown).Value;
                RunOnce();//运行测试
            }
        }

        //Alpha数字
        private void nud_Alpha_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.边缘拟合)
                (line as GetLineUseCanny).parameter.hv_Alpha = (double)(sender as NumericUpDown).Value;
        }


        //确定
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

        //取消
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
                (data as BaseShape).SetPosition();
                RunOnce();


            }
        }

        private void cmb_VerticalTracking_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                (data as BaseShape).position_Vertical_L = verticalPositions[cmb_VerticalTracking_L.SelectedIndex] as BasePosition;
                (data as BaseShape).SetPosition();
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

        private void nud_slg_b_pex_ValueChanged(object sender, EventArgs e)
        {
            if (sign == LineStyle.灰度抓取)
            {
                (line as GetLineUseThreshold).b = (double)nud_slg_b_pex.Value;
                RunOnce();//运行测试
            }
        }
    }
}
