using API.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Carro> carros = [
    new Carro() {Id = 1, Name = "Fusca"},
    new Carro() {Id = 2, Name = "Agera"},
    new Carro() {Id = 3, Name = "R34 puple edition"}
 ];
app.MapGet("/", () => "Hello World!");
app.MapGet("/api/carros",() => {
    return Results.Ok(carros);
});

app.Run();
