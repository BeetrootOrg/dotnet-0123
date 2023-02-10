string name = "illia";
 if (name == "Illia"){
    System.Console.WriteLine(("Hi,Illia"));
 }
 else if (name == "illia"){
    System.Console.WriteLine("Hi,Illia");
 }
 else 
 
 {
    System.Console.WriteLine("Hi,not Illia");
 }
 System.Console.WriteLine("next operation");
 
 System.Console.WriteLine("switch/case");
 switch(name)
 {
    case "Illia":
        System.Console.WriteLine("Hi,Illia");
        break;
    case "illia":
        System.Console.WriteLine("Hi,illia");
         break;
    default:
        System.Console.WriteLine("Hi,not Illia");
        break;

 }
 int a = 10;
 int b = (a == 10 ? 15 : 20);//if (a == 10){ b = 15} else (b = 20)
 System.Console.WriteLine(b);
 //posible but not preferable
 if (a == 10)
     b = 15;
 else 
    b = 20;

System.Console.WriteLine(("numbers from 0 to 9"));
    for (int i = 0; i < 10; ++i){
    System.Console.WriteLine(i);
    }

    var sum = 0;

for ( int i = 0; i <= 10; ++i){
    sum +=i;//sum = sum + 1,повторяет sum += i,каждый раз пока условие не нарушенно
}
System.Console.WriteLine($"Sun from 0 ti 10 is equal to {sum}");
var  mul = 1;
for(int i = 1;  i <= 10;++i){
    mul *=i;//mul = mul*i
}
System.Console.WriteLine($"mul from 1 t0 10 {mul} ");

 mul = 1;
  int j = 1;
 while (j <= 10){
   
    mul*=j;
     ++j;//mul *=j++
 }      
 System.Console.WriteLine($"цикл while {mul}"); 


 mul = 1;
 j = 1;
 do 
 {
 mul *=j++;
 }
 while( j <=10);
 System.Console.WriteLine($"do while {mul}");


sum = 0;
 for (int i = 0; i <=42; i++)
 {
   sum += i;
 }
 System.Console.WriteLine($"even numbers");
sum = 0;
 for (int i = 0; i <=42; i +=2)
 {
   sum += i;
 }
System.Console.WriteLine($"sum of even numbers {sum}");

System.Console.WriteLine("odd numbers");

sum = 0;
 for (int i = 1; i <=42; i +=2)//odd numbers the same ass even but strats from 1
 {
   sum += i;
 }

System.Console.WriteLine($"sum of odd numbers {sum}");