namespace ConsoleApp
{
    public class ChangeableChangeArgs
    {
        public int Old {get; init;}
        public int New {get; init;}
    }
    public delegate void OnChangeableChange(Changeable obj, ChangeableChangeArgs args);
    public class Changeable
    {
        private int _number;
        public int Number 
        {
            get
            {
                return _number;
            }
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
        private event OnChangeableChange _onChangeableChange;
        public event OnChangeableChange OnChangeableChange
        {
            add
            {
                _onChangeableChange += value;
            }
            remove
            {
                _onChangeableChange -= value;
            }
        }
        private void InvokeOnChangeableChange(ChangeableChangeArgs args)
        {
            _onChangeableChange?.Invoke(this, args);
        }
    }
}