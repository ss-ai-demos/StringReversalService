// This file contains unit tests for the StringReverser class. It uses NUnit to verify the correctness of the string reversal functionality.
using NUnit.Framework;

[TestFixture]
public class StringReverserTests
{
    private StringReverser _stringReverser;

    [SetUp]
    public void Setup()
    {
        _stringReverser = new StringReverser();
    }

    [Test]
    public void Reverse_WhenCalledWithNormalString_ReturnsReversedString()
    {
        var result = _stringReverser.Reverse("hello");
        Assert.AreEqual("olleh", result);
    }

    [Test]
    public void Reverse_WhenCalledWithEmptyString_ReturnsEmptyString()
    {
        var result = _stringReverser.Reverse("");
        Assert.AreEqual("", result);
    }

    [Test]
    public void Reverse_WhenCalledWithSingleCharacter_ReturnsSameCharacter()
    {
        var result = _stringReverser.Reverse("a");
        Assert.AreEqual("a", result);
    }

    [Test]
    public void Reverse_WhenCalledWithPalindrome_ReturnsSameString()
    {
        var result = _stringReverser.Reverse("madam");
        Assert.AreEqual("madam", result);
    }

    [Test]
    public void Reverse_WhenCalledWithWhitespace_ReturnsWhitespaceReversed()
    {
        var result = _stringReverser.Reverse("  ");
        Assert.AreEqual("  ", result);
    }
}