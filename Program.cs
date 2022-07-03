using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "Discription",
        //TermsOfService = System.UriKind("None"),
        Contact = new OpenApiContact() { Name = "John Doe", Email = "john@xyzmail.com" },
        License = new OpenApiLicense() { Name = "License Terms" }
    }) ;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // specifying the Swagger JSON endpoint.
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
