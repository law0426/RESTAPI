using System.ComponentModel.DataAnnotations;
using RestApi.Interfaces;

namespace RestApi.Models;

public class UserTask(/*int id,*/ string title, string description, DateTime dueDate) : IUserTask
{
    [Key]
    public int Id {get; init;}/* = id;*/ //Commented section is vestigial code.

    public string Title { get; set; } = title; 
    public string Description { get; set; } = description;
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; } = dueDate;
    // Kept for posterity. Commented out for best practice POCO.
    // public void MarkAsCompleted()
    // {
    //     IsCompleted = true;
    // }
}
