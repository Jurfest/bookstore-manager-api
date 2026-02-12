using BookstoreManager.Exceptions;
using BookstoreManager.Infrastructure;

namespace BookstoreManager.UseCases;

public class DeleteBookUseCase
{
    public void Execute(Guid id)
    {
        using var dbContext = new BookstoreManagerDbContext();
        
        var entity = dbContext.Books.FirstOrDefault(book => book.Id == id);
        
        if (entity is null)
            throw new NotFoundException("Client not found.");

        dbContext.Books.Remove(entity);
        dbContext.SaveChanges();
    }
}