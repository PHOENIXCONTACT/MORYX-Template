using MyApplication.Resources.MyResource;
using NUnit.Framework;

namespace MyApplication.Tests;

[TestFixture]
public class MyResourceTest
{
    [Test]
    public void ResourceKeepsValue()
    {
        // Arrange
        var myResource = new MyResource();
        myResource.Value = 42;

        // Act
        myResource.Value = 1337;

        // Assert
        Assert.That(1337, Is.EqualTo(myResource.Value));
    }
}
