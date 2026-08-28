using RestApi.Interfaces;

namespace RestApi.Models;

public class QueryDto
{
    public string? Title{set;get;}
    public string? Description{set;get;}
    public DateTime? StartDate{set;get;}
    public DateTime? EndDate{set;get;}

    //TODO: Make async.
    public async Task<IQueryable<IUserTask>> BuildQuery(ITaskContext context)
    {
        var list = await context.AsyncGetAllTasks();
        var query = list.AsQueryable();
        if(!string.IsNullOrWhiteSpace(Title)) query = query.Where(task => task.Title.Contains(Title, StringComparison.InvariantCultureIgnoreCase));
        if(!string.IsNullOrWhiteSpace(Description)) query = query.Where( task => task.Description.Contains(Description, StringComparison.InvariantCultureIgnoreCase));
        if(StartDate.HasValue) query = query.Where( task => task.DueDate > StartDate);
        if(EndDate.HasValue) query = query.Where( task => task.DueDate < EndDate);
        return query;
    }
}