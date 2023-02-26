namespace ConsoleApp.Models{
    public class Author:Person{
        public Guid Id {get;set;} =new Guid();
        public IEnumerable<Boock> Boocks {get;}
    }
}