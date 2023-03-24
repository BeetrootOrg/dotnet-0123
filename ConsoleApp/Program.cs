using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

static void SerializeToJSON<T>(T obj, string filename)
{
    File.WriteAllText($"{filename}.json", JsonConvert.SerializeObject(obj));
}

int number = 42;
bool isActive = true;
string str = "Hello, world!";
decimal money = 42.5M;
int[] arr = new[] { 1, 2, 3 };
Test test = new()
{
    Number = 1,
    Money = 1.1m,
    Text = "Hello",
    IsActive = true,
    Numbers = new List<int> { 1, 2, 3 },
    Inners = new Inner[]
    {
        new Inner
        {
            InnerNumber = 1,
            InnerMoney = 1.1m,
            InnerText = "Hello",
            InnerIsActive = true
        },
        new Inner
        {
            InnerNumber = 2,
            InnerMoney = 2.2m,
            InnerText = "World",
            InnerIsActive = false
        }
    }
};

SerializeToJSON(number, "./json/int");
SerializeToJSON(isActive, "./json/bool");
SerializeToJSON(str, "./json/str");
SerializeToJSON(money, "./json/float");
SerializeToJSON(arr, "./json/intarr");
SerializeToJSON(test, "./json/test");

internal class Test
{
    public int Number { get; init; }
    public decimal Money { get; init; }
    public string Text { get; init; }
    public bool IsActive { get; init; }
    public IEnumerable<int> Numbers { get; init; }
    public Inner[] Inners { get; init; }
    public object Null { get; init; }
}

internal class Inner
{
    public int InnerNumber { get; init; }
    public decimal InnerMoney { get; init; }
    public string InnerText { get; init; }
    public bool InnerIsActive { get; init; }
}