using BookstoreManager.Contracts.Responses;
using BookstoreManager.Exceptions;
using BookstoreManager.Infrastructure;

namespace BookstoreManager.UseCases;

public class GetBookByIdUseCase
{
    public BookResponse Execute(Guid id)
    {
        using var dbContext = new BookstoreManagerDbContext();

        var entity = dbContext
            .Books
            .FirstOrDefault(book => book.Id == id);
        
        if (entity is null)
            throw new NotFoundException("Book not found.");

        return new BookResponse(
            entity.Id,
            entity.Title,
            entity.Author,
            entity.Genre.ToString(),
            entity.Price,
            entity.Stock,
            entity.CreatedAt,
            entity.UpdatedAt
        );
    }
}