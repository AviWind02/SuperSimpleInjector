﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace SuperSimpleInjector
{
    internal class Injection
    {
        private string GTA5 = "GTA5.exe";

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(
           int dwDesiredAccess,
           bool bInheritHandle,
           int dwProcessId
       );

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibraryA(
            string lpLibFileName
        );

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(
            IntPtr hModule,
            string lpProcName
        );

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(
            IntPtr hProcess,
            IntPtr lpThreadAttributes,
            int dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            int dwCreationFlags,
            int lpThreadId
        );

        [DllImport("kernel32.dll")]
        private static extern int WaitForSingleObject(
            IntPtr hProcess,
            int dwMilliseconds
        );

        [DllImport("kernel32.dll")]
        private static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            int lpAddress,
            int dwSize,
            int flAllocationType,
            int flProtect
        );

        [DllImport("kernel32.dll")]
        private static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            int dwSize,
            int dwFreeType
        );

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            IntPtr lpBuffer,
            int nSize,
            int lpNumberOfBytesWritten
        );

        [Flags]
        private enum PROCESS_ACCESS_FLAGS
        {
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
            PROCESS_VM_OPERATION = 0x0008,
        }

        [Flags]
        private enum MEMORY_ACCESS_FLAGS
        {
            MEM_COMMIT = 0x00001000,
            MEM_RELEASE = 0x00008000
        }

        [Flags]
        private enum PAGE_ACCESS_FLAGS
        {
            PAGE_READWRITE = 0x04
        }

        public bool InjectDll(string processname, string dllpath)
        {
            try
            {
                if (Process.GetProcessesByName(processname).Length == 0)
                    return false;

                var handle = OpenProcess((int)(PROCESS_ACCESS_FLAGS.PROCESS_VM_READ | PROCESS_ACCESS_FLAGS.PROCESS_VM_WRITE | PROCESS_ACCESS_FLAGS.PROCESS_VM_OPERATION), false, Process.GetProcessesByName(processname)[0].Id);
                var buffer = VirtualAllocEx(handle, 0, dllpath.Length + 1, (int)MEMORY_ACCESS_FLAGS.MEM_COMMIT, (int)PAGE_ACCESS_FLAGS.PAGE_READWRITE);

                WriteProcessMemory(handle, buffer, Marshal.StringToHGlobalAnsi(dllpath), dllpath.Length + 1, 0);
                WaitForSingleObject(CreateRemoteThread(handle, IntPtr.Zero, 0, GetProcAddress(LoadLibraryA("kernel32.dll"), "LoadLibraryA"), buffer, 0, 0), -1);
                VirtualFreeEx(handle, buffer, 0, (int)MEMORY_ACCESS_FLAGS.MEM_RELEASE);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Injection Error: FAILED!");
            }
            return false;
        }
     
    }
}
