# quotesapi-dotnet-mini
Simple CRUD api using .NET 6 Minimal API, with requests to create/read/update/delete a testing db of quotes. 
Based directly on [MS Docs Minimal API tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio).

## Tools used:
- VS Code (on Macbook Pro M1)
- Dotnet CLI 
- Postman
- Entity Framework Core v6.0.7 and its [In-Memory database](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli).
  - NOTE: SQlite is preferred, even for testing

## Project Purpose:
- Build the simplest implimentation of a .NET Minimal API
<img width="133" alt="Screen Shot 2022-07-24 at 3 18 30 AM" src="https://user-images.githubusercontent.com/61135183/180636733-a9e0904d-ecc1-41cd-a9da-a362adceef0e.png">
- Use the simplest example of a [Data Transfer Object (DTO) ](https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)
- Test HTTP requests with Postman
<img width="190" alt="Screen Shot 2022-07-24 at 3 20 23 AM" src="https://user-images.githubusercontent.com/61135183/180636780-c90c322d-2c99-44e4-9771-8811c86774b8.png">

# To Run & Test
1) Clone this repo
2) Run in VisualStudio, **or** type "dotnet run" in a console with Dotnet CLI while navigated into the QuotesAPI directory
3) Test using curl, HttpRepl, Postman, Insomnia, etc. I use [Postman](https://www.postman.com/)

## Screenshots
<img width="1006" alt="Screen Shot 2022-07-24 at 3 31 16 AM" src="https://user-images.githubusercontent.com/61135183/180637081-2a3c9075-a643-4867-a1d5-942a026bb482.png">
<img width="1006" alt="Screen Shot 2022-07-24 at 3 32 57 AM" src="https://user-images.githubusercontent.com/61135183/180637130-024be60d-6954-439d-8e2d-8952722fe8b4.png">
<img width="1005" alt="Screen Shot 2022-07-24 at 3 33 19 AM" src="https://user-images.githubusercontent.com/61135183/180637140-71d1a18e-729c-4055-8e17-4301beafb0ef.png">
<img width="1001" alt="Screen Shot 2022-07-24 at 3 33 49 AM" src="https://user-images.githubusercontent.com/61135183/180637151-ade43cb2-4871-4927-ad09-23785b333aea.png">
<img width="1037" alt="Screen Shot 2022-07-24 at 3 47 03 AM" src="https://user-images.githubusercontent.com/61135183/180637543-8e2f158b-9293-475e-b5ce-4dbeb4b27cc5.png">


