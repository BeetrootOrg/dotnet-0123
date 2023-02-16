// additional methods
void WriteArray(char[] array)
{
    foreach (var item in array)
    {
        Console.Write($"{item} ");
    }
    Console.Write("\n");
}

void SwapElementsInArray(char[] array, int firstIndex, int secondIndex)
{
    char temp = array[firstIndex];
    array[firstIndex] = array[secondIndex];
    array[secondIndex] = temp;
}

char[] CopyArray(char[] originArray)
{
    char[] copyArray = new char[originArray.Length];
    Array.Copy(originArray, copyArray, originArray.Length);
    return copyArray;
}

char[] BubbleSort( char[] array)
{
    char[] copy = CopyArray(array);
    for (int i = 0; i < copy.Length-1; i++)
    {
        for (int j = 0; j < copy.Length-i-1; j++)
        {
            if (copy[j] > copy[j+1]) SwapElementsInArray(copy,j,j+1);
        }
    }
    return copy;
}


//homework part
bool Compare(string first, string second)
{
    return first==second;
}

void Analyze(string str)
{
    Console.WriteLine($"Analyze string \"{str}\"");
    int Letters = 0;
    int Digits = 0;
    int Controls = 0;
    foreach (var item in str)
    {
        Letters += Char.IsLetter(item)?1:0;
        Digits += Char.IsDigit(item)?1:0;
        Controls += Char.IsControl(item)?1:0;
    }
    Console.WriteLine($"Letters = {Letters}");
    Console.WriteLine($"Digits = {Digits}");
    Console.WriteLine($"Controls = {Controls}");
}

string Sort(string str)
{
    char[] chars = str.Replace(" ","").ToLower().ToCharArray();
    chars = BubbleSort(chars);
    return new string(chars);
}

char[] Duplicate(string str)
{
    char[] dupl= new char[str.Length/2];
    string copy = str.Replace(" ","").ToLower();
    int index = 0;
    for (int i = 0; i < copy.Length; i++)
    {
        int count = 0;
        for (int j = i+1; j < copy.Length; j++)
        {
            if (copy[i]==copy[j])
            {
                count++;
            }
        }
        if (count>0)
        {
            dupl[index] = copy[i];
            index++;
            copy = copy.Replace(copy[i].ToString(),"");
            i--;
        }
    }
    return dupl[..index];
}


string s1 = "Hello";
string s2 = "Hello and hi";
string s3 = "Hello 1234 \n.";


Console.WriteLine($"Compare({s1}; {s2}) = {Compare(s1,s2)}");
Analyze(s3);
Console.WriteLine($"Sort({s1}) = {Sort(s2)}");
Console.Write($"Duplicate({s2}) = ");
WriteArray(Duplicate(s2));
