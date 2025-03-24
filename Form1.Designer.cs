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
            this.textBox_Hotkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_manual = new System.Windows.Forms.TabPage();
            this.tabPage_hotkey = new System.Windows.Forms.TabPage();
            this.button_regHotkey = new System.Windows.Forms.Button();
            this.button_unregHotkey = new System.Windows.Forms.Button();
            this.label_status_regHotkey = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage_manual.SuspendLayout();
            this.tabPage_hotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt1_Paste
            // 
            this.bt1_Paste.Location = new System.Drawing.Point(190, 95);
            this.bt1_Paste.Margin = new System.Windows.Forms.Padding(4);
            this.bt1_Paste.Name = "bt1_Paste";
            this.bt1_Paste.Size = new System.Drawing.Size(100, 29);
            this.bt1_Paste.TabIndex = 5;
            this.bt1_Paste.Text = "粘贴";
            this.bt1_Paste.UseVisualStyleBackColor = true;
            this.bt1_Paste.Click += new System.EventHandler(this.bt1_Paste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "基本延迟";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "浮动值";
            // 
            // tb_DelayStandard
            // 
            this.tb_DelayStandard.Location = new System.Drawing.Point(90, 64);
            this.tb_DelayStandard.Margin = new System.Windows.Forms.Padding(4);
            this.tb_DelayStandard.MaxLength = 8;
            this.tb_DelayStandard.Name = "tb_DelayStandard";
            this.tb_DelayStandard.Size = new System.Drawing.Size(76, 25);
            this.tb_DelayStandard.TabIndex = 2;
            this.tb_DelayStandard.Text = "10";
            this.tb_DelayStandard.TextChanged += new System.EventHandler(this.TextboxIntValidator_TextChanged);
            this.tb_DelayStandard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxIntValidator_KeyPress);
            // 
            // tb_DelayVariance
            // 
            this.tb_DelayVariance.Location = new System.Drawing.Point(90, 98);
            this.tb_DelayVariance.Margin = new System.Windows.Forms.Padding(4);
            this.tb_DelayVariance.MaxLength = 8;
            this.tb_DelayVariance.Name = "tb_DelayVariance";
            this.tb_DelayVariance.Size = new System.Drawing.Size(76, 25);
            this.tb_DelayVariance.TabIndex = 4;
            this.tb_DelayVariance.Text = "5";
            this.tb_DelayVariance.TextChanged += new System.EventHandler(this.TextboxIntValidator_TextChanged);
            this.tb_DelayVariance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxIntValidator_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "单击按钮后，将于3s后开始。\r\n可以设置输入每一个字符之间的延迟。\r\n延迟 (ms) 范围为 [基本延迟，基本延迟 + 浮动值]";
            // 
            // linkLabel_Github
            // 
            this.linkLabel_Github.AutoSize = true;
            this.linkLabel_Github.Location = new System.Drawing.Point(262, 16);
            this.linkLabel_Github.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_Github.Name = "linkLabel_Github";
            this.linkLabel_Github.Size = new System.Drawing.Size(138, 15);
            this.linkLabel_Github.TabIndex = 6;
            this.linkLabel_Github.TabStop = true;
            this.linkLabel_Github.Text = "Github 源代码仓库";
            this.linkLabel_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Github_LinkClicked);
            // 
            // textBox_Hotkey
            // 
            this.textBox_Hotkey.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_Hotkey.Location = new System.Drawing.Point(97, 69);
            this.textBox_Hotkey.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Hotkey.Name = "textBox_Hotkey";
            this.textBox_Hotkey.ReadOnly = true;
            this.textBox_Hotkey.Size = new System.Drawing.Size(252, 25);
            this.textBox_Hotkey.TabIndex = 8;
            this.textBox_Hotkey.Text = "None";
            this.textBox_Hotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Hotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Hotkey_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "热键";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_manual);
            this.tabControl.Controls.Add(this.tabPage_hotkey);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(394, 168);
            this.tabControl.TabIndex = 9;
            // 
            // tabPage_manual
            // 
            this.tabPage_manual.Controls.Add(this.label1);
            this.tabPage_manual.Controls.Add(this.bt1_Paste);
            this.tabPage_manual.Controls.Add(this.label3);
            this.tabPage_manual.Controls.Add(this.label2);
            this.tabPage_manual.Controls.Add(this.tb_DelayStandard);
            this.tabPage_manual.Controls.Add(this.tb_DelayVariance);
            this.tabPage_manual.Location = new System.Drawing.Point(4, 25);
            this.tabPage_manual.Name = "tabPage_manual";
            this.tabPage_manual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_manual.Size = new System.Drawing.Size(386, 139);
            this.tabPage_manual.TabIndex = 0;
            this.tabPage_manual.Text = "手动";
            // 
            // tabPage_hotkey
            // 
            this.tabPage_hotkey.Controls.Add(this.label5);
            this.tabPage_hotkey.Controls.Add(this.label6);
            this.tabPage_hotkey.Controls.Add(this.label_status_regHotkey);
            this.tabPage_hotkey.Controls.Add(this.button_unregHotkey);
            this.tabPage_hotkey.Controls.Add(this.button_regHotkey);
            this.tabPage_hotkey.Controls.Add(this.textBox_Hotkey);
            this.tabPage_hotkey.Controls.Add(this.label4);
            this.tabPage_hotkey.Location = new System.Drawing.Point(4, 25);
            this.tabPage_hotkey.Name = "tabPage_hotkey";
            this.tabPage_hotkey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_hotkey.Size = new System.Drawing.Size(386, 139);
            this.tabPage_hotkey.TabIndex = 1;
            this.tabPage_hotkey.Text = "热键";
            // 
            // button_regHotkey
            // 
            this.button_regHotkey.Location = new System.Drawing.Point(193, 101);
            this.button_regHotkey.Name = "button_regHotkey";
            this.button_regHotkey.Size = new System.Drawing.Size(75, 23);
            this.button_regHotkey.TabIndex = 9;
            this.button_regHotkey.Text = "注册热键";
            this.button_regHotkey.UseVisualStyleBackColor = true;
            this.button_regHotkey.Click += new System.EventHandler(this.button_regHotkey_Click);
            // 
            // button_unregHotkey
            // 
            this.button_unregHotkey.Enabled = false;
            this.button_unregHotkey.Location = new System.Drawing.Point(274, 101);
            this.button_unregHotkey.Name = "button_unregHotkey";
            this.button_unregHotkey.Size = new System.Drawing.Size(75, 23);
            this.button_unregHotkey.TabIndex = 10;
            this.button_unregHotkey.Text = "注销热键";
            this.button_unregHotkey.UseVisualStyleBackColor = true;
            this.button_unregHotkey.Click += new System.EventHandler(this.button_unregHotkey_Click);
            // 
            // label_status_regHotkey
            // 
            this.label_status_regHotkey.AutoSize = true;
            this.label_status_regHotkey.ForeColor = System.Drawing.Color.Firebrick;
            this.label_status_regHotkey.Location = new System.Drawing.Point(94, 105);
            this.label_status_regHotkey.Name = "label_status_regHotkey";
            this.label_status_regHotkey.Size = new System.Drawing.Size(22, 15);
            this.label_status_regHotkey.TabIndex = 11;
            this.label_status_regHotkey.Text = "●";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "注册状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 45);
            this.label5.TabIndex = 13;
            this.label5.Text = "选中热键框，按下任意键作为热键。\r\n注册热键后，按下热键，程序立刻开始。\r\n字符间的延迟设置同 <手动> 标签页。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 188);
            this.Controls.Add(this.linkLabel_Github);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Paster By ZHider from wed0n";
            this.tabControl.ResumeLayout(false);
            this.tabPage_manual.ResumeLayout(false);
            this.tabPage_manual.PerformLayout();
            this.tabPage_hotkey.ResumeLayout(false);
            this.tabPage_hotkey.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox_Hotkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_manual;
        private System.Windows.Forms.TabPage tabPage_hotkey;
        private System.Windows.Forms.Label label_status_regHotkey;
        private System.Windows.Forms.Button button_unregHotkey;
        private System.Windows.Forms.Button button_regHotkey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

