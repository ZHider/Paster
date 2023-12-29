namespace Paster
{
    partial class Form1
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
            this.bt1_Paste = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_DelayStandard = new System.Windows.Forms.TextBox();
            this.tb_DelayVariance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel_Github = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // bt1_Paste
            // 
            this.bt1_Paste.Location = new System.Drawing.Point(178, 92);
            this.bt1_Paste.Name = "bt1_Paste";
            this.bt1_Paste.Size = new System.Drawing.Size(75, 23);
            this.bt1_Paste.TabIndex = 5;
            this.bt1_Paste.Text = "粘贴";
            this.bt1_Paste.UseVisualStyleBackColor = true;
            this.bt1_Paste.Click += new System.EventHandler(this.bt1_Paste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "基本延迟";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "浮动值";
            // 
            // tb_DelayStandard
            // 
            this.tb_DelayStandard.Location = new System.Drawing.Point(103, 67);
            this.tb_DelayStandard.MaxLength = 8;
            this.tb_DelayStandard.Name = "tb_DelayStandard";
            this.tb_DelayStandard.Size = new System.Drawing.Size(58, 21);
            this.tb_DelayStandard.TabIndex = 2;
            this.tb_DelayStandard.Text = "10";
            this.tb_DelayStandard.TextChanged += new System.EventHandler(this.TextboxIntValidator_TextChanged);
            this.tb_DelayStandard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxIntValidator_KeyPress);
            // 
            // tb_DelayVariance
            // 
            this.tb_DelayVariance.Location = new System.Drawing.Point(103, 94);
            this.tb_DelayVariance.MaxLength = 8;
            this.tb_DelayVariance.Name = "tb_DelayVariance";
            this.tb_DelayVariance.Size = new System.Drawing.Size(58, 21);
            this.tb_DelayVariance.TabIndex = 4;
            this.tb_DelayVariance.Text = "5";
            this.tb_DelayVariance.TextChanged += new System.EventHandler(this.TextboxIntValidator_TextChanged);
            this.tb_DelayVariance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxIntValidator_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "单击按钮后，将于3s后开始。延迟 (ms) \r\n范围为 [基本延迟，基本延迟 + 浮动值]";
            // 
            // linkLabel_Github
            // 
            this.linkLabel_Github.AutoSize = true;
            this.linkLabel_Github.Location = new System.Drawing.Point(176, 70);
            this.linkLabel_Github.Name = "linkLabel_Github";
            this.linkLabel_Github.Size = new System.Drawing.Size(107, 12);
            this.linkLabel_Github.TabIndex = 6;
            this.linkLabel_Github.TabStop = true;
            this.linkLabel_Github.Text = "Github 源代码仓库";
            this.linkLabel_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Github_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 129);
            this.Controls.Add(this.linkLabel_Github);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DelayVariance);
            this.Controls.Add(this.tb_DelayStandard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt1_Paste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Paster By ZHider from wed0n";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt1_Paste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_DelayStandard;
        private System.Windows.Forms.TextBox tb_DelayVariance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel_Github;
    }
}

