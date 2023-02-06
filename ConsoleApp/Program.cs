int a=42;
int b=41;
int c=a+b;
Console.WriteLine(a+b);
Console.WriteLine(c);

Console.WriteLine(6/3);
Console.WriteLine(7/3);
Console.WriteLine(8/3);
Console.WriteLine(9/3);
Console.WriteLine();

Console.WriteLine(6%3);
Console.WriteLine(7%3);
Console.WriteLine(8%3);
Console.WriteLine(9%3);

float f=1.1F;
double d=1.2;
decimal dl=1.3M;
Console.WriteLine();
Console.WriteLine(f);
Console.WriteLine(d);
Console.WriteLine(dl);
Console.WriteLine(d/2.5);

Console.WriteLine(6.0/3.0);
Console.WriteLine(7.0/3.0);
Console.WriteLine(8.0/3.0);
Console.WriteLine(9.0/3.0);


bool b1=true;
bool b2=false;
Console.WriteLine(b1);
Console.WriteLine(b2);

Console.WriteLine("AND");
System.Console.WriteLine(b1&&b2);
System.Console.WriteLine($"true and true={true&&true}");
System.Console.WriteLine($"false and true={false&&true}");
System.Console.WriteLine($"true and false={true&&false}");
System.Console.WriteLine($"false and false={false&&false}");

Console.WriteLine("Or");
System.Console.WriteLine(b1||b2);
System.Console.WriteLine($"true or true={true||true}");
System.Console.WriteLine($"false or true={false||true}");
System.Console.WriteLine($"true or false={true||false}");
System.Console.WriteLine($"false or false={false||false}");

System.Console.WriteLine("comparison");
int i1=42;
int i2=42;
int i3=43;
System.Console.WriteLine($"i1 == i2 ={i1 == i2}");
System.Console.WriteLine($"i1 == i3 ={i1 == i3}");
System.Console.WriteLine($"i1 != i2 ={i1 != i2}");
System.Console.WriteLine($"i1 != i3 ={i1 != i3}");