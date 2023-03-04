using System.Text;
bool Compare(string a,string b)

{
    if (a.Contains(b))
     {
       return true;
     }
    return false;

}
string a = "Hello";
string b = "world";
string c = "Hello";

System.Console.WriteLine(Compare(a,b));

System.Console.WriteLine(Compare(a,c));

void Analyze(string word)
{
    int Digits = 0;
    int Letters = 0;
    int Symbols = 0;
    foreach (char b in word)
    {
        if (char.IsLetter(b))
        {
            Letters++;
    
        }
        else if (char.IsDigit(b))
        {
            Digits++;
        }
        else 
        {
            Symbols++;
        }
    
    }
    System.Console.WriteLine(Letters);
    System.Console.WriteLine(Digits);
    System.Console.WriteLine(Symbols);
}
string word = "hello322$";
Analyze(word);

string Sort(string str)
{
    StringBuilder sorted = new StringBuilder (str);//долго не мог разобраться с тем как изменить string str,поэтому подсмотрел
        //метод StringBuilder
    int n = str.Length;
 for(int i = 0; i < n - 1;i++)   
 {
    for( int j = 0;j< n - i - 1;j++)
    {
        
        if(char.ConvertToUtf32(sorted.ToString().ToLower(),j)>char.ConvertToUtf32(sorted.ToString().ToLower(),j+1))
        {
            char curr = sorted[j];
            sorted[j] = sorted[j+1];
            sorted[j+1] = curr;

        }
    
    }
 }
 return sorted.ToString();
 }
string str = "dcba";
System.Console.WriteLine(str);
string sorted=Sort(str);
System.Console.WriteLine(sorted);

char[] Duplicate(string input)
{
    char[] result = new char[0];
    for(int i = 0 ;i<input.Length;i++)

    {
         char curr =input[i];
        for(int j = i+1;j<input.Length;j++)
        {   
           
            if (curr == input[j] && !result.Contains(curr) )
            {
                Array.Resize(ref result,result.Length + 1);
                result[result.Length - 1] = curr;

            }
        }
        
    }
    return result;
}
 void WriteArray(char [] array)
 {
     foreach (var item in array) 
     {
         Console.WriteLine(item);
     }
 }
string input = "hello and hi";
System.Console.WriteLine(input);
WriteArray(Duplicate(input));

