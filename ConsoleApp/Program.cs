using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using ConsoleApp;



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
//foreach (var group in persons.GroupBy(p => p.Gender))
//{
//  Console.WriteLine($"There are {group.Count()} {group.Key.ToString().ToLower(CultureInfo.CurrentCulture)}s");
//}
foreach (IGrouping<Gender, Person> group in persons.GroupBy(p => p.Gender))
{
    string gender = group.Key.ToString().ToLower(CultureInfo.CurrentCulture);
    Console.WriteLine($"There are {group.Count()} {gender}s");
}

// var names = person.Select
IEnumerable<Name> names = persons.Select(p =>
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

// foreach (var group in nonUniqueNames)
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

Person theFriendestPerson = persons.MaxBy(p => p.Friends.Length);
Console.WriteLine($"Person with max friends number is {theFriendestPerson.Name} with {theFriendestPerson.Friends.Length} friends");

// 1st approach

//var friendestPeople1 = persons.GroupBy(p => p.Friends.Length)
IGrouping<int, Person> friendestPeople1 = persons.GroupBy(p => p.Friends.Length)
    .MaxBy(group => group.Key);

Console.WriteLine($"People with max friends number are {string.Join(", ", friendestPeople1.Select(p => p.Name))} with {friendestPeople1.Key} friends each");

// 2nd approach
int maxFriendsNumber = persons.Max(p => p.Friends.Length);
Person[] friendestPeople2 = persons.Where(p => p.Friends.Length == maxFriendsNumber).ToArray();

Console.WriteLine($"There are {friendestPeople2.Length} people with {maxFriendsNumber} of friends");

Console.WriteLine($"Everybody registered in past = {persons.All(p => p.Registered < DateTime.Now)}");
Console.WriteLine($"Anybody without friend = {persons.Any(p => p.Friends.Length == 0)}");

IEnumerable<Person> distinctByEyeColor = persons.DistinctBy(p => p.EyeColor);
Console.WriteLine($"{nameof(distinctByEyeColor)}.Count() = {distinctByEyeColor.Count()}");

Person firstPerson = persons.First();
Person firstWith4Friends = persons.First(p => p.Friends.Length == 4);

Console.WriteLine($"First = {firstPerson}");
Console.WriteLine($"First with 4 friend = {firstWith4Friends}");

Person firstWith6Friends = persons.FirstOrDefault(p => p.Friends.Length == 6);
Console.WriteLine($"First with 6 friend = {firstWith6Friends}");

Person personWithExactName = persons.Single(p => p.Name == "Holloway Meyers");
Console.WriteLine($"Person with exact name = {personWithExactName}");

Person orderedPerson = persons.OrderBy(x => x.Name).First();
Console.WriteLine($"First person = {orderedPerson}");

IEnumerable<Friend[]> allFriendsBad = persons.Select(x => x.Friends);
IEnumerable<Friend> allFriendsGood = persons.SelectMany(x => x.Friends);

// Homework

// 1

Person north = persons.MaxBy(p => p.Latitude);
Console.WriteLine($"{north.Name} is located farthest north: {north.Latitude}");

Person south = persons.MinBy(p => p.Latitude);
Console.WriteLine($"{south.Name} is located farthest south: {south.Latitude}");

Person east = persons.MaxBy(p => p.Longitude);
Console.WriteLine($"{east.Name} is located farthest east: {east.Longitude}");

Person west = persons.MinBy(p => p.Longitude);
Console.WriteLine($"{west.Name} is located farthest west: {west.Longitude}");

// 2

// var pairs =  Enumerable.Range(0, persons.Count() - 1);

// 3

var personsWithSameWords = persons.Join(
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
    .OrderBy(p => (p.SameAboutWords.Count()));

foreach (var item in personsWithSameWords)
{
    Console.WriteLine($"Person: {item.First.Name}");
    Console.WriteLine($"\tSame about words: {String.Join(", ", item.SameAboutWords.OrderBy(p => p))}");
} 

// 4

var personsWithSameFriends = persons.Join(
    persons, 
    p => true, 
    p => true, 
    (p1, p2) => new 
    {
        First = p1,
        Second = p2,
        Friends = p1.Friends.Select(p => p.Name).Intersect(p2.Friends.Select(p => p.Name))
    })
    .Where(p => !ReferenceEquals(p.First, p.Second))
    .Where(p => p.Friends.Count() > 0); 
 
foreach (var item in personsWithSameFriends)
{
    Console.WriteLine($"Person: {item.First.Name}");
    Console.WriteLine($"\tFriends: {String.Join(", ", item.Friends)}");
}