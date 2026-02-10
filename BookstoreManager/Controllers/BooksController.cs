using Microsoft.AspNetCore.Mvc;

namespace BookstoreManager.Controllers;

public class BooksController : ApiControllerBase
{
    [HttpGet]
    public IActionResult TempEndpoint()
    {
        return Ok("Ok");
    }
}