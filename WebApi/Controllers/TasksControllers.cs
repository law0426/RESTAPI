using RestApi.Interfaces;
using RestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("/[Controller]/")] //This essentially takes the name bellow and 
//removes the controller part, leaving the "Tasks" route that it's responsible for.
//Basically enforcing consistency in the naming conventions.
public class TasksController(ITaskContext context, ILogger<TasksController> logger) : ControllerBase
{
    


    //Gets request types and links them to appropriate endpoint methods.
    [HttpGet] //This part decides the name in swagger.
    [ProducesResponseType(StatusCodes.Status200OK)]
    /*//the Attribute BELLOW tells the METHOD where to find the object. If it WASN'T used..? 
    //Then there would be no method called to create the object, and the method bellow wouldn't have the argument necessary to execute properly.
    //Called from the client upon url input? I'm assuming? FML too much guesswork.
    //But at least I know the query is essentially the part of the URL that comes after the '?' usually with a lot of
    //Elements like ?Title=string. with multiple parameters separated by &.*/
    //Ok, how do I make this whole thing async?

    public async Task<IActionResult> GetAllAsync([FromQuery] QueryDto? dto) // add CancellationToken cancellationToken?
    {
        logger.LogInformation("Received Get request on standard route!");
        return Ok(await dto.BuildQuery(context)); //TODO: Add cancellation token? Allow nullability?
    }


    [HttpGet("complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetComplete()
    {
        return Ok(await context.AsyncGetCompleteTasks());
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
    public async Task <IActionResult> GetPending()
    {
        return Ok( await context.AsyncGetPendingTasks());
    }
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] //Despite the syntax, this is for errorhandling?
    public async Task< IActionResult> Get(int id)
    {
        var task = await context.AsyncGetTaskById(id);
        if(task is null) return NotFound();
        return Ok(task);
    }
    [HttpPatch("complete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(int id)
    {
        var completedTask = await context.AsyncCompleteTask(id);
        if(completedTask) return NoContent();//Action successful, but nothing to return.
        else return NotFound();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedTask = await context.AsyncDeleteTask(id);
        if(deletedTask) return NoContent();
        else return NotFound();
    }
    //TODO: Update with better status? Created?
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] UserTaskDto dto) //Somehow gets data from body. How? I dunno. FURTHER READING.
    {
        return Ok(await dto.AsyncInsertTask(context));
    }
}
