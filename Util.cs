using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Paster
{
    public static class Utils
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern long GetLastError();

        public struct HotkeyRecord
        {
            public Keys Modifiers;
            public Keys Hotkey;

            public override string ToString()
            {
                return $"{Modifiers} + {Hotkey}\n";
            }
        }


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

        public static bool SendKey(char c)
        {
            if (c == '\r')
            {
                // 忽略 \r
                return true;
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
            return SendInputHandler.SendInput(inputs) != 0;

        }

        public static void DoPaste(string text, int DelayStandard, int DelayMax)
        {
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


        public static INPUT[] InputObjUnicode(char c)
        {
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

    class HotKey
    {
        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,        //要定义热键的窗口的句柄
            int id,           //定义热键ID（不能与其它ID重复）      
            KeyModifiers fsModifiers,  //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            Keys vk           //定义热键的内容
        );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,        //要取消热键的窗口的句柄
            int id           //要取消热键的ID
        );
        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        public static readonly Dictionary<Keys, KeyModifiers> Keys2KeyModifiers = new Dictionary<Keys, KeyModifiers>
        {
            {Keys.Control, KeyModifiers.Ctrl},
            {Keys.ControlKey, KeyModifiers.Ctrl},
            {Keys.Shift, KeyModifiers.Shift},
            {Keys.ShiftKey, KeyModifiers.Shift},
            {Keys.Alt, KeyModifiers.Alt},
            {Keys.Menu, KeyModifiers.Alt},
            {Keys.LWin, KeyModifiers.WindowsKey},
            {Keys.RWin, KeyModifiers.WindowsKey},
            {Keys.None, KeyModifiers.None},
        };

        private static readonly Dictionary<Keys, string> KeyModifiersToString = new Dictionary<Keys, string>
            {
                {Keys.Control, "Ctrl"},
                {Keys.Shift, "Shift" },
                {Keys.Alt, "Alt"},
                {Keys.Control | Keys.Alt, "Ctrl + Alt"},
                {Keys.Control | Keys.Shift, "Ctrl + Shift"},
                {Keys.Alt | Keys.Shift, "Alt + Shift"},
                {Keys.Control | Keys.Alt | Keys.Shift, "Ctrl + Alt + Shift"}
            };

        private static readonly Keys[] KeyModifierKeys = new Keys[]
        {
            Keys.ControlKey,
            Keys.ShiftKey,
            Keys.Menu
        };

        private static string KeyCodeToString(Keys Key)
        {
            if (Key >= Keys.D0 && Key <= Keys.D9)
            {
                return Key.ToString().Remove(0, 1);
            }
            else if (Key >= Keys.NumPad0 && Key <= Keys.NumPad9)
            {
                return Key.ToString().Replace("Pad", "");
            }
            else
            {
                return Key.ToString();
            }
        }

        public static bool IsModifierKeys(Keys k) { return Array.IndexOf(KeyModifierKeys, k) != -1; }

        public static string HotKeyToString(KeyEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (e.Modifiers != Keys.None) { sb.Append(KeyModifiersToString[e.Modifiers]); sb.Append(" + "); }
            if (e.KeyCode != Keys.None && !IsModifierKeys(e.KeyCode)) { sb.Append(KeyCodeToString(e.KeyCode)); }
            return sb.ToString();
        }
    }
}
