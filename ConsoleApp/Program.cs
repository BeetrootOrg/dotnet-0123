﻿string name = "maksym";
if (name=="Maksym"){
    Console.WriteLine("Hi, Maksym");
}
else if (name=="maksym"){
    Console.WriteLine("Hi, maksym");
}
else {
    Console.WriteLine("Hi, not Maksym");
}

Console.WriteLine("switch/case");
switch (name)
{
    case "Maksym": 
    Console.WriteLine("Hi, Maksym");
    break;
    case "maksym": 
    Console.WriteLine("Hi, maksym");
    break;
    default: 
    Console.WriteLine("Hi, not Maksym");
    break;
}

int a = 10;
int b = a==10 ? 15 : 20;
Console.WriteLine(b);

for (int i = 0;i<10;++i){
    Console.WriteLine(i);
}

System.Console.WriteLine("sum 1..10");

var sum = 0;
for (int i = 0;i<=10;++i){
    sum+=i;
}
Console.WriteLine($"Sum from 0 to 10 = {sum}");

var mul = 1;
for (int i = 1;i<11;++i)
{
    mul*=i;
}
Console.WriteLine($"mul from 0 to 10 = {mul}");

//while
mul =1 ;
int j = 1;
while(j<=10)
{
    mul *= j++;
}
Console.WriteLine($"mul from 0 to 10 = {mul}");

//do while
mul = 1;
j = 1;
do
{
    mul *= j++;
} while(j<=10);
Console.WriteLine($"mul from 0 to 10 = {mul}");


//continue
sum = 0;
for(int i = 0;i<=42;i+=2)
{
    sum+=i;
}
Console.WriteLine($"Sum of even from 0 to 42 = {sum}");

sum = 0;
for(int i = 0;i<=42;i++)
{
    if (i%2!=0) continue;
    sum+=i;
}
Console.WriteLine($"Sum of even from 0 to 42 = {sum}");

//break
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break;
    }
    System.Console.WriteLine("new execution");
}

//convert int.Parse
/*System.Console.WriteLine("enter a:");
string input = Console.ReadLine();
int num1 = int.Parse(input);
System.Console.WriteLine("enter b:");
input = Console.ReadLine();
int num2 = int.Parse(input);
System.Console.WriteLine(num1+num2);
*/

//convert try parse
 string input = Console.ReadLine();
 bool success = int.TryParse(input,out int num3);
 if (success)
 {
    System.Console.WriteLine($"you enter {num3}");
 }
 else
 {
    System.Console.WriteLine("you enter wrong");
 }

 //convert Convert

 input = Console.ReadLine();
 int num5 = Convert.ToInt32(input);
 System.Console.WriteLine($"enter number {num5}");