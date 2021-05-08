using System;
using System.Windows.Forms;

namespace GagLab1_WF
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ResNumberInput.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ResNumberInput.Text = "";
        }

        private void ResNumberInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OkButton.PerformClick();
            }
        }
    }
}