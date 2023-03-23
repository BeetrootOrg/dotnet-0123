using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleApp;
using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

// 1. Find out who is located farthest north/south/west/east using latitude/longitude data
Person northest = persons.MaxBy(p => p.Latitude);
Console.WriteLine($"Northest person: {northest.Name}; Latitude: {northest.Latitude}");

Person southest = persons.MinBy(p => p.Latitude);
Console.WriteLine($"Southest person: {southest.Name}; Latitude: {southest.Latitude}");

Person eastest = persons.MaxBy(p => p.Longitude);
Console.WriteLine($"Eastest person: {eastest.Name}; Latitude: {eastest.Longitude}");

Person westest = persons.MinBy(p => p.Longitude);
Console.WriteLine($"Westest person: {westest.Name}; Longitude: {westest.Latitude}");


// 2. Find max and min distance between 2 persons


// 3. Find 2 persons whos ‘about’ have the most same words
var personsWithMostSameAboutWords = persons.Join(
    persons, 
    p => true, 
    p => true, 
    (p1, p2) => new 
    {
        First = p1,
        Second = p2, 
        SameAboutWords = p1.About.Split(" ").Intersect(p2.About.Split(" "))
    })
    .Where(p => !ReferenceEquals(p.First, p.Second))
    .OrderByDescending(p => (p.SameAboutWords.Count()))
    .Take(2);

foreach (var item in personsWithMostSameAboutWords)
{
    Console.WriteLine($"Person: {item.First.Name}");
    Console.WriteLine($"\tSame about words: {String.Join(", ", item.SameAboutWords.OrderBy(p => p))}");
} 


// 4. Find persons with same friends (compare by friend’s name)
var personsWithSameFriends = persons.Join(
    persons, 
    p => true, 
    p => true, 
    (p1, p2) => new 
    {
        First = p1,
        Second = p2,
        SameFriends = p1.Friends.Select(p => p.Name).Intersect(p2.Friends.Select(p => p.Name))
    })
    .Where(p => !ReferenceEquals(p.First, p.Second))
    .Where(p => p.SameFriends.Count() > 0); 
 
foreach (var item in personsWithSameFriends)
{
    Console.WriteLine($"Person: {item.First.Name}");
    Console.WriteLine($"\tFriends: {String.Join(", ", item.SameFriends)}");
}
