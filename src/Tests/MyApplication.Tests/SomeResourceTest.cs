using MyApplication.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Tests
{
    [TestFixture]
    public class SomeResourceTest
    {
        [Test]
        public void ResourceKeepsValue()
        {
            // Arrange
            var someResource = new SomeResource();
            someResource.Value = 42;

            // Act
            someResource.Value = 1337;

            // Assert
            Assert.AreEqual(1337, someResource.Value);
        }
    }
}
