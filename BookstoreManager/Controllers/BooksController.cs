using BookstoreManager.Contracts.Requests;
using BookstoreManager.Contracts.Responses;
using BookstoreManager.Models;
using BookstoreManager.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManager.Controllers;

public class BooksController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status201Created)]
    // [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult AddBook([FromBody] CreateBookRequest request)
    {
        var useCase = new CreateBookUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    // [HttpGet]
    // public IActionResult TempEndpoint()
    // {
    //     var response = new List<Book>()
    //     {
    //         new Book
    //         {
    //             Author = "Diego",
    //             Price = 22,
    //             Stock = 2,
    //             Genre = BookGenre.Poetry,
    //             Title = "Dieguito",
    //         },
    //     };
    //         
    //     return Ok(response);
    // }
}