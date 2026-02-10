namespace BookstoreManager.Models;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
    
    public void Update(
        string title,
        string author,
        BookGenre genre,
        decimal price,
        int stock)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Stock = stock;

        MarkAsUpdated();
    }
}