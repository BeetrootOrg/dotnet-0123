using Calendar.Console;
using Calendar.Console.Controllers;

Context context = Context.CreateContext();
IController controller = new MainMenuController(context);

while (controller != null)
{
    controller.Show();
    controller = controller.Action();
}
