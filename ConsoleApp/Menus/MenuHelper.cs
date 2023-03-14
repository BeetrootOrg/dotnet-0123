using ConsoleApp.Data;
using ConsoleApp.Models;

namespace ConsoleApp.Menus
{
    public static class MenuHelper
    {
        static string wrong = "---------------\nInvalid input. Try again";
        static Context context = new();
        public static MenuItem MenuExit = new() { Key = "E", Text = "Exit ", MenuAction = Exit };
        public static MenuItem MenuTop = new() { Key = "T", Text = "Top Menu", MenuAction = MenuTopAction };
        public static MenuItem MenuVoteMain = new() { Key = "V", Text = "Vote Main Menu", MenuAction = MenuVoteMainAction };
        public static MenuItem MenuVoteCreate = new() { Key = "1", Text = "Create vote topic", MenuAction = MenuVoteCreateAction };
        public static MenuItem MenuVoteResult = new() { Key = "3", Text = "Results", MenuAction = MenuVoteResultAction };
        public static MenuItem MenuVoteTopic = new() { Key = "2", Text = "Vote", MenuAction = MenuVoteTopicAction };
        //public static MenuItem MenuVoteOption = new() { Key = "2", Text = "Vote", MenuAction = MenuVoteOptionAction };

        private static void VoteOptionAction(string item, object value)
        {
            if (value == null || !(value is Option)) return;
            ((Option)value).VoteCounter++;
            context.Save();
            Console.WriteLine("Vote added");
            Console.ReadKey();
            MenuVoteMainAction();
        }
        private static void MenuVoteOptionAction(string item, object value)
        {
            Console.Clear();
            if (value == null || !(value is Topic)) return;
            var topic = (Topic)value;
            Menu.ShowMenu("Vote:", $"Vote for topic '{topic.Name}':",
                 topic.Options.Select(x => new MenuItem()
                 {
                     Key = x.Id.ToString(),
                     Text = x.Name,
                     Value = x,
                     MenuAction = VoteOptionAction
                 }).ToList(),
              MenuExit, MenuVoteMain, null);
        }
        private static void MenuVoteTopicAction(string item = "", object value = null)
        {
            Console.Clear();
            Menu.ShowMenu("Vote:", "Enter topic name:",
                context.Topics.Select(x => new MenuItem()
                {
                    Key = x.Id.ToString(),
                    Text = x.Name,
                    Value = x,
                    MenuAction = MenuVoteOptionAction
                }).ToList(),
             MenuExit, MenuVoteMain, null);
        }

        private static void MenuVoteResultAction(string item = "", object value = null)
        {
            Console.Clear();
            Console.WriteLine($"Results:\n{string.Join('\n',context.Topics.Select(x=> context.TopicResult(x)))}");
            Console.ReadKey();
        }

        public static void MenuVoteCreateAction(string item, object value)
        {
            string name;
            string option;
            Topic topic;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Topic Vote Name (press Enter to return):");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) return;
                topic = context.CreateTopic(name);
                Console.WriteLine(topic == null ? wrong : "Topic created");
            }
            while (topic == null);
            do
            {
                Console.WriteLine($"Enter Name new Option for {topic.Name}(press Enter to return):");
                option = Console.ReadLine();
                var options = context.CreateOptionForTopic(option, topic);
                Console.WriteLine(options == null ? wrong : "Options created");
            } while (!string.IsNullOrEmpty(option));
        }

        public static void CheckEmptyStringAndMenuAction(string value, MenuTypeAction action)
        {
            if (string.IsNullOrEmpty(value)) InputEmptyString(action);
        }

        public static void InputEmptyString(MenuTypeAction action)
        {
            MenuItem menu = action switch
            {
                MenuTypeAction.VoteMainMenu => MenuVoteMain,
                _ => MenuTop,
            };
            menu.MenuAction?.Invoke("", null);
        }

        public static void MenuVoteMainAction(string item = "", object value = null)
        {
            Menu.ShowMenu("MainMenu Vote:", "=================================",
                new()
                {
                    MenuVoteCreate,
                    MenuVoteTopic,
                    MenuVoteResult
                },
             MenuExit, MenuTop, null);
        }

        public static void MenuTopAction(string item="", object value=null)
        {
            Menu.ShowMenu("Top Menu:", "=================================",
                new()
                {
                    new(){Key="1", Text="Vote Homework;", MenuAction=MenuVoteMainAction},
                    new(){Key="2", Text="Snake Gamed;", MenuAction=MenuSnakeGame}
                },
             MenuExit, null, null);
        }

        private static void MenuSnakeGame(string item="", object value=null)
        {
            Console.Clear();
            Console.WriteLine("Will be created soon... Press any key.");
            Console.ReadKey();
            MenuHelper.MenuTopAction();
        }

        public static void Exit(string item, object value) => Environment.Exit(0);
        public enum MenuTypeAction
        {
            VoteMainMenu = 0,
        }
    }

}