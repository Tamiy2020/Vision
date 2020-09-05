using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vision.DataProcess;
using Vision.DataProcess.CalculationLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_Distance : Form
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
        /// 执行单元列队1
        /// </summary>
        List<MeasuringUnit> unitList1;

        /// <summary>
        /// 执行单元列队2
        /// </summary>
        List<MeasuringUnit> unitList2;

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

        public Ufrm_Distance(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Distance(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
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
            calculate.kCx = (double)nud_k.Value;
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
                nud_RealValue.Value = (decimal)calculate.hv_RealDistance.D;
                nud_k.Value = (decimal)calculate.kCx.D;
            }
        }

        /// <summary>
        /// 更新下拉列表框
        /// </summary>
        private void UpdateComboBox()
        {
            cmb_Item1.Items.Clear();
            cmb_Item2.Items.Clear();
            cmb_Item1.SelectedItem = null;
            cmb_Item2.SelectedItem = null;
            foreach (var item in unitList1)//添加cmb_Item1项
            {
                cmb_Item1.Items.Add(item.name);
            }
            foreach (var item in unitList2)//添加cmb_Item2项
            {
                cmb_Item2.Items.Add(item.name);
            }
        }

        #region 窗体加载时
        private void Ufrm_Distance_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            if (EditMode)
            {
                nud_Spacing.Value = data.StringHeight;

                txt_Name.Text = data.name;
               // txt_Name.Enabled = false;//编辑模式下不能编辑名字
                //编辑模式
                calculate = data as BaseCal_Single;
                if (calculate is DisPointToPoint)
                {
                    unitList1 = measureManager.ListAllPoint();//获取所有点
                    unitList2 = measureManager.ListAllPoint();//获取所有点
                    foreach (var item in unitList1)//添加cmb_Item1项
                    {
                        cmb_Item1.Items.Add(item.name);
                    }
                    foreach (var item in unitList2)//添加cmb_Item2项
                    {
                        cmb_Item2.Items.Add(item.name);
                    }
                    rdo_PTP.Checked = true;
                    lab_Item1.Text = "点1";
                    lab_Item2.Text = "点2";
                    rdo_PTL.Enabled = false;
                    rdo_LTL.Enabled = false;
                    cmb_Item1.SelectedIndex = Func_System.GetIndex(unitList1, calculate.unit1);
                    cmb_Item2.SelectedIndex = Func_System.GetIndex(unitList2, calculate.unit2);
                    if (cmb_Item1.SelectedIndex == -1)
                    {
                        calculate.unit1 = new Point(0, 0);
                    }
                    if (cmb_Item2.SelectedIndex == -1)
                    {
                        calculate.unit2 = new Point(0, 0);
                    }
                }
                if (calculate is DisPointToLine)
                {
                    unitList1 = measureManager.ListAllPoint();//获取所有点
                    unitList2 = measureManager.ListAllLine();//获取所有线
                    foreach (var item in unitList1)//添加cmb_Item1项
                    {
                        cmb_Item1.Items.Add(item.name);
                    }
                    foreach (var item in unitList2)//添加cmb_Item2项
                    {
                        cmb_Item2.Items.Add(item.name);
                    }
                    rdo_PTL.Checked = true;
                    lab_Item1.Text = "点";
                    lab_Item2.Text = "线";
                    rdo_PTP.Enabled = false;
                    rdo_LTL.Enabled = false;
                    cmb_Item1.SelectedIndex = Func_System.GetIndex(unitList1, calculate.unit1);
                    cmb_Item2.SelectedIndex = Func_System.GetIndex(unitList2, calculate.unit2);
                    if (cmb_Item1.SelectedIndex == -1)
                    {
                        calculate.unit1 = new Point(0, 0);
                    }
                    if (cmb_Item2.SelectedIndex == -1)
                    {
                        calculate.unit2 = new Line(0, 0, 1, 1);
                    }
                }
                if (calculate is DisLineToLine)
                {
                    unitList1 = measureManager.ListAllLine();//获取所有线
                    unitList2 = measureManager.ListAllLine();//获取所有线
                    foreach (var item in unitList1)//添加cmb_Item1项
                    {
                        cmb_Item1.Items.Add(item.name);
                    }
                    foreach (var item in unitList2)//添加cmb_Item2项
                    {
                        cmb_Item2.Items.Add(item.name);
                    }
                    rdo_LTL.Checked = true;
                    lab_Item1.Text = "线1";
                    lab_Item2.Text = "线2";
                    rdo_PTL.Enabled = false;
                    rdo_PTP.Enabled = false;
                    cmb_Item1.SelectedIndex = Func_System.GetIndex(unitList1, calculate.unit1);
                    cmb_Item2.SelectedIndex = Func_System.GetIndex(unitList2, calculate.unit2);
                    if (cmb_Item1.SelectedIndex == -1)
                    {
                        calculate.unit1 = new Line(0, 0, 1, 1);
                    }
                    if (cmb_Item2.SelectedIndex == -1)
                    {
                        calculate.unit2 = new Line(0, 0, 1, 1);
                    }
                }

                nud_MaxValue.Value = (decimal)calculate.maxValue;
                nud_MinValue.Value = (decimal)calculate.minValue;
                nud_k.Value = (decimal)calculate.kCx.D;
                nud_RealValue.Value = (decimal)calculate.hv_RealDistance.D;
                prepared = true;
                RunOnce();
            }
            else
            {
                nud_k.Value = (decimal)measureManager.k;
                prepared = true;
                rdo_LTL.Checked = true;
                //非编辑模式
            }
        }
        #endregion

        #region 最小值
        private void nud_MinValue_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.minValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }
        #endregion

        #region 最大值
        private void nud_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.maxValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }
        #endregion

        #region 点到点
        private void rdo_PTP_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked && prepared)
            {
                calculate = new DisPointToPoint(measureManager.k, new Point(0, 0), new Point(0, 0));
                data = calculate;
                unitList1 = measureManager.ListAllPoint();//获取所有点
                unitList2 = measureManager.ListAllPoint();//获取所有点
                UpdateComboBox();
                lab_Item1.Text = "点1";
                lab_Item2.Text = "点2";
            }
        }
        #endregion

        #region 点到线
        private void rdo_PTL_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked && prepared)
            {
                calculate = new DisPointToLine(measureManager.k, new Point(0, 0), new Line(0, 0, 1, 1));
                data = calculate;
                unitList1 = measureManager.ListAllPoint();//获取所有点
                unitList2 = measureManager.ListAllLine();//获取所有线
                UpdateComboBox();
                lab_Item1.Text = "点";
                lab_Item2.Text = "线";
            }
        }

        #endregion

        #region 线到线
        private void rdo_LTL_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked && prepared)
            {
                calculate = new DisLineToLine(measureManager.k, new Line(0, 0, 1, 1), new Line(0, 0, 1, 1));
                data = calculate;
                unitList1 = measureManager.ListAllLine();//获取所有线
                unitList2 = measureManager.ListAllLine();//获取所有线
                UpdateComboBox();
                lab_Item1.Text = "线1";
                lab_Item2.Text = "线2";
            }
        }
        #endregion

        #region 项目1下拉列表框
        private void cmb_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate.unit1 = unitList1[(sender as ComboBox).SelectedIndex];
            RunOnce();
        }
        #endregion

        #region 项目2下拉列表框
        private void cmb_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate.unit2 = unitList2[(sender as ComboBox).SelectedIndex];
            RunOnce();
        }
        #endregion

        #region k值
        private void nud_k_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.kCx = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }
        #endregion

        #region 计算k值
        private void btn_Calck_Click(object sender, EventArgs e)
        {
            if (calculate != null && calculate.hv_PxDistance != null && calculate.hv_PxDistance.D != 0)
            {
                calculate.kCx = (double)nud_RealValue.Value /
                    calculate.hv_PxDistance;
            }
            RunOnce();
        }
        #endregion

        #region 窗体关闭时
        private void Ufrm_Distance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditMode)
            {
                try
                {
                    MeasuringUnit u1 = Func_System.GetUnit(unitList1, (data as BaseCal_Single).unit1.iD);
                    if (u1 == null)
                        u1 = Func_System.GetUnit(unitList1, (oldData as BaseCal_Single).unit1.iD);

                    MeasuringUnit u2 = Func_System.GetUnit(unitList2, (data as BaseCal_Single).unit2.iD);
                    if (u2 == null)
                        u2 = Func_System.GetUnit(unitList2, (oldData as BaseCal_Single).unit2.iD);

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

        #region 确定
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

        #region 取消
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }
        #endregion

        #region 字符间距调整
        private void nud_Spacing_ValueChanged(object sender, EventArgs e)
        {
            data.StringHeight = (int)nud_Spacing.Value;
        } 
        #endregion
    }
}
