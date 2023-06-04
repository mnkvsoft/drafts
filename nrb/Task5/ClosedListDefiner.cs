using System.Collections.Generic;

namespace Task5;

static class ClosedListDefiner
{
    public static bool IsClosed(OneWayLinkedList items)
    {
        var visitedItems = new List<object>();

        foreach (var item in items)
        {
            if (visitedItems.Contains(item))
                return true;
            visitedItems.Add(item);
        }

        return false;
    }
}