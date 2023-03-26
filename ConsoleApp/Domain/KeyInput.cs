using SnakeGame.Objects;
namespace SnakeGame.Domain
{
    internal class KeyInput
    {
        public Direction MovementDirection { get; private set; }

        public KeyInput()
        {
            MovementDirection = Direction.Up;
        }
        public void EnterKey()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W or ConsoleKey.UpArrow:
                    {
                        this.MovementDirection = Direction.Up;
                        break;
                    }
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    {
                        this.MovementDirection = Direction.Down;
                        break;
                    }
                case ConsoleKey.A or ConsoleKey.LeftArrow:
                    {
                        this.MovementDirection = Direction.Left;
                        break;
                    }
                case ConsoleKey.D or ConsoleKey.RightArrow:
                    {
                        this.MovementDirection = Direction.Right;
                        break;
                    }
                case ConsoleKey.D0:
                    {
                        Exit();
                        break;
                    }
            }
        }

        void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

    }
}