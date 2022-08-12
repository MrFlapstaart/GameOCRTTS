using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GameOCRTTS
{
    internal static class WinAPI
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        internal static IntPtr GetActiveWindow()
        {
            IntPtr handle = IntPtr.Zero;
            return GetForegroundWindow();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        internal static Rectangle GetActiveWindowRect()
        {
            IntPtr actwind = GetActiveWindow();
            GetWindowRect(actwind, out RECT actwindrect);

            Rectangle bounds = new Rectangle
            {
                X = actwindrect.Left,
                Y = actwindrect.Top,
                Width = actwindrect.Right - actwindrect.Left,
                Height = actwindrect.Bottom - actwindrect.Top
            };

            return bounds;
        }

                
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int Left;        // x position of upper-left corner  
        public int Top;         // y position of upper-left corner  
        public int Right;       // x position of lower-right corner  
        public int Bottom;      // y position of lower-right corner  
    }
}
