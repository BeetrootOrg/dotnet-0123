using System;
using System.Collections.Generic;
using ConsoleApp;

namespace ConsoleApp.Tests;

public class ExtensionsTest
{
    private Example[] _collection;
    private Dictionary<int, List<Example>> _dictionary;

    [Fact]
    public void GroupByResultIsNotNull()
    {
        _collection = Examples.Collection();
        _dictionary = _collection.GroupBy(x => x.A);
        Assert.NotNull(_dictionary);
    }

    [Fact]
    public void GroupByResultIsEmpty()
    {
        _collection = Examples.EmptyCollection();
        _dictionary = _collection.GroupBy(x => x.A);
        Assert.Empty(_dictionary);
    }

     [Fact]
    public void GroupByResultThrowException()
    {
        _collection = null;
        Assert.Throws<ArgumentNullException>(() => _collection.GroupBy(x => x.A));
    }
}