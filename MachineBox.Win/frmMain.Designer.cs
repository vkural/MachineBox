using MachineBox.Core.Globals;

namespace MachineBox.Win
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSummary = new System.Windows.Forms.RichTextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSummary);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(330, 191);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtSummary
            // 
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSummary.ForeColor = System.Drawing.Color.Gray;
            this.txtSummary.Location = new System.Drawing.Point(6, 14);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(318, 171);
            this.txtSummary.TabIndex = 1;
            this.txtSummary.Text = "";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 10000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 199);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtSummary;
        private System.Windows.Forms.Timer tmrUpdate;
    }
}

