// Book class that inherits from Media
class Book : Media
{
    public string Author { get; set; }

    // Constructor for creating a new Book
    public Book(string title, string author, int rating) : base(title, rating)
    {
        Author = author;
    }
}