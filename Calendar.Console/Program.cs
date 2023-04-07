using Calendar.Console.Controllers;
using Calendar.Console;

Context context = Context.CreateContext();
IController controller = new MainMenuController(context);
while (controller != null)
{
    controller.Show();
    controller = controller.Action();
}

