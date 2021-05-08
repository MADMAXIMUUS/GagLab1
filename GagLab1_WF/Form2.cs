using System;
using System.IO;
using System.Windows.Forms;

namespace GagLab1_WF
{
    public partial class Form2 : Form
    {
        public bool IsOpen = false;
        public Form2()
        {
            InitializeComponent();
            saveFileDialog1.FileName = Directory.GetCurrentDirectory() + @"\Resmod00";
            PathInput.Text = saveFileDialog1.FileName;
            PathInput.Focus();
            if (IsOpen)
            {
                OpenFileButton.Visible = true;
                SaveFileButton.Visible = false;
            }
            else
            {
                OpenFileButton.Visible = false;
                SaveFileButton.Visible = true;
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                PathInput.Text = openFileDialog1.FileName;
        }
        
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                PathInput.Text = saveFileDialog1.FileName;
        }

        private void PathInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OkButton.PerformClick();
            }
        }
    }
}