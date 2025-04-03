namespace TaskApp.Api.Domain;

public class TaskToDo
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; }
}