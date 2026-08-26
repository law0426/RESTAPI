using ASPNETAlong.Interfaces;

namespace ASPNETAlong.Models;

public class QueryDto
{
    public string? Title{set;get;}
    public string? Description{set;get;}
    public DateTime? StartDate{set;get;}
    public DateTime? EndDate{set;get;}

    //TODO: Make async.
    public IQueryable<IUserTask> BuildQuery(ITaskContext context)
    {
        var query = context.GetAllTasks().AsQueryable();
        if(!string.IsNullOrWhiteSpace(Title)) query = query.Where(task => task.Title.Contains(Title, StringComparison.InvariantCultureIgnoreCase));
        if(!string.IsNullOrWhiteSpace(Description)) query = query.Where( task => task.Description.Contains(Description, StringComparison.InvariantCultureIgnoreCase));
        if(StartDate.HasValue) query = query.Where( task => task.DueDate > StartDate);
        if(EndDate.HasValue) query = query.Where( task => task.DueDate < EndDate);
        return query;
    }
}