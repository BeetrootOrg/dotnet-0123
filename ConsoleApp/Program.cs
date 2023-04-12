using System;

using ConsoleApp;

Person[] people =
{
      new Person("Aaron", "Bank of India"), // 3
      new Person("Finn", "Amazon"), // 1
      new Person("Bernard", "Canara Bank"), // 5 
      new Person("Asher", "Canara Bank"), // 6
      new Person("Kate", "Bank of India"), // 4
      new Person("Alice", "Amazon"), // 2
  };

var companies = people.GroupByEnumerable(p => p.Company);
foreach (var company in companies)
{
    Console.WriteLine(company.Key);
    foreach (var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine();
}

record class Person(string Name, string Company);



