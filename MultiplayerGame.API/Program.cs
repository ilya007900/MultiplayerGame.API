using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiplayerGame.API.Options;
using MultiplayerGame.Application.Chats.Services;
using MultiplayerGame.Application.GameRooms.Services;
using MultiplayerGame.Application.Games.Services;
using MultiplayerGame.Domain.Chats;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.Games;
using MultiplayerGame.Infrastructure.Behaviors;
using MultiplayerGame.Infrastructure.Database;
using MultiplayerGame.Infrastructure.Database.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSignalR();

builder.Services.Configure<GameOptions>(
    builder.Configuration.GetRequiredSection("GameOptions"));

builder.Services.AddDbContext<MultiplayerGameDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MultiplayerGame"));
});

builder.Services.AddValidatorsFromAssemblyContaining(typeof(MultiplayerGame.Application.AssemblyMarker));

builder.Services.AddMediatR(configuration =>
{
    configuration
        .RegisterServicesFromAssemblyContaining(typeof(MultiplayerGame.Application.AssemblyMarker))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
});

builder.Services
    .AddTransient<IGameRoomEventsBroker, GameRoomEventsBroker>()
    .AddTransient<IGameEventsBroker, GameEventsBroker>()
    .AddTransient<IChatEventsBroker, ChatEventsBroker>();

builder.Services
    .AddTransient<IGameRoomRepository, GameRoomRepository>()
    .AddTransient<IGameRepository, GameRepository>()
    .AddTransient<IChatRepository, ChatRepository>()
    .AddTransient<IMovementRepository, MovementRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MultiplayerGameDbContext>();
    db.Database.Migrate();
}

app.UseCors(options =>
{
    options
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<GameRoomHub>("/game-room");
app.MapHub<GameHub>("/game");
app.MapHub<ChatHub>("/chat");

app.Run();
