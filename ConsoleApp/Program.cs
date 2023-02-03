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

int a = 10;
int b = (a == 10 ? 15 : 20); // if (a == 10) { b = 15 } else { b = 20 }
Console.WriteLine(b);

// POSSIBLE BUT NOT PREFERABLE
if (a == 10) 
    b = 15; 
else 
    b = 20;

Console.WriteLine("NUMBERS FROM 0 TO 9");
for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
}