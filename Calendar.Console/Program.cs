using Calendar.Console;
using Calendar.Console.Controllers;

var context = Context.CreateContext();
IController controller = new MainMenuController(context);

while (controller != null)
{
    controller.Show();
    controller = controller.Action();
}
