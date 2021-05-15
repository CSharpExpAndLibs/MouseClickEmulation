using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeUtils
{
    /// <summary>
    /// Screen座標構造体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Point
    {
        public Int32 X;
        public Int32 Y;
    };

    /// <summary>
    /// マウス入力定義
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    };

    /// <summary>
    /// キーボード入力定義
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public short wVk;
        public short wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    };

    /// <summary>
    /// 汎用デバイス入力定義
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    };

    /// <summary>
    /// 入力状態Union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_UNION
    {
        [FieldOffset(0)] public MOUSEINPUT mouse;
        [FieldOffset(0)] public KEYBDINPUT keyboard;
        [FieldOffset(0)] public HARDWAREINPUT hardware;
    }

    /// <summary>
    /// カレント入力状態
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public int type;
        public INPUT_UNION ui;
    };


    /// <summary>
    /// 
    /// </summary>
    public static class NativeMethods
    {

        // 定数の定義
        /// <summary>
        /// INPUT.type
        /// </summary>
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        /// <summary>
        /// MOUSEINPUT.???
        /// </summary>
        public const int MOUSEEVENTF_MOVE = 0x1;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_WHEEL = 0x800;
        public const int WHEEL_DELTA = 120;

        /// <summary>
        /// KEYBDINPUT.???
        /// </summary>
        public const int KEYEVENTF_KEYDOWN = 0x0;
        public const int KEYEVENTF_KEYUP = 0x2;
        public const int KEYEVENTF_EXTENDEDKEY = 0x1;

        /// <summary>
        /// キーボード入力等をエミュレートする
        /// </summary>
        /// <param name="nInputs"></param>
        /// <param name="pInputs"></param>
        /// <param name="cbsize"></param>
        [DllImport("user32.dll", SetLastError = true)]
        public extern static void SendInput(int nInputs, ref INPUT pInputs, int cbsize);


        /// <summary>
        /// 仮想キーコードをスキャンキーコードに変換する
        /// </summary>
        /// <param name="uCode"></param>
        /// <param name="uMapType"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public extern static uint MapVirtualKey(uint uCode, uint uMapType);

        /// <summary>
        /// HotKeyの登録
        /// </summary>
        /// <param name="hwnd"></param>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool RegisterHotKey(
            IntPtr hwnd,
            int id,
            uint fsModifiers,
            uint vk);

        /// <summary>
        /// HotKeyの削除
        /// </summary>
        /// <param name="hwnd"></param>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool UnregisterHotKey(IntPtr hwnd, int id);

        /// <summary>
        /// 文字を仮想キーコードに変換する
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public extern static short VkKeyScan(char ch);

        /// <summary>
        /// カーソルイメージからハンドルを作成する
        /// </summary>
        /// <param name="hInst"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="fuLoad"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public extern static int LoadImage(IntPtr hInst,
            string name, uint type, int cx, int cy, uint fuLoad);

        /// <summary>
        /// カーソルを設定する
        /// </summary>
        /// <param name="hCursor"></param>
        /// <returns>カレントのカーソルリソース</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public extern static int SetCursor(int hCursor);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool SetSystemCursor(int hcur, uint id);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static int GetCursor();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int CopyIcon(int pcur);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

    }
}
