using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace PortScanTool.Model
{
    internal static class FormHelper
    {
        private static readonly object _sync = new object();
        private static ListBox failedBox;
        private static ListBox passedBox;

        public static void AddItem(Tuple<IPAddress, int> item, bool isPassed)
        {
            lock (_sync)
            {
                ListBox listBox = isPassed ? passedBox : failedBox;
                AddItem(item, listBox);
            }
        }

        private static void AddItem(Tuple<IPAddress, int> item, ListBox listBox)
        {
            listBox.Invoke(new Action(() => listBox.Items.Add(item)));
            listBox.Invoke(new Action(() => listBox.SelectedIndex = listBox.Items.Count - 1));
        }

        public static void SetFailedBox(ListBox listBox)
        {
            failedBox = listBox;
        }
        public static void SetPassedBox(ListBox listBox)
        {
            passedBox = listBox;
        }
    }
}
