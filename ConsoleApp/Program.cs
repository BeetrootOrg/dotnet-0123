using System;
using System.Collections.Generic;
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


int oldestAge = persons.Max(p => p.Age);
Person oldest = persons.MaxBy(p => p.Age);

Console.WriteLine($"Oldest age = {oldestAge}");
Console.WriteLine($"Oldest person = {oldest}");