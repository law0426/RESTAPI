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
    /*//the Attribute BELLOW tells the METHOD where to find the object. If it WASN'T used..? 
    //Then there would be no method called to create the object, and the method bellow wouldn't have the argument necessary to execute properly.
    //Called from the client upon url input? I'm assuming? FML too much guesswork.
    //But at least I know the query is essentially the part of the URL that comes after the '?' usually with a lot of
    //Elements like ?Title=string. with multiple parameters separated by &.*/
    //Ok, how do I make this whole thing async?

    public async Task<IActionResult> Get([FromQuery] QueryDto? dto) // add CancellationToken cancellationToken?
    {
        logger.LogInformation("Received Get request on standard route!");
        return Ok( dto.BuildQuery(context)); //TODO: Add cancellation token?
    }


    [HttpGet("complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetComplete()
    {
        return Ok(context.GetCompleteTasks());
    }
    /* //Old functioning version bellow:
    public IActionResult Get([FromQuery] QueryDto? dto) 
    {
        logger.LogInformation("Received Get request on standard route!");
        return Ok(dto.BuildQuery(context));
    }
    [HttpGet("complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetComplete()
    {
        return Ok(context.GetCompleteTasks());
    }
*/


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
    //TODO: Update with better status? Created?
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] UserTaskDto dto) //Somehow gets data from body. How? I dunno. FURTHER READING.
    {
        return Ok(dto.InsertTask(context));
    }
}
