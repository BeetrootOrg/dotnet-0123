string name = "vviktor";
if (name == "Viktor")
{ Console.WriteLine($"name = {name}"); }

else if (name == "viktor")
{
    Console.WriteLine($"name = {name}");
}

else
{
    Console.WriteLine($"name is other = {name}");
}
System.Console.WriteLine("next operation");

switch (name)
{
    case "Viktor":
        { Console.WriteLine($"name = {name}"); }
        break;

    case "viktor":
        { Console.WriteLine("name = viktor"); }
        break;

    default:
        Console.WriteLine($"name is other = {name}");
        break;
}

int a = 11;
int b = (a == 10 ? 15 : 20);
Console.WriteLine(b);


for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
};


var sum = 0;
for (int i = 0; i <= 10; ++i)
{
    sum += i;
    }
    Console.WriteLine($"sum from 0 to 10 = {sum}");

Console.WriteLine("MULTIPLICATION");

var mul = 1;
for (int i = 1; i <= 10; ++i)
{
    mul *= i;
}
Console.WriteLine(mul);
