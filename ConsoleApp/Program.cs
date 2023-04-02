using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Company
{
  public class Worker
  {
    public static string FirstName;
    public static string LastName;
    public int Age;
    public int PhoneNumber {get; set;}
    public int Salary {get; set;}

    public void GetPhoneNumber(int number)
    {
        PhoneNumber = number;
    }

    public void GetSalary(int salary)
    {
        Salary = salary;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type worker1 = Type.GetType("Company.Worker");

            MethodInfo[] methods = worker1.GetMethods();

            int i = 0;
            foreach (MethodInfo methodInfo in methods)
            {
                i++;
                Console.WriteLine($"Method [{i}] = {methodInfo.Name}");
            }

            Type worker2 = Type.GetType("Company.Worker");

            FieldInfo[] fields = worker2.GetFields();

            int x = 0;
            foreach (FieldInfo fieldInfo in fields)
            {
                x++;
                Console.WriteLine($"Type {worker2.Name} has field {fieldInfo.Name} with type {fieldInfo.FieldType.Name}");

                if (fieldInfo.IsStatic)
                {
                    Console.WriteLine(", static");
                }
                else if (fieldInfo.IsPublic)
                {
                    Console.WriteLine(", public");
                }
            }
        }
    }
  }
}