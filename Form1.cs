using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int SM_REMOTESESSION = 0x1000;

        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        #endregion OSVERSIONINFOEX

        [DllImport("user32")]
        static extern bool GetSystemMetrics(int index);
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Client Name = " + Environment.GetEnvironmentVariable("CLIENTNAME");
            label2.Text = "ComputerName = " + Environment.MachineName;
            if (TerminalServices())
            {
                label3.Text = "TerminalServices = true";
            }
            else
            {
                label3.Text = "TerminalServices = false";
            }
        }

        private bool TerminalServices()
        {
            OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX
            {
                dwOSVersionInfoSize =
                              Marshal.SizeOf(typeof(OSVERSIONINFOEX))
            };



            if (!GetVersionEx(ref osVersionInfo))
            {
                return false;
            }
            if ((osVersionInfo.wSuiteMask & 0x00000010) == 0x00000010)
            {
                return GetSystemMetrics(SM_REMOTESESSION);
            }
            else
            {
                return false;
            }

        }
    }
}
