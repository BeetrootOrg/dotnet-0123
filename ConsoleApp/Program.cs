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




    

