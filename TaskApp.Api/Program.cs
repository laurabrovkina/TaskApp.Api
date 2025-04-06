using TaskApp.Api.Extensions;
using TaskApp.Api.Models;
using TaskApp.Api.Persistence;
using TaskApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddPersistence();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            // policy should be more restricted
            policy.AllowAnyHeader().AllowAnyMethod();
            policy.WithOrigins("http://localhost:5173");
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
DbInitializer.Initialize(DbConstants.DefaultConnectionStringPath);

app.MapPost("/task", async (CreateTask createTask, ITaskService taskService) =>
    {
        await taskService.Create(createTask);
    })
    .WithName("CreateTask")
    .WithOpenApi();

app.MapGet("/tasks", async (ITaskService taskService) => await taskService.GetAllAsync())
    .WithName("GetTasks")
    .WithOpenApi();

app.MapDelete("/task", async (Guid id, ITaskService taskService) =>
    {
        await taskService.Delete(id);
    })
    .WithName("DeleteTask")
    .WithOpenApi();

app.Run();