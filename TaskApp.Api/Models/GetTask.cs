namespace TaskApp.Api.Models;

public class GetTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; }
}