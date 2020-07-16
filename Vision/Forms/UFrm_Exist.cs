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
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class UFrm_Exist : Form
    {
       private  HObject ho_Image;

        private Frm_Edit form;

        /// <summary>
        /// 灰度区域检测单元
        /// </summary>
        private GetRegionUseThreshold getRegionUseThreshold;

        /// <summary>
        /// 测量单元
        /// </summary>
        private  MeasuringUnit data;

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
        /// 执行运行一次方法事件
        /// </summary>
        public event Func<int, int> OnRunOnce;

        public UFrm_Exist(Frm_Edit form,HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public UFrm_Exist(Frm_Edit form,HObject ho_Image, MeasuringUnit data)//编辑模式
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
            if (measureManager==null)
            {
                measureManager = form.measureManager;
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
            getRegionUseThreshold.minValue = (double)nud_MinValue.Value;
            getRegionUseThreshold.maxValue = (double)nud_MaxValue.Value;
            DrawMode(true);

            Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);
            getRegionUseThreshold.parameter.rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);

            DrawMode(false);
            prepared = true;
            RunOnce();
        }

        private void  RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                data .Measure(ho_Image);
                data .DisplayDetail(hWindow_Final1);
                lbl_Area .Text= getRegionUseThreshold.hv_Area.D.ToString();
                if (OnRunOnce != null) OnRunOnce.Invoke(0);

            }

        }

        public virtual void FinalAssessment()
        {
            getRegionUseThreshold.name = (txt_Name.Text).Trim();
            getRegionUseThreshold.formType = GetType();
            getRegionUseThreshold.minValue = (double)nud_MinValue.Value;
            getRegionUseThreshold.maxValue = (double)nud_MaxValue.Value;
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

        private void UFrm_Exist_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
