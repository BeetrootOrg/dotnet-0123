using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    public class VotingOptionsBuilder
    {
        private IndexDictionary<string, int> _votingOptions = new IndexDictionary<string, int>();

        public VotingOptionsBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            _votingOptions = new IndexDictionary<string, int>();
        }

        public void AddOption()
        {
            while (true)
            {
                if (_votingOptions.Count > 8)
                {
                    Console.WriteLine("You cannot create more than 9 options!");
                    break;
                }
                Console.WriteLine("Enter vote option (press enter if all options added):");
                string input = Console.ReadLine();
                if (input == "")
                {
                    if (_votingOptions.Count > 1)
                    {
                        break;
                    }
                    Console.WriteLine("You need at least two options!");
                    continue;
                }
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Option name must be not empty!");
                    continue;
                }
                if (!_votingOptions.TryAdd(input, 0))
                {
                    Console.WriteLine("This option already exist!");
                    continue;
                }
            }
        }
        public IndexDictionary<string, int> GetVotingOptions()
        {
            IndexDictionary<string, int> result = this._votingOptions;
            this.Reset();
            return result;
        }
    }
}