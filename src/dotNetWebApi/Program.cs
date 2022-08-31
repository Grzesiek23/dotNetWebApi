using dotNetWebApi.Installers;
using dotNetWebApi.Installers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Install(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(x => x.RouteTemplate = "api-docs/{documentName}/swagger.json");
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();