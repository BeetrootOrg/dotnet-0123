using HumanResources;

Assistant assistant1 = new Assistant("Oleg", "Bojcov");
Console.WriteLine(assistant1.ToString());
Performer performer1 = (Performer)assistant1.ToPromote();
Console.WriteLine(performer1.ToString());
Manager manager1 = (Manager)performer1.ToPromote();
Console.WriteLine(manager1.ToString());
Boss boss1 = (Boss)manager1.ToPromote();
Console.WriteLine(boss1.ToString());
