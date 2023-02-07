int Max2(int a, int b) => a > b ? a : b; 
int Max3(int a, int b, int c) => Max2(a, b) > c ? Max2(a, b) : c; 
int Max4(int a, int b, int c, int d) => Max3(a, b, c) > d ? Max3(a, b, c) : d; 

int Min2(int a, int b) => a < b ? a : b; 
int Min3(int a, int b, int c) => Min2(a, b) < c ? Min2(a, b) : c; 
int Min4(int a, int b, int c, int d) => Min3(a, b, c) < d ? Min3(a, b, c) : d; 

bool TrySumIfOdd(int a, int b, out int result)
{
    result = a + b;
    return (result % 2) == 1;
}

// Extra
string Repeat(string X, int N) => N == 1 ? X : X += Repeat(X, N - 1);
