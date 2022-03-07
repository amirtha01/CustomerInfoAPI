var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Sample REST Web API";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Swagger middleware 
    app.UseSwagger();
    app.UseSwaggerUi3();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
