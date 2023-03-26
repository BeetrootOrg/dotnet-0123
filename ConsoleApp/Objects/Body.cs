namespace SnakeGame.Objects
{
    internal class Body
    {
        public char BodyChar { get; } = '*';
        public int X { get; set; }
        public int Y { get; set; }
        public Body()
        {
            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight / 2;
        }
        public Body(Meal meal)
        {
            X = meal.X;
            Y = meal.Y;
        }
        public Body(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void ChangeCoords(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        X -= 1;
                        break;
                    }
                case Direction.Right:
                    {
                        X += 1;
                        break;
                    }
                case Direction.Up:
                    {
                        Y -= 1;
                        break;
                    }
                case Direction.Down:
                    {
                        Y += 1;
                        break;
                    }
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Body body &&
                   BodyChar == body.BodyChar &&
                   X == body.X &&
                   Y == body.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BodyChar, X, Y);
        }
    }
}