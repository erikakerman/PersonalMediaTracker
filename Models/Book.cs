class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }

    public Book(string title, string author, int rating)
    {
        Title = title;
        Author = author;
        Rating = rating;
    }
}