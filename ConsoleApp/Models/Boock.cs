namespace ConsoleApp.Models{
    public class Book{
        public Guid Id {get;set;} =new Guid();
        public string Name {get;set;}
        public Author Author {get;set;}
    }
}