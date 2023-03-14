namespace ConsoleApp.Menus
{
    public static class Menu
    {
        static string wrong = "---------------\nInvalid input. Try again";
        public static void ShowMenu(string title, string desription, List<MenuItem> Items, MenuItem ExitItem, MenuItem ReturnItem, MenuItem DefaultItem)
        {
            bool showwrong = false;
            if (Items == null) Items = new();
            if (ReturnItem != null) Items.Add(ReturnItem);
            if (ExitItem != null) Items.Add(ExitItem);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{title}\n{desription}");
                Console.WriteLine("\t" + string.Join("\n\t", Items.Select(x => x.MenuText)));
                if (showwrong) Console.WriteLine(wrong);
                string s = Console.ReadLine();
                var item = Items.FirstOrDefault(x => x.Key.ToLower() == s.ToLower());
                item?.MenuAction?.Invoke(s, item?.Value);
                showwrong = true;
            }
        }
    }
    public delegate void MenuAction(string item, object value);

    public class MenuItem
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public Object Value { get; set; }
        public string MenuText { get => $"{Key}. {Text}"; }
        public MenuAction MenuAction { get; set; }
    }
}