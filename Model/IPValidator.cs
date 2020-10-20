using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PortScanTool.Model
{
    public class IPValidator
    {
        public static IPValidator Parse(string input)
        {
            string pattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            if (Regex.IsMatch(input, pattern))
                return new IPValidator();
            else throw new ArgumentException(input);
        }
    }
}
