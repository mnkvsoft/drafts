using System;
using System.Linq;
using NUnit.Framework;

namespace Task4;

public class TextDefiner_Tests
{
    public static TestCaseData[] Cases
    {
        get
        {
            return new[]
            {
                new TestCaseData("B***AC").Returns(1),
                new TestCaseData("").Returns(0),
                new TestCaseData("B***AC_B***AC").Returns(2),
                new TestCaseData("B***A**").Returns(0),
                new TestCaseData("_B***AC_B***AC_____B***AC_").Returns(3)
            };
        }
    }
    
    [TestCaseSource(nameof(Cases))]
    public int GetCountOfOccurrences_DifferentCases_ValidResult(string text)
    {
        return TextDefiner.GetCountOfOccurrences(text);
    }
    
    [Test]
    public void GetCountOfOccurrences_TextLengthExceeded_Exception()
    {
        string longText = new string(Enumerable.Repeat('*', (int)Math.Pow(2, 16) + 1).ToArray());
        Assert.Throws<ArgumentException>(() => TextDefiner.GetCountOfOccurrences(longText));
    }
}