using Microsoft.Extensions.Logging;
using OpenTracing;
using PortScanTool.Model;
using PortScanTool.Model.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanTool
{
    public partial class PortScan : Form
    {

        private bool isScrool = false;

        private readonly ILogger _logger;
        private readonly ITracer _tracer;
        public PortScan(ILogger<PortScan> logger, ITracer tracer)
        {
            _logger = logger;
            _tracer = tracer;
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> canBeRun = CanBeRun();
            if (canBeRun.Item1)
            {
                ClearResults();
                ProccessStatus.SetStatus("Generating Ip Address...");
                List<IPAddress> ipAddressItems = GenerateIpAddress.GetFromRange(StartedIp.Text.Replace(" ", ""), EndIp.Text.Replace(" ", ""));
                ProccessStatus.SetStatus("Scanning...");
                Scan.Run(ipAddressItems);
            }
            else
            {
                MessageBox.Show(canBeRun.Item2);
                _logger.LogError(canBeRun.Item2);
            }
        }
        private void ClearResults()
        {
            failedItems.Items.Clear();
            passedItems.Items.Clear();
        }

        private void ThreadTrackBar_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(threadTrackBar, threadTrackBar.Value.ToString());
            isScrool = true;
        }

        private void ThreadTrackBar_MouseLeave(object sender, EventArgs e)
        {
            if (isScrool && (Scan.GetStatus() == ScanStatus.Running || Scan.GetStatus() == ScanStatus.Restarted))
            {
                isScrool = false;
                Scan.Cancel();
                Scan.ReRun();
                ProccessStatus.SetStatus("Scanning...");
            }
        }

        private void PortScan_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(threadTrackBar, threadTrackBar.Value.ToString());
            FormHelper.SetFailedBox(failedItems);
            FormHelper.SetPassedBox(passedItems);
            Scan.SetTrackBar(threadTrackBar);
            ProccessStatus.SetLabelCounter(ProccessValue);
        }

        private void Terminate_Click(object sender, EventArgs e)
        {
            if (CanBeTerminate())
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                ProccessStatus.SetStatus("Terminated...");
                Scan.Cancel();
            }
            else
            {
                string message = "Tool is already stoped";
                MessageBox.Show(message);
                LogHelper.Log(_tracer, message);
            }
        }

        private Tuple<bool, string> CanBeRun()
        {
            string firstIp = IPValidator.Parse(StartedIp.Text);
            string secondtIp = IPValidator.Parse(EndIp.Text);
            if (string.IsNullOrWhiteSpace(firstIp) || string.IsNullOrWhiteSpace(secondtIp))
            {
                string message = "Ipaddress is not valid. Please input valid ip addrres.";
                LogHelper.Log(_tracer, message);
                return new Tuple<bool, string>(false, message);
            }
            string messageRunning = "Tool is already running.";
            return new Tuple<bool, string>((Scan.GetStatus() == ScanStatus.None || Scan.GetStatus() == ScanStatus.Canceled), messageRunning);
        }

        private bool CanBeTerminate()
        {
            return Scan.GetStatus() == ScanStatus.Running || Scan.GetStatus() == ScanStatus.Restarted;
        }

        private void ClearItems_Click(object sender, EventArgs e)
        {
            ClearResults();
        }
    }
}
