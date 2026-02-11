namespace BookstoreManager.Contracts.Responses;

public sealed class BookResponse
{
    public Guid Id { get; }
    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public decimal Price { get; }
    public int Stock { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }

    
    public BookResponse(
        Guid id,
        string title,
        string author,
        string genre,
        decimal price,
        int stock,
        DateTime createdAt,
        DateTime? updatedAt)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Stock = stock;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}