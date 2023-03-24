using System.IO;
using System.Xml.Serialization;

using ConsoleApp;

using Newtonsoft.Json;

using YamlDotNet.Serialization;

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

static void SerializeToYAML<T>(T obj, string filename)
{
    ISerializer serializer = new SerializerBuilder().Build();
    File.WriteAllText($"{filename}.yaml", serializer.Serialize(obj));
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
SerializeToJSON(str, "./json/str");
SerializeToJSON(money, "./json/float");
SerializeToJSON(arr, "./json/intarr");
SerializeToJSON(test, "./json/test");

SerializeToXML(number, "./xml/int");
SerializeToXML(isActive, "./xml/bool");
SerializeToXML(str, "./xml/str");
SerializeToXML(money, "./xml/float");
SerializeToXML(arr, "./xml/intarr");
SerializeToXML(test, "./xml/test");

SerializeToYAML(number, "./yaml/int");
SerializeToYAML(isActive, "./yaml/bool");
SerializeToYAML(str, "./yaml/str");
SerializeToYAML(money, "./yaml/float");
SerializeToYAML(arr, "./yaml/intarr");
SerializeToYAML(test, "./yaml/test");