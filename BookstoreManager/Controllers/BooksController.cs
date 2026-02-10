using BookstoreManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManager.Controllers;

public class BooksController : ApiControllerBase
{
    [HttpGet]
    public IActionResult TempEndpoint()
    {
        var response = new List<Book>()
        {
            new Book
            {
                Author = "Diego",
                Price = 22,
                Stock = 2,
                Genre = BookGenre.Poetry,
                Title = "Dieguito",
            },
        };
            
        return Ok(response);
    }
}