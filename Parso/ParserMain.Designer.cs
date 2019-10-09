namespace Parso
{
    partial class ParserMain
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
            this.btnParseAction = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtBatchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbApplicationType = new System.Windows.Forms.ComboBox();
            this.batchStartDate = new System.Windows.Forms.DateTimePicker();
            this.batchEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnParseAction
            // 
            this.btnParseAction.Location = new System.Drawing.Point(12, 118);
            this.btnParseAction.Name = "btnParseAction";
            this.btnParseAction.Size = new System.Drawing.Size(552, 31);
            this.btnParseAction.TabIndex = 0;
            this.btnParseAction.Text = " Parse";
            this.btnParseAction.UseVisualStyleBackColor = true;
            this.btnParseAction.Click += new System.EventHandler(this.btnParseAction_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 155);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(552, 150);
            this.progressBar.TabIndex = 5;
            // 
            // txtBatchName
            // 
            this.txtBatchName.Location = new System.Drawing.Point(100, 12);
            this.txtBatchName.Name = "txtBatchName";
            this.txtBatchName.Size = new System.Drawing.Size(464, 20);
            this.txtBatchName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Batch Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Application";
            // 
            // cmbApplicationType
            // 
            this.cmbApplicationType.FormattingEnabled = true;
            this.cmbApplicationType.Location = new System.Drawing.Point(100, 39);
            this.cmbApplicationType.Name = "cmbApplicationType";
            this.cmbApplicationType.Size = new System.Drawing.Size(464, 21);
            this.cmbApplicationType.TabIndex = 9;
            // 
            // batchStartDate
            // 
            this.batchStartDate.Location = new System.Drawing.Point(100, 66);
            this.batchStartDate.Name = "batchStartDate";
            this.batchStartDate.Size = new System.Drawing.Size(200, 20);
            this.batchStartDate.TabIndex = 10;
            // 
            // batchEndDate
            // 
            this.batchEndDate.Location = new System.Drawing.Point(364, 66);
            this.batchEndDate.Name = "batchEndDate";
            this.batchEndDate.Size = new System.Drawing.Size(200, 20);
            this.batchEndDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date";
            // 
            // ParserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(576, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.batchEndDate);
            this.Controls.Add(this.batchStartDate);
            this.Controls.Add(this.cmbApplicationType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBatchName);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnParseAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ParserMain";
            this.Text = "PARSO";
            this.Load += new System.EventHandler(this.ParserMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParseAction;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtBatchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbApplicationType;
        private System.Windows.Forms.DateTimePicker batchStartDate;
        private System.Windows.Forms.DateTimePicker batchEndDate;
        private System.Windows.Forms.Label label3;
    }
}

