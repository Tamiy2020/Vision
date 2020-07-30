using System;
using System.Windows.Forms;

namespace Vision.Forms
{
    public partial class Frm_Start : Form
    {
        private int time;
        public Frm_Start()
        {
            InitializeComponent();
        }

        private void UpdataDisplay(int val)
        {
            if (InvokeRequired)
            {
                Action<int> myInvoke = UpdataDisplay;
                Invoke(myInvoke, new object[] { val });
                return;
            }
        }

        private void Frm_Start_Load(object sender, EventArgs e)
        {
            timer1.Interval = 40;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            UpdataDisplay(time);
            if (time >= 100)
            {
                timer1.Enabled = false;
                Close();
            }
        }
    }
}
