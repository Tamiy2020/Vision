using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vision.DataProcess;
using Vision.DataProcess.CalculationLib;
using Vision.DataProcess.ParameterLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_MultipleDistance : Form
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
        /// 测量单元1
        /// </summary>
        private MeasuringUnit item1;

        /// <summary>
        /// 测量单元2
        /// </summary>
        private MeasuringUnit item2;

        /// <summary>
        /// 基准线组
        /// </summary>
        private List<Line> baseLines;

        /// <summary>
        /// 线组
        /// </summary>
        private List<GetSetOfLines> lineGroups;

        /// <summary>
        /// 计算单元组
        /// </summary>
        private BaseCal_Multi calculates;


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


        public Ufrm_MultipleDistance(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_MultipleDistance(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
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

            if (cmb_slg_Item.SelectedItem == null)
            {
                (data as BaseCal_Multi).SetAllMaxValue((double)nud_MaxValue.Value);
                (data as BaseCal_Multi).SetAllMinValue((double)nud_MinValue.Value);
                (data as BaseCal_Multi).SetAllK((double)nud_k.Value);
            }
            else
            {
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].minValue = (double)nud_slg_MinValue.Value;
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].maxValue = (double)nud_slg_MaxValue.Value;
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].kCx = (double)nud_slg_k.Value;
            }
            if ((data as BaseCal_Multi).baseLine == null || (data as BaseCal_Multi).lines == null)
            {
                if ((data as BaseCal_Multi).baseLine == null)
                {
                    (data as BaseCal_Multi).baseLine = new Line(0, 0, 1, 1);
                }
                if ((data as BaseCal_Multi).lines == null)
                {
                    (data as BaseCal_Multi).lines = new GetSetOfLines();
                    (data as BaseCal_Multi).lines.AddLine(
                        new GetLineUseThreshold(
                            new Threshold(new Rectangle2(0, 0, 0, 1, 1))));
                }
                if (data is MultipleDistance)
                {
                    for (int i = 0; i < (data as MultipleDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as MultipleDistance).calList[i];
                        item.unit1 = (data as MultipleDistance).baseLine;
                        item.unit2 = (data as MultipleDistance).lines.LineList[i];
                    }
                }
                if (data is DropDistance)
                {
                    for (int i = 0; i < (data as DropDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as DropDistance).calList[i];
                        item.unit1 = (data as DropDistance).baseLine;
                        item.unit2 = (data as DropDistance).lines.LineList[i];
                    }
                }
                if (data is PinDistance)
                {
                    for (int i = 0; i < (data as PinDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as PinDistance).calList[i];
                        item.unit1 = (data as PinDistance).lines.LineList[i];
                        item.unit2 = (data as PinDistance).lines.LineList[i + 1];
                    }
                }
            }
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
            if (Run() && cmb_slg_Item.SelectedItem != null)
            {
                nud_slg_RealValue.Value = (decimal)(data as BaseCal_Multi).calList[Convert.ToInt32(cmb_slg_Item.Text) - 1].hv_RealDistance.D;
                try
                {
                    nud_slg_k.Value = (decimal)(data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].kCx.D;
                }
                catch (Exception)
                {
                    nud_slg_k.Value = 10;
                }
            
            }
        }

        /// <summary>
        /// 枚举项目
        /// </summary>
        private void EnumItem()
        {
            List<MeasuringUnit> lines = measureManager.ListAllLine();
            baseLines = new List<Line>();
            foreach (var item in lines)
            {
                baseLines.Add(item as Line);
                cmb_Item1.Items.Add(item.name);
            }
            lines = measureManager.ListAllLineGroup();
            lineGroups = new List<GetSetOfLines>();
            foreach (var item in lines)
            {
                lineGroups.Add(item as GetSetOfLines);
                cmb_Item2.Items.Add(item.name);
            }
        }

        /// <summary>
        /// 重置枚举项目
        /// </summary>
        private void ResetEnumItem()
        {
            cmb_Item1.Items.Clear();
            cmb_Item2.Items.Clear();
            cmb_slg_Item.Items.Clear();
            EnumItem();
        }

        /// <summary>
        /// 设置项
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool SetItem(int index)
        {
            if (index == 1)
            {
                if (calculates.baseLine == baseLines[cmb_Item1.SelectedIndex])
                {
                    item1 = calculates.baseLine;
                    return true;
                }
                calculates.baseLine = baseLines[cmb_Item1.SelectedIndex];
                item1 = calculates.baseLine;
                return calculates.CreateDistanceList();
            }
            else
            {
                if (calculates.lines == lineGroups[cmb_Item2.SelectedIndex])
                {
                    item2 = calculates.lines;
                    return true;
                }
                calculates.lines = lineGroups[cmb_Item2.SelectedIndex];
                item2 = calculates.lines;
                return calculates.CreateDistanceList();
            }
        }

        #region 窗体加载中
        private void Ufrm_MultipleDistance_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            EnumItem();//枚举项目

            if (EditMode)//编辑模式
            {
                nud_Spacing.Value = data.StringHeight;
                groupBox1.Visible = false;

                if (data is MultipleDistance)
                {
                    calculates = data as MultipleDistance;
                    Text = "多边测距窗体";
                }
                if (data is DropDistance)
                {
                    calculates = data as DropDistance;
                    Text = "高低落差窗体";
                }
                if (data is PinDistance)
                {
                    calculates = data as PinDistance;
                    Text = "Pin距窗体";
                }
                cmb_Item1.SelectedIndex = Func_System.GetIndex(baseLines, calculates.baseLine);
                cmb_Item2.SelectedIndex = Func_System.GetIndex(lineGroups, calculates.lines);
                if (cmb_Item1.SelectedIndex == -1 || cmb_Item2.SelectedIndex == -1)
                {
                    hWindow_Final1.HobjectToHimage(ho_Image);
                    calculates.calList.Clear();
                    if (cmb_Item1.SelectedIndex == -1)
                        calculates.baseLine = null;
                    if (cmb_Item2.SelectedIndex == -1)
                        calculates.lines = null;
                }
                nud_k.Value = (decimal)calculates.kCx.D;
                nud_MinValue.Value = (decimal)calculates.minValue;
                nud_MaxValue.Value = (decimal)calculates.maxValue;

                txt_Name.Text = data.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                prepared = true;
                RunOnce();
                try
                {
                    cmb_slg_Item.Items.AddRange((data as BaseCal_Multi).GetAllCal());
                    cmb_slg_Item.SelectedIndex = 0;
                }
                catch { }
            }
            else
            {
                calculates = new MultipleDistance(measureManager.k);
                nud_k.Value = (decimal)measureManager.k;
                data = calculates;
                prepared = true;
            }
        }
        #endregion

        #region 基准线下拉列表框
        private void cmb_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetItem(1) && prepared)
            {
                cmb_slg_Item.Items.Clear();
                cmb_slg_Item.Items.AddRange((data as BaseCal_Multi).GetAllCal());
            }
            RunOnce();
        }
        #endregion

        #region 多边下拉列表框
        private void cmb_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetItem(2) && prepared)
            {
                cmb_slg_Item.Items.Clear();
                cmb_slg_Item.Items.AddRange((data as BaseCal_Multi).GetAllCal());
            }
            RunOnce();
        }
        #endregion

        #region 整体k值
        private void nud_k_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && prepared)
            {
                (data as BaseCal_Multi).SetAllK((double)(sender as NumericUpDown).Value);
                RunOnce();
            }
        }
        #endregion

        #region 整体最小值
        private void nud_MinValue_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && prepared)
            {
                (data as BaseCal_Multi).SetAllMinValue((double)(sender as NumericUpDown).Value);
                if (cmb_slg_Item.SelectedItem != null)
                {
                    nud_slg_MinValue.Value = nud_MinValue.Value;
                }
                RunOnce();
            }
        }
        #endregion

        #region 整体最大值
        private void nud_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && prepared)
            {
                (data as BaseCal_Multi).SetAllMaxValue((double)(sender as NumericUpDown).Value);
                if (cmb_slg_Item.SelectedItem != null)
                {
                    nud_slg_MaxValue.Value = nud_MaxValue.Value;
                }
                RunOnce();
            }
        }

        #endregion

        #region 单项选择修改的一项
        private void cmb_slg_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data != null && (data as BaseCal_Multi).calList.Count >= 0)
            {
                nud_slg_MaxValue.Value = (decimal)(data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].maxValue;
                nud_slg_MinValue.Value = (decimal)(data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].minValue;
                nud_slg_k.Value = (decimal)(data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].kCx.D;
                nud_slg_RealValue.Value = (decimal)(data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].hv_RealDistance.D;
            }
        }
        #endregion

        #region 单项k值
        private void nud_slg_k_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && (data as BaseCal_Multi).calList.Count >= 0 && cmb_slg_Item.SelectedItem != null)
            {
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].kCx = (double)(sender as NumericUpDown).Value;
                RunOnce();
            }
        }
        #endregion

        #region 单项最小值
        private void nud_slg_MinValue_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && (data as BaseCal_Multi).calList.Count >= 0 && cmb_slg_Item.SelectedItem != null)
            {
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].minValue = (double)(sender as NumericUpDown).Value;
                RunOnce();
            }
        }
        #endregion

        #region 单项最大值
        private void nud_slg_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            if (data != null && (data as BaseCal_Multi).calList.Count >= 0 && cmb_slg_Item.SelectedItem != null)
            {
                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].maxValue = (double)(sender as NumericUpDown).Value;
                RunOnce();
            }
        }
        #endregion

        #region 计算k值按钮
        private void btn_slg_Calck_Click(object sender, EventArgs e)
        {
            if (data != null && (data as BaseCal_Multi).calList.Count >= 0 && cmb_slg_Item.SelectedItem != null)
            {

                (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].kCx = (double)nud_slg_RealValue.Value /
                    (data as BaseCal_Multi).calList[cmb_slg_Item.SelectedIndex].hv_PxDistance;
                RunOnce();
            }
        }
        #endregion

        #region 多边测距单项按钮
        private void rdo_MultipleDistance_CheckedChanged(object sender, EventArgs e)
        {
            ResetEnumItem();
            if ((sender as RadioButton).Checked == true)
            {
                calculates = new MultipleDistance(measureManager.k);
                data = calculates;
                Text = "多边测距窗体";
            }
        }
        #endregion

        #region 高低落差单选按钮
        private void rdo_DropDistance_CheckedChanged(object sender, EventArgs e)
        {
            ResetEnumItem();
            if ((sender as RadioButton).Checked == true)
            {
                calculates = new DropDistance(measureManager.k);
                data = calculates;
                Text = "高低落差窗体";
            }
        }
        #endregion

        #region Pin距单选按钮
        private void rdo_PinDistance_CheckedChanged(object sender, EventArgs e)
        {
            ResetEnumItem();
            if ((sender as RadioButton).Checked == true)
            {
                calculates = new PinDistance(measureManager.k);
                data = calculates;
                Text = "Pin距窗体";
            }
        }
        #endregion

        #region 窗体关闭时
        private void Ufrm_MultipleDistance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditMode)
            {
                MeasuringUnit u1 = null;
                try
                {
                    u1 = (Line)Func_System.GetUnit(baseLines, (data as BaseCal_Multi).baseLine.iD);
                }
                catch (Exception) { }
                try
                {
                    if (u1 == null)
                        u1 = (Line)Func_System.GetUnit(baseLines, (oldData as BaseCal_Multi).baseLine.iD);
                }
                catch (Exception) { }

                MeasuringUnit u2 = null;
                try
                {
                    u2 = (GetSetOfLines)Func_System.GetUnit(lineGroups, (data as BaseCal_Multi).lines.iD);
                }
                catch (Exception) { }
                try
                {
                    if (u2 == null)
                        u2 = (GetSetOfLines)Func_System.GetUnit(lineGroups, (oldData as BaseCal_Multi).lines.iD);
                }
                catch (Exception) { }

                if (u1 == null)
                {
                    u1 = new Line(0, 0, 1, 1);
                }
                if (u2 == null)
                {
                    u2 = new GetSetOfLines();
                    (u2 as GetSetOfLines).AddLine(
                        new GetLineUseThreshold(
                            new Threshold(new Rectangle2(0, 0, 0, 1, 1))));
                }
               (data as BaseCal_Multi).baseLine = (Line)u1;
                (data as BaseCal_Multi).lines = (GetSetOfLines)u2;
                if (data is MultipleDistance)
                {
                    for (int i = 0; i < (data as MultipleDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as MultipleDistance).calList[i];
                        item.unit1 = (data as MultipleDistance).baseLine;
                        item.unit2 = (data as MultipleDistance).lines.LineList[i];
                    }
                }
                if (data is DropDistance)
                {
                    for (int i = 0; i < (data as DropDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as DropDistance).calList[i];
                        item.unit1 = (data as DropDistance).baseLine;
                        item.unit2 = (data as DropDistance).lines.LineList[i];
                    }
                }
                if (data is PinDistance)
                {
                    for (int i = 0; i < (data as PinDistance).calList.Count; i++)
                    {
                        BaseCal_Single item = (data as PinDistance).calList[i];
                        item.unit1 = (data as PinDistance).lines.LineList[i];
                        item.unit2 = (data as PinDistance).lines.LineList[i + 1];
                    }
                }
            }
        }
        #endregion

        #region 字符间距调整
        private void nud_Spacing_ValueChanged(object sender, EventArgs e)
        {
            data.StringHeight = (int)nud_Spacing.Value;
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
            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        } 
        #endregion
    }
}
