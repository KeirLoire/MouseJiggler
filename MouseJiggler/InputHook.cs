using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MouseJiggler
{
    public static class InputHook
    {
        public static event EventHandler UserActivity;

        private static IntPtr hookId = IntPtr.Zero;
        private static LowLevelProc proc = HookCallback;

        private const int WH_MOUSE_LL = 14;

        private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(
        int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")] 
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        public static void Start()
        {
            hookId = SetHook(proc);
        }

        public static void Stop()
        {
            UnhookWindowsHookEx(hookId);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
                UserActivity?.Invoke(null, EventArgs.Empty);

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
                using (var curModule = curProcess.MainModule)
                    return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }


    }
}
