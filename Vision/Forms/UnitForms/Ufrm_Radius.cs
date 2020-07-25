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
using Vision.DataProcess.CalculationLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_Radius : Form
    {

        private HObject ho_Image;

        private Frm_Edit form;

        private MeasureManager measureManager;

        /// <summary>
        /// 计算单元
        /// </summary>
        private BaseCal_Single calculate;

        /// <summary>
        /// 圆列队
        /// </summary>
        private List<Circle> circles;

        /// <summary>
        /// 测量单元列队
        /// </summary>
        private List<MeasuringUnit> measuringUnits;



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

        public Ufrm_Radius(Frm_Edit form, HObject ho_Image)
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_Radius(Frm_Edit form, HObject ho_Image, MeasuringUnit data)
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }


        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();


            calculate.maxValue = (double)nud_MaxValue.Value;
            calculate.minValue = (double)nud_MinValue.Value;
        }


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

        private void RunOnce()
        {
            if (Run())
            {
                nud_RealValue.Value = (decimal)(calculate.hv_RealDistance != null ? calculate.hv_RealDistance.D : 0);
                nud_k.Value = (decimal)calculate.kCx.D;
            }

        }

        private void Ufrm_Radius_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }

            circles = new List<Circle>();
            measuringUnits = measureManager.ListAllCircle();
            foreach (var item in measuringUnits)
            {
                circles.Add(item as Circle);
                cmb_Circles.Items.Add(item.name);
            }
            if (EditMode)
            {
                //编辑模式
               
                nud_Spacing.Value = data.StringHeight;

                txt_Name.Text = data.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                calculate = data as BaseCal_Single;
                cmb_Circles.SelectedIndex = Func_System.GetIndex(measuringUnits, calculate.unit1);
                if (cmb_Circles.SelectedIndex == -1)
                {
                    calculate.unit1 = new Circle(0, 0, 1);
                }
                nud_MaxValue.Value = (decimal)calculate.maxValue;
                nud_MinValue.Value = (decimal)calculate.minValue;
                nud_k.Value = (decimal)calculate.kCx.D;
                nud_RealValue.Value = (decimal)(calculate.hv_RealDistance != null ? calculate.hv_RealDistance.D : 0);
                prepared = true;
                RunOnce();
            }
            else
            {
                calculate = new CircleRadius(measureManager.k, new Circle(0, 0, 1));
                nud_k.Value = (decimal)measureManager.k;
                data = calculate;
                prepared = true;
            }
        }

        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate.unit1 = circles[(sender as ComboBox).SelectedIndex];
            RunOnce();
        }

        private void nud_k_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.kCx = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }

        private void nud_MinValue_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.minValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }

        private void nud_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            if (calculate != null)
            {
                calculate.maxValue = (double)(sender as NumericUpDown).Value;
            }
            RunOnce();
        }

        private void btn_Calck_Click(object sender, EventArgs e)
        {
            if (calculate != null && calculate.hv_PxDistance != null && calculate.hv_PxDistance.D != 0)
            {
                calculate.kCx = (double)nud_RealValue.Value /
                    calculate.hv_PxDistance;
            }
            RunOnce();
        }

        private void Ufrm_Radius_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditMode)
            {
                try
                {
                    MeasuringUnit u1 = Func_System.GetUnit(measuringUnits, (data as BaseCal_Single).unit1.iD);
                    if (u1 == null)
                        u1 = Func_System.GetUnit(measuringUnits, (oldData as BaseCal_Single).unit1.iD);

                    if (u1 == null)
                        u1 = new Circle(0, 0, 1);

                    (data as BaseCal_Single).unit1 = u1;
                }
                catch (Exception)
                { }
            }
        }

        private void nud_Spacing_ValueChanged(object sender, EventArgs e)
        {
            data.StringHeight = (int)nud_Spacing.Value;
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
            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }
    }
}
