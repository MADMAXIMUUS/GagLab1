using System.ComponentModel;

namespace GagLab1_WF
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathInput = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathInput
            // 
            this.PathInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.PathInput.Location = new System.Drawing.Point(9, 31);
            this.PathInput.Name = "PathInput";
            this.PathInput.Size = new System.Drawing.Size(550, 26);
            this.PathInput.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.OkButton.Location = new System.Drawing.Point(484, 63);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 26);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CancelButton.Location = new System.Drawing.Point(565, 64);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 26);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.OpenFileButton.Location = new System.Drawing.Point(565, 31);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 26);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.PathLabel.Location = new System.Drawing.Point(12, 9);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PathLabel.Size = new System.Drawing.Size(472, 19);
            this.PathLabel.TabIndex = 4;
            this.PathLabel.Text = "Введите путь для файла или нажмите на ... для выбора файла";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SaveDialogButton
            // 
            this.SaveFileButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SaveFileButton.Location = new System.Drawing.Point(565, 31);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(75, 26);
            this.SaveFileButton.TabIndex = 5;
            this.SaveFileButton.Text = "...";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(646, 102);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.PathInput);
            this.MaximumSize = new System.Drawing.Size(662, 141);
            this.MinimumSize = new System.Drawing.Size(662, 141);
            this.Name = "Form2";
            this.Text = "Регистратор ресурсов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label PathLabel;
        public System.Windows.Forms.TextBox PathInput;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button CancelButton;

        #endregion
    }
}