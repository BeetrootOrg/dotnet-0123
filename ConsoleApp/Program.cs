using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

Console.WriteLine($"People count = {persons.Count()}");

Func<Person, bool> malePredicate = (Person p) => p.Gender is Gender.Male;

Console.WriteLine($"Male count = {persons.Count(malePredicate)}");
Console.WriteLine($"Female count = {persons.Count(p => p.Gender is Gender.Female)}");

int youngestAge = persons.Min(p => p.Age);
Person youngest = persons.MinBy(p => p.Age);

Console.WriteLine($"Youngest age = {youngestAge}");
Console.WriteLine($"Youngest person = {youngest}");
Console.WriteLine($"Youngest person name = {youngest.Name}");

int oldestAge = persons.Max(p => p.Age);
Person oldest = persons.MaxBy(p => p.Age);

Console.WriteLine($"Oldest age = {oldestAge}");
Console.WriteLine($"Oldest person = {oldest}");
Console.WriteLine($"Oldest person name = {oldest.Name}");

double averageAge = persons.Average(p => p.Age);
Console.WriteLine($"Average age = {averageAge}");

foreach (IGrouping<string, Person> group in persons.GroupBy(p => p.EyeColor))
{
    Console.WriteLine($"There are {group.Count()} with {group.Key} eye color");
}

foreach (IGrouping<Gender, Person> group in persons.GroupBy(p => p.Gender))
{
    string gender = group.Key.ToString().ToLower(CultureInfo.CurrentCulture);
    Console.WriteLine($"There are {group.Count()} {gender}s");
}

IEnumerable<Name> names = persons
    .Select(p =>
    {
        string[] splitted = p.Name.Split(' ');
        return new Name
        {
            FirstName = splitted[0],
            LastName = splitted[1]
        };
    })
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, names));

IEnumerable<IGrouping<string, string>> nonUniqueNames = names.Select(n => n.FirstName)
    .GroupBy(x => x)
    .Where(group => group.Count() > 1);

foreach (IGrouping<string, string> group in nonUniqueNames)
{
    Console.WriteLine($"Name {group.Key} appeared {group.Count()} times");
}

foreach (var group in persons.Join(
                                    persons,
                                    p => true,
                                    p => true,
                                    (p1, p2) => new
                                    {
                                        First = p1,
                                        Second = p2
                                    }
                                ).Where(group => !ReferenceEquals(group.First, group.Second))
                                .Where(group => group.First.Company == group.Second.Company))
{
    Console.WriteLine($"Potential coleagues are {group.First.Name} and {group.Second.Name}");
}