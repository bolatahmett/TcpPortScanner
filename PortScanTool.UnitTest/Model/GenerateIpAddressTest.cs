using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PortScanTool.Model;

namespace PortScanTool.UnitTest.Model
{
    public class GenerateIpAddressTest
    {
        [Fact]
        public void GetFromRange_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PortScanTool.Model.GenerateIpAddress.GetFromRange(null, null)); 
        }

        [Theory]
        [InlineData("213.74.123.67", "213.74.123.70")]
        public void GetFromRange_ReturnItems(string fromIP, string toIp)
        {
            var result = PortScanTool.Model.GenerateIpAddress.GetFromRange(fromIP, toIp);

            Assert.NotNull(result);
        }

        [Fact]
        public void AddPort_ReturnItems()
        {
            Mock<List<int>> p = new Mock<List<int>>();
            var result =p.Object.AddPort();
            Assert.NotNull(result);
        }
    }
}
