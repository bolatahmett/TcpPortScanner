using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanTool.Model
{
    internal static class ProccessStatus
    {
        private static System.Windows.Forms.Label label;

        internal static void SetLabelCounter(System.Windows.Forms.Label label)
        {
            ProccessStatus.label = label;
        }

        internal static void SetStatus(string text)
        {
            label.Invoke(new Action(() => label.Text = text));
        }
    }
}
