// Base class for all types of media
class Media
{
    public string Title { get; set; }
    public int Rating { get; set; }

    // Constructor to create a new Media object
    public Media(string title, int rating)
    {
        Title = title;
        Rating = rating;
    }
}