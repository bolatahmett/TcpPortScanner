using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanTool.Model
{
    public static class Scan
    {
        private static readonly List<Tuple<IPAddress, int>> inProccess = new List<Tuple<IPAddress, int>>();
        private static List<Tuple<IPAddress, int>> ipAdressWithPort = new List<Tuple<IPAddress, int>>();
        private static TrackBar trackBar;
        internal static Guid guid;
        private static ScanStatus scanStatus = ScanStatus.None;

        public static CancellationTokenSource cancellationToken = new CancellationTokenSource();

        private static readonly object _sync = new object();

        internal static void Run(List<IPAddress> ipAddresses)
        {
            scanStatus = ScanStatus.Running;
            cancellationToken = new CancellationTokenSource();
            ipAdressWithPort = ipAddresses.AddPort();
            int maxDoP = trackBar.Value;
            _ = ParalelScan.ParallelForEachAsync(ipAdressWithPort, CheckTcpPort, guid, maxDoP, cancellationToken.Token);
        }

        internal static void Cancel()
        {
            scanStatus = ScanStatus.Canceled;
            guid = Guid.NewGuid();
            cancellationToken.Cancel();
        }

        internal static void ReRun()
        {
            scanStatus = ScanStatus.Restarted;
            cancellationToken = new CancellationTokenSource();
            List<Tuple<IPAddress, int>> ipAdressWithPortEx = ipAdressWithPort.Except(inProccess).ToList();
            int maxDoP = trackBar.Value;
            _ = ParalelScan.ParallelForEachAsync(ipAdressWithPortEx, CheckTcpPort, guid, maxDoP, cancellationToken.Token);
        }

        internal static async Task CheckTcpPort(Tuple<IPAddress, int> ipAddressWithPort)
        {
            IPAddress ipAddress = ipAddressWithPort.Item1;
            int port = ipAddressWithPort.Item2;
            inProccess.Add(new Tuple<IPAddress, int>(ipAddress, port));

            try
            {
                using (var tcpClient = new TcpClient())
                {
                    await tcpClient.ConnectAsync(ipAddress, port);
                    lock (_sync)
                    {
                        FormHelper.AddItem(new Tuple<IPAddress, int>(ipAddress, port), true);
                    }
                }
            }
            catch (SocketException)
            {
                lock (_sync)
                {
                    FormHelper.AddItem(new Tuple<IPAddress, int>(ipAddress, port), false);
                }
            }

        }

        public static void SetTrackBar(TrackBar trackBar)
        {
            Scan.trackBar = trackBar;
        }

        internal static ScanStatus GetStatus()
        {
            return scanStatus;
        }
    }
}
