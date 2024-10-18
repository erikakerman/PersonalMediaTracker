using System;
using System.Collections.Generic;
using System.Linq;

// Base class for all types of media
class Media
{
    private static int nextId = 1;

    public int Id { get; }
    public string Title { get; set; }
    public int Rating { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool Completed { get; set; }

    // Constructor to create a new Media object
    public Media(string title, int rating, DateTime purchaseDate, bool completed = false)
    {
        Id = nextId++;
        Title = title;
        Rating = rating;
        PurchaseDate = purchaseDate;
        Completed = completed;
    }

    // Method to mark the media as completed
    public void MarkAsCompleted()
    {
        Completed = true;
    }
}