class Film : Media
{
    public string Director { get; set; }

    public Film(string title, string director, int rating) : base(title, rating)
    {
        Director = director;
    }
}