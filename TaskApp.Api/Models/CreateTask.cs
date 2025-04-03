namespace TaskApp.Api.Models;

public class CreateTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; }
}