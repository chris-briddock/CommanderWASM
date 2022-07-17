using Commander.WASM.Server.Data;
using Commander.WASM.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Commander.WASM.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandsController : ControllerBase
{
private readonly ICommandRepo _repo;
private ILogger _logger;
public CommandsController(ICommandRepo commandRepo, ILogger<CommandsController> logger)
{
    _repo = commandRepo;
    _logger = logger;
}
[HttpGet("{id}")]
public async Task<ActionResult<Command>> Get(Guid Id)
{
    try
    {
        Command command = await _repo.ReadAsync(Id);
        return Ok(command);
    }
    catch
    {
        _logger.LogError("Error in GetCommand, failed to read from the database.");
        return NotFound();

    }
}
[HttpGet]
public async Task<ActionResult<IEnumerable<Command>>> Get()
{
    try
    {
        IEnumerable<Command> commands = await _repo.ReadAllAsync();
        return Ok(commands);
    }
    catch
    {
        _logger.LogError("Error in GetCommands, failed to read from the database.");
        return NoContent();
    }
}
[HttpPut]
public ActionResult<Command> Put([FromBody] Command command)
{
    if (command == null)
    {
        return BadRequest();
    }
    _repo.Update(command);
    if (_repo.SaveChanges() == true)
    {
        return Ok();
    }
    else
    {
        _logger.LogError("Error in PutCommand, failed to update the database.");
        return BadRequest();
    }
}
[HttpPost]
public ActionResult<Command> Post([FromBody] Command command)
{
    _repo.Create(command);

    var savedChanges = _repo.SaveChangesAsync();

    if (savedChanges.IsCompletedSuccessfully)
    {
        return CreatedAtAction(nameof(Get), new { id = command.Id }, command);
    }
    else
    {
        return BadRequest();
    }
}
[HttpDelete("{id}")]
public ActionResult<Command> Delete([FromBody] Guid Id)
{
    if (Id == Guid.Empty)
    {
        return BadRequest();
    }
    _repo.Delete(Id);
    var savedChanges = _repo.SaveChangesAsync();
    if (savedChanges.IsCompletedSuccessfully)
    {
        return NoContent();
    }
    else
    {
        return BadRequest();
    }
}
}

