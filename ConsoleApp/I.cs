namespace ConsoleApp
{
    public interface IEmployeeBad
    {
        decimal Salary { get; }
        void DoWork();
        void Manage();
    }

    public interface IBaseEmployee
    {
        decimal Salary { get; }
    }

    public interface IPerformer : IBaseEmployee
    {
        void DoWork();
    }

    public interface IManager : IBaseEmployee
    {
        void Manage();
    }
}