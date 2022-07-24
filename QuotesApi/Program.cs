using Microsoft.EntityFrameworkCore;
using QuotesApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services ((optional)) to the container here before the app definition.

builder.Services.AddDbContext<QuotesDb>(opt => opt.UseInMemoryDatabase("QuoteList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// =============================================================================
// Add Requests here:

app.MapGet("/", () => "Welcome! This is a basic Quotes API");                                                   // Define Index (NOT NEEDED) //

app.MapPost("/api/quotes", async (QuoteDTO quoteDTO, QuotesDb db) =>                                            // Create new quote (POST) //
{
    var quote = new Quote
    {
        Content = quoteDTO.Content,
        Source = quoteDTO.Source,
        SubSource = quoteDTO.SubSource
    };
    db.Quotes.Add(quote);
    await db.SaveChangesAsync();

    return Results.Created($"/quotes/{quote.Id}", new QuoteDTO(quote)); //returns contents of quote created
});

app.MapGet("/api/quotes", async (QuotesDb db) =>                                                                // Read all quotes (GET) //
    // await db.Quotes.ToListAsync());         //without DTO
    await db.Quotes.Select(x => new QuoteDTO(x)).ToListAsync());

app.MapGet("/api/quotes/{id}", async (int id, QuotesDb db) =>                                                   // Read a quote by Id (GET) //
    await db.Quotes.FindAsync(id)
        is Quote quote
            ? Results.Ok(new QuoteDTO(quote))     //without DTO is just Results.Ok(quote)
            : Results.NotFound());

app.MapPut("/api/quotes/{id}", async (int id, QuoteDTO quoteDTO, QuotesDb db) =>                                // Update a quote by Id (PUT) //
{
    var quote = await db.Quotes.FindAsync(id); //looks in db for quote by Id, then points to it

    if (quote is null) return Results.NotFound(); //if Id doesnt exist, 404 response

    quote.Content = quoteDTO.Content;
    quote.Source = quoteDTO.Source;
    quote.SubSource = quoteDTO.SubSource;

    await db.SaveChangesAsync();

    return Results.NoContent(); 
    //this Results.NoContent() is the reason it returns a 204 response rather than the content modified like in POST ??
});

app.MapDelete("/api/quotes/{id}", async (int id, QuotesDb db) =>                                                // Delete a quote by Id //
{
    if (await db.Quotes.FindAsync(id) is Quote quote) //if it can find and point to the quote by it's id:
    {
        db.Quotes.Remove(quote); //remove it
        await db.SaveChangesAsync(); //save changes to the db
        return Results.Ok(new QuoteDTO(quote)); //return only the DTO details of what was deleted
    }

    return Results.NotFound(); //else 404 response
});
// =============================================================================

app.Run();