using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vision.DataProcess;
using Vision.DataProcess.PositionLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_DatumLine : Form
    {
        /// <summary>
        /// 图像
        /// </summary>
        private HObject ho_Image;

        /// <summary>
        /// 编辑窗体
        /// </summary>
        private Frm_Edit form;

        /// <summary>
        /// 测量单元管理器
        /// </summary>
        private MeasureManager measureManager;

        /// <summary>
        /// 线
        /// </summary>
        private Line line;

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

        /// <summary>
        /// 垂直定位列队
        /// </summary>
        private List<MeasuringUnit> verticalPositions;

        public Ufrm_DatumLine(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_DatumLine(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;

        }

        /// <summary>
        /// 绘制模式
        /// </summary>
        /// <param name="enable"></param>
        private void DrawMode(bool enable)
        {
            HOperatorSet.SetColor(hWindow_Final1.hWindowControl.HalconWindow, "blue");//设置显示颜色-蓝色
            hWindow_Final1.hWindowControl.Focus();//聚焦到窗口
            hWindow_Final1.DrawModel = enable;//禁止缩放平移
            splitContainer1.Panel2.Enabled = !enable;
        }

        /// <summary>
        /// 数据赋值
        /// </summary>
        private void FinalAssessment()
        {
            data.function = "基准线";
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
        }

        /// <summary>
        /// 运行测试
        /// </summary>
        private void RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                data.Measure(ho_Image);
                data.DisplayDetail(hWindow_Final1);
            }

        }

        #region 窗体加载时
        private void Ufrm_DatumLine_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            #region 跟踪
            List<MeasuringUnit> translations = measureManager.ListAllTranslation();//所有平移跟踪

            verticalPositions = new List<MeasuringUnit>();
            for (int i = translations.Count - 1; i >= 0; i--)
            {


                if ((translations[i] as TranslationTracking).line.AxByC0.k == null)
                {
                    continue;
                }

                if ((translations[i] as TranslationTracking).line.AxByC0.k.D == 0)//？是水平线
                {
                    verticalPositions.Add(translations[i]);//添加垂直定位
                    cmb_VerticalTracking_L.Items.Add(translations[i].name);//添加垂直跟踪
                    cmb_VerticalTracking_R.Items.Add(translations[i].name);//添加垂直跟踪

                }
            }
            #endregion

            //判断是否编辑模式进入
            if (EditMode)
            {
                line = data as Line;
                nud_xStart.Value = (decimal)line.hv_Column1.D;
                nud_yStart.Value = (decimal)line.hv_Row1.D;
                nud_xEnd.Value = (decimal)line.hv_Column2.D;
                nud_yEnd.Value = (decimal)line.hv_Row2.D;

                if (line.position_Vertical_L != null)
                {
                    cmb_VerticalTracking_L.SelectedItem = line.position_Vertical_L.name;
                }

                if (line.position_Vertical_R != null)
                {
                    cmb_VerticalTracking_R.SelectedItem = line.position_Vertical_R.name;
                }

                txt_Name.Text = data.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                prepared = true;
                RunOnce();
            }
            else
            {
                line = new Line();
                data = line;
                data.name = txt_Name.Text;
            }
        }

        #endregion

        #region 画基准线
        private void btn_Draw_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启

            line.SetLine(Func_HalconFunction.DrawLine(hWindow_Final1.hWindowControl.HalconWindow));//画线

            DrawMode(false);//绘制模式关闭

            nud_xStart.Value = (decimal)line.hv_Column1.D;//赋值
            nud_yStart.Value = (decimal)line.hv_Row1.D;//赋值
            nud_xEnd.Value = (decimal)line.hv_Column2.D;//赋值
            nud_yEnd.Value = (decimal)line.hv_Row2.D;//赋值

            prepared = true;
            RunOnce();
        }

        #endregion

        #region 起点x
        private void nud_xStart_ValueChanged(object sender, EventArgs e)
        {
            line.hv_Column1 = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }
        #endregion

        #region 起点y
        private void nud_yStart_ValueChanged(object sender, EventArgs e)
        {
            line.hv_Row1 = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }
        #endregion

        #region 终点x
        private void nud_xEnd_ValueChanged(object sender, EventArgs e)
        {
            line.hv_Column2 = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }
        #endregion

        #region 终点y
        private void nud_yEnd_ValueChanged(object sender, EventArgs e)
        {
            line.hv_Row2 = (double)(sender as NumericUpDown).Value;
            RunOnce();
        }
        #endregion

        #region 确定
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
        #endregion

        #region 取消
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }
        #endregion

        #region 垂直跟踪左
        private void cmb_VerticalTracking_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                line.position_Vertical_L = verticalPositions[cmb_VerticalTracking_L.SelectedIndex] as BasePosition;
                RunOnce();
            }
        }
        #endregion

        #region 垂直跟踪右
        private void cmb_VerticalTracking_R_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prepared)
            {
                line.position_Vertical_R = verticalPositions[cmb_VerticalTracking_R.SelectedIndex] as BasePosition;
                RunOnce();
            }
        } 
        #endregion
    }
}
