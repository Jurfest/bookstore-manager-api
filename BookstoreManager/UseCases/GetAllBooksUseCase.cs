using BookstoreManager.Contracts.Responses;
using BookstoreManager.Infrastructure;

namespace BookstoreManager.UseCases;

public class GetAllBooksUseCase
{
    public List<BookResponse> Execute()
    {
        using var dbContext = new BookstoreManagerDbContext();

        var books = dbContext.Books
            .Select(entity => new BookResponse(
                entity.Id,
                entity.Title,
                entity.Author,
                entity.Genre.ToString(),
                entity.Price,
                entity.Stock,
                entity.CreatedAt,
                entity.UpdatedAt
            ))
            .ToList();

        return books;
    }
}