using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

Person northernmostPerson = persons.Where(coord => coord.Latitude > 0)
                                .MaxBy(item => item.Latitude);
System.Console.WriteLine($"Northernmost person is {northernmostPerson.Name}"
                           + $"with {northernmostPerson.Latitude} latitude and {northernmostPerson.Longitude} longuitude");

Person southernmostPerson = persons.Where(coord => coord.Latitude < 0)
                                .MinBy(item => item.Latitude);
System.Console.WriteLine($"southernmost person is {southernmostPerson.Name}"
                           + $"with {southernmostPerson.Latitude} latitude and {southernmostPerson.Longitude} longuitude");

Person easternmostPerson = persons.Where(coord => coord.Longitude > 0)
                                .MaxBy(item => item.Longitude);
System.Console.WriteLine($"easternmost person is {easternmostPerson.Name}"
                           + $"with {easternmostPerson.Latitude} latitude and {easternmostPerson.Longitude} longuitude");

Person westernmostPerson = persons.Where(coord => coord.Longitude < 0)
                                .MinBy(item => item.Longitude);
System.Console.WriteLine($"westernmost person is {westernmostPerson.Name}"
                           + $"with {westernmostPerson.Latitude} latitude and {westernmostPerson.Longitude} longuitude");


var pairsOfPersons = persons.SelectMany(x => persons, (x, y) => (x, y))
                       .Where(tuple => tuple.Item1.Index < tuple.Item2.Index);


//   Max/Min distance
double GetDistanceBetweenPersons((Person person1, Person person2) tupleOfPersons)
{
    return Math.Sqrt(Math.Pow(tupleOfPersons.person1.Longitude - tupleOfPersons.person2.Longitude, 2) +
            Math.Pow(tupleOfPersons.person1.Latitude - tupleOfPersons.person2.Latitude, 2));
}


var maxDistanceBetweenPersons = pairsOfPersons.MaxBy(item => GetDistanceBetweenPersons(item));
System.Console.WriteLine($"Max distance between {maxDistanceBetweenPersons.x.Name} & {maxDistanceBetweenPersons.y.Name}"+
                            $" with distance {GetDistanceBetweenPersons(maxDistanceBetweenPersons)}");

var minDistanceBetweenPersons = pairsOfPersons.MinBy(item => GetDistanceBetweenPersons(item));
System.Console.WriteLine($"Min distance between {minDistanceBetweenPersons.x.Name} & {minDistanceBetweenPersons.y.Name}"+
                            $" with distance {GetDistanceBetweenPersons(minDistanceBetweenPersons)}");


//  Most same words
double GetAboutMostSameWords((Person person1, Person person2) tupleOfPersons)
{
    string about1 = new StringBuilder().Append(tupleOfPersons.person1.About).ToString();
    string about2 = new StringBuilder().Append(tupleOfPersons.person2.About).ToString();
    HashSet<string> about1Set = about1.ToLower().Replace(".", "").Replace("\r", "").Replace("\n", "").Split(' ').ToHashSet();
    HashSet<string> about2Set = about2.ToLower().Replace(".", "").Replace("\r", "").Replace("\n", "").Split(' ').ToHashSet();
    HashSet<string> intersectionSet = new HashSet<string>(about1Set);
    intersectionSet.IntersectWith(about2Set);
    HashSet<string> unionSet = new HashSet<string>(about1Set);
    unionSet.UnionWith(about2Set);
    return (double)intersectionSet.Count/(double)unionSet.Count;
}

var theMostSameWordsInAbout = pairsOfPersons.MaxBy(item => GetAboutMostSameWords(item));
System.Console.WriteLine($"The most same words in about have {theMostSameWordsInAbout.x.Name} & {theMostSameWordsInAbout.y.Name}"+
                            $" with similarity {GetAboutMostSameWords(theMostSameWordsInAbout)}");

// Persons with same friends

bool HaveSameFriendWithOther((Person person1, Person person2) tupleOfPersons)
{
    HashSet<string> names1 = tupleOfPersons.person1.Friends.Select(item => item.Name).ToHashSet();
    HashSet<string> names2 = tupleOfPersons.person2.Friends.Select(item => item.Name).ToHashSet();
    names1.IntersectWith(names2);
    return names1.Count!=0;
}

var personsWhoHaveSameFriends = pairsOfPersons.Where(item => HaveSameFriendWithOther(item));

foreach (var item in personsWhoHaveSameFriends)
{
    System.Console.WriteLine($"{item.x.Name} & {item.y.Name} have same friends");
}