namespace SnakeGame.Objects
{
    internal class SnakeBody
    {
        public List<Body> Snake {get;private set;}
        internal Body _head;
        internal int _length
        {
            get => Snake.Count;
        }

        public SnakeBody()
        {
            Snake = new List<Body>
            {
                new Body()
            };
            _head = Snake.First();
        }
        public SnakeBody(List<Body> bodies)
        {
            Snake = bodies;
            _head = Snake.First();
        }
        public void AddTail(Body tail)
        {
            Snake.Add(tail);
        }
    }
}