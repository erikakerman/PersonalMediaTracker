using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>();
        bool exitProgram = false;

        while (!exitProgram)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(books);
                    break;
                case "2":
                    ViewAllBooks(books);
                    break;
                case "3":
                    exitProgram = true;
                    Console.WriteLine("Thank you for using the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("=== Book Management System ===");
        Console.WriteLine("1. Add a new book");
        Console.WriteLine("2. View all books");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice (1-3): ");
    }

    static void AddBook(List<Book> books)
    {
        Console.Write("Enter the book title: ");
        string title = Console.ReadLine();

        Book book = new Book(title);
        books.Add(book);

        Console.WriteLine("Book added successfully!");
    }

    static void ViewAllBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books in the list.");
        }
        else
        {
            Console.WriteLine("Books in the list:");
            foreach (Book b in books)
            {
                Console.WriteLine(b.Title);
            }
        }
    }
}