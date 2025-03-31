using DevFreela.API.Models;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration.GetSection("OpeningTime");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<OpeningTimeOption>(Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ExampleClass>(e => new ExampleClass{ Name = "Initial state"});

builder.Services.AddScoped<ExampleClass>(e => new ExampleClass{ Name = "Initial state"});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
