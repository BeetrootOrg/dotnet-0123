using System;
using System.Collections.Generic;

using ConsoleApp;

Person[] people =
{
      new Person("Aaron", "Bank of India"),
      new Person("Finn", "Amazon"),
      new Person("Bernard", "Canara Bank"),
      new Person("Asher", "Canara Bank"),
      new Person("Kate", "Bank of India"),
      new Person("Alice", "Amazon"),
  };

IDictionary<string, IEnumerable<Person>> companies = people.GroupByEnumerable(p => p.Company);
foreach (KeyValuePair<string, IEnumerable<Person>> company in companies)
{
    Console.WriteLine(company.Key);
    foreach (Person? person in company.Value)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine();
}

internal record class Person(string Name, string Company);



