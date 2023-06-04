using System;
using System.Collections;
using System.Collections.Generic;

namespace Task5;

class OneWayLinkedList : IEnumerable<object>
{
    private OneWayLinkedListNode? _first;
    private OneWayLinkedListNode? _last;

    public void Add(OneWayLinkedListNode node)
    {
        if (_first == null)
        {
            _first = node;
            _last = node;
        }
        else
        {
            _last!.Next = node;
            _last = node;
        }
    }

    public void Add(object item)
    {
        if (_first == null)
        {
            _first = new OneWayLinkedListNode(item);
            _last = _first;
        }
        else
        {
            var newNode = new OneWayLinkedListNode(item);
            _last!.Next = newNode;
            _last = newNode;
        }
    }

    public IEnumerator<object> GetEnumerator()
    {
        return new OneWayLinkedListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class OneWayLinkedListEnumerator : IEnumerator<object>
    {
        private readonly OneWayLinkedList _list;

        public OneWayLinkedListEnumerator(OneWayLinkedList list)
        {
            _list = list;
        }

        private OneWayLinkedListNode? _currentNode;

        public bool MoveNext()
        {
            if (_currentNode == null)
            {
                if (_list._first == null)
                    return false;
                _currentNode = _list._first;
                return true;
            }

            if (_currentNode.Next == null)
                return false;

            _currentNode = _currentNode.Next;
            return true;
        }

        public void Reset()
        {
            _currentNode = null;
        }

        public object Current
        {
            get
            {
                if (_currentNode == null)
                    throw new InvalidOperationException("Need invoke MoveNext()");
                return _currentNode.Value;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}