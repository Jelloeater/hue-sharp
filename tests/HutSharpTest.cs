using System;
using libs;
using Xunit;


namespace HueSharpTest
{
    public class HutSharpTest
    {
        /// Test to make sure we have a valid API call and get a non-empty string
        [Fact]
        public void TestNewLight()
        {
            var light = new Light(1);
            Assert.NotEmpty(light.Name);
        }
    }
}