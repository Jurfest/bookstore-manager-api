using Microsoft.AspNetCore.Mvc;

namespace BookstoreManager.Controllers;

// TODO: Add version control 
// dotnet add package Asp.Versioning.Mvc
// [Route("api/v{version:apiVersion}/[controller]")]
// [ApiVersion("1.0")]
// config Program.cs

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    
}