namespace RestApi.Models;

using RestApi.Interfaces;
using Microsoft.EntityFrameworkCore;



public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options), ITaskContext
{
    public DbSet<UserTask> Tasks{get;set;}
    //private List<IUserTask> Tasks = [];
    //private int _nextId;
    public int Count => Tasks.Count();

    public IUserTask AddTask(string title, string description, DateTime dueDate)
    {
        var newTask = new UserTask(/*++_nextId,*/ title, description,dueDate);
        Tasks.Add(newTask);
        SaveChanges();
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
        var task = Tasks.FirstOrDefault(task => task.Id == id);
        if (task is null) return false;
        task.IsCompleted = true;
        SaveChanges();
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
        var task = Tasks.FirstOrDefault(task => task.Id == id);
        if (task is null) return false;
        Tasks.Remove(task);
        SaveChanges();
        return true;
    }

    public List<IUserTask> GetAllTasks()
    {
        return [..Tasks.AsNoTracking()];//FURTHER READING: ".." needs elaborating.
    }
    // public async Task <List<IUserTask>> AsyncGetAllTasks()
    // {
    //     return Tasks;
    // }

    public List<IUserTask> GetCompleteTasks()
    {
        return [..Tasks.Where(task => task.IsCompleted).AsNoTracking()];
    }
    public async  Task<List<IUserTask>> AsyncGetCompleteTasks()
    {
        return [..Tasks.Where(task => task.IsCompleted).AsNoTracking()];
    }

    public List<IUserTask> GetPendingTasks()
    {
        return [..Tasks.Where(task => !task.IsCompleted).AsNoTracking()];
    }
    public async Task< List<IUserTask>> AsyncGetPendingTasks()
    {
        return [..Tasks.Where(task => !task.IsCompleted).AsNoTracking()];
    }

    public IUserTask? GetTaskById(int id)
    {
        return Tasks.AsNoTracking().FirstOrDefault(task => task.Id == id);
    }
    public async Task<IUserTask?> AsyncGetTaskById(int id)
    {
        return Tasks.AsNoTracking().FirstOrDefault(task => task.Id == id);
    }
}
