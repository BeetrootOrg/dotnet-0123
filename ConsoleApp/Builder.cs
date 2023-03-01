namespace ConsoleApp
{
    public record Car
    {
        public string Name { get; init; }
        public string Color { get; init; }
        public int Year { get; init; }
        public int Price { get; init; }
    }

    public class CarBuilder
    {
        private string _name;
        private string _color;
        private int _year;
        private int _price;

        public CarBuilder WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace", nameof(name));
            }

            _name = name;
            return this;
        }

        public CarBuilder WithColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException("Color cannot be null or whitespace", nameof(color));
            }

            _color = color;
            return this;
        }

        public CarBuilder WithYear(int year)
        {
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new ArgumentException("Year must be between 1900 and current year", nameof(year));
            }

            _year = year;
            return this;
        }

        public CarBuilder WithPrice(int price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative", nameof(price));
            }

            _price = price;
            return this;
        }

        public Car Build()
        {
            return _name == null || _color == null || _year == 0 || _price == 0
                ? throw new InvalidOperationException("Car is not fully built")
                : new Car
                {
                    Name = _name,
                    Color = _color,
                    Year = _year,
                    Price = _price
                };
        }

        public CarBuilder Clear()
        {
            _name = null;
            _color = null;
            _year = 0;
            _price = 0;
            return this;
        }
    }
}