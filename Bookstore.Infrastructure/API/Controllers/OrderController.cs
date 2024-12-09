using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller
{
    [HttpPost("post")]
    public ActionResult<Order> Post([FromBody] Order entry)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}")]
    public ActionResult<Order> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<Order>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("put/{id}")]
    public ActionResult<Order> Put(int id, [FromBody] Order entry)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
