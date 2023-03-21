using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

System.Console.WriteLine(persons.Count());
