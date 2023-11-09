using System;
using System.IO;
using System.Runtime.InteropServices;

namespace md2cs.Helpers
{
    public static class OpenFileHelper
    {
        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static bool OpenAndSelect(string path)
        {
            if (IsMacOS())
            {
                OpenAndSelectMac(path);
                return true;
            }

            if (IsWindows())
            {
                OpenAndSelectWindows(path);
                return true;
            }

            if (IsLinux())
            {
                OpenLinux(path);
                return true;
            }

            return false;
        }

        public static void OpenAndSelectMac(string path)
        {
            var openInsideDirectory = false;

            var macPath = path.Replace("\\", "/"); // Mac finder doesn't like backward slashes

            if (Directory.Exists(macPath)) // if path requested is a directory, automatically open inside that directory
            {
                openInsideDirectory = true;
            }

            if (!macPath.StartsWith("\""))
            {
                macPath = "\"" + macPath;
            }
            if (!macPath.EndsWith("\""))
            {
                macPath += "\"";
            }
            var arguments = (openInsideDirectory ? "" : "-R ") + macPath;
            //Debug.Log("arguments: " + arguments);
            try
            {
                System.Diagnostics.Process.Start("open", arguments);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                // tried to open mac finder in windows
                // just silently skip error
                e.HelpLink = ""; // do anything with this variable to silence warning about not using it
            }
        }

        public static void OpenAndSelectWindows(string path)
        {
            var openInsideDirectory = false;

            var winPath = path.Replace("/", "\\"); // Windows explorer doesn't like forward slashes

            if (Directory.Exists(winPath)) // if path requested is a directory, automatically open inside that directory
            {
                openInsideDirectory = true;
            }
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", (openInsideDirectory ? "/root," : "/select,") + winPath);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                // tried to open win explorer in mac
                // just silently skip error
                e.HelpLink = ""; // do anything with this variable to silence warning about not using it
            }
        }

        public static void OpenLinux(string path)
        {
            var linuxPath = path.Replace("\\", "/"); // Linux doesn't like backward slashes in paths
            
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = linuxPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}

