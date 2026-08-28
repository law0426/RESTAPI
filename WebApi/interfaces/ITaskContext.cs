namespace RestApi.Interfaces;
using RestApi.Models;

public interface ITaskContext
{
    int Count {get;}
    List<IUserTask> GetAllTasks();
    Task<List<UserTask>> AsyncGetAllTasks();
    IUserTask? GetTaskById(int id);
    Task<UserTask?> AsyncGetTaskById(int id);
    List<IUserTask> GetPendingTasks();
    Task<List<UserTask>> AsyncGetPendingTasks();

    List<IUserTask> GetCompleteTasks();
    Task< List<UserTask>> AsyncGetCompleteTasks();


    bool CompleteTask(int id);
    Task<bool>  AsyncCompleteTask(int id);
    bool DeleteTask(int id);
    Task<bool> AsyncDeleteTask(int id);
    Task<UserTask> AddTask(string title, string description, DateTime dueDate);
}