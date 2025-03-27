using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();


app.MapGet("/api/carros", ([FromServices] AppDataContext ctx) => {

    if (ctx.Carros.Any()) {
        return Results.Ok(ctx.Carros.ToList());
    }

    return Results.NotFound();

});

app.MapPost("/api/carros", ([FromBody] Carro carro,
                            [FromServices] AppDataContext ctx) => {

        ctx.Carros.Add(carro);
        ctx.SaveChanges();

        return Results.Created("", carro);
});

app.MapGet("/api/carros/{id}", ([FromRoute] int id,
                [FromServices] AppDataContext ctx) => {
    Carro? carro = ctx.Carros.Find(id);

    if(carro != null){
        return Results.Ok(carro);
    }
    return Results.NotFound();
});

app.MapPut("/api/carros/{id}", ([FromRoute] int id,
                [FromBody] Carro carro,
                [FromServices] AppDataContext ctx) =>{
    
    Carro? etidade = ctx.Carros.Find(id);

    if(etidade != null){
        etidade.Name = carro.Name;
        ctx.Carros.Update(etidade);
        ctx.SaveChanges();
        return Results.Ok(etidade);
    }
    return Results.NotFound();

});

app.MapDelete("/api/carros/{id}", ([FromRoute] int id,
                [FromServices] AppDataContext ctx) =>{

    Carro? carro = ctx.Carros.Find(id);
    if(carro == null){
        return Results.NotFound();
    }
    ctx.Carros.Remove(carro);
    ctx.SaveChanges();
    return Results.NoContent();
});


app.Run();
