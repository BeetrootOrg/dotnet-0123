using System;
using System.Collections.Generic;
using Shouldly;

namespace ConsoleApp.UnitTests
{
    public class GroupByExtensionMethodTests
    {
        [Fact]
        public void GroupByEnumerableShouldReturnEmpty()
        {
            Person[] people = Array.Empty<Person>();
            IDictionary<Person, IEnumerable<Person>> result = people.GroupByEnumerable(x => x);
            result.Count.ShouldBe(0);
        }
        [Fact]
        public void GroupByEnumerableShouldWorkWithAnonymousTypes()
        {
            var list = new[]
            {
                new {Name = "Nick", Age = 32},
                new {Name = "Cole", Age = 54},
                new {Name = "Nick", Age = 12},
                new {Name = "Kendrick", Age = 22},
                new {Name = "Kanye", Age = 54}
            };
            var result = list.GroupByEnumerable(x => x.Name);
            result.Count.ShouldBe(4);
        }
        [Fact]
        public void GroupByEnumerableShouldReturnDictionary()
        {
            List<Person> ungrouped = new()
            {
                new Person("Aaron", "Bank of India"),
                new Person("Finn", "Amazon"),
                new Person("Bernard", "Canara Bank"),
                new Person("Asher", "Canara Bank"),
                new Person("Kate", "Bank of India"),
                new Person("Alice", "Amazon"),
            };
            List<Person> grouped = new()
            {
                new Person("Finn", "Amazon"),
                new Person("Alice", "Amazon"),
                new Person("Aaron", "Bank of India"),
                new Person("Kate", "Bank of India"),
                new Person("Bernard", "Canara Bank"),
                new Person("Asher", "Canara Bank"),
            };
            IDictionary<string, IEnumerable<Person>> result = ungrouped.GroupByEnumerable(x => x.Company);

            result.Count.ShouldBe(3);
        }

        [Fact]
        public void GroupByEnumberableShouldThrowException()
        {
            Action action = () => EnumerableExtensions.GroupByEnumerable<string, string>(null, x => x);
            _ = action.ShouldThrow<NullReferenceException>();
        }
        internal record class Person(string Name, string Company);
    }
}