
 
using System.Text;

/*Console.WriteLine("Enter the first word");
string s1 = Console.ReadLine();

Console.WriteLine("Enter the second word");
string s2 = Console.ReadLine();

bool Compare(string s1, string s2)
{
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
Compare(s1, s2);*/

Console.Clear();

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

}
Console.WriteLine($"letters: {0}, digits: {1}, special: {2}");

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