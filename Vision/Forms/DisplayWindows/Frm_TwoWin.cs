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

   
    public partial class Frm_TwoWin : Form
    {
        public List<HWindow_Final> h_Windows;

        public List<Label> labels_OK;

        public List<Label> labels_Sum;

        public List<Label> labels_Num;

        public List<Label> labels_Yield;

        public Frm_TwoWin(Control parent)
        {
            InitializeComponent();

            //图像显示列队
            h_Windows = new List<HWindow_Final>
            {
                hWindow_Final1,
                hWindow_Final2
            };

            //OK/NG显示列队
            labels_OK = new List<Label>
            {
                lbl_OK1,
                lbl_OK2
            };

            //总数显示列队
            labels_Sum = new List<Label>
            {
               lbl_Sum1,
               lbl_Sum2
            };

            //良品显示列队
            labels_Num = new List<Label>
            {
                lbl_Num1,
                lbl_Num2
            };

            //良率显示列队
            labels_Yield = new List<Label>
            {
                lbl_Yield1,
                lbl_Yield2
            };

            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = parent;
        }
    }
}
