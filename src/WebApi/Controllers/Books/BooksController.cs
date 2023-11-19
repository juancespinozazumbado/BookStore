
using Microsoft.AspNetCore.Mvc;

namespace Bibiolteca.WebApi.Controllers.Books;


[ApiController]
[Route("Api/v1/Books/")]
public class BooksController : ControllerBase
{

    [HttpGet()]
    public ActionResult<string> GetBooks()
    {
        return Ok("Hello");

    }

     [HttpGet("{id}")]
    public ActionResult<string> GetBook()
    {
        var json =
        @"
        {
            ""Book"": ""BookName"",
            ""Id"": ""Idk""
        } 
        ";
        return Ok(json);

    }

}