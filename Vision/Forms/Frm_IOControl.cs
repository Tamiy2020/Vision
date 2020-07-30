using System;
using System.Threading;
using System.Windows.Forms;

namespace Vision.Forms
{
    public partial class Frm_IOControl : Form
    {
        Frm_Main mainForm;
        public Frm_IOControl(Frm_Main form)
        {
            InitializeComponent();
            mainForm = form;
            try
            {
                numericUpDown1.Value = form.configManager.ExecutionManager.listMeasureManager[0].sleeptime;
            }
            catch (Exception) { }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in mainForm.configManager.ExecutionManager.listMeasureManager)
                {
                    item.sleeptime = (int)numericUpDown1.Value;
                }
            }
            catch (Exception)
            {
            }

            Thread.Sleep(500);

            Close();
        }
    }
}
