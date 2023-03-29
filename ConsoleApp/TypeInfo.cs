using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp
{
    public class AssemblyInfoGetter
    {
        private Assembly TargetAssembly { get; init; }

        public AssemblyInfoGetter(Type type)
        {
            TargetAssembly = type.Assembly;
        }

        public void ShowInfo()
        {
            foreach (var item in TargetAssembly.GetTypes())
            {
                Console.WriteLine($"Type {item.Name} has methods:");
                ShowMethodsInClass(item);
            }
        }

        private void ShowMethodsInClass(Type classType)
        {
            foreach (var item in classType.GetMethods())
            {
                System.Console.WriteLine($"\t{item.Name}");
                ShowParameters(item);
            }
        }
        private void ShowParameters(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters().Select(pi => pi.ParameterType);
            if (parameters.Count() != 0)
            {
                Console.WriteLine($"\t\tParameters:");
                foreach (var item in parameters)
                {
                    Console.WriteLine($"\t\t{item.Name}");
                }
            }
            else
            {
                Console.WriteLine($"\t\tNo parameters");
            }
            Console.WriteLine($"\t\tReturn:");
            Console.WriteLine($"\t\t{methodInfo.ReturnType}");

        }
    }
}