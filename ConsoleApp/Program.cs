using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Newtonsoft.Json;

static void SerializeToJSON<T>(T obj, string filename)
{
    File.WriteAllText($"{filename}.json", JsonConvert.SerializeObject(obj));
}

static void SerializeToXML<T>(T obj, string filename)
{
    XmlSerializer serializer = new(typeof(T));
    using FileStream file = File.Create($"{filename}.xml");
    serializer.Serialize(file, obj);
}

int number = 42;
bool isActive = true;
string str = "Hello world!";
decimal money = 42.5M;
int[] arr = new[] {1, 2, 3};

Test test = new()
{
    Number = 1,
    Money = 1.1m,
    Text = "Hello",
    IsActive = true,
    Numbers = new int[] { 1, 2, 3 },
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
SerializeToJSON(str, "./json/string");
SerializeToJSON(money, "./json/float");
SerializeToJSON(arr, "./json/intarr");
SerializeToJSON(test, "./json/test");

SerializeToXML(number, "./xml/int");
SerializeToXML(isActive, "./xml/bool");
SerializeToXML(str, "./xml/string");
SerializeToXML(money, "./xml/float");
SerializeToXML(arr, "./xml/intarr");
SerializeToXML(test, "./xml/test");

class Test
{
    public int Number { get; init; }
    public decimal Money { get; init; }
    public string Text { get; init; }
    public bool IsActive {get; init; }
    public IEnumerable<int> Numbers { get; init; } 
    public Inner[] Inners { get; init; }
    public object Null { get; init; }
}

class Inner
{
    public int InnerNumber { get; init; }
    public decimal InnerMoney { get; init; }
    public string InnerText { get; init; }
    public bool InnerIsActive {get; init; }
}