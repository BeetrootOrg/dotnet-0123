using System;
using System.Collections.Generic;
using System.IO;

using ConsoleApp;

using Newtonsoft.Json;

IEnumerable<Person> persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
Console.WriteLine(string.Join(Environment.NewLine, persons));
