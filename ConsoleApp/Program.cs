 Console.WriteLine("Please enter a first number");
           string input1 = Console.ReadLine();
           bool success1 = int.TryParse(input1, out int num1);
          
           Console.WriteLine("Please enter a second number");
           string input2 = Console.ReadLine();
           bool success2 = int.TryParse(input2, out int num2);

           int sum = 0;

           if (success1 && success2)
           {
               if (num1 >= num2)
               {
                   for (int i = num2; i <= num1; i++)
                   {
                       sum += i;
                   }
                   Console.WriteLine("Sum of numbers = " + sum);
               }

               else
               {
                   for (int j = num1; j <= num2; j++)
                   {
                       sum += j;
                   }
                   Console.WriteLine("Sum of numbers = " + sum);
               }
           }
           
           else
           {
               {
                   Console.WriteLine("You entered a wrong number");
               }
           }