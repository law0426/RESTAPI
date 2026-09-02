namespace RestApi.Models;

using RestApi.Interfaces;
using Microsoft.EntityFrameworkCore;



public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options), ITaskContext
{
    public required DbSet<UserTask> Tasks{get;set;}
    //private List<IUserTask> Tasks = [];
    //private int _nextId;
    public int Count => Tasks.Count();

    public async Task<UserTask> AsyncAddTask(string title, string description, DateTime dueDate)
    {
        var newTask = new UserTask(/*++_nextId,*/ title, description,dueDate);
        await Tasks.AddAsync(newTask);
        await SaveChangesAsync();
        return newTask;
    }

    public bool CompleteTask(int id)
    {
        var task = Tasks.FirstOrDefault(task => task.Id == id);
        if (task is null) return false;
        task.IsCompleted = true;
        SaveChanges();
        return true;
    }

    public async Task<bool> AsyncCompleteTask(int id)
    {
        var task = await Tasks.FirstOrDefaultAsync(task => task.Id == id);
        if (task is null) return false;
        task.IsCompleted = true;
        await SaveChangesAsync();
        return true;
    }
    

    public bool DeleteTask(int id)
    {
        var task = Tasks.FirstOrDefault(task => task.Id == id);
        if (task is null) return false;
        Tasks.Remove(task);
        SaveChanges();
        return true;
    }
    public async Task<bool> AsyncDeleteTask(int id)
    {
        var task = await Tasks.FirstOrDefaultAsync(task => task.Id == id);
        if (task is null) return false;
        Tasks.Remove(task);
        await SaveChangesAsync();
        return true;
    }

    public List<IUserTask> GetAllTasks()
    {
        return [..Tasks.AsNoTracking()];//FURTHER READING: ".." needs elaborating.
    }
    public async Task <List<UserTask>> AsyncGetAllTasks()
    {
        return await Tasks.ToListAsync();
    }

    public List<IUserTask> GetCompleteTasks()
    {
        return [..Tasks.Where(task => task.IsCompleted).AsNoTracking()];
    }
    public async  Task<List<UserTask>> AsyncGetCompleteTasks()
    {
        return await Tasks.Where(task => task.IsCompleted).ToListAsync();
    }

    public List<IUserTask> GetPendingTasks()
    {
        return [..Tasks.Where(task => !task.IsCompleted).AsNoTracking()];
    }
    public async Task< List<UserTask>> AsyncGetPendingTasks()
    {
        return await Tasks.Where(task => !task.IsCompleted).ToListAsync();
    }

    public IUserTask? GetTaskById(int id)
    {
        return Tasks.AsNoTracking().FirstOrDefault(task => task.Id == id);
    }
    public async Task<UserTask?> AsyncGetTaskById(int id)
    {
        return await Tasks.AsNoTracking().FirstOrDefaultAsync(task => task.Id == id);
    }
}
