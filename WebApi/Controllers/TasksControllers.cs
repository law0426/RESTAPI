using ASPNETAlong.Interfaces;
using ASPNETAlong.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAlong.Controllers;

[ApiController]
[Route("/[Controller]/")] //This essentially takes the name bellow and 
//removes the controller part, leaving the "Tasks" route that it's responsible for.
//Basically enforcing consistency in the naming conventions.
public class TasksController(ITaskContext context, ILogger<TasksController> logger) : ControllerBase
{
    //Gets request types and links them to appropriate endpoint methods.
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        logger.LogInformation("Received Get request on standard route!");
        return Ok(context.GetAllTasks());
    }
    [HttpGet("complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetComplete()
    {
        return Ok(context.GetCompleteTasks());
    }
    [HttpGet("pending")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetPending()
    {
        return Ok(context.GetPendingTasks());
    }
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] //Despite the syntax, this is for errorhandling?
    public IActionResult Get(int id)
    {
        var task = context.GetTaskById(id);
        if(task is null) return NotFound();
        return Ok(task);
    }
    [HttpPatch("complete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Patch(int id)
    {
        var completedTask = context.CompleteTask(id);
        if(completedTask) return NoContent();//Action successful, but nothing to return.
        else return NotFound();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var deletedTask = context.DeleteTask(id);
        if(deletedTask) return NoContent();
        else return NotFound();
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] UserTaskDto dto) //Somehow gets data from body. How? I dunno. FURTHER READING.
    {
        return Ok(dto.InsertTask(context));
    }
}
