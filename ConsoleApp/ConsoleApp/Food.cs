namespace SnakeGame;

class Food
{
    public Point Position { get; private set; }

    public Food()
    {
        Generate();
    }

    public void Generate()
    {
        Random random = new Random();
        int x = random.Next(Console.WindowWidth);
        int y = random.Next(Console.WindowHeight);
        Position = new Point(x, y);
    }

    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write("8");
    }
}