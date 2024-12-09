using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockLevelController : Controller
{
    [HttpPost("post")]
    public ActionResult<StockLevel> Post([FromBody] StockLevel entry)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}")]
    public ActionResult<StockLevel> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<StockLevel>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("put/{id}")]
    public ActionResult<StockLevel> Put(int id, [FromBody] StockLevel entry)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
