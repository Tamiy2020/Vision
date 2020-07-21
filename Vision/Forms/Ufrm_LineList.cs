﻿using HalconDotNet;
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
using Vision.DataProcess.ParameterLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.Forms
{
    public partial class Ufrm_LineList : Form
    {
        private HObject ho_Image;

        private Frm_Edit form;

        private MeasureManager measureManager;

        /// <summary>
        /// 一组线单元
        /// </summary>
        private GetSetOfLines getSetOfLines;

        /// <summary>
        /// 抓线单元
        /// </summary>
        private GetLineUseThreshold slgLine;



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

        public Ufrm_LineList(Frm_Edit form, HObject ho_Image)//构造函数
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            EditMode = false;
        }

        public Ufrm_LineList(Frm_Edit form, HObject ho_Image, MeasuringUnit data)//编辑模式
        {
            InitializeComponent();
            this.form = form;
            this.ho_Image = ho_Image;
            this.data = data;
            oldData = (MeasuringUnit)data.Clone();
            EditMode = true;
        }

        private void DrawMode(bool enable)
        {
            HOperatorSet.SetColor(hWindow_Final1.hWindowControl.HalconWindow, "blue");//设置显示颜色-蓝色
            hWindow_Final1.hWindowControl.Focus();//聚焦到窗口
            hWindow_Final1.DrawModel = enable;//禁止缩放平移
            splitContainer1.Panel2.Enabled = !enable;

            if (null == slgLine)
            {
                btn_slg_ReDrowROI.Enabled = false;

            }
            else if (!enable)
            {
                btn_slg_ReDrowROI.Enabled = true;

            }

        }

        private void FinalAssessment()
        {
            data.name = (txt_Name.Text).Trim();
            data.formType = GetType();
        }

        private void RunOnce()
        {
            if (prepared)
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
                data.Measure(ho_Image);
                data.DisplayDetail(hWindow_Final1);
            }

        }

        private void Ufrm_LineList_Load(object sender, EventArgs e)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
            if (measureManager == null)
            {
                measureManager = form.measureManager;
            }
            if (EditMode)
            {
                getSetOfLines = data as GetSetOfLines;
                //nud_MaxGray.Value = trb_MaxGray.Value = (getSetOfLines.LineList[0] as GetLineUseThreshold).parameter.hv_MaxGray;
               // nud_MinGray.Value = trb_MinGray.Value = (getSetOfLines.LineList[0] as GetLineUseThreshold).parameter.hv_MinGray;
                if (2 == (getSetOfLines.LineList[0] as GetLineUseThreshold).TPLR)
                {
                    rdo_DownEdge.Checked = true;
                }
                if (3 == (getSetOfLines.LineList[0] as GetLineUseThreshold).TPLR)
                {
                    rdo_LeftEdge.Checked = true;
                }
                if (4 == (getSetOfLines.LineList[0] as GetLineUseThreshold).TPLR)
                {
                    rdo_RightEdge.Checked = true;
                }
                cmb_slg_SelectItem.Items.AddRange(getSetOfLines.GetLinesName());//添加combobox项

                txt_Name.Text = getSetOfLines.name;
                txt_Name.Enabled = false;//编辑模式下不能编辑名字
                prepared = true;
                RunOnce();
            }
            else
            {
                getSetOfLines = new GetSetOfLines();
                data = getSetOfLines;
            }
        }

        private void btn_DrawROIs_Click(object sender, EventArgs e)
        {
            getSetOfLines.RemoveAll();//删除所有项
            hWindow_Final1.HobjectToHimage(ho_Image);//刷新图片
            hWindow_Final1.ContextMenuStrip = contextMenuStrip1;//启用右键菜单
            DrawMode(true);//绘制模式开启
            Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
            DrawMode(false);//绘制模式关闭
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(rectangle1);//创建矩形
            hWindow_Final1.DispObj(ho_Rectangle, "blue");//显示矩形
            //创建该项
            GetLineUseThreshold line = new GetLineUseThreshold(new Threshold(Func_Mathematics.ToRectangle2(rectangle1)));
            getSetOfLines.AddLine(line);//添加该项
            cmb_slg_SelectItem.SelectedItem = null;//
            slgLine = null;
        }


        // 整体最小灰度滑条
        private void trb_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MinGray.Value > trb_MaxGray.Value)
            {
                trb_MaxGray.Value = trb_MinGray.Value;
                nud_MaxGray.Value = trb_MaxGray.Value;
            }
            nud_MinGray.Value = trb_MinGray.Value;
        }

        //整体最小灰度数字
        private void nud_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MinGray.Value > nud_MinGray.Value)
            {
                nud_MaxGray.Value = nud_MinGray.Value;
                trb_MaxGray.Value = (int)nud_MaxGray.Value;
            }
            trb_MinGray.Value = (int)nud_MinGray.Value;
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
                if ((getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MinGray > (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MaxGray)
                    (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
            }
            RunOnce();//运行测试
        }

        //整体最大灰度滑条
        private void trb_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_MaxGray.Value < trb_MinGray.Value)
            {
                trb_MinGray.Value = trb_MaxGray.Value;
                nud_MinGray.Value = (int)trb_MinGray.Value;
            }
            nud_MaxGray.Value = trb_MaxGray.Value;
        }

        //整体最大灰度数字
        private void nud_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_MaxGray.Value < nud_MinGray.Value)
            {
                nud_MinGray.Value = nud_MaxGray.Value;
                trb_MinGray.Value = (int)nud_MinGray.Value;
            }
            trb_MaxGray.Value = (int)nud_MaxGray.Value;
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
                if ((getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MinGray > (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MaxGray)
                    (getSetOfLines.GetLine(i) as GetLineUseThreshold).parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
            }
            RunOnce();//运行测试
        }

        //上
        private void rdo_UpEdge_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).TPLR = 1;
            }
            RunOnce();//运行测试
        }


        //下
        private void rdo_DownEdge_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).TPLR = 2;
            }
            RunOnce();//运行测试
        }

        //左
        private void rdo_LeftEdge_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).TPLR = 3;
            }
            RunOnce();//运行测试
        }

        //右
        private void rdo_RightEdge_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < getSetOfLines.CountOfLine; i++)
            {
                (getSetOfLines.GetLine(i) as GetLineUseThreshold).TPLR = 4;
            }
            RunOnce();//运行测试
        }

        //选择单项
        private void cmb_slg_SelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_slg_SelectItem.SelectedItem == null)
            {
                btn_slg_ReDrowROI.Enabled = false;

                return;
            }
            slgLine = getSetOfLines.GetLine(cmb_slg_SelectItem.SelectedIndex) as GetLineUseThreshold;//获取选择的项
            trb_slg_MaxGray.Value = slgLine.parameter.hv_MaxGray.I;
            trb_slg_MinGray.Value = slgLine.parameter.hv_MinGray.I;
            nud_slg_MaxGray.Value = slgLine.parameter.hv_MaxGray.I;
            nud_slg_MinGray.Value = slgLine.parameter.hv_MinGray.I;
            nud_slg_b_pex.Value = (decimal)slgLine.b.D;
            btn_slg_ReDrowROI.Enabled = true;
        }

        //重画选区
        private void btn_slg_ReDrowROI_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启
            Rectangle1 rectangle1 = Func_Mathematics.ToRectangle1(slgLine.parameter.rectangle2);
            Rectangle2 rectangle2;
            if (rectangle1 != null)
            {
                rectangle1 = Func_HalconFunction.DrawRectangle1Mod(hWindow_Final1.hWindowControl.HalconWindow, rectangle1);//画矩形
                rectangle2 = Func_Mathematics.ToRectangle2(rectangle1);
            }
            else
            {
                rectangle2 = Func_HalconFunction.DrawRectangle2Mod(hWindow_Final1.hWindowControl.HalconWindow, slgLine.parameter.rectangle2);
            }
            DrawMode(false);//绘制模式关闭
            slgLine.parameter.rectangle2 = rectangle2;
            RunOnce();//运行测试
        }

        //单项最小灰度滑条
        private void trb_slg_MinGray_Scroll(object sender, EventArgs e)
        {
            if (trb_slg_MinGray.Value > trb_slg_MaxGray.Value)
            {
                trb_slg_MaxGray.Value = trb_slg_MinGray.Value;
                nud_slg_MaxGray.Value = trb_slg_MaxGray.Value;
            }
            nud_slg_MinGray.Value = trb_slg_MinGray.Value;
        }

        //单项最小灰度数字
        private void nud_slg_MinGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_slg_MinGray.Value > nud_slg_MinGray.Value)
            {
                nud_slg_MaxGray.Value = nud_slg_MinGray.Value;
                trb_slg_MaxGray.Value = (int)nud_slg_MaxGray.Value;
            }
            trb_slg_MinGray.Value = (int)nud_slg_MinGray.Value;
            if (slgLine == null) return;
            slgLine.parameter.hv_MinGray = (int)(sender as NumericUpDown).Value;
            RunOnce();//运行测试
        }

        //单项最大灰度滑条
        private void trb_slg_MaxGray_Scroll(object sender, EventArgs e)
        {
            if (trb_slg_MaxGray.Value < trb_slg_MinGray.Value)
            {
                trb_slg_MinGray.Value = trb_slg_MaxGray.Value;
                nud_slg_MinGray.Value = trb_slg_MinGray.Value;
            }
            nud_slg_MaxGray.Value = trb_slg_MaxGray.Value;
        }

        //单项最大灰度数字
        private void nud_slg_MaxGray_ValueChanged(object sender, EventArgs e)
        {
            if (nud_slg_MaxGray.Value < nud_slg_MinGray.Value)
            {
                nud_slg_MinGray.Value = nud_slg_MaxGray.Value;
                trb_slg_MinGray.Value = (int)nud_slg_MinGray.Value;
            }
            trb_slg_MaxGray.Value = (int)nud_slg_MaxGray.Value;
            if (slgLine == null) return;
            slgLine.parameter.hv_MaxGray = (int)(sender as NumericUpDown).Value;
            RunOnce();//运行测试
        }

        //上下微调
        private void nud_slg_b_pex_ValueChanged(object sender, EventArgs e)
        {
            slgLine.b = (double)nud_slg_b_pex.Value;
            RunOnce();//运行测试
        }

        //下一个
        private void tsmi_Next_Click(object sender, EventArgs e)
        {
            DrawMode(true);//绘制模式开启
            Rectangle1 rectangle1 = Func_HalconFunction.DrawRectangle1(hWindow_Final1.hWindowControl.HalconWindow);//画矩形
            DrawMode(false);//绘制模式关闭
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(rectangle1);//创建矩形 
            hWindow_Final1.DispObj(ho_Rectangle, "blue");//显示矩形

            GetLineUseThreshold line = new GetLineUseThreshold(new Threshold(Func_Mathematics.ToRectangle2(rectangle1)));
            getSetOfLines.AddLine(line);
        }

        //完成
        private void tsmi_Done_Click(object sender, EventArgs e)
        {
            hWindow_Final1.ContextMenuStrip = null;//禁用右键菜单
            cmb_slg_SelectItem.Items.Clear();//清空cmbobox
            cmb_slg_SelectItem.Items.AddRange(getSetOfLines.GetLinesName());//添加combobox项
            prepared = true;
            RunOnce();//运行测试
        }

        private void tsmi_Cancel_Click(object sender, EventArgs e)
        {
            hWindow_Final1.ContextMenuStrip = null;//禁用右键菜单
            RunOnce();//运行测试
        }

        //确定
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

        //取消
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (EditMode) data.SetData(oldData);//?编辑模式,恢复数据
            Close();
        }
    }
}
