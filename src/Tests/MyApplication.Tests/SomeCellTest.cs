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
    public class SomeCellTest
    {
        [Test]
        public void ResourceKeepsValue()
        {
            // Arrange
            var someCell = new SomeCell();
            someCell.Value = 42;

            // Act
            someCell.Value = 1337;

            // Assert
            Assert.AreEqual(1337, someCell.Value);
        }
    }
}
