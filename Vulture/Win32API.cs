using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Text;

using System.Diagnostics;

namespace Vulture
{
    public class Win32APIwrapper
    {
        #region DLL_IMPORT
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc,
            IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd,
            StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd,
            StringBuilder lpClassName, int nMaxCount);
        #endregion

        public Win32APIwrapper()
        {
            Debug.WriteLine("construct");
        }

        ~Win32APIwrapper()
        {

        }

        public bool EnumWindow()
        {
            bool r_inf = false;
            
            EnumWindows(new EnumWindowsDelegate(EnumWindowCallBack), IntPtr.Zero);

            return r_inf;
        }

        public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        private static bool EnumWindowCallBack(IntPtr hWnd, IntPtr lparam)
        {
            //ウィンドウのタイトルの長さを取得する
            int textLen = GetWindowTextLength(hWnd);
            if (0 < textLen)
            {
                //ウィンドウのタイトルを取得する
                StringBuilder tsb = new StringBuilder(textLen + 1);
                GetWindowText(hWnd, tsb, tsb.Capacity);

                //ウィンドウのクラス名を取得する
                StringBuilder csb = new StringBuilder(256);
                GetClassName(hWnd, csb, csb.Capacity);

                //結果を表示する
                Console.WriteLine("クラス名:" + csb.ToString());
                Console.WriteLine("タイトル:" + tsb.ToString());
            }
            return true;
        }
    }
}
