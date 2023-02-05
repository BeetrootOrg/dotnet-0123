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

mul = 1;
int j = 1;
while (j <= 10)
{
    mul *= j++;

}
Console.WriteLine(mul);


// for (;;) -- можна опускати аргументи


mul = 1;
j = 1;
do mul *= j++;
while (j <= 10);

Console.WriteLine(mul);

while (false)
{
    Console.WriteLine("never here");
}

do {
    Console.WriteLine("only once");
    }
while (false);

sum = 0;
for (int i = 0; i <= 42; i += 2)
{
sum += i;
}
Console.WriteLine($"sum of even from 0 to 42 = {sum}");

sum = 0;
for (int i = 1; i <= 42; i += 2)
{
sum += i;
}
Console.WriteLine($"sum of odd from 0 to 42 = {sum}");

sum = 0;
for (int i = 0; i <= 42; ++i)
{
sum += i;
}
Console.WriteLine($"sum from 0 to 42 = {sum}");