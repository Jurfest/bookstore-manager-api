using BookstoreManager.Models;

namespace BookstoreManager.Contracts.Requests;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
}