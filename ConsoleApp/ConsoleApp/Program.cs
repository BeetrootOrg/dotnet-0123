using System;
using System.Collections.Generic;

namespace VoteApp
{
    class VoteOption
    {
        public string Option { get; set; }
        public int VoteCount { get; set; }
    }

    class Vote
    {
        static void Main(string[] args)
        {
            List<VoteOption> voteOptions = new List<VoteOption>();
            List<string> votedUsers = new List<string>();

            Console.Write("Enter vote topic: ");
            string topic = Console.ReadLine();

            Console.WriteLine("Enter vote options (enter 'done' when finished):");
            string option = Console.ReadLine();
            while (option != "done")
            {
                voteOptions.Add(new VoteOption { Option = option, VoteCount = 0 });
                option = Console.ReadLine();
            }

            Console.WriteLine("Vote topic: " + topic);
            Console.WriteLine("Vote options:");
            foreach (VoteOption voteOption in voteOptions)
            {
                Console.WriteLine(voteOption.Option);
            }

            while (true)
            {
                Console.WriteLine("Enter 'vote' to vote or 'exit' to exit:");
                string voteOrExit = Console.ReadLine();
                if (voteOrExit.ToLower() == "exit")
                {
                    break;
                }
                else if (voteOrExit.ToLower() == "vote")
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    if (votedUsers.Contains(name))
                    {
                        Console.WriteLine("You have already voted!");
                    }
                    else
                    {
                        Console.Write("Enter your vote: ");
                        string vote = Console.ReadLine();

                        VoteOption selectedOption = voteOptions.Find(v => v.Option == vote);
                        if (selectedOption != null)
                        {
                            selectedOption.VoteCount++;
                            votedUsers.Add(name);
                            Console.WriteLine("Vote recorded!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid vote option.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }

            Console.WriteLine("Final voting results:");
            foreach (VoteOption voteOption in voteOptions)
            {
                Console.WriteLine(voteOption.Option + ": " + voteOption.VoteCount);
            }
        }
    }
}
