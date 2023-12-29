using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Paster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt1_Paste_Click(object sender, EventArgs e)
        {
            bt1_Paste.Enabled = false;

            string text = Utils.GetClipboardText();
            if (text == string.Empty) { return; }

            int DelayStandard = int.Parse(tb_DelayStandard.Text);
            int DelayMax = int.Parse(tb_DelayVariance.Text) + DelayStandard;

            // 体现了作者十分想要 GTX4090 的急切心情
            System.Threading.Thread.Sleep(4090 - 1090);

            if (DelayMax == 0)
            {
                // 当不延迟时不调用 Sleep
                foreach (var c in text)
                {
                    Utils.SendKey(c);
                }
            }
            else if (DelayStandard == DelayMax)
            {
                // 当 DelayVariance==0 时不产生随机数
                foreach (var c in text)
                {
                    Utils.SendKey(c);
                    System.Threading.Thread.Sleep(DelayStandard);
                }
            }
            else
            {
                int delay;
                Random random = new Random();
                foreach (var c in text)
                {
                    Utils.SendKey(c);
                    delay = random.Next(DelayStandard, DelayMax);
                    System.Threading.Thread.Sleep(delay);
                }
            }

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
    }

    public static class SendInputHandler
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(
            uint cInputs,
            INPUT[] pInputs,
            int cbSize
        );

        public static uint SendInput(INPUT[] inputs)
        {
            return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        // 定义INPUT结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint Type;
            public InputUnion Data;
        }

        public static uint INPUT_MOUSE = 0; // The event is a mouse event. Use the mi structure of the union.
        public static uint INPUT_KEYBOARD = 1;  // The event is a keyboard event. Use the ki structure of the union.
        public static uint INPUT_HARDWARE = 2;  // The event is a hardware event. Use the hi structure of the union.

        // 定义InputUnion联合体
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT MouseInput;
            [FieldOffset(0)]
            public KEYBDINPUT KeyboardInput;
            [FieldOffset(0)]
            public HARDWAREINPUT HardwareInput;
        }

        // 定义MOUSEINPUT结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        // 定义KEYBDINPUT结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort VirtualKeyCode;
            public ushort Scan;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        public const ushort VK_RETURN = 0x0D;   // Enter 键

        // 如果指定， 则 wScan 扫描代码由两个字节组成的序列组成，其中第一个字节的值为 0xE0。 有关详细信息 ，请参阅扩展键标志 。
        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        // 如果指定，则释放密钥。 如果未指定，则按键。
        public const uint KEYEVENTF_KEYUP = 0x0002;
        // 如果指定， wScan 将标识密钥，并忽略 wVk 。
        public const uint KEYEVENTF_SCANCODE = 0x0008;
        // 如果指定，系统会合成 VK_PACKET 击键。 wVk 参数必须为零。 此标志只能与 KEYEVENTF_KEYUP 标志组合使用。
        public const uint KEYEVENTF_UNICODE = 0x0004;


        // 定义HARDWAREINPUT结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint Msg;
            public ushort ParamL;
            public ushort ParamH;
        }

        public static KEYBDINPUT KeybInputObj(char c)
        {
            KEYBDINPUT kinput;
            kinput.VirtualKeyCode = 0;
            kinput.Scan = c;
            kinput.Flags = KEYEVENTF_UNICODE;
            kinput.Time = 0;
            kinput.ExtraInfo = IntPtr.Zero;

            return kinput;
        }

        public static KEYBDINPUT KeybInputObj(
            ushort VirtualKeyCode, ushort Scan, uint Flags
        )
        {
            KEYBDINPUT kinput;
            kinput.VirtualKeyCode = VirtualKeyCode;
            kinput.Scan = Scan;
            kinput.Flags = Flags;
            kinput.Time = 0;
            kinput.ExtraInfo = IntPtr.Zero;

            return kinput;
        }


        public static INPUT[] InputObjUnicode(char c) {
            INPUT[] input = { new INPUT() };
            input[0].Type = INPUT_KEYBOARD;
            input[0].Data.KeyboardInput = KeybInputObj(c);
            return input;
        }

        public static INPUT[] InputObjEnter()
        {
            var inputs = new INPUT[2];
            inputs[0].Type = INPUT_KEYBOARD;
            inputs[0].Data.KeyboardInput = KeybInputObj(VK_RETURN, 0, 0);

            inputs[1].Type = INPUT_KEYBOARD;
            inputs[1].Data.KeyboardInput = KeybInputObj(VK_RETURN, 0, KEYEVENTF_KEYUP);

            return inputs;
        }

    }

    public static class Utils
    {
        public static string GetClipboardText()
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                //如果剪贴板中的数据是文本格式 
                return iData.GetData(DataFormats.Text).ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SendKey(char c)
        {
            if (c == '\r')
            {
                // 忽略 \r
                return;
            }

            SendInputHandler.INPUT[] inputs;
            if (c == '\n')
            {
                //必须特别处理回车
                inputs = SendInputHandler.InputObjEnter();
            }
            else
            {
                inputs = SendInputHandler.InputObjUnicode(c);
            }
            SendInputHandler.SendInput(inputs);

        }

    }

}
