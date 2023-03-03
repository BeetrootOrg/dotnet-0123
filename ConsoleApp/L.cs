namespace ConsoleApp
{
    public class LiskovBaseBad
    {
#pragma warning disable
        public void DoSomething()
#pragma warning enable
        {
            Console.WriteLine("Base");
        }
    }

    public class LiskovDerivedBad : LiskovBaseBad
    {
        public new void DoSomething()
        {
            Console.WriteLine("Derived");
        }
    }

    public class LiskovBaseGood
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("Base");
        }
    }

    public class LiskovDerivedGood : LiskovBaseGood
    {
        public override void DoSomething()
        {
            Console.WriteLine("Derived");
        }
    }
}