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
                    RemoveMedia(mediaList);
                    break;
                case "7":
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

    // Display the main menu options
    static void DisplayMenu()
    {
        Console.WriteLine("=== Media Management System ===");
        Console.WriteLine("1. Add a new book");
        Console.WriteLine("2. Add a new film");
        Console.WriteLine("3. View all media");
        Console.WriteLine("4. Sort by rating");
        Console.WriteLine("5. Export to .csv");
        Console.WriteLine("6. Remove media");
        Console.WriteLine("7. Exit");
        Console.Write("Enter your choice (1-7): ");
    }

    // Method to add a new book
    static void AddBook(List<Media> mediaList)
    {
        Console.Write("Enter the book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the author name: ");
        string author = Console.ReadLine();

        int rating = GetRating();

        DateTime purchaseDate = GetPurchaseDate();

        Console.Write("Has the book been completed? (y/n): ");
        bool completed = Console.ReadLine().ToLower() == "y";

        // Create a new Book object and add it to the list
        Book book = new Book(title, author, rating, purchaseDate, completed);
        mediaList.Add(book);

        Console.WriteLine("Book added successfully!");
    }

    // Add a new film to the media list

    static void AddFilm(List<Media> mediaList)
    {
        Console.Write("Enter the film title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the director name: ");
        string director = Console.ReadLine();

        int rating = GetRating();

        DateTime purchaseDate = GetPurchaseDate();

        Console.Write("Has the film been watched? (y/n): ");
        bool completed = Console.ReadLine().ToLower() == "y";

        // Create a new Film object and add it to the list
        Film film = new Film(title, director, rating, purchaseDate, completed);
        mediaList.Add(film);

        Console.WriteLine("Film added successfully!");
    }

    // Helper method to get a valid purchase date from the user
    static DateTime GetPurchaseDate()
    {
        while (true)
        {
            Console.Write("Enter the purchase date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime purchaseDate))
            {
                return purchaseDate;
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }

    // Get a valid rating from the user
    static int GetRating()
    {
        int rating = 0;
        while (true)
        {
            Console.Write("Enter the rating (1-5): ");
            try
            {
                rating = int.Parse(Console.ReadLine());
                if (rating >= 1 && rating <= 5)
                {
                    return rating;
                }
                else
                {
                    Console.WriteLine("Rating must be between 1 and 5. Please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }

    // Display all media items in the list
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
                string completionStatus = item.Completed ? "Completed" : "Not completed";
                if (item is Book book)
                {
                    Console.WriteLine($"ID: {book.Id}, Book - Title: {book.Title}, Author: {book.Author}, Rating: {book.Rating}, " +
                                      $"Purchase Date: {book.PurchaseDate:yyyy-MM-dd}, Status: {completionStatus}");
                }
                else if (item is Film film)
                {
                    Console.WriteLine($"ID: {film.Id}, Film - Title: {film.Title}, Director: {film.Director}, Rating: {film.Rating}, " +
                                      $"Purchase Date: {film.PurchaseDate:yyyy-MM-dd}, Status: {completionStatus}");
                }
            }
        }
    }

    // Sort media items by rating in descending order
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

    // Remove Media from list
    static void RemoveMedia(List<Media> mediaList)
    {
        if (mediaList.Count == 0)
        {
            Console.WriteLine("There are no items in the list to remove.");
            return;
        }

        ViewAllMedia(mediaList);
        Console.Write("Enter the ID of the media you want to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Media mediaToRemove = mediaList.FirstOrDefault(m => m.Id == id);
            if (mediaToRemove != null)
            {
                mediaList.Remove(mediaToRemove);
                Console.WriteLine($"Media with ID {id} has been removed successfully.");
            }
            else
            {
                Console.WriteLine($"No media found with ID {id}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.");
        }
    }

    // Export media list to a CSV file
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