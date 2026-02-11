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
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult AddBook([FromBody] CreateBookRequest request)
    {
        var useCase = new CreateBookUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllBooksUseCase();
            
        var response = useCase.Execute();

        if (response.Count == 0)
        {
            return NoContent();
        }
            
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetBookByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }
}