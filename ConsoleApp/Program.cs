int Max2(int a, int b) => a > b ? a : b; 

int Max3(int a, int b, int c)
{
    int max2 = Max2(a, b);
    return max2 > c ? max2 : c; 
}

int Max4(int a, int b, int c, int d)
{
    int max3 = Max3(a, b, c);
    return max3 > d ? max3 : d; 
}

int Min2(int a, int b) => a < b ? a : b; 

int Min3(int a, int b, int c)
{
    int min2 = Min2(a, b);
    return  min2 < c ? min2 : c;
}
 
int Min4(int a, int b, int c, int d)
{
    int min3 = Min3(a, b, c);
    return min3 < d ? min3 : d; 
}

bool TrySumIfOdd(int a, int b, out int result)
{
    result = a + b;
    return (result % 2) == 1;
}

// Extra
string Repeat(string X, int N) => N == 1 ? X : X += Repeat(X, N - 1);
