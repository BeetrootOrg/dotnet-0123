using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

var t1 = DelayAMessage(TimeSpan.FromSeconds(1), "First message");
var t2 = DelayAMessage(TimeSpan.FromSeconds(2), "Second message");
var t3 = DelayAMessage(TimeSpan.FromSeconds(3), "Third message");

Stopwatch sw = new();

sw.Start();
await Task.WhenAll(t1, t2, t3);
sw.Stop();

Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}");

static async Task DelayAMessage(TimeSpan delay, string message)
{
    await Task.Delay(delay);
    Console.WriteLine(message);
}