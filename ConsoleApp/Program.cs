string name = "dima";

if (name == "Dima")
{
    Console.WriteLine("Hi, Dima");
}
else if (name == "dima")
{
    Console.WriteLine("Hi, dima");
}
else if (name == "dima")
{
    Console.WriteLine("Hi, DIMA");
}
else
{
    Console.WriteLine("Hi, not Dima");
}

Console.WriteLine("next operation");

Console.WriteLine("SWITCH/CASE");
switch (name)
{
case "Dima":
    Console.WriteLine("Hi, Dima");
    break;
case "dima":
    Console.WriteLine("Hi, dima");
    break;
default:
    Console.WriteLine("Hi, not Dima");
    break;
}