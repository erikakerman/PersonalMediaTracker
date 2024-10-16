using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        List<Media> mediaList = new List<Media>();
        bool exitProgram = false;

        while (!exitProgram)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(mediaList);
                    break;
                case "2":
                    AddFilm(mediaList);
                    break;
                case "3":
                    ViewAllMedia(mediaList);
                    break;
                case "4":
                    SortMediaByRating(mediaList);
                    break;
                case "5":
                    ExportToCSV(mediaList);
                    break;
                case "6":
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
        Console.WriteLine("=== Media Management System ===");
        Console.WriteLine("1. Add a new book");
        Console.WriteLine("2. Add a new film");
        Console.WriteLine("3. View all media");
        Console.WriteLine("4. Sort by rating");
        Console.WriteLine("5. Export to .csv");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    static void AddBook(List<Media> mediaList)
    {
        Console.Write("Enter the book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the author name: ");
        string author = Console.ReadLine();

        int rating = GetRating();

        Book book = new Book(title, author, rating);
        mediaList.Add(book);

        Console.WriteLine("Book added successfully!");
    }

    static void AddFilm(List<Media> mediaList)
    {
        Console.Write("Enter the film title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the director name: ");
        string director = Console.ReadLine();

        int rating = GetRating();

        Film film = new Film(title, director, rating);
        mediaList.Add(film);

        Console.WriteLine("Film added successfully!");
    }

    static int GetRating()
    {
        int rating = 0;
        while (rating < 1 || rating > 5)
        {
            Console.Write("Enter the rating (1-5): ");
            if (int.TryParse(Console.ReadLine(), out rating))
            {
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine("Rating must be between 1 and 5. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
        return rating;
    }

    static void ViewAllMedia(List<Media> mediaList)
    {
        if (mediaList.Count == 0)
        {
            Console.WriteLine("There are no items in the list.");
        }
        else
        {
            Console.WriteLine("Media in the list:");
            foreach (Media item in mediaList)
            {
                if (item is Book book)
                {
                    Console.WriteLine($"Book - Title: {book.Title}, Author: {book.Author}, Rating: {book.Rating}");
                }
                else if (item is Film film)
                {
                    Console.WriteLine($"Film - Title: {film.Title}, Director: {film.Director}, Rating: {film.Rating}");
                }
            }
        }
    }
    static void SortMediaByRating(List<Media> mediaList)
    {
        if (mediaList.Count == 0)
        {
            Console.WriteLine("The list is empty. There's nothing to sort.");
            return;
        }

        mediaList.Sort((a, b) => b.Rating.CompareTo(a.Rating));

        Console.WriteLine("Media list sorted by rating (descending order):");
        ViewAllMedia(mediaList);
    }

    static void ExportToCSV(List<Media> mediaList)
    {
        string filePath = @"D:\media_list.csv";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header
                writer.WriteLine("Type;Title;Author/Director;Rating");

                // Write each media item
                foreach (Media item in mediaList)
                {
                    string line;
                    if (item is Book book)
                    {
                        line = $"Book;{book.Title};{book.Author};{book.Rating}";
                    }
                    else if (item is Film film)
                    {
                        line = $"Film;{film.Title};{film.Director};{film.Rating}";
                    }
                    else
                    {
                        continue; // Skip if it's neither a Book nor a Film
                    }
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Data exported successfully!");
            Console.WriteLine($"File saved at: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while writing the file: {ex.Message}");
        }
    }
}