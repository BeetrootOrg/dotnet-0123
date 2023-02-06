const int n = 5;

int prev = 1;
int curr = 1;

int i = n - 2;
while (i-- > 0)
{
    int temp = prev;
    prev = curr;
    curr += temp;
}

Console.WriteLine(curr);