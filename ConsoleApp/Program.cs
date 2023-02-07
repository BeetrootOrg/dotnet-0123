// homework/03-Conditions & Loops

/*
Create a program that will start with declaration of two constants (X and Y) and will count the sum of all numbers between these constants. 
If they are equal then sum should be one of them

Example:

X=10
Y=12
Sum=10+11+12=33

X=5
Y=2
Sum=2+3+4+5=14

X=10
Y=10
Sum=10

Extra:

Read values of X and Y from the console. If output is invalid - write to console Invalid input and exit the program.

*/
int x;
int y;
int suma;
string input;


// тут вводимо Х
for (; ; )
{
    Console.WriteLine("Enter X");
    input = Console.ReadLine();
    bool isOk = int.TryParse(input, out int x1);
    if (isOk)
    {
        x = x1;
        break;
    }
    else
    {
        Console.WriteLine("...");
        Console.WriteLine("try again");
        Console.WriteLine("...");
    }

}
// Console.WriteLine(x);


// тут вводимо У
for (; ; )
{
    Console.WriteLine("Enter У");
    input = Console.ReadLine();
    bool isOk = int.TryParse(input, out int y1);
    if (isOk)
    {
        y = y1;
        break;
    }
    else
    {
        Console.WriteLine("...");
        Console.WriteLine("try again");
        Console.WriteLine("...");
    }

}
// Console.WriteLine(y);


if (x == y)
{
    suma = x;
}
else
{
int maximum = Math.Max (x, y);
int minimum = Math.Min (x, y);

for (int i = minimum, i = maximum, ++i)
}









/*
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

sum = 0;
for (int i = 38; i <= 42; ++i)
{
    if (i % 2 == 1)
    {
        continue;
    }
sum += i;
}
Console.WriteLine($"sum of even from 38 to 42 = {sum}");

for (int i= 0; 1 < 100; ++i)
{
    if (i == 10) 
    {
        break;
    }
    Console.WriteLine("message");
}

/*

// Конкатенація нижче
Console.WriteLine("Please enter the value:");
string inp = Console.ReadLine ();
Console.WriteLine($"You have entered {inp}");


Console.WriteLine("Please enter the value #1:");
string inp1 = Console.ReadLine ();
Console.WriteLine("Please enter the value #2:");
string inp2 = Console.ReadLine ();

Console.WriteLine($"sum is {inp1 + inp2}");
*/



// Парсинг нижче
/*
string input;

Console.WriteLine("Please enter the value #1:");
input = Console.ReadLine ();
int inp1 = int.Parse (input);

Console.WriteLine("Please enter the value #2:");
input = Console.ReadLine ();
int inp2 = int.Parse (input);

Console.WriteLine($"sum is {inp1 + inp2}");


// парсинг безпечний із перевіркою чи це є число

string input;
Console.WriteLine("enter number:");
input = Console.ReadLine ();
bool succsees = int.TryParse (input, out int num3);

if (succsees)
{
Console.WriteLine($"you entered {num3}");
}
else
{
Console.WriteLine($"you entered NOT NUMBER {num3}");
}


// string input;
Console.WriteLine("enter decimal number 4:");
input = Console.ReadLine ();
decimal d1 = decimal.Parse (input);
Console.WriteLine($"you entered = {d1}");

*/


/*
System.Console.WriteLine("enter a number");
string input1 = Console.ReadLine ();
int number = Convert.ToInt32 (input1);
System.Console.WriteLine($"you entered {number}");
*/

/*
DateTime data = new DateTime(2025, 1, 10, 21, 54, 30);
Console.WriteLine(data);

DateTime data1 = DateTime.Now;
Console.WriteLine(data1);

TimeSpan ts1 = new TimeSpan(0, 70, 20);
Console.WriteLine(data + ts1);

System.Console.WriteLine(data < data1);
*/