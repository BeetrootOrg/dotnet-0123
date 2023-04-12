using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

var t1 = DelayAMessage(TimeSpan.FromSeconds(1), "First message");
var t2 = DelayAMessage(TimeSpan.FromSeconds(2), "Second message");
var t3 = DelayAMessage(TimeSpan.FromSeconds(3), "Third message");
var tasks = new List<Task> {t1, t2, t3};

// Stopwatch sw = new();

// sw.Start();
while (tasks.Any())
{
// await Task.WhenAll(t1, t2, t3);
    var result = await Task.WhenAny(tasks);
    Console.WriteLine("One task finished ");
    tasks.Remove(result);
}
// Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}");

static async Task DelayAMessage(TimeSpan delay, string message)
{
    await Task.Delay(delay);
    Console.WriteLine(message);
}