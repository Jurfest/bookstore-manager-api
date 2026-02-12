using BookstoreManager.Contracts.Requests;
using BookstoreManager.Contracts.Responses;
using BookstoreManager.Exceptions;
using BookstoreManager.Infrastructure;
using BookstoreManager.Models;
using BookstoreManager.UseCases.SharedValidator;

namespace BookstoreManager.UseCases;

public class CreateBookUseCase
{
    public BookResponse Execute(CreateBookRequest request)
    {
        Validate(request);
        
        using var dbContext = new BookstoreManagerDbContext();
        
        ValidateBusinessRules(request, dbContext);
        
        var entity = new Book {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock
        };
        dbContext.Books.Add(entity);
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
    
    private void Validate(CreateBookRequest request)
    {
        var validator = new RequestBookValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
    
    private void ValidateBusinessRules(CreateBookRequest request, BookstoreManagerDbContext dbContext)
    {
        var alreadyExists = dbContext.Books.Any(book =>
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