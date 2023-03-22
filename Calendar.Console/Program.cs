using Calendar.Console.Controllers;

IController controller = new MainMenuController();
while (controller != null)
{
    controller.Show();
    controller = controller.Action();
}
