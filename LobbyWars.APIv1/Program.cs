using LobbyWars.APIv1;
using LobbyWars.Application.Commands;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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