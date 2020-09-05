using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vision.DataProcess;
using Vision.DataProcess.CalculationLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_Angle : Form
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
        /// 计算单元
        /// </summary>
        private BaseCal_Single calculate;

        /// <summary>
        /// 线组
        /// </summary>
        private List<Line> lines;

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

        public Ufrm_Angle(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Angle(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式的构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }

        /// <summary>
        /// 数据赋值
        /// </summary>
        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();

            calculate.maxValue = (double)nud_MaxValue.Value;
            calculate.minValue = (double)nud_MinValue.Value;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        private bool Run()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                if (data.Measure(ho_Image) == -100)
                    return false;
                data.DisplayDetail(hWindow_Final1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 运行测试
        /// </summary>
        private void RunOnce()
        {
            if (Run())
            {
                txt_RealValue.Text = (calculate.hv_RealDistance != null ? calculate.hv_RealDistance.D : 0).ToString("f1");
            }
          
        }

        #region 窗体加载时
        private void Ufrm_Angle_Load(object sender, System.EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            lines = new List<Line>();
            List<MeasuringUnit> units = measureManager.ListAllLine();//获取所有线
            foreach (var item in units)
            {
                lines.Add(item as Line);
                cmb_Item1.Items.Add(item.name);
                cmb_Item2.Items.Add(item.name);
            }
            //判断是否编辑模式进入
            if (EditMode)
            {
                nud_Spacing.Value = data.StringHeight;

                cbx_AlwaysMinAngel.Visible = false;
                txt_Name.Text = data.name;
                //txt_Name.Enabled = false;//编辑模式下不能编辑名字
                calculate = data as BaseCal_Single;
                cmb_Item1.SelectedIndex = Func_System.GetIndex(lines, calculate.unit1 as Line);
                cmb_Item2.SelectedIndex = Func_System.GetIndex(lines, calculate.unit2 as Line);
                if (cmb_Item1.SelectedIndex == -1)
                {
                    calculate.unit1 = new Line(0, 0, 1, 1);
                }
                if (cmb_Item2.SelectedIndex == -1)
                {
                    calculate.unit2 = new Line(0, 0, 1, 1);
                }
                nud_MaxValue.Value = (decimal)calculate.maxValue;
                nud_MinValue.Value = (decimal)calculate.minValue;
                txt_RealValue.Text = (calculate.hv_RealDistance != null ? calculate.hv_RealDistance.D : 0).ToString("f1");
                prepared = true;
                RunOnce();
            }
            else
            {
                calculate = new AngelLineToLine(measureManager.k, new Line(0, 0, 1, 1), new Line(0, 0, 1, 1));
                data = calculate;
                prepared = true;
            }
        }

        #endregion

        #region 线1下拉列表框
        private void cmb_Item1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            calculate.unit1 = lines[(sender as ComboBox).SelectedIndex];
            RunOnce();
        }
        #endregion

        #region 线2下拉列表框
        private void cmb_Item2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            calculate.unit2 = lines[(sender as ComboBox).SelectedIndex];
            RunOnce();
        }
        #endregion

        #region 最小值
        private void nud_MinValue_ValueChanged(object sender, System.EventArgs e)
        {
            if (calculate != null)
            {
                calculate.minValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();

        }
        #endregion

        #region 最大值
        private void nud_MaxValue_ValueChanged(object sender, System.EventArgs e)
        {
            if (calculate != null)
            {
                calculate.maxValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }
        #endregion

        #region 总是选择锐角复选框
        private void cbx_AlwaysMinAngel_CheckedChanged(object sender, System.EventArgs e)
        {
            (calculate as AngelLineToLine).AlwaysMinAngel = (sender as CheckBox).Checked;
            RunOnce();
        }
        #endregion

        #region 字符间距调整
        private void nud_Spacing_ValueChanged(object sender, System.EventArgs e)
        {
            data.StringHeight = (int)nud_Spacing.Value;
        }
        #endregion

        #region 窗体关闭时
        private void Ufrm_Angle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditMode)
            {
                try
                {
                    MeasuringUnit u1 = Func_System.GetUnit(lines, (data as BaseCal_Single).unit1.iD);
                    if (u1 == null)
                        u1 = Func_System.GetUnit(lines, (oldData as BaseCal_Single).unit1.iD);

                    MeasuringUnit u2 = Func_System.GetUnit(lines, (data as BaseCal_Single).unit2.iD);
                    if (u2 == null)
                        u2 = Func_System.GetUnit(lines, (oldData as BaseCal_Single).unit2.iD);

                    if (u1 == null)
                        u1 = new Line();
                    if (u2 == null)
                        u2 = new Line();

                    (data as BaseCal_Single).unit1 = u1;
                    (data as BaseCal_Single).unit2 = u2;
                }
                catch (Exception)
                { }
            }
        }
        #endregion

        #region 确定按钮
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Trim() != data.name)//非编辑模式
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

        #region 取消按钮
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        } 
        #endregion
    }
}
