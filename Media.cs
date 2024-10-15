class Media
{
    public string Title { get; set; }
    public int Rating { get; set; }

    public Media(string title, int rating)
    {
        Title = title;
        Rating = rating;
    }
}