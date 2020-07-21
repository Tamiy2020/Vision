using HalconDotNet;
using Rabbit.InvokeHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.CameraLib;
using Vision.DataProcess;

namespace Vision.Forms
{
    public partial class Frm_Edit : Form
    {
        /// <summary>
        ///  测量单元管理器
        /// </summary>
        public MeasureManager measureManager;



        public Frm_Edit(Control parent, MeasureManager measureManager)
        {
            InitializeComponent();

            Initialize(parent, measureManager);//初始化
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize(Control parent, MeasureManager measureManager)
        {
            TopLevel = false;//设为非顶级窗体
            Parent = parent;//设置控件的父容器
            Dock = DockStyle.Fill;//停靠模式填充
            this.measureManager = measureManager;
            measureManager.camera.ImageAcqed += Camera_ImageAcqed;//挂载图像接收完成事件

            measureManager.AddCompleted += MeasureManager_AddCompleted;//挂载测量单元管理器添加完成事件
            measureManager.ModificationCompleted += MeasureManager_ModificationCompleted;//挂载测量单元管理器修改完成事件

        }

        public void SetExecutionUnit(MeasureManager measureManager)
        {
            this.measureManager = measureManager;

            measureManager.AddCompleted += MeasureManager_AddCompleted;//挂载测量单元管理器添加完成事件
            measureManager.ModificationCompleted += MeasureManager_ModificationCompleted;//挂载测量单元管理器修改完成事件
            UpdateDataGridView();
        }


        private int MeasureManager_ModificationCompleted(object sender, object e)
        {
            object[] vs = e as object[];
            dgv_File.CurrentRow.Cells[0].Value = vs[0];
            dgv_File.CurrentRow.Cells[1].Value = vs[1];
            // dataGridView1.CurrentRow.Cells[2].Value = vs[2];
            // dataGridView1.CurrentRow.Cells[3].Value = vs[3];
            UpdateDataGridView();
            return 0;
        }

        /// <summary>
        /// 更新列表显示
        /// </summary>
        public void UpdateDataGridView()
        {
            dgv_File.Rows.Clear();
            foreach (var item in measureManager.ListAllUnit())
            {
                dgv_File.Rows.Add(item);//在表格视图中添加测量项
                if (item[2].ToString ()=="产品有无"|| item[2].ToString() == "缺陷检测")
                {
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Blue;
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Tomato;
                }
            }
        }

        /// <summary>
        /// 更新测量数据表格
        /// </summary>
        private void UpdateDataGridView_Data()
        {
            dgv_Data.Rows.Clear();
            List<object[]> rows = measureManager.ListAllData();
            foreach (var item in rows)
            {
                if (item !=null)
                {
                    dgv_Data.Rows.Add(item);//在表格视图中添加测量项

                    if (Convert.ToInt32(item[2]) > Convert.ToInt32(item[4]) || Convert.ToInt32(item[4]) > Convert.ToInt32(item[3]))
                    {
                        //if (item[1].ToString() =="产品有无")
                        //{
                        //    dgv_Data.Rows.Clear();
                        //    return;
                        //}
                        dgv_Data.Rows[dgv_Data.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
                    }
                }
               
            }

        }

        private int MeasureManager_AddCompleted(object sender, object e)
        {
            dgv_File.Rows.Add(e as object[]);
            UpdateDataGridView();
            return 0;
        }

        //图像处理
        private void Camera_ImageAcqed(HObject ho_Image)
        {

            if (measureManager.bisTest)
            {
                measureManager.MeasureStartDetail(ho_Image);//测量
                hWindow_Final1.HobjectToHimage(ho_Image);
                measureManager.DisplayResult(hWindow_Final1);//字符串

                this.Invoke(new Action(UpdateDataGridView_Data));

            }
            else
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
            }
        }


        public HObject GetImage()
        {
            return hWindow_Final1.Image;
        }

        public HWindow GetHWindow()
        {
            return hWindow_Final1.hWindowControl.HalconWindow;
        }


        /// <summary>
        /// 实时模式
        /// </summary>
        /// <param name="sign"></param>
        public void LiveMod(bool sign)
        {
            toolStrip1.Enabled = !sign;
            dgv_File .Enabled = !sign;
        }

        //基准线
        private void tsbtn_DatumLine_Click(object sender, EventArgs e)
        {
            Ufrm_DatumLine ufrm_DatumLine = new Ufrm_DatumLine(this, hWindow_Final1.Image);
            ufrm_DatumLine.ShowDialog();
        }

        //边缘提取
        private void tsbtn_Line_Click(object sender, EventArgs e)
        {
            Ufrm_Line ufrm_Line = new Ufrm_Line(this, hWindow_Final1.Image);
            ufrm_Line.ShowDialog();
        }

        //多边抓取
        private void tsbtn_LineList_Click(object sender, EventArgs e)
        {
            Ufrm_LineList ufrm_LineList = new Ufrm_LineList(this, hWindow_Final1.Image);
            ufrm_LineList.ShowDialog();
        }

        //圆
        private void tsbtn_Circle_Click(object sender, EventArgs e)
        {
            Ufrm_Circle ufrm_Circle = new Ufrm_Circle(this, hWindow_Final1.Image);
            ufrm_Circle.ShowDialog();
        }

        //缺陷检测
        private void tsbtn_Exist_Click(object sender, EventArgs e)
        {
            UFrm_Exist uFrm_Exist = new UFrm_Exist(this, hWindow_Final1.Image);
            uFrm_Exist.ShowDialog();
        }



        //编辑/删除
        private void dgv_File_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 3|| e.RowIndex < 0 || e.ColumnIndex > 4 || e.RowIndex == dgv_File.RowCount) return;//点击的不是按钮
            string s = "定位线";
            foreach (DataGridViewCell item in dgv_File.Rows[e.RowIndex].Cells) if (s == item.FormattedValue.ToString()) return;

            //获取该项id
            int id = int.Parse(dgv_File.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 3)//编辑
            {
                object data = measureManager.GetMeasuringUnit(id);//查找该id对应的项
                if (data == null) { MessageBox.Show("查无此项修改失败"); return; }//查无此项修改失败


                #region 反射生成窗体
                Type formType = (measureManager.GetMeasuringUnit(id) as MeasuringUnit).formType;//拿到窗体类型
                object form = Activator.CreateInstance(formType, this, hWindow_Final1.Image, data);//通过窗体类型创建窗体
                /*  PropertyInfo propertyInfo = formType.GetProperty("Parent");//找到Paraent属性
                  propertyInfo.SetValue(form, splitContainer1.Panel2, null);//赋值Paraent属性 */
                MethodInfo methodInfo = formType.GetMethod("ShowDialog", new Type[] { });//找到Show方法

                methodInfo.Invoke(form, null);//执行Show方法 
                #endregion

            }
            if (e.ColumnIndex == 4)//删除
            {
                if (MessageBox.Show("确定删除吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //执行删除操作
                    if (measureManager.RemoveMeasuringUnit(id) == null)
                    {
                        dgv_File.Rows.Remove(dgv_File.Rows[e.RowIndex]);//从表格中删除该行

                        #region 删除定位时删除定位线
                        if (e.RowIndex >= 1)
                        {
                            foreach (DataGridViewCell item in dgv_File.Rows[e.RowIndex - 1].Cells)
                            {

                                if (s == item.FormattedValue.ToString())
                                {
                                    measureManager.RemoveMeasuringUnit(id - 1);
                                    dgv_File.Rows.Remove(dgv_File.Rows[e.RowIndex - 1]);//删除定位线
                                    return;
                                }
                            }
                        }
                        #endregion



                    }
                }
            }
        }

        private void Frm_Edit_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }


        //文件控制  不可编辑
        private void dgv_File_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex ==1||e.ColumnIndex ==2)
            {
                e.Cancel = true;
            }
        }

        //测量数据 不可编辑
        private void dgv_Data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex>=0)
            {
                e.Cancel = true;
            }
        }

     
    }
}
