using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PortScanTool.Model
{
    public class IPValidator
    {
        public static string Parse(string input)
        {
            input = input.Replace(" ", "");
            IPAddress address;
            if (IPAddress.TryParse(input, out address))
            {
                return address.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
