using ChoiceTech.Halcon.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.Forms
{
    public partial class Frm_FiveWin : Form
    {
        public List<HWindow_Final> h_Windows;

        public List<Label> labels_OK;

        public List<Label> labels_Sum;

        public List<Label> labels_Num;

        public List<Label> labels_Yield;

        public Frm_FiveWin(Control parent)
        {
            InitializeComponent();

            //图像显示列队
            h_Windows = new List<HWindow_Final>
            {
                hWindow_Final1,
                hWindow_Final2,
                hWindow_Final3,
                hWindow_Final4,
                hWindow_Final5
            };

            //OK/NG显示列队
            labels_OK = new List<Label>
            {
                lbl_OK1,
                lbl_OK2,
                lbl_OK3,
                lbl_OK4,
                lbl_OK5
            };

            //总数显示列队
            labels_Sum = new List<Label>
            {
               lbl_Sum1,
               lbl_Sum2,
               lbl_Sum3,
               lbl_Sum4,
               lbl_Sum5
            };

            //良品显示列队
            labels_Num = new List<Label>
            {
                lbl_Num1,
                lbl_Num2,
                lbl_Num3,
                lbl_Num4,
                lbl_Num5

            };

            //良率显示列队
            labels_Yield = new List<Label>
            {
                lbl_Yield1,
                lbl_Yield2,
                lbl_Yield3,
                lbl_Yield4,
                lbl_Yield5
            };


            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = parent;

        }
    }
}
