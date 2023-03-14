namespace ConsoleApp
{
    public static class App
    {
        private static TopicList topicList = new TopicList();
        private static OptionList optionList = new OptionList();

        public static void Run()
        {
            while(true)
            {
                Choice();
            }
        }

        private static void Choice()
        {
            Menu.Default();
            
            ConsoleKeyInfo key = Console.ReadKey();
            
            if (key.Key == ConsoleKey.D0)
            {
                Environment.Exit(0);
            }
            else if (key.Key == ConsoleKey.D1)
            {
                CreateTopic();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Vote();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                ShowResults();
            }
        }

        private static void CreateTopic()
        {
            int minOptionsCount = 2;
            int optionsCounter = 0;

            Console.Clear();
            Console.WriteLine(Messages.EnterTopic);
            string name = Validator.GetInput();
            
            Topic topic = new Topic(name);
            topicList.Add(topic);

            while (true)
            {
                Console.WriteLine(Messages.EnterOption);
                string option = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(option))
                {
                    if (optionsCounter < minOptionsCount)
                    {
                        Console.WriteLine($"{Messages.FewOptionsCount} {minOptionsCount}");
                        continue;
                    }
                    break;
                }

                optionList.Add(new Option(++optionsCounter, topic.Id, option));
            }

            Menu.Return();
        }

        public static void Vote()
        {
            Console.Clear();
            Console.WriteLine(Messages.ChooseTopic);
            Menu.Build(topicList);

            while(true)
            {
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int topicId))
                {
                    Console.WriteLine(Messages.ChoiceIsNotValid);
                    continue;
                }
                
                if (topicId == 0)
                {
                    break;
                }

                if (!topicList.ItemExists(topicId))
                {
                    Console.WriteLine(Messages.ChoiceIsNotValid);
                    continue;
                }

                Console.WriteLine($"{Messages.VoteFor} {topicList.GetNameById(topicId)}");
                Menu.Build(optionList);

                while(true)
                {
                    input = Console.ReadLine();
                    
                    if (!int.TryParse(input, out int optionId))
                    {
                        Console.WriteLine(Messages.ChoiceIsNotValid);
                        continue;
                    }
                    
                    if (optionId == 0)
                    {
                        break;
                    }

                    if (!optionList.ItemExists(optionId, topicId))
                    {
                        Console.WriteLine(Messages.ChoiceIsNotValid);
                        continue;
                    }

                    optionList.AddVote(optionId, topicId);
                    Console.WriteLine(Messages.VoteAdded);
                    break;
                }

                Menu.Return();
                break;
            }
        }

        public static void ShowResults()
        {
            Console.Clear();
            Console.WriteLine(Messages.ChooseTopic);
            Menu.Build(topicList);

            while(true)
            {
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int topicId))
                {
                    Console.WriteLine(Messages.ChoiceIsNotValid);
                    continue;
                }
                
                if (topicId == 0)
                {
                    break;
                }

                if (!topicList.ItemExists(topicId))
                {
                    Console.WriteLine(Messages.ChoiceIsNotValid);
                    continue;
                }

                Menu.BuildFullData(optionList);

                Menu.Return();
                break;
            }
        }
    }
}