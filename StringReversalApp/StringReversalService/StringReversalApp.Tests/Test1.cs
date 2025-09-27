using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringReversalApp.Tests;

[TestClass]
public sealed class StringReverserTests
{
    [TestMethod]
    public void Reverse_WithNormalString_ReturnsReversed()
    {
        // Arrange
        var reverser = new global::StringReverser();
        var input = "Hello World";

        // Act
        var result = reverser.Reverse(input);

        // Assert
        Assert.AreEqual("dlroW olleH", result);
    }

    [TestMethod]
    public void Reverse_WithEmptyString_ReturnsEmpty()
    {
        var reverser = new global::StringReverser();
        var result = reverser.Reverse(string.Empty);
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void Reverse_WithNull_ReturnsEmpty()
    {
        var reverser = new global::StringReverser();
        var result = reverser.Reverse(null!);
        Assert.AreEqual(string.Empty, result);
    }
}
