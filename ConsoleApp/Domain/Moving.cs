using SnakeGame.Objects;

namespace SnakeGame.Domain
{
    internal class Moving
    {
        public SnakeBody CurrentSnakeBody {get; private set;}
        private Direction CurrentDirection {get;set;}
        public Moving()
        {
            CurrentSnakeBody = new SnakeBody();
            CurrentDirection = Direction.Up;
        }
        public Moving(KeyInput keyInput, SnakeBody snakeBody)
        {
            CurrentSnakeBody = snakeBody;
            CurrentDirection = keyInput.MovementDirection;
        }
        public void MakeMove()
        {
            List<Body> oldBody = new List<Body>(CurrentSnakeBody.Snake);
            Body newHead = new Body(oldBody[0].X, oldBody[0].Y);
            newHead.ChangeCoords(CurrentDirection);
            if (IsLosingSituation(newHead))
            {
                Lose();
            }
            List<Body> newBody = new List<Body>();
            newBody.Add(newHead);
            newBody.AddRange(oldBody.SkipLast(1).ToList());
            CurrentSnakeBody = new SnakeBody(newBody);
        }
        public void CheckDirection()
        {
            KeyInput keyInput = new KeyInput();
            keyInput.EnterKey();
            CurrentDirection = keyInput.MovementDirection;
        }
        private bool IsLosingSituation(Body newHead)
        {
            return newHead.X<0||newHead.X>=Console.WindowWidth||
                    newHead.Y<0||newHead.Y>=Console.WindowHeight || IsHeadOnBody(newHead);
        }

        private bool IsHeadOnBody(Body newHead)
        {      
            foreach (var item in CurrentSnakeBody.Snake.Skip(1).ToList())
            {
                if (item.Equals(newHead))
                {
                    return true;
                }
            }
            return false;
        }

        private void Lose()
        {
            Console.Clear();
            Console.WriteLine($"You lose with score {CurrentSnakeBody._length}!");
            Environment.Exit(0);
        }
    }
}
