using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            measureManager.camera.ImageAcqed += Camera_ImageAcqed;//绑定图像接收完成事件

            measureManager.AddCompleted += MeasureManager_AddCompleted;//绑定测量单元管理器添加完成事件
            measureManager.ModificationCompleted += MeasureManager_ModificationCompleted;//绑定测量单元管理器修改完成事件

        }

        public void SetExecutionUnit(MeasureManager measureManager)
        {
            this.measureManager = measureManager;

            measureManager.AddCompleted += MeasureManager_AddCompleted;//绑定测量单元管理器添加完成事件
            measureManager.ModificationCompleted += MeasureManager_ModificationCompleted;//绑定测量单元管理器修改完成事件
            UpdateDataGridView();//更新文件控制表格显示
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
                if (item[2].ToString() == "产品有无" || item[2].ToString() == "缺陷检测" || Regex.IsMatch(item[2].ToString(), @"/*距离") || Regex.IsMatch(item[2].ToString(), @"/*距") || item[2].ToString() == "高低落差" || Regex.IsMatch(item[2].ToString(), @"/*计算"))
                {
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Blue;
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Tomato;
                }
                if (Regex.IsMatch(item[2].ToString(), @"/*定位"))
                {
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;
                    dgv_File.Rows[dgv_File.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Red;
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
                if (item != null)
                {
                    dgv_Data.Rows.Add(item);//在表格视图中添加测量项

                    if (item.Length == 24)//多边测距专用
                    {
                        for (int i = 4; i < 24; i++)
                        {
                            bool b = double.TryParse(item[i].ToString(), out double d);
                            if (b)
                            {
                                if (Convert.ToDouble(item[2]) > d || d > Convert.ToDouble(item[3]))
                                {
                                    dgv_Data.Rows[dgv_Data.Rows.Count - 1].Cells[i].Style.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                    }

                    else
                    {
                        if (Convert.ToDouble(item[2]) > Convert.ToDouble(item[4]) || Convert.ToDouble(item[4]) > Convert.ToDouble(item[3]))
                        {
                            if (item[1].ToString() == "产品有无")
                            {
                                dgv_Data.Rows[dgv_Data.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
                                // dgv_Data.Rows.Clear();
                                return;
                            }
                            dgv_Data.Rows[dgv_Data.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
                        }
                    }


                }

            }

        }

        //修改完成
        private int MeasureManager_ModificationCompleted(object sender, object e)
        {
            object[] vs = e as object[];
            dgv_File.CurrentRow.Cells[0].Value = vs[0];
            dgv_File.CurrentRow.Cells[1].Value = vs[1];
            dgv_File.CurrentRow.Cells[2].Value = vs[2];

            UpdateDataGridView();//更新文件控制表格显示
            return 0;
        }

        //添加完成
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

        /// <summary>
        /// 得到图像
        /// </summary>
        /// <returns></returns>
        public HObject GetImage()
        {
            return hWindow_Final1.Image;
        }

        /// <summary>
        /// 得到图像窗口句柄
        /// </summary>
        /// <returns></returns>
        public HWindow GetHWindow()
        {
            return hWindow_Final1.hWindowControl.HalconWindow;
        }

        /// <summary>
        /// 管理员模式
        /// </summary>
        /// <param name="sign"></param>
        public void AdminMod(bool sign)
        {
            toolStrip1.Enabled = sign;
            dgv_File.Enabled = sign;
        }


        #region 跟踪定位
        private void tsbtn_Position_Click(object sender, EventArgs e)
        {
            new Ufrm_Position(this, hWindow_Final1.Image).Show();
        }
        #endregion

        #region 基准线
        private void tsbtn_DatumLine_Click(object sender, EventArgs e)
        {
            new Ufrm_DatumLine(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 边缘提取
        private void tsbtn_Line_Click(object sender, EventArgs e)
        {
            new Ufrm_Line(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 多边抓取
        private void tsbtn_LineList_Click(object sender, EventArgs e)
        {
            new Ufrm_LineList(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 圆
        private void tsbtn_Circle_Click(object sender, EventArgs e)
        {
            new Ufrm_Circle(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 距离测量
        private void tsbtn_Distance_Click(object sender, EventArgs e)
        {
            new Ufrm_Distance(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 多边测距
        private void tsbtn_MultipleDistance_Click(object sender, EventArgs e)
        {
            new Ufrm_MultipleDistance(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 角度计算
        private void tsbtn_Angle_Click(object sender, EventArgs e)
        {
            new Ufrm_Angle(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 半径计算
        private void tsbtn_Radius_Click(object sender, EventArgs e)
        {
            new Ufrm_Radius(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 缺陷检测
        private void tsbtn_Exist_Click(object sender, EventArgs e)
        {
            new UFrm_Exist(this, hWindow_Final1.Image).ShowDialog();
        }
        #endregion

        #region 编辑/删除
        private void dgv_File_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 3 || e.RowIndex < 0 || e.ColumnIndex > 4 || e.RowIndex == dgv_File.RowCount) return;//点击的不是按钮
            //获取该项id
            int id = int.Parse(dgv_File.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 3)//编辑
            {
                object data = measureManager.GetMeasuringUnit(id);//查找该id对应的项
                if (data == null) { MessageBox.Show("查无此项修改失败"); return; }//查无此项修改失败


                #region 反射生成窗体
                Type formType = (measureManager.GetMeasuringUnit(id) as MeasuringUnit).formType;//拿到窗体类型
                object form = Activator.CreateInstance(formType, this, hWindow_Final1.Image, data);//通过窗体类型创建窗体
                //PropertyInfo propertyInfo = formType.GetProperty("Parent");//找到Paraent属性
                //propertyInfo.SetValue(form, splitContainer1.Panel2, null);//赋值Paraent属性 
                MethodInfo methodInfo = formType.GetMethod("ShowDialog", new Type[] { });//找到ShowDialog方法

                methodInfo.Invoke(form, null);//执行ShowDialog方法 
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
                        return;
                    }
                }
            }
        }
        #endregion

        #region 窗体加载时
        private void Frm_Edit_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        } 
        #endregion


        //文件控制  不可编辑
        private void dgv_File_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.Cancel = true;
            }
        }

        //测量数据 不可编辑
        private void dgv_Data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                e.Cancel = true;
            }
        }


    }
}
