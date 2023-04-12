using Calendar.Console.Controllers;
using Calendar.Console;

const string filename = "input.json";

Context context = Context.CreateContext(filename);
IController controller = new MainMenuController(context);
while (controller != null)
{
    controller.Show();
    controller = controller.Action();
}

