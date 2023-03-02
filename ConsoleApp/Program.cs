using Library;

Client client1 = new ("Tom", "Hanks", true );
Client client2 = new ("Robert", "Dauni", false);
Client client3 = new ("Nicole", "Kidman", true);


Author author1 = new Author("Vasyl", "Shklar");
Author author2 = new Author("Taras", "Shevchenko");


Book book1 = new Book("Chorniij Voron", author1, "novel");
Book book2 = new Book("Son", author2, "comedy");

Console.WriteLine(book1.BookId);
Console.WriteLine(book2.BookId);
Console.WriteLine(book1.BookId);
DateTime taking1 = new DateTime(2023, 03, 02);
DateTime returning1 = new DateTime(2023, 04, 25);

Record record1 = new Record(book1, client3, taking1, returning1);
