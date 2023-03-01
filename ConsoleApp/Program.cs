using Library;

Client client1 = new ("Tom", "Hanks", true );
Client client2 = new ("Robert", "Dauni", false);
Client client3 = new ("Nicole", "Kidman", true);
Console.WriteLine(client1);

Author author1 = new Author("Taras", "Shevchenko");

Books book1 = new Books("Love", author1, "novel");
Books book2 = new Books("Loves", author1, "novels");

Console.WriteLine(book1.BookId);
Console.WriteLine(book2.BookId);
Console.WriteLine(book1.BookId);
BookAccounting item1 = new BookAccounting(book1, true);
Record record1 = new Record(book1, client3, , );
