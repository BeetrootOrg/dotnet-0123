using System;
using System.Reflection;
using System.Text;
using ConsoleApp;

using TestingNamespace;


AssemblyInfoGetter infoAboutType = new AssemblyInfoGetter(typeof(Car));

infoAboutType.ShowInfo();
