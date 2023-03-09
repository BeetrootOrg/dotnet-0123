using ConsoleApp;

Assistant assistant = new Assistant("John", "Doe");
Console.WriteLine(assistant);
Console.WriteLine(assistant.Promotion());

Performer performer = assistant.Promote();
Console.WriteLine(performer);
Console.WriteLine(performer.Promotion());
Console.WriteLine(performer.GetType());

Manager manager = performer.Promote();
Console.WriteLine(manager);
Console.WriteLine(manager.Promotion());

Boss boss = manager.Promote();
Console.WriteLine(boss);
Console.WriteLine(boss.Promotion());
