int x=10;
int y=12;
int sum=0;
int X=x;
int Y=y;

if (x==y) sum=x;
else
{
    if (x>y) {X=y;Y=X;}
    for(var i=X;i<=Y;i++){ sum=sum+i; }
}
Console.WriteLine($"the sum of all numbers between {x}..{y} is {sum}");

Console.WriteLine("Extra:");
int x1; int y1;
sum=0;
try{
    x1=Convert.ToInt16(Console.ReadLine());
    y1=Convert.ToInt16(Console.ReadLine());
    if (x1==y1) sum=x1; else
    {
        for(var i=x1;i<=y1;i++){ sum=sum+i; }
    }
    Console.WriteLine($"the sum of all numbers between {x1}..{y1} is {sum}");
} catch {Console.WriteLine("Invalid input"); return;}   
// string inv="invalid";
// string? x1;
// string? y1;
// string ou;
// try{
//     x1=Console.ReadLine();
//     y1=Console.ReadLine();
//     ou=$"{x1}{y1}";
//     if (string.IsNullOrEmpty(x1) || string.IsNullOrEmpty(y1)) {Console.WriteLine("Invalid input"); return;}
//     if (ou.ToLower().Contains(inv)) {Console.WriteLine("Invalid input"); return;}
// } catch {Console.WriteLine("Invalid input"); return;}