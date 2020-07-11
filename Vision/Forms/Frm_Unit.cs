using ChoiceTech.Halcon.Control;
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

namespace Vision.Forms
{
    public partial class Frm_Unit : Form
    {
        /// <summary>
        /// 图片
        /// </summary>
        protected HObject ho_Image;

        /// <summary>
        /// 测量单元
        /// </summary>
        protected MeasuringUnit data;

        /// <summary>
        /// 旧测量单元
        /// </summary>
        protected MeasuringUnit oldData;

        /// <summary>
        /// 编辑模式
        /// </summary>
        public bool EditMode { get; }

        /// <summary>
        /// 可以执行测量方法的标志
        /// </summary>
        protected bool prepared;

        /// <summary>
        /// 测量单元管理器
        /// </summary>
        protected MeasureManager measureManager;

        /// <summary>
        /// 显示窗口
        /// </summary>
        protected HWindow_Final hWindow_Final;

        /// <summary>
        /// 执行运行一次方法事件
        /// </summary>
        public event Func<int, int> OnRunOnce;


        public Frm_Unit()
        {
            InitializeComponent();
            Initialization();
            EditMode = false;
        }


        public Frm_Unit(MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            Initialization();
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }



        private void Initialization()
        {
            Dock = DockStyle.Fill;
            TopLevel = false;
            prepared = false;
        }

        /// <summary>
        /// 设置该窗体字段
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="mUM"></param>
        /// <param name="hWindow_Final"></param>
        protected  void SetData(HObject ho_Image, MeasureManager measureManager, HWindow_Final hWindow_Final)
        {
            this.ho_Image = ho_Image;
            this.measureManager = measureManager;
            this.hWindow_Final = hWindow_Final;
            this.Controls.Remove(pnl_Top);
            this.Controls.Remove(pnl_Bottom);
        }

        #region 窗体加载时
        private void Frm_Unit_Load(object sender, EventArgs e)
        {
            if (ParentForm != null && ho_Image == null && measureManager == null && hWindow_Final == null)
            {
                ho_Image = (ParentForm as Frm_Edit).ho_Image;
                measureManager = (ParentForm as Frm_Edit).measureManager;
                hWindow_Final = (ParentForm as Frm_Edit).hWindow_Final1;
            }
        }
        #endregion

        /// <summary>
        /// 绘制模式
        /// </summary>
        /// <param name="enable"></param>
        public virtual void DrawMode(bool enable)
        {
            HOperatorSet.SetColor(hWindow_Final.hWindowControl.HalconWindow, "blue");//设置显示颜色-蓝色
            hWindow_Final.hWindowControl.Focus();//聚焦到窗口
            hWindow_Final.DrawModel = enable;//禁止缩放平移
            pnl_Fill.Enabled = !enable;//禁用参数调节区
            txt_Name.Enabled = !enable;//禁用名字输入框
            btn_OK.Enabled = !enable;//禁用确定按钮
            btn_Cancel.Enabled = !enable;//禁用取消按钮
        }

        /// <summary>
        /// 运行一次
        /// </summary>
        /// <returns></returns>
        public virtual bool RunOnce()
        {
            if (prepared)
            {
                hWindow_Final.HobjectToHimage(ho_Image);
                if (data.Measure(ho_Image) == -100)
                    return false;
                data.DisplayDetail(hWindow_Final);
                OnRunOnce?.Invoke(0);//事件触发
                return true;
            }
            return false;
        }

        /// <summary>
        /// 窗体关闭前最后赋值
        /// </summary>
        public virtual void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
        }

        #region 取消按钮
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (EditMode)
            { 
                data.SetData(oldData);//?编辑模式,恢复数据
            }
            Close();
        }
        #endregion

        #region 窗体关闭时
        private void Frm_Unit_FormClosing(object sender, FormClosingEventArgs e)
        {
            hWindow_Final.HobjectToHimage(ho_Image);
            if (ParentForm is Frm_Edit)
            {
                (ParentForm as Frm_Edit).EditMod(false);
            }
               
        }
        #endregion

        /// <summary>
        /// 确定
        /// </summary>
        private void OK()
        {
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

        /// <summary>
        /// 外部触发关闭
        /// </summary>
        public void ExternalOK()
        {
            OK();
        }

        #region 确定按钮
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

            OK();
        }
        #endregion

        #region 字符间距
        private void nud_Spacing_ValueChanged(object sender, EventArgs e)
        {
            data.StringHeight = (int)nud_Spacing.Value;
        } 
        #endregion
    }
}
