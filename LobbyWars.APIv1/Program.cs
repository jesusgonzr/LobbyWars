using LobbyWars.APIv1;
using LobbyWars.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the Swagger generator, defining one or more Swagger documents
string version = typeof(Program).Assembly.GetName().Version.ToString();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lobby Wars API",
        Version = "v" + version,
        Description = "Lobby Wars API REST",
        Contact = new OpenApiContact()
        {
            Name = "Jesus G.",
            Email = "jesusgonzr@gmail.com",
        },
    });
});

builder.Services.AddApplication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Winner Contract
app.MapPost("/WinnerContract", async (string contract1, string contract2, IMediator mediator) =>
{
    if (string.IsNullOrEmpty(contract1) || string.IsNullOrEmpty(contract2))
    {
        return Results.BadRequest();
    }

    var command = new GetWinnerContract()
    {
        Contract1 = contract1,
        Contract2 = contract2
    };

    var commandResult = await mediator.Send(command);

    return commandResult is { } ? Results.Ok(commandResult) : Results.BadRequest("Tie.");
})
.WithName("WinnerContract")
.WithOpenApi();

// Minimun signature
app.MapPost("/MinimumSignatureNecessaryToWin", async (string contract1, string contract2, IMediator mediator) =>
{
    if (string.IsNullOrEmpty(contract1) || string.IsNullOrEmpty(contract2))
    {
        return Results.BadRequest();
    }

    var command = new GetMinimumSignatureNecessaryToWin()
    {
        Contract1 = contract1,
        Contract2 = contract2
    };

    var commandResult = await mediator.Send(command);

    return commandResult is { } ? Results.Ok(commandResult) : Results.BadRequest("Tie.");
})
.WithName("MinimumSignatureNecessaryToWin")
.WithOpenApi();

app.Run();