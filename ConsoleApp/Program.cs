string name="dima";

if (name=="Dima") Console.WriteLine("Hi, Dima");
else if (name=="dima") Console.WriteLine("Hi,not dima");
else Console.WriteLine("Hi,not Dima");

Console.WriteLine("Next operation");

Console.WriteLine("SWITCH/CASE");

switch(name){
    case "Dima":
    Console.WriteLine("Hi, Dima"); break;
    case "dima":
    Console.WriteLine("Hi, dima"); break;
    default:
    Console.WriteLine("Hi,not Dima"); break;
}

int a=10;
int b=(a==10?15:20);

Console.WriteLine(b);

for(var i=0;i<10;++i){
    Console.WriteLine(i);
}

var sum=0;
for(var i=0;i<10;++i){
    sum+=i;
}
Console.WriteLine(sum);

var mul=1;
for(var i=0;i<=10;++i){
    mul*=i;
}
Console.WriteLine(mul);

mul=1;
int j=1;
while(j <=10){
    mul*=j++;
}
mul=1;
j=1;

do{
    mul*=j++;
}while(j <=10);

sum=0;
for(var x=0;x<=42;++x){
    if ((x%2)==0) sum+=x;
}

Console.WriteLine(sum);
sum=0;
for(var x=0;x<=42;++x){
    if ((x%2)>0) sum+=x;
}

Console.WriteLine(sum);
sum=0;
for(var x=0;x<=42;++x){
    sum+=x;
}

Console.WriteLine(sum);

sum=0;
for(var x=0;x<=42;++x){
   if ((x%2)>0) continue;
    sum+=x;
}

Console.WriteLine(sum);

sum=0;
for(var x=0;x<=42;++x){
   if ((x==5)) break;;
    sum+=x;
}

Console.WriteLine(sum);