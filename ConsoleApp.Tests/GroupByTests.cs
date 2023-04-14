using Shouldly;

namespace ConsoleApp.Tests
{
    public class GroupByTests
    {
        [Fact]
        public void GroupByShouldThrowNullReferenceException()
        {
            Action act = () => EnumerableExtensions.GroupBy<int, int>(null, x => x);
            _ = act.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void GroupByShouldGroupCorrectly()
        {
            int[] collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IDictionary<int, IEnumerable<int>> result = collection.GroupBy(x => x % 2);
            result.Count.ShouldBe(2);
            result[0].ShouldBe(new[] { 2, 4, 6, 8, 10 });
            result[1].ShouldBe(new[] { 1, 3, 5, 7, 9 });
        }

        [Fact]
        public void GroupByShouldWorkWithAnonymousObject()
        {
            var collection = new[]
            {
                new { Name = "John", Age = 20 },
                new { Name = "Jane", Age = 21 },
                new { Name = "Jack", Age = 22 },
                new { Name = "Jill", Age = 23 },
                new { Name = "Joe", Age = 24 },
                new { Name = "Jen", Age = 25 },
                new { Name = "Jim", Age = 26 },
                new { Name = "Jenny", Age = 27 },
                new { Name = "Jenny", Age = 28 },
                new { Name = "Jenny", Age = 29 },
            };
            var result = collection.GroupBy(x => x.Name);
            result.Count.ShouldBe(8);
        }

        [Fact]
        public void GroupByShouldWorkWithEmptyCollection()
        {
            int[] collection = Array.Empty<int>();
            IDictionary<int, IEnumerable<int>> result = collection.GroupBy(x => x % 2);
            result.Count.ShouldBe(0);
        }
    }
}