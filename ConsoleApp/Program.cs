
static int Sum(int a,int b)
{
 var sum = a + b;
 return sum;
}
//static int sumoneline(int a,int b)=>a+b;{return a+b;}
static int SumOneLine(int a, int b)
{
    return a + b;
}

int a = 15;
int b = 20;
System.Console.WriteLine(Sum(a,b));
System.Console.WriteLine(SumOneLine(42,80));

int inc = 0;
void IncrementWithClosure ()
{
    ++inc;
}

void IncrementWithoutClosure ()
{
    int inc = 0;
    ++inc;
}
IncrementWithClosure();
IncrementWithClosure();
IncrementWithoutClosure();

System.Console.WriteLine(inc);

void Assign42(int param)
{
    param = 42;
}
Assign42(a);
System.Console.WriteLine(a);


void Assign42ref(ref int param)
{
    param = 42;
}
Assign42ref(ref a);
System.Console.WriteLine(a);

void Assign42Out(out int param)
{
    param = 42;

}
int temp1;
Assign42Out(out temp1);
System.Console.WriteLine(temp1);
Assign42Out( out int temp2);
System.Console.WriteLine(temp2);

void RefNoAssign(ref int param)
{

}
int temp3 = 15;
RefNoAssign(ref temp3);
System.Console.WriteLine(temp3);
