using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : Controller
{
    [HttpPost("post")]
    public ActionResult<Customer> Post([FromBody] Customer entry)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}")]
    public ActionResult<Customer> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("put/{id}")]
    public ActionResult<Customer> Put(int id, [FromBody] Customer entry)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
