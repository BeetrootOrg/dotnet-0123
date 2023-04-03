using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

Person northest = persons.MaxBy(p => p.Longitude);
var farthestPersons = persons
    .Join(
        persons,
        p => true,
        p => true,
        (p1, p2) => new { p1, p2 }
    )
    .Where(p => !ReferenceEquals(p.p1, p.p2))
    .Select(p => new
    {
        p.p1,
        p.p2,
        Distance = Math.Sqrt(Math.Pow(p.p1.Latitude - p.p2.Latitude, 2) + Math.Pow(p.p1.Longitude - p.p2.Longitude, 2))
    })
    .MaxBy(p => p.Distance);


var mostCommonAbout = persons
    .Join(
        persons,
        p => true,
        p => true,
        (p1, p2) => new { p1, p2 }
    )
    .Where(p => !ReferenceEquals(p.p1, p.p2))
    .Select(p =>
    {
        string[] about1 = p.p1.About.Split(' ');
        string[] about2 = p.p2.About.Split(' ');

        int commonWords = about1.Intersect(about2).Count();
        return new { p.p1, p.p2, commonWords };
    })
    .MaxBy(p => p.commonWords);

var bestFriends = persons
    .Join(
        persons,
        p => true,
        p => true,
        (p1, p2) => new { p1, p2 }
    )
    .Where(p => !ReferenceEquals(p.p1, p.p2))
    .Select(p =>
    {
        IEnumerable<string> friends1 = p.p1.Friends.Select(f => f.Name);
        IEnumerable<string> friends2 = p.p2.Friends.Select(f => f.Name);

        int commonFriends = friends1.Intersect(friends2).Count();
        return new { p.p1, p.p2, commonFriends };
    })
    .MaxBy(p => p.commonFriends);
