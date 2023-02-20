
using System.Text;

Console.WriteLine("Enter the first word");
string s1 = Console.ReadLine();

Console.WriteLine("Enter the second word");
string s2 = Console.ReadLine();

bool Compare(string s1, string s2)
{
    if(s1.Length != s2.Length)
    {
        Console.WriteLine("strings are not equal");
        return false;
    }
    for( int i = 0; s1.Length < i; i++)
    {
        if( s1[i] != s2[i])
        {
            Console.WriteLine("strings are not equal");
            return false;
        }
    }

    Console.WriteLine("strings are equal");
    return true;
}
Compare(s1, s2);


Console.WriteLine("Enter the word");
string word = Console.ReadLine();

void Analyze(string word)
{
    int alp = 0;
    int digit = 0;
    int splch = 0;

    foreach (char item in word)
    {
        if(Char.IsLetter(item))
        {
            alp++;
        }

        if(Char.IsDigit(item))
        {
            digit++;
        }

        if(Char.IsControl(item))
        {
            splch++;
        }
        
    }
    Console.WriteLine("Letters: {0} Digits: {1} Controls: {2}", alp, digit, splch);
}
Analyze(word);

/*
while(word[i] != '\0')
    {
        if((word[i] >= 'a' && word[i] <= 'z') || (word[i] >= 'a' && word[i] <= 'z'))
        {
            alp++;
        }
        else if(word[i] >= '0' && word[i] <= '9')
        {
            digit++;
        }
        else
        {
            splch++;
        }
        i++;
    }
*/

void sortString(string srt)
{
    char []arr = srt.ToCharArray();
    Array.Sort(arr);
    Console.WriteLine(String.Join("",arr));
}
sortString("qwertyuiop");

void WriteArray(char[] array)
{
    foreach (var item in array)
    {
        Console.Write($"{item} ");
    }
    Console.Write("\n");
}


char[] Duplicate(string s)
{
    StringBuilder sb = new();
    string str = s.ToLower();
    
    foreach (char ch in str)
    {
        if (sb.ToString().Contains(ch) || Char.IsWhiteSpace(ch))
        {
            continue;
        }

        int i = str.Split(ch).Length - 1;
        
        if (i > 1)
        {
            sb.Append(ch);
        }
    }
    
    return sb.ToString().ToCharArray(); 
}
string s = "Hello and hi";
Console.Write($"Duplicate({s}) = ");
WriteArray(Duplicate(s));
