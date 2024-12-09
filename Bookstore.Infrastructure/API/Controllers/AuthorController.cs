using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : Controller
{
    [HttpPost("post")]
    public ActionResult<Author> Post([FromBody] Author entry)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}")]
    public ActionResult<Author> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<Author>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("put/{id}")]
    public ActionResult<Author> Put(int id, [FromBody] Author entry)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
