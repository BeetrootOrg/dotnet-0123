bool IfEqual(string a,string b)

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

System.Console.WriteLine(IfEqual(a,b));

System.Console.WriteLine(IfEqual(a,c));