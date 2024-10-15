using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>();

        Console.WriteLine("Enter a book title:");
        string title = Console.ReadLine();

        Book book = new Book(title);
        books.Add(book);

        Console.WriteLine("Book added successfully!");

        Console.WriteLine("\nBooks in the list:");
        foreach (Book b in books)
        {
            Console.WriteLine(b.Title);
        }
    }
}