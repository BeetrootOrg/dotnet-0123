namespace SnakeGame;

class Snake
    {
        private List<Point> body;
        private Point direction;

        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            body.Add(new Point(9, 10));
            body.Add(new Point(8, 10));
            body.Add(new Point(7, 10));

            direction = new Point(1, 0);
        }

        public void Move()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }

            body[0] += direction;
        }

        public bool HitWall()
        {
            Point head = body[0];
            return head.X < 0 || head.X >= Console.WindowWidth ||
                   head.Y < 0 || head.Y >= Console.WindowHeight;
        }

        public bool HitBody()
        {
            Point head = body[0];
            return body.Skip(1).Any(p => p == head);
        }

        public bool Eat(Food food)
        {
            Point head = body[0];
            if (head == food.Position)
            {
                body.Add(body[body.Count - 1]);
                return true;
            }

            return false;
        }

        public void ChangeDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (direction.X != 1) // Prevent going backward
                        direction = new Point(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (direction.X != -1)
                        direction = new Point(1, 0);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (direction.Y != 1)
                        direction = new Point(0, -1);

                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (direction.Y != -1)
                        direction = new Point(0, 1);
                    break;
            }
        }

        public void Draw()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("*");
            }
        }

        
    }