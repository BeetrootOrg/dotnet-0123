using Calendar.Console;
using Calendar.Console.Controllers;

using CommandLine;

_ = Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options =>
    {
        Context context = Context.CreateContext(options.Filename);
        IController controller = new MainMenuController(context);

        while (controller != null)
        {
            controller.Show();
            controller = controller.Action();
        }
    });

