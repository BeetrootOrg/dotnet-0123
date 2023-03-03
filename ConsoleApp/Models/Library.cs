namespace ConsoleApp.Models
{
    public class Library { 
        public IEnumerable<Book> Books {get;set;}
        public IEnumerable<User> Users {get;set;}
        public IEnumerable<Record> Registry {get;set;}
    }
}