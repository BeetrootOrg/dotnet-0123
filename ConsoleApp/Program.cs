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