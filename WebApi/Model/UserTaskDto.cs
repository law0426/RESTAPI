using System.Text.Json.Serialization;
using RestApi.Interfaces;

namespace RestApi.Models;


//This helps us search the body for the parameters. Which are used to for the backend usertask object.
public class UserTaskDto
{
    [JsonPropertyName("title")]
    public required string Title{get;set;}
    [JsonPropertyName("description")]
    public required string Description{get;set;}
    [JsonPropertyName("dueDate")]
    public required DateTime DueDate{get;set;}

//Task itaskcontext, creates a task with dto properties, returns iusertask.
    // public IUserTask InsertTask(ITaskContext context)
    // {
    //     return context.AddTask(Title, Description, DueDate);
    // }
    public async Task<UserTask> AsyncInsertTask(ITaskContext context)
    {
        return await context.AsyncAddTask(Title, Description, DueDate);
    }
}