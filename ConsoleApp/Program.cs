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
