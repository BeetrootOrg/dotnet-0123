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
                InvokeOnChangeableChange(new ChangeableChangeArgs
                {
                    Old = _number,
                    New = value
                });

                _number = value;
            }
        }

        private event OnChangeableChange OnChangeableChange;

        public event OnChangeableChange OnChangeableChangeEvent
        {
            add => OnChangeableChange += value;
            remove => OnChangeableChange -= value;
        }

        private void InvokeOnChangeableChange(ChangeableChangeArgs args)
        {
            OnChangeableChange?.Invoke(this, args);
        }
    }
}