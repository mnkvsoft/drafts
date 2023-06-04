using System;
using NUnit.Framework;

namespace Task1;

public class Sorter_Tests
{
    public static TestCaseData[] Cases
    {
        get
        {
            return new TestCaseData[]
            {
                new(
                    new[] { 8, 2, 9, 4, 9, 0 },
                    new[] { 0, 2, 4, 8, 9, 9 }),
                new(
                    new[] { 1, 0, 0 },
                    new[] { 0, 0, 1 }),
                new(
                    new[] { 9, 9, 8 },
                    new[] { 8, 9, 9 }),
                new(
                    new[] { 1 },
                    new[] { 1 }),
                new(
                    Array.Empty<int>(),
                    Array.Empty<int>())
            };
        }
    }

    [TestCaseSource(nameof(Cases))]
    public void Sort_DifferentCases_ValidResult(int[] values, int[] expected)
    {
        Sorter.Sort(values);

        Assert.That(values, Is.EquivalentTo(expected));
    }
}