using BookstoreManager.Contracts.Requests;
using BookstoreManager.Contracts.Responses;
using BookstoreManager.Exceptions;
using BookstoreManager.Infrastructure;
using BookstoreManager.UseCases.SharedValidator;

namespace BookstoreManager.UseCases;

public class UpdateBookUseCase
{
    public BookResponse Execute(Guid id, UpdateBookRequest request)
    {
        Validate(request);

        using var dbContext = new BookstoreManagerDbContext();
        
        var entity = dbContext.Books.FirstOrDefault(b => b.Id == id);

        if (entity is null)
            throw new NotFoundException("Book not found.");
        
        ValidateBusinessRules(id, request, dbContext);

        entity.Update(
            request.Title,
            request.Author,
            request.Genre,
            request.Price,
            request.Stock
        );

        dbContext.SaveChanges();

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

    private void Validate(UpdateBookRequest request)
    {
        var validator = new RequestBookValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
    
    private void ValidateBusinessRules(Guid id, UpdateBookRequest request, BookstoreManagerDbContext dbContext)
    {
        var alreadyExists = dbContext.Books.Any(book =>
            book.Id != id &&
            book.Title == request.Title &&
            book.Author == request.Author);

        if (alreadyExists)
        {
            throw new ErrorOnValidationException(new List<string>
            {
                "A book with the same title and author already exists."
            });
        }
    }
}
