using System.ComponentModel;

namespace GagLab1_WF
{
    partial class Form3
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
            this.ResNumberInput = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ResNumberLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResNumberInput
            // 
            this.ResNumberInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ResNumberInput.Location = new System.Drawing.Point(9, 31);
            this.ResNumberInput.Name = "ResNumberInput";
            this.ResNumberInput.Size = new System.Drawing.Size(235, 26);
            this.ResNumberInput.TabIndex = 0;
            this.ResNumberInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResNumberInput_KeyDown);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.OkButton.Location = new System.Drawing.Point(87, 64);
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
            this.CancelButton.Location = new System.Drawing.Point(169, 64);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 26);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ResNumberLabel
            // 
            this.ResNumberLabel.AutoSize = true;
            this.ResNumberLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ResNumberLabel.Location = new System.Drawing.Point(12, 9);
            this.ResNumberLabel.Name = "ResNumberLabel";
            this.ResNumberLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResNumberLabel.Size = new System.Drawing.Size(232, 19);
            this.ResNumberLabel.TabIndex = 4;
            this.ResNumberLabel.Text = "Введите количество ресурсов ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 91);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(253, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(253, 113);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResNumberLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ResNumberInput);
            this.MaximumSize = new System.Drawing.Size(269, 152);
            this.MinimumSize = new System.Drawing.Size(269, 152);
            this.Name = "Form3";
            this.Text = "Регистратор ресурсов";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.Label ResNumberLabel;
        public System.Windows.Forms.TextBox ResNumberInput;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;

        #endregion
    }
}