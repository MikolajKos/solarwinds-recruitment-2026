using RickAndMortyApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

builder.Services.AddHttpClient<IRickAndMortyService, RickAndMortyService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
