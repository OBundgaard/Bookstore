using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockLevelController(INoSQLRepository<StockLevel> stockLevelRepository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<StockLevel>> Post([FromBody] StockLevel entry)
    {
        var createdStockLevel = await stockLevelRepository.Post(entry);
        return Ok(createdStockLevel);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<StockLevel>> Get(int id)
    {
        var stockLevel = await stockLevelRepository.Get(id.ToString());

        if (stockLevel == null)
            return NotFound();

        return Ok(stockLevel);
    }

    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<StockLevel>>> GetAll()
    {
        var stockLevels = await stockLevelRepository.GetAll();
        return Ok(stockLevels);
    }

    [HttpPut("put/{id}")]
    public async Task<ActionResult<StockLevel>> Put(int id, [FromBody] StockLevel entry)
    {
        if (id != entry.BookID)
            return BadRequest();

        var existingStockLevel = await stockLevelRepository.Get(id.ToString());
        if (existingStockLevel == null)
            return NotFound();

        var updatedStockLevel = await stockLevelRepository.Put(entry);
        return Ok(updatedStockLevel);

    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingStockLevel = await stockLevelRepository.Get(id.ToString());
        if (existingStockLevel == null)
            return NotFound();

        await stockLevelRepository.Delete(id.ToString());
        return NoContent();
    }
}
