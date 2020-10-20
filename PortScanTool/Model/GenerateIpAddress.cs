using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PortScanTool.Model
{
    public static class GenerateIpAddress
    {
        private const int MAX_PORT = 65535;
        public static List<IPAddress> GetFromRange(string fromIP, string toIp)
        {
            var start = IPAddress.Parse(fromIP).GetAddressBytes();
            var end = IPAddress.Parse(toIp).GetAddressBytes();
            var addresses = new List<IPAddress>();
            for (var i = start[0]; i <= end[0]; i++)
                for (var j = start[1]; j <= end[1]; j++)
                    for (var k = start[2]; k <= end[2]; k++)
                        for (var l = start[3]; l <= end[3]; l++)
                            addresses.Add(new IPAddress(new[] { i, j, k, l }));
            return addresses;
        }

        public static List<Tuple<T, int>> AddPort<T>(this List<T> source)
        {
            List<Tuple<T, int>> result = new List<Tuple<T, int>>();
            for (int i = 1; i <= MAX_PORT; i++)
            {
                foreach (var item in source)
                {
                    result.Add(new Tuple<T, int>(item, i));
                }
            }
            return result;
        }
    }
}
