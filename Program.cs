using System;

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();

        Console.WriteLine("Enter a book title:");
        string title = Console.ReadLine();

        book.AddTitle(title);

        Console.WriteLine("Book title added successfully!");
    }
}