using PortScanTool.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanTool
{
    public partial class PortScan : Form
    {
        private bool isScrool = false;
        public PortScan()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            ProccessStatus.SetStatus("Generating Ip Address...");
            List<IPAddress> ipAddressItems = GenerateIpAddress.GetFromRange("213.74.123.67", "213.74.123.67");
            //List<IPAddress> ipAddressItems = GenerateIpAddress.GetFromRange(StartedIp.Text.Replace(" ",""), EndIp.Text.Replace(" ", ""));
            ProccessStatus.SetStatus("Scanning...");
            Scan.Run(ipAddressItems);
        }

        private void ThreadTrackBar_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(threadTrackBar, threadTrackBar.Value.ToString());
            isScrool = true;
        }

        private void ThreadTrackBar_MouseLeave(object sender, EventArgs e)
        {
            if (isScrool)
            {
                isScrool = false;
                Scan.Cancel();
                Scan.ReRun();
                ProccessStatus.SetStatus("Scanning...");
            }
        }

        private void PortScan_Load(object sender, EventArgs e)
        {
            FormHelper.SetFailedBox(failedItems);
            FormHelper.SetPassedBox(passedItems);
            Scan.SetTrackBar(threadTrackBar);
            ProccessStatus.SetLabelCounter(ProccessValue);
        }

        private void Terminate_Click(object sender, EventArgs e)
        {
            ProccessStatus.SetStatus("Terminated...");
            Scan.Cancel();
        }
    }
}
