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
    public partial class Ufrm_Position : Form
    {
        private HObject ho_Image;

        private Frm_Edit form;

        private MeasureManager measureManager;

     

        /// <summary>
        /// 跟踪定位单元
        /// </summary>
        private TranslationTracking transformation;


        /// <summary>
        /// 测量单元
        /// </summary>
        private MeasuringUnit data;

        /// <summary>
        /// 旧测量单元
        /// </summary>
        protected MeasuringUnit oldData;


        /// <summary>
        /// 可以执行测量方法的标志
        /// </summary>
        private bool prepared;

        /// <summary>
        /// 编辑模式
        /// </summary>
        public bool EditMode { get; }


        public Ufrm_Position(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Position(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }

        private void Ufrm_Position_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            if (EditMode)
            {
                prepared = true;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                transformation = data as TranslationTracking;
                transformation.line = (data as TranslationTracking).line;

                /*  nud_MaxGray.Value = trb_MaxGray.Value = getRegionUseThreshold.parameter.hv_MaxGray;
                  nud_MinGray.Value = trb_MinGray.Value = getRegionUseThreshold.parameter.hv_MinGray;*/

                nud_MaxGray.Value = trb_MaxGray.Value = (transformation.line as GetLineUseThreshold).parameter.hv_MaxGray;
                nud_MinGray.Value = trb_MinGray.Value = (transformation.line as GetLineUseThreshold).parameter.hv_MinGray;
              
                if (2 == (transformation.line as GetLineUseThreshold).TPLR)
                {
                    rdo_DownEdge.Checked = true;
                }
                if (3 == (transformation.line as GetLineUseThreshold).TPLR)
                {
                    rdo_LeftEdge.Checked = true;
                }
                if (4 == (transformation.line as GetLineUseThreshold).TPLR)
                {
                    rdo_RightEdge.Checked = true;
                }

            }
            else
            {
                transformation = new TranslationTracking();
                data = transformation;
                transformation.line = new GetLineUseThreshold();

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

        private void RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                transformation.line.Measure(ho_Image);
                transformation.line.DisplayDetail(hWindow_Final1);
            }

        }

        private void btn_SelectROI_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启
            Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
            DrawMode(false);//绘制模式关闭
            (transformation.line as GetLineUseThreshold).parameter.rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);//ROI矩形赋值

            prepared = true;
            RunOnce();
        }

        private void trb_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MinGray.Value > trb_MaxGray.Value)
            {
                trb_MaxGray.Value = trb_MinGray.Value;
                nud_MaxGray.Value = trb_MaxGray.Value;
            }
            nud_MinGray.Value = trb_MinGray.Value;
        }

        private void nud_MinGray_ValueChanged(object sender, EventArgs e)
        {


            if (nud_MinGray.Value > nud_MinGray.Value)
            {
                nud_MaxGray.Value = nud_MinGray.Value;
                trb_MaxGray.Value = (int)nud_MaxGray.Value;
            }
            trb_MinGray.Value = (int)nud_MinGray.Value;
            (transformation.line as GetLineUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
            RunOnce();//运行测试

        }

        private void trb_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MaxGray.Value < trb_MinGray.Value)
            {
                trb_MinGray.Value = trb_MaxGray.Value;
                nud_MinGray.Value = trb_MinGray.Value;
            }
            nud_MaxGray.Value = trb_MaxGray.Value;
        }

        private void nud_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MaxGray.Value < nud_MinGray.Value)
            {
                nud_MinGray.Value = nud_MaxGray.Value;
                trb_MinGray.Value = (int)nud_MinGray.Value;
            }
            trb_MaxGray.Value = (int)nud_MaxGray.Value;
            (transformation.line as GetLineUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
            RunOnce();//运行测试
        }

        private void rdo_UpEdge_CheckedChanged(object sender, EventArgs e)
        {
            (transformation.line as GetLineUseThreshold).TPLR = 1;
            RunOnce();//运行测试
        }

        private void rdo_DownEdge_CheckedChanged(object sender, EventArgs e)
        {
            (transformation.line as GetLineUseThreshold).TPLR = 2;
            RunOnce();//运行测试
        }

        private void rdo_LeftEdge_CheckedChanged(object sender, EventArgs e)
        {
            (transformation.line as GetLineUseThreshold).TPLR = 3;
            RunOnce();//运行测试
        }

        private void rdo_RightEdge_CheckedChanged(object sender, EventArgs e)
        {
            (transformation.line as GetLineUseThreshold).TPLR = 4;
            RunOnce();//运行测试
        }





        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
            transformation.oldLline.SetLine(transformation.line);
            if (transformation.line.AxByC0.k == null)//？是垂直线
            {
                data.function = "水平定位";
            }
            else if (transformation.line.AxByC0.k.D == 0)//？是水平线
            {
                data.function = "垂直定位";
            }
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!EditMode)//非编辑模式
            {
                if (txt_Name.Text.Trim() == "线" || txt_Name.Text.Trim() == "多边" || txt_Name.Text.Trim() == "圆" || txt_Name.Text.Trim() == "有无" || txt_Name.Text.Trim() == "单项计算" || txt_Name.Text.Trim() == "多边计算" || txt_Name.Text.Trim() == "角度" || txt_Name.Text.Trim() == "半径" || txt_Name.Text.Trim() == "定位" || txt_Name.Text.Trim() == "定位线" || txt_Name.Text.Trim() == "点")
                {
                    MessageBox.Show("名字不能为默认名称，请您重新输入名字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }
    }
}
