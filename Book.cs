class Book : Media
{
    public string Author { get; set; }

    public Book(string title, string author, int rating) : base(title, rating)
    {
        Author = author;
    }
}