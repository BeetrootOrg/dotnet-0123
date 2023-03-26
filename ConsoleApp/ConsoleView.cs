using SnakeGame.Domain;
using SnakeGame.Objects;
namespace SnakeGame.ConsoleView
{
    internal class ConsoleView
    {
        private Moving MainObject { get; set; }
        private Meal MealOnField { get; set; }
        public double GameSpeed 
        {
            get => 0.3 - MainObject.CurrentSnakeBody._length/100;
        }
        private List<Body> _queryOfTails;
        public ConsoleView()
        {
            MainObject = new Moving();
            MealOnField = GenerateMealCoords();
            _queryOfTails = new List<Body>();
        }
        public void Render()
        {
            Console.Clear();
            MainObject.MakeMove();
            IsGrowing();
            WriteMeal();
            WriteSnake();
            WriteTail();
        }
        private bool IsGrowing()
        {
            if(!IsMealOnBody(MealOnField)) 
            {
                return false;
            }
            _queryOfTails.Add(new Body(MealOnField));
            MealOnField = GenerateMealCoords();
            return true;
        }
        public void Test()
        {
            MainObject = new Moving(new KeyInput(), new SnakeBody( new List<Body>
            {
                new Body(),
                new Body(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1),
                new Body(Console.WindowWidth / 2, Console.WindowHeight / 2 + 2)
            }));
        }
        private void WriteTail()
        {
            if (_queryOfTails.Count==0)
            {
                return;
            }
            Body tail = _queryOfTails.First();
            if (!IsTailInBody(tail))
            {
                Console.SetCursorPosition(tail.X, tail.Y);
                Console.Write(tail.BodyChar);
                MainObject.CurrentSnakeBody.AddTail(tail);
                _queryOfTails.RemoveAt(0);
            }
        }
        private bool IsTailInBody(Body tail)
        {
            foreach (var item in MainObject.CurrentSnakeBody.Snake)
            {
                if (item.Equals(tail))
                {
                    return true;
                }
            }
            return false;
        }
        public void Action()
        {
            MainObject.CheckDirection();
        }
        private void WriteSnake()
        {
            foreach (var item in MainObject.CurrentSnakeBody.Snake)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.BodyChar);
            }
        }
        private void WriteMeal()
        {
            Console.SetCursorPosition(MealOnField.X, MealOnField.Y);
            Console.Write(MealOnField.MealChar);
        }
        private Meal GenerateMealCoords()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            Meal output = new Meal();
            do
            {
                output.X = random.Next(0, Console.WindowWidth);
                output.Y = random.Next(0, Console.WindowHeight);
            } while (IsMealOnBody(output));
            return output;
        }
        private bool IsMealOnBody(Meal meal)
        {
            foreach (var item in MainObject.CurrentSnakeBody.Snake)
            {
                if ((meal.X == item.X) && (meal.Y == item.Y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}