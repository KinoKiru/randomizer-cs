var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();



app.UseCors(x => x
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithOrigins("https://localhost:7031")
                  .SetIsOriginAllowed(origin => true) //allow any origin
                                                      //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                  .AllowCredentials());


app.MapControllers();

app.Run();