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
   
    public partial class Frm_CloseTip : Form
    {
        private int time;
        public Frm_CloseTip()
        {
            InitializeComponent();
        }

        private void Frm_CloseTip_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time >= 100)
            {
                timer1.Enabled = false;
                Close();
            }
        }
    }
}
