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

    // No PUT, o ID vem pela rota, não pelo body.
    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] UpdateBookRequest request)
    {
        var useCase = new UpdateBookUseCase();
        var response = useCase.Execute(id, request);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteBookUseCase();
        useCase.Execute(id);

        return NoContent();
    }
}