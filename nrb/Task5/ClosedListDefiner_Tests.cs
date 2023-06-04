using NUnit.Framework;

namespace Task5;

public class ClosedListDefiner_Tests
{
    [Test]
    public void IsClosed_ClosedList_True()
    {
        var first = new OneWayLinkedListNode(new object());
        var loop = new OneWayLinkedListNode(new object())
        {
            Next = first
        };
        
        var items = new OneWayLinkedList
        {
            first,
            new object(),
            new object(),
            new object(),
            loop
        };

        Assert.True(ClosedListDefiner.IsClosed(items));
    }
    [Test]
    public void IsClosed_NotClosedList_False()
    {
        var items = new OneWayLinkedList
        {
            new object(),
            new object(),
            new object(),
        };

        Assert.False(ClosedListDefiner.IsClosed(items));
    }
}