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
            Tuple<bool, string> canBeRun = CanBeRun();
            if (canBeRun.Item1)
            {
                ClearResults();
                ProccessStatus.SetStatus("Generating Ip Address...");
                //List<IPAddress> ipAddressItems = GenerateIpAddress.GetFromRange("213.74.123.67", "213.74.123.67");
                List<IPAddress> ipAddressItems = GenerateIpAddress.GetFromRange(StartedIp.Text.Replace(" ", ""), EndIp.Text.Replace(" ", ""));
                ProccessStatus.SetStatus("Scanning...");
                Scan.Run(ipAddressItems);
            }
            else
            {
                MessageBox.Show(canBeRun.Item2);
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
            if (isScrool && Scan.GetStatus() == ScanStatus.Running)
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
                MessageBox.Show("Tool is already stoped");
            }
        }

        private Tuple<bool, string> CanBeRun()
        {
            string firstIp = IPValidator.Parse(StartedIp.Text);
            string secondtIp = IPValidator.Parse(EndIp.Text);
            if (string.IsNullOrWhiteSpace(firstIp) || string.IsNullOrWhiteSpace(secondtIp))
            {
                return new Tuple<bool, string>(false, "Ipaddress is not valid. Please input valid ip addrres.");
            }
            return new Tuple<bool, string>((Scan.GetStatus() == ScanStatus.None || Scan.GetStatus() == ScanStatus.Canceled), "Tool is already running."); ;
        }

        private bool CanBeTerminate()
        {
            return Scan.GetStatus() == ScanStatus.Running || Scan.GetStatus() == ScanStatus.Restarted;
        }

        private void ClearItems_Click(object sender, EventArgs e)
        {
            ClearResults();
        }

        void StartedIp_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                 
                    e.Cancel = true;
            }
            
        }
        void EndIp_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {

        }
    }
}
