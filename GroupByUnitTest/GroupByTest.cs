using System;
using System.Collections.Generic;
using ConsoleApp;
namespace GroupByUnitTest
{
    public class GroupByTest
    {
        [Fact]
        public void GroupBy_NullCollection_ThrowsArgumentNullException()
        {
            IEnumerable<int> collection = null;
            Func<int, int> selector = x => x;

            Assert.Throws<ArgumentNullException>(() => collection.GroupBy(selector));
        }

        [Fact]
        public void GroupBy_ReturnsCorrectDictionary()
        {
            List<int> collection = new List<int> { 1, 2, 2, 3, 3, 3 };
            Func<int, int> selector = x => x;

            Dictionary<int, List<int>> output = collection.GroupBy(selector);

            Assert.Equal(3, output.Count);
            Assert.Equal(new List<int> { 1 }, output[1]);
            Assert.Equal(new List<int> { 2, 2 }, output[2]);
            Assert.Equal(new List<int> { 3, 3, 3 }, output[3]);
        }

        [Fact]
        public void GroupBy_ReturnsCorrectDictionary_WithCustomSelector()
        {
            List<string> collection = new List<string> { "a", "bb", "ccc", "dddd" };
            Func<string, int> selector = x => x.Length;

            Dictionary<int, List<string>> output = collection.GroupBy(selector);

            Assert.Equal(4, output.Count);
            Assert.Equal(new List<string> { "a" }, output[1]);
            Assert.Equal(new List<string> { "bb" }, output[2]);
            Assert.Equal(new List<string> { "ccc" }, output[3]);
            Assert.Equal(new List<string> { "dddd" }, output[4]);
        }
    }
}