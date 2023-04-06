namespace ConsoleApp.Models.Objects
{
    internal interface IGameObject
    {
        public char Symbol { get; }
        public int X { get; init; }
        public int Y { get; init; }
        public void Render();
    }
}