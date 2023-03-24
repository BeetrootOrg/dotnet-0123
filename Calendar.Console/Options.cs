using CommandLine;

namespace Calendar.Console
{
    internal class Options
    {
        [Option('f', "filename", Required = false, HelpText = "Path to input data", Default = "input.json")]
        public string Filename { get; init; }
    }
}