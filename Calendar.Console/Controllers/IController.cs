namespace Calendar.Console.Controllers
{
    internal interface IController
    {
        void Show();

        IController Action();
    }
}