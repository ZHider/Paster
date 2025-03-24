using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Paster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// 
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        /// 
        /// 
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == 517)
            {
                HotkeyCallback();
            }
            base.WndProc(ref m);
        }

        private void HotkeyCallback()
        {
            this.DoPaste();
        }

        private void DoPaste()
        {
            string text = Utils.GetClipboardText();
            if (text == string.Empty) { return; }

            int DelayStandard = int.Parse(tb_DelayStandard.Text);
            int DelayMax = int.Parse(tb_DelayVariance.Text) + DelayStandard;

            Utils.DoPaste(text, DelayStandard, DelayMax);
        }

        private void bt1_Paste_Click(object sender, EventArgs e)
        {
            bt1_Paste.Enabled = false;

            // 体现了作者十分想要 GTX5090 的急切心情
            System.Threading.Thread.Sleep(5090 - 2090);

            this.DoPaste();

            bt1_Paste.Enabled = true;
        }

        /// <summary>
        /// 仅允许输入数字、控制键和退格键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxIntValidator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            { return; }
            e.Handled = true;
        }

        /// <summary>
        /// 用于让 Textbox 的输入一定为合法的 Int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxIntValidator_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (int.TryParse(tb.Text, out int value) && value > 0)
                { 
                    tb.Text = value.ToString(); 
                }
                else 
                { 
                    tb.Text = "0"; 
                }
            }
        }

        private void linkLabel_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_Github.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/ZHider/Paster");
        }

        private Utils.HotkeyRecord MyHotkeyRecord = new Utils.HotkeyRecord();
        private void textBox_Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotkeyRegistered) { return; }
            (sender as TextBox).Text = HotKey.HotKeyToString(e);
            MyHotkeyRecord.Modifiers = e.Modifiers;
            MyHotkeyRecord.Hotkey = HotKey.IsModifierKeys(e.KeyCode) ? Keys.None : e.KeyCode;
        }

        private bool HotkeyRegistered = false;
        private void HotkeyStatusRefresh(bool hotkeyStatus)
        {
            button_regHotkey.Enabled = !hotkeyStatus;
            button_unregHotkey.Enabled = hotkeyStatus;
            label_status_regHotkey.ForeColor = hotkeyStatus ? System.Drawing.Color.Green : System.Drawing.Color.Firebrick;
        }

        private bool RegisterHotkey(bool doReg)
        {
            bool done;
            if (doReg)
            {
                done = HotKey.RegisterHotKey(
                    this.Handle, 517,
                    HotKey.Keys2KeyModifiers[MyHotkeyRecord.Modifiers],
                    MyHotkeyRecord.Hotkey
                );
                HotkeyStatusRefresh(done);
            }
            else
            {
                done = HotKey.UnregisterHotKey(this.Handle, 517);
                HotkeyStatusRefresh(!done);
            }
            return done;
        }
        private void button_regHotkey_Click(object sender, EventArgs e)
        {
            HotkeyRegistered = RegisterHotkey(true);
            if (!HotkeyRegistered)
            {
                MessageBox.Show(
                    "注册热键失败，请重试。\n错误码：" + Utils.GetLastError(),
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
        }

        private void button_unregHotkey_Click(object sender, EventArgs e)
        {
            HotkeyRegistered = !RegisterHotkey(false);
            if (HotkeyRegistered)
            {
                MessageBox.Show(
                    "注销热键失败，请重试。\n错误码：" + Utils.GetLastError(),
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
        }
    }

}
