// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

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
        var someCell = new SomeCell();
        someCell.Value = 42;

        // Act
        someCell.Value = 1337;

        // Assert
        Assert.That(1337, Is.EqualTo(someCell.Value));
    }
}
