using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

Person northPerson = persons.Where(coord => coord.Latitude > 0).MaxBy(item => item.Latitude);

System.Console.WriteLine($"Northest person is {northPerson.Name}");

Person southPerson = persons.Where(coord => coord.Latitude < 0).MinBy(item => item.Latitude);

System.Console.WriteLine($"Southest person is {southPerson.Name}");

Person eastPerson = persons.Where(coord => coord.Longitude > 0).MaxBy(item => item.Longitude);

System.Console.WriteLine($"Eastest person is {eastPerson.Name}");

Person westPerson = persons.Where(coord => coord.Longitude < 0).MinBy(item => item.Longitude);

System.Console.WriteLine($"Westernest person is {westPerson.Name}");

var pairs = persons.SelectMany(x => persons, (x, y) => (x, y)).Where(tuple => tuple.Item1.Index < tuple.Item2.Index);

double Distance((Person p1, Person p2) tupleOfPersons)
{
    return Math.Sqrt(Math.Pow(tupleOfPersons.p1.Longitude - tupleOfPersons.p2.Longitude, 2) + Math.Pow(tupleOfPersons.p1.Latitude - tupleOfPersons.p2.Latitude, 2));
}

var maxDistance = pairs.MaxBy(item => Distance(item));
System.Console.WriteLine($"Max distance between {maxDistance.x.Name} and {maxDistance.y.Name}");

var minDistance = pairs.MinBy(item => Distance(item));
System.Console.WriteLine($"Min distance between {minDistance.x.Name} and {minDistance.y.Name}");

int CountSameWords((Person p1, Person p2) tupleOfPersons)
{
    string wordsPerson1 = new StringBuilder().Append(tupleOfPersons.p1.About).ToString();
    string wordsPerson2 = new StringBuilder().Append(tupleOfPersons.p2.About).ToString();
    HashSet<string> Person1Set = wordsPerson1.ToLower().Replace(".", "").Replace("\r", "").Replace("\n", "").Split(' ').ToHashSet();
    HashSet<string> Person2Set = wordsPerson2.ToLower().Replace(".", "").Replace("\r", "").Replace("\n", "").Split(' ').ToHashSet();
    HashSet<string> intersectionSet = new HashSet<string>(Person1Set);
    intersectionSet.IntersectWith(Person2Set);
    HashSet<string> unionSet = new HashSet<string>(Person1Set);
    unionSet.UnionWith(Person2Set);

    return (int)((double)intersectionSet.Count/(double)unionSet.Count);
}

var mostSameWords = pairs.MaxBy(item => CountSameWords(item));
System.Console.WriteLine($"The most same words in about have {mostSameWords.x.Name} and {mostSameWords.y.Name}");

bool SameFriends((Person p1, Person p2) tupleOfPersons)
{
    HashSet<string> names1 = tupleOfPersons.p1.Friends.Select(item => item.Name).ToHashSet();
    HashSet<string> names2 = tupleOfPersons.p2.Friends.Select(item => item.Name).ToHashSet();
    names1.IntersectWith(names2);
    return names1.Count!=0;
}

foreach (var item in pairs.Where(item => SameFriends(item)))
{
    System.Console.WriteLine($"{item.x.Name} and {item.y.Name} have same friends");
}