using MyApplication.Resources;
using NUnit.Framework;

namespace MyApplication.Tests;

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
        Assert.That(1337, Is.EqualTo(someResource.Value));
    }
}
