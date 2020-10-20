using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace PortScanTool.UnitTest.Model
{
    public class IPValidatorTest
    {
        [Theory]
        [InlineData("192.168.1.1")]
        public void Parse_ReturnTrue(string ipAddress)
        {
            string result = PortScanTool.Model.IPValidator.Parse(ipAddress);
            Assert.NotNull(result);
        }

        [Fact]
        public void Parse_ReturnNull()
        {
            string result = PortScanTool.Model.IPValidator.Parse("232323");
            Assert.NotNull(result);
        }
    }
}
