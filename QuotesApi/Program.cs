using Microsoft.EntityFrameworkCore;
using QuotesApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services ((optional)) to the container here before the app definition.
builder.Services.AddDbContext<QuotesDb>(opt => opt.UseInMemoryDatabase("QuoteList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Add Request Mappings here:
app.MapGet("/", () => "Welcome! This is a basic Quotes API");
app.MapGet("/quotes/all", async (QuotesDb db) =>
    await db.Quotes.ToListAsync());

app.MapGet("/quotes/{id}", async (int id, QuotesDb db) =>
    await db.Quotes.FindAsync(id)
        is Quote quote
            ? Results.Ok(quote)
            : Results.NotFound());

app.MapPost("/quotes", async (Quote quote, QuotesDb db) =>
{
    db.Quotes.Add(quote);
    await db.SaveChangesAsync();

    return Results.Created($"/quotes/{quote.Id}", quote);
});

app.MapPut("/quotes/{id}", async (int id, Quote inputquote, QuotesDb db) =>
{
    var quote = await db.Quotes.FindAsync(id);

    if (quote is null) return Results.NotFound();

    quote.Content = inputquote.Content;
    quote.Source = inputquote.Source;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/quotes/{id}", async (int id, QuotesDb db) =>
{
    if (await db.Quotes.FindAsync(id) is Quote quote)
    {
        db.Quotes.Remove(quote);
        await db.SaveChangesAsync();
        return Results.Ok(quote);
    }

    return Results.NotFound();
});

app.Run();