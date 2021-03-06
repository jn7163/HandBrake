﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UwpDetect.cs" company="HandBrake Project (http://handbrake.fr)">
//   This file is part of the HandBrake source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//  Helper class to detect if we are running in a UWP container.
//  https://msdn.microsoft.com/en-us/library/windows/desktop/hh446599(v=vs.85).aspx
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HandBrakeWPF.Utilities
{
    using System;
    using System.Runtime.InteropServices;

    public class UwpDetect
    {
        [DllImport("kernel32.dll")]
        static extern int GetCurrentPackageFullName(ref int length, IntPtr fullName);

        public static bool IsUWP()
        {
            if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor <= 1)
            {
                return false;
            }

            int length = 0;
            IntPtr name = IntPtr.Zero;
            GetCurrentPackageFullName(ref length, name); // Only available in 6.2 or later.

            if (length > 0)
            {
                return true;
            }

            return false;
        }
    }
}
