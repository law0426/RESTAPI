using RestApi.Interfaces; //TODO: RESTRUCTURE AND RENAME.
using RestApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// builder.Services.AddSwaggerGen();
// builder.Services.AddTodoItemDbContext(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddSingleton<ITaskContext, TaskContext>();







var app = builder.Build();

// Console.WriteLine($"is environment in development? {builder.Environment.IsDevelopment()}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "Todo App v1"));
}

//TODO: replace with controllers.

app.UseStaticFiles();

app.MapFallbackToFile("index.html");

app.UseHttpsRedirection();

app.MapGet("/helloworld", () => "Hello, world!");

//Example of expanded expression for possible multiple result messages:
// app.MapGet("/tasks", (ITaskContext context) =>{
//  Results.Ok(context.GetAllTasks()); 
// }) 

// app.MapGet("/tasks/complete", (ITaskContext context) => context.GetCompleteTasks());

// app.MapGet("/tasks/pending", (ITaskContext context) => context.GetPendingTasks());

// app.MapGet("/task/{id}", (int id, ITaskContext context) => context.GetTaskById(id));

// app.MapPatch("/tasks/complete/{id}", (int id, ITaskContext context) => context.CompleteTask(id));

// app.MapDelete("/tasks/{id}", (int id, ITaskContext context) => context.DeleteTask(id));

// app.MapPost("/tasks", (string title, string description, DateTime dueDate, ITaskContext context) => context.AddTask(title, description, dueDate));


app.MapControllers();


app.Run();




