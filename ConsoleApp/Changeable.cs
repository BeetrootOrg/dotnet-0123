namespace ConsoleApp
{
    public class ChangeableChangeArgs
    {
        public int Old { get; init; }
        public int New { get; init; }
    }

    public delegate void OnChangeableChange(Changeable obj, ChangeableChangeArgs args);

    public class Changeable
    {
        private int _number;

        public int Number
        {
            get => _number;
            set
            {
                OnChangeableChange(this, new ChangeableChangeArgs
                {
                    Old = _number,
                    New = value
                });

                _number = value;
            }
        }

        public OnChangeableChange OnChangeableChange { get; set; }
    }
}