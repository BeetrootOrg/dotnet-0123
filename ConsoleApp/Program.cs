//max of n parameters 
int max2(int a, int b)

{
    return a > b
    ? a
    : b;


}
System.Console.WriteLine($"max of two parameters is:{max2(30, 30)}");

int max3(int a, int b, int c)

{
    return c > max2(a, b)
    ? c
    : max2(a, b);



}
System.Console.WriteLine($"max of three parameters is:{max3(30, 40, 22)}");
int max4(int a, int b, int c, int d)

{
    return d > max3(a, b, c)
    ? d
    : max3(a, b, c);
}
System.Console.WriteLine($"max of four parameters is:{max4(50, 40, 15, 22)}");

//min of n parameters

int min2(int a, int b)

{
    return a < b
    ? a
    : b;



}
System.Console.WriteLine($"min of two parameters is:{min2(30, 10)}");

int min3(int a, int b, int c)

{
    return c < min2(a, b)
    ? c
    : min2(a, b);



}
System.Console.WriteLine($"min of three parameters is:{min3(30, 40, 22)}");

int min4(int a, int b, int c, int d)

{
    return d < min3(a, b, c)
    ? d
    : min3(a, b, c);
}
System.Console.WriteLine($"min of four parameters is:{min4(50, 40, 15, 22)}");


bool TrySumIfOdd(int a, int b, out int result)
{

    if ((a + b) % 2 == 0)
    {
        result = a + b;
        return false;
    }
    result = a+b;
    return true;
   

}

bool result = TrySumIfOdd(5,3,out int temp1);
System.Console.WriteLine($"TrySumIfOdd(5,3) = {result}. Result = {temp1}");
 result = TrySumIfOdd(5,2,out temp1);
 System.Console.WriteLine($"TrySumIfOdd(5,2) = {result}. Result = {temp1}");