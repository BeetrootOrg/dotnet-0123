using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

Task t1 = DelayAMessage(TimeSpan.FromSeconds(1), "First message");
Task t2 = DelayAMessage(TimeSpan.FromSeconds(2), "Second message");
Task t3 = DelayAMessage(TimeSpan.FromSeconds(3), "Third message");
List<Task> tasks = new() { t1, t2, t3 };

while (tasks.Any())
{
    Task result = await Task.WhenAny(tasks);
    Console.WriteLine("One of tasks finished");
    _ = tasks.Remove(result);
}

static async Task DelayAMessage(TimeSpan delay, string message)
{
    await Task.Delay(delay);
    Console.WriteLine(message);
}