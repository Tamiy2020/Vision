﻿using ChoiceTech.Halcon.Control;
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
    public partial class Frm_FourWin : Form
    {
        public List<HWindow_Final> h_Windows = new List<HWindow_Final>();
        public Frm_FourWin(Control parent)
        {
            InitializeComponent();

            h_Windows.Add(hWindow_Final1);
            h_Windows.Add(hWindow_Final2);
            h_Windows.Add(hWindow_Final3);
            h_Windows.Add(hWindow_Final4);

            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = parent;


        }
    }
}
