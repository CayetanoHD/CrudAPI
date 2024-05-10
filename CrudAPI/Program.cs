using CrudAPI.Core.Application;
using CrudAPI.Extentions;
using CrudAPI.Infrastructure.Persistence;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string _quickCors = "_CrudCors";

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddCors(options =>
{
    options.AddPolicy(_quickCors, builder =>
    {
        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(_quickCors);
app.UseSwaggerExtention();

app.MapControllers();

app.Run();
//await Task.CompletedTask;