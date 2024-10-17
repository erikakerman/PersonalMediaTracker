// Film class that inherits from Media
class Film : Media
{
    public string Director { get; set; }

    // Constructor for creating a new Film
    public Film(string title, string director, int rating) : base(title, rating)
    {
        Director = director;
    }
}