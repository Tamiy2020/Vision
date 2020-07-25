using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class UFrm_Exist : Form
    {
        private HObject ho_Image;

        private Frm_Edit form;

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
        protected MeasuringUnit oldData;

        private MeasureManager measureManager;

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




        public UFrm_Exist(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public UFrm_Exist(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }




        private void UFrm_Exist_Load(object sender, EventArgs e)
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
                //编辑模式
                getRegionUseThreshold = data as GetRegionUseThreshold;
                nud_MaxGray.Value = trb_MaxGray.Value = getRegionUseThreshold.parameter.hv_MaxGray;
                nud_MinGray.Value = trb_MinGray.Value = getRegionUseThreshold.parameter.hv_MinGray;
                rdo_Exist.Checked = getRegionUseThreshold.Exist;
                rdo_ExistTwo.Checked = !getRegionUseThreshold.Exist;
                nud_MaxValue.Value = (decimal)getRegionUseThreshold.maxValue;
                nud_MinValue.Value = (decimal)getRegionUseThreshold.minValue;

                if (getRegionUseThreshold.position_Horizontal != null)
                {
                    cmb_HorizontalTracking.SelectedItem = getRegionUseThreshold.position_Horizontal.name;
                }



                if (getRegionUseThreshold.position_Vertical_L != null)
                {
                    cmb_VerticalTracking_L.SelectedItem = getRegionUseThreshold.position_Vertical_L.name;
                }

                txt_Name.Text = getRegionUseThreshold.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                prepared = true;
                RunOnce();
            }
            else
            {
                //非编辑模式
                getRegionUseThreshold = new GetRegionUseThreshold();
                data = getRegionUseThreshold;
            }
        }


        private void DrawMode(bool enable)
        {
            HOperatorSet.SetColor(hWindow_Final1.hWindowControl.HalconWindow, "blue");//设置显示颜色-蓝色
            hWindow_Final1.hWindowControl.Focus();//聚焦到窗口
            hWindow_Final1.DrawModel = enable;//禁止缩放平移
            splitContainer1.Panel2.Enabled = !enable;

        }

        //框选区域
        private void btn_SelectROI_Click(object sender, EventArgs e)
        {

            DrawMode(true);

            Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);
            getRegionUseThreshold.parameter.rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);

            DrawMode(false);
            prepared = true;
            RunOnce();
        }

        private void RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                data.Measure(ho_Image);
                data.DisplayDetail(hWindow_Final1);
                lbl_Area.Text = getRegionUseThreshold.hv_Area.D.ToString();
            }

        }

        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
        }

        private void nud_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MinGray.Value > nud_MinGray.Value)
            {
                nud_MaxGray.Value = nud_MinGray.Value;
                trb_MaxGray.Value = (int)nud_MaxGray.Value;
            }
            trb_MinGray.Value = (int)nud_MinGray.Value;
            getRegionUseThreshold.parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
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
            getRegionUseThreshold.parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
            RunOnce();
        }

        private void rdo_Exist_CheckedChanged(object sender, EventArgs e)
        {
            getRegionUseThreshold.Exist = (sender as RadioButton).Checked;
            RunOnce();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rdo_ExistTwo.Checked)
            {
                data.function = "缺陷检测";
            }
            if (rdo_Exist.Checked)
            {
                data.function = "产品有无";
            }
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
            //if (EditMode) data=oldData;//?编辑模式,恢复数据
            Close();
        }

        private void nud_MinValue_ValueChanged(object sender, EventArgs e)
        {
            getRegionUseThreshold.minValue = (double)nud_MinValue.Value;

        }

        private void nud_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            getRegionUseThreshold.maxValue = (double)nud_MaxValue.Value;
        }

        private void cmb_HorizontalTracking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                getRegionUseThreshold.position_Horizontal = horizontalPositions[cmb_HorizontalTracking.SelectedIndex] as BasePosition;
                getRegionUseThreshold.SetPosition();
                RunOnce();
            }
        }

        private void cmb_VerticalTracking_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                getRegionUseThreshold.position_Vertical_L = verticalPositions[cmb_VerticalTracking_L.SelectedIndex] as BasePosition;
                getRegionUseThreshold.SetPosition();
                RunOnce();
            }
        }

       
    }
}
