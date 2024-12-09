using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    [HttpPost("post")]
    public ActionResult<Book> Post([FromBody] Book entry)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}")]
    public ActionResult<Book> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("put/{id}")]
    public ActionResult<Book> Put(int id, [FromBody] Book entry)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
