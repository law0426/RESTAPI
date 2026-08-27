namespace RestApi.Interfaces;

public interface ITaskContext
{
    int Count {get;}
    List<IUserTask> GetAllTasks();
    IUserTask? GetTaskById(int id);
    Task<IUserTask?> AsyncGetTaskById(int id);
    List<IUserTask> GetPendingTasks();
    Task<List<IUserTask>> AsyncGetPendingTasks();

    List<IUserTask> GetCompleteTasks();
    Task< List<IUserTask>> AsyncGetCompleteTasks();


    bool CompleteTask(int id);
    Task<bool>  AsyncCompleteTask(int id);
    bool DeleteTask(int id);
    Task<bool> AsyncDeleteTask(int id);
    IUserTask AddTask(string title, string description, DateTime dueDate);
}